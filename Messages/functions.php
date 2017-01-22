<?php
// ========== VRYZKA S DATABASE ===========
mb_internal_encoding('utf-8');
$db = mysqli_connect('local','root', '', 'otpuski');
if(!$db) {
    echo 'no database';
}

mysqli_set_charset($db, 'utf8');
?>