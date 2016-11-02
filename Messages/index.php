<?php
$pageTitle='Login form';
include './includes/header.php';
include './functions.php';
echo '
    <div class="greeting">
        Здрасти, моля логни се в системата!
    </div>
    <form method="post" action="index.php">
        <div class="textin">Потребител: <input type="text" name="username" readonly /> </div>
        <div class="textin">Парола: <input type="password" name="password" readonly /></div>
        <div><input type="submit" value="ВХОД" /></div>
    </form>
    <div class="notes">
        Ако не си регистриран първо направи това от тук:
        <a href="register.php">Регистрация на нов потребител</a>
    </div>
    <div class="notes notestwo">
        В случай, че си забравил паролата си цъкни тук:
        <a href="reset.php">Забравена парола или потребителско име</a>
    </div>
    ';
// data validation 
if($_POST) {
    $user= trim($_POST['username']);
    $pass= trim($_POST['password']);
    if(mb_strlen($user)<2 || mb_strlen($user)<2) {
        echo '<p class="error">Невалидно потребителско име, моля опитайте отново!</p>';
    }
}
// quiery validation
$user_escaped = mysqli_real_escape_string($db, $user);
$pass_escaped = mysqli_real_escape_string($db, $pass);
$q= mysqli_query($db, 'SELECT * FROM users WHERE username="'.$user_escaped.'"');
if(mysqli_num_rows($q) > 0) {
    echo '<p class="correct">Валидно потребителско име!</p>';
    $qpass= mysqli_query($db, 'SELECT * FROM users WHERE username="'.$user_escaped.'" AND pass="'.$pass_escaped.'"');
    //var_dump($qpass);
    if(mysqli_num_rows($qpass) > 0) {
    echo '<p class="correct">Валидна парола!</p>';
    } else {
        echo '<p class="error">Невалидна парола, моля опитайте отново!</p>';
    }
} else {
    echo '<p class="error">Невалидно потребителско име, моля опитайте отново!</p>';
}

include './includes/footer.php';
?>

