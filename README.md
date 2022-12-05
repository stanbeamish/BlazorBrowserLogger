# BlazorBrowserLogger (WIP)

This solution contains two projects.

## BlazorBrowserConsole

A Razor component library that offers a better logging to the Browser console

### Supported function

- LogStyled(string message, LogLevel logLevel, Styles style)
- SimpleLogStyled(string message, LogLevel loglevel, string style)
- LogTable(object data)

### Available Styles
- Default
- Nice
- Fancy

### Available LogLevels
- Default -> console.log
- Info -> console.info
- Warning -> console.warning
- Error -> console.error

## BlazorBrowserConsoleUi

A Blazor WASM standalone project, that allows you to test the logging to the Browser console.

See the <a href="https://stanbeamish.github.io/BlazorBrowserLogger/" target="_blank">Running App hosted on Github Pages</a>
