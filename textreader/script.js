document.getElementById("openFile").addEventListener("change", function () {
    var fr = new FileReader(), text;
    fr.onload = function (event) {
        text = event.target.result;
        text = text.replace(/(BEGIN:VCARD)/g, "|");
        var arr = text.split("|");
        console.log(arr.length);
        arr.forEach(function(element) {

            var elarr = element
            .replace(/(VERSION:2.1)/g, "")
            .replace(/(END:VCARD)/g, "")
            .replace(/;/g, ";\n")
            .replace(/^\s*\n/gm, "")
            .trim().split('\n');

            for(i = 0; i<elarr.length; i++){
                if (elarr[i] == ';' || elarr[i] == '\n' || elarr[i] == undefined) {
                    delete elarr[i];
                }
            }

            newdiv = document.createElement('pre');    
            newdiv.textContent = elarr.join('\n');;
            document.body.appendChild(newdiv);
        }, this);
    }
    fr.readAsText(this.files[0]);
});