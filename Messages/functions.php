<?php
// ========== VRYZKA S DATABASE ===========
mb_internal_encoding('utf-8');
$db = mysqli_connect('127.0.0.1','root', '', 'otpuski');
if(!$db) {
    echo 'no database';
}
mysqli_set_charset($db, 'utf8');

function render ($data, $name) {
    include './includes/header.php';
    include $name;
    include './includes/footer.php';
}
?>