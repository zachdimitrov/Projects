$(function() {
    $(".textin input").focus(function() {
        this.value = "";
        this.removeAttribute('readonly');
        $(this).css("background-color", "#a8dbb3");
    });
});