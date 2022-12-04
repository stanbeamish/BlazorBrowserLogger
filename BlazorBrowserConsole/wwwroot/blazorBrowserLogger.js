function tableLog(data) {
    console.table(data);
}

function groupLog(data, logLevel) {
    if (logLevel === 'log') {
        console.group('%c' + data);
    }
    if (logLevel === 'info') {
        console.group('%c' + "😌" + data);
    }
    if (logLevel === 'warn') {
        console.group('%c' + "🧐️" + data);
    }
    if (logLevel === 'error') {
        console.group('%c' + "😱" + data);
    }
}

function groupEndLog() {
    console.groupEnd();
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

function clearLog() {
    console.clear();
}

export { tableLog, styledLog, groupLog, groupEndLog, clearLog };