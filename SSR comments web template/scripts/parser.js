function createContent(comments) {

    let info = [];
    let blocks = comments.split("\n\r");
    console.log(blocks);
    for (let i = 0, len = blocks.length; i < len; i += 1) {
        let lines = blocks[i].split('\n').filter(c => c !== "");
        let block = {};
        block.comment = [];
        let imageId = i + 1;
        if (i > 7) {
            imageId = i + 6;
        }
        block.images = {
            commentImage: "./comments/EYA RL View " + (imageId) + ".pdf.jpg",
            proposedImage: "./proposed/EYA-RL_View-" + (imageId) + ".jpg"
        };
        for (let j = 0, len = lines.length; j < len; j += 1) {
            if (lines[j][0] === "-") {

                block.comment.push(lines[j].slice(2));
            } else {
                block.title = lines[j];
            }
        }
        info.push(block);
    }

    let data = { data: info };

    console.log(data);
    // use tpl from template.tpl loaded in html
    let template = Handlebars.compile(tpl);
    document.getElementById('container')
        .innerHTML = template(data);
}

var myPromise = new Promise((resolve, reject) => {
    document.getElementById('fileinput').addEventListener('change', readSingleFile, false);
    var comments;

    function readSingleFile(evt) {
        var f = evt.target.files[0];
        if (f) {
            var r = new FileReader();
            r.onload = (function(f) {
                return function(e) {
                    comments = e.target.result;
                    resolve(comments);
                };
            }(f));
            r.readAsText(f);
        } else {
            reject("Error!");
        }
    }
});

myPromise.then(x => {
    createContent(x);
});