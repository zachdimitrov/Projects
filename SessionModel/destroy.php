<?php
session_start();
session_destroy();
header('location: sessions.php');
exit;
?>