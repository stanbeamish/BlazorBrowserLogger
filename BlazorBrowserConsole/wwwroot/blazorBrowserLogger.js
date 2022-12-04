function tableLog(data) {
    console.table(data);
}

function styledLog(data, logLevel, style) {
    if (logLevel === 'log') {
        console.log('%c' + data, style);
    }
    if (logLevel === 'info') {
        console.info('%c' + "😌" + data, style);    
    }
    if (logLevel === 'warn') {
        console.warn('%c' + "🧐️" + data, style);
    }
    if (logLevel === 'error') {
        console.error('%c' + "😱" + data, style);
    }
}

export { tableLog, styledLog };