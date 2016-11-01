<?php
// ========== VRYZKA S DATABASE ===========
mb_internal_encoding('utf-8');
$db = mysqli_connect('localhost','Zach', 'pb1186ch', 'messages');
if(!$db) {
    echo 'no database';
}

mysqli_set_charset($db, 'utf8');
?>