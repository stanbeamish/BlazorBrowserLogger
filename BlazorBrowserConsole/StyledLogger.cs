using Microsoft.JSInterop;

namespace BlazorBrowserConsole;

public class StyledLogger : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public StyledLogger(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorBrowserConsole/blazorBrowserLogger.js").AsTask());
    }
    
    public async ValueTask LogTable(object data)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("tableLog", data);
    }
    
    
    public async ValueTask LogStyled(string message, LogLevel? logLevel, Styles? style)
    {
        style ??= Styles.Default;
        
        Console.WriteLine($"Called LogStyled with: {message}");
        
        var module = await _moduleTask.Value;
        var logSettings = SetLogSettings(logLevel ?? LogLevel.Default);
        
        var cssStyle = style switch
        {
            Styles.Default => $"color: {logSettings.ForegroundColor}; background-color: {logSettings.BackgroundColor}; font-family: monospace; font-size: 12px; padding: 4px;",
            Styles.Nice => $"border: 1px solid #ccc; background-color: {logSettings.BackgroundColor}; color: {logSettings.ForegroundColor}; font-size: 1.2em; padding: 8px;",
            Styles.Fancy => $"background-color: {logSettings.BackgroundColor}; color: {logSettings.ForegroundColor} ; font-weight: bold ; " +
                            "font-size: 1.2rem; border-radius: 15px 5px;" +
                            "border: 1px solid black; padding: 8px;",
            _ => $"color: {logSettings.ForegroundColor}; background-color: {logSettings.BackgroundColor};"
        };
        
        Console.WriteLine($"\nSet cssStyle to: {cssStyle}");

        await module.InvokeVoidAsync("styledLog", message, logSettings.LogLevelString, cssStyle);
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    private static LogSettings SetLogSettings(LogLevel logLevel)
    {
        var logSettings = new LogSettings();
        switch (logLevel)
        {
            case LogLevel.Info:
                logSettings.BackgroundColor = "#BFFDFE";
                logSettings.LogLevelString = "info";
                break;
            case LogLevel.Warning: 
                logSettings.BackgroundColor = "#FBE589";
                logSettings.LogLevelString = "warn";
                break;
            case LogLevel.Error:
                logSettings.BackgroundColor = "#B54847";
                logSettings.ForegroundColor = "white";
                logSettings.LogLevelString = "error";
                break;
            case LogLevel.Default:
            default:
                break;
        };

        return logSettings;
    }
}

class LogSettings
{
    public string ForegroundColor { get; set; } = "black";
    public string BackgroundColor { get; set; } = "white";
    public string LogLevelString { get; set; } = "log";
}