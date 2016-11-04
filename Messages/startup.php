<?php
session_start();
$pageTitle='All documents';
include './includes/header.php';
include './functions.php';
echo '
<div class="greeting">
Здравей, '.$_SESSION["user"].'! Моля избери от опциите!
</div>
<div class="textreg">
<a href="index.php">Изход</a>
</div>
';

include './includes/footer.php';
?>