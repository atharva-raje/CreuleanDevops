function blazorDownloadFile(file) {
    var blob = new Blob([file.data], { type: file.contentType });
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = file.fileName;
    link.click();
}