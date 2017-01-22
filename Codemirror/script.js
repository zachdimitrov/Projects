(function () {
    var div = document.getElementById('codetest');
    var myCodeMirror = CodeMirror(div, {
        value: "function myScript(){return 100;}\n",
        mode: "javascript"
    });
})();