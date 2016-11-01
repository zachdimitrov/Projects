<?php
$pageTitle='Contact List';
include './includes/header.php';
echo '
    <div>
        Здрасти, моля логни се в системата!
    </div>
    <form method="post">
        <div>Потребител: <input type="text" name="username" /> </div>
        <div>Парола: <input type="password" name="password" /></div>
        <div><input type="submit" value="ВХОД" /></div>
    </form>
    <div>
        Ако не си регистриран първо направи това от тук:
        <a href="register.php">Регистрация на нов потребител</a>
    </div>
    <div>
        В случай, че си забравил паролата си цъкни тук:
        <a href="reset.php">Забравена парола или потребителско име</a>
    </div>
    ';

// ========== VRYZKA S DATABASE ===========
$con = mysqli_connect('localhost','Zach', 'pb1186ch', 'messages');
if(!$connection) {
    echo 'no database';
    exit;
}
mysqli_query($con, 'SET NAMES utf8');

include './includes/footer.php';
?>

