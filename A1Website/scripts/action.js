$(document).ready(function () {
    var $lita = $('.links').children();

    $lita.forEach(function (element) {
        element.on('click', 'a', function (event) {
            $(this).css({
                'font-weight': 'bold',
                'padding': '10px 20px',
                'border': '1px solid black'
            });
        }, this);
    }
});