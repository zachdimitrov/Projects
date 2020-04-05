var tpl = `
{{#each data}}
    <b>{{title}}</b>
    <div class="images">
        <a href="{{images.commentImage}}" target="_blank"><img src="{{images.commentImage}}" alt="No Image!"></a>
        <a href="{{images.proposedImage}}" target="_blank"><img src="{{images.proposedImage}}" alt="No Image!"></a>
    </div>
    <ul>
        {{#each comment}}
        <li>
            {{this}}
        </li>
        {{/each}}
    </ul>
{{/each}}
`