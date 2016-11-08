<?php
session_start();
$pageTitle='All documents';
include './includes/header.php';
include './functions.php';
if(!$_SESSION["user"]) {
    header('location: index.php');
    exit();
}
echo '
<div class="greeting">
Здравей, '.$_SESSION["user"].'! Моля избери от опциите!
</div>
<div class="textreg">
<a href="logout.php">Изход</a>
</div>
';
include './includes/footer.php';
?>