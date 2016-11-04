<?php
$pageTitle='Reset password';
include './includes/header.php';
include './functions.php';
echo '
    <div class="greeting">
        Свържи се със администратора за да ти открие паролата!
    </div>
    <div class="notes">
        Е-мейл:
        <a href="mailto:zachd@a1studioarch.com?Subject=Please%20reset%20my%20password!" target="_top">zachd@a1studioarch.com</a>
    </div>
    <div class="notes notestwo">
        Телефон:
        <a href="#">0884 520 935</a>
    </div>
    <div class="notes">
        Обратно към формата за вход:
        <a href="index.php">Вход на съществуващ потребител</a>
    </div>
    ';
include './includes/footer.php';
?>