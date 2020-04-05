let info = {};
let invoices = text.split('++++\n');
let notes = invoices[0];
let newNotes = notes.replace('0.\nЗабележки:\n', '').split('\n').filter(a => a !== '');
info.notes = newNotes;
info.invoices = {};
for (let i = 1; i < invoices.length; i++) {
    let invoice = invoices[i];
    let name = invoice.split('\n')[0];
    info.invoices[name] = {};
    let clean = invoice.substring(invoice.indexOf('\n') + 1);
    info.invoices[name].projects = [];
    let spl = clean.split('====\n');
    for (let j in spl) {
        let proj = spl[j];
        let projSpl = proj.split('\n');
        let prj = {};
        prj.project = projSpl[1];
        prj.team = {};
        prj.phase = {};

        for (let k = 1; k < projSpl.length; k++) {
            let line = projSpl[k];
            if (line) {
                if (line === 'моделиране') {
                    prj.team.modelling = projSpl[k + 1];
                    k++;
                }
                if (line === 'визуализация') {
                    prj.team.visualisation = projSpl[k + 1];
                    k++;
                }
                if (line === 'постпродукция') {
                    prj.team.postproduction = projSpl[k + 1];
                    k++;
                }
                if (line[0] === '0') {
                    prj.phase.scope = line.substring(2);
                }
                if (line[0] === '1') {
                    prj.phase.files = line.substring(2);
                }
                if (line[0] === '2') {
                    prj.phase.model = line.substring(2);
                }
                if (line[0] === '3') {
                    prj.phase.render = line.substring(2);
                }
                if (line[0] === '4') {
                    prj.phase.postprod = line.substring(2);
                }
            }
        }
        info.invoices[name].projects.push(prj);
    }
}
console.log(info);
// use tpl from template.tpl loaded in html
let template = Handlebars.compile(tpl);
document.getElementById('container')
    .innerHTML = template(info);