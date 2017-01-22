var tpl = `
<h2 id="zab">Забележки:</h2>
{{#notes}}
<p id="notes">&nbsp;&nbsp;&nbsp;&nbsp;{{this}}</p>
{{/notes}}
</h1><hr>
<h1>Описание на извършената работа по всеки проект за всяка издадена фактура</h1>
</h1><hr>
{{#each invoices}}
<h1 class=" invoice ">Фактура №: {{@key}}</h1><hr>

{{#projects}}
<div class="project">
    <h2 class="proj-name">{{project}}</h2>
    <h3>Екип работил по проекта:</h3>
    <div class="team">
        <p class="modelling">
            моделиране:
            <span>{{team.modelling}}</span>
        </p>
        {{#if team.visualisation}}
        <p class="visualisator">
            визуализация:
            <span>{{team.visualisation}}</span>
        </p>
        {{/if}}
        {{#if team.postproduction}}
        <p class="postproduction">
            постпродукция:
            <span>{{team.postproduction}}</span>
        </p>
        {{/if}}
    </div>
    <h3>Извършена работа по роекта:</h3>
    <ol>
        <li><p>{{phase.scope}}</p></li>
        <li><p>{{phase.files}}</p></li>
        <li><p>{{phase.model}}</p></li>
        <li><p>{{phase.render}}</p></li>
        {{#if phase.postprod}}
        <li><p>{{phase.postprod}}</p></li>
        {{/if}}
    </ol>
</div>
{{/projects}} 
{{/each}}
`;