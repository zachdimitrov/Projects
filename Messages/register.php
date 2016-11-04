<?php
session_start();
$pageTitle='Login form';
include './includes/header.php';
include './functions.php';
echo '
<div class="greeting">
Моля, въведете потребителско име и парола
</div>
<form method="post" action="register.php" id="regform">
<div class="textreg">Въведете потребителско име: <input type="text" name="username" readonly /> </div>
<div class="textreg">Въведете парола: <input type="password" name="password" readonly /></div>
<div class="textreg">Повторете паролата: <input type="password" name="passrep" readonly /></div>
<div><input type="submit" value="РЕГИСТРАЦИЯ" /></div>
</form>
<div class="notes">
За да се върнеш във формата за вход натисни тук:
<a href="index.php">Вход на съществуващ потребител</a>
</div>
<div class="notes notestwo">
В случай, че си забравил паролата си цъкни тук:
<a href="reset.php">Забравена парола или потребителско име</a>
</div>
';
// data validation
$user = "";
$pass = "";
$passr = "";
if($_POST) {
    $user= trim($_POST['username']);
    $pass= trim($_POST['password']);
    $passr= trim($_POST['passrep']);
    if(mb_strlen($user)<2 || mb_strlen($pass)<2) {
        echo '<p class="error">Невалидно потребителско име, моля опитайте отново!</p>';
        //header('location: register.php');
    } else {
        // quiery validation
        $user_escaped = mysqli_real_escape_string($db, $user);
        $pass_escaped = mysqli_real_escape_string($db, $pass);
        $passrep_escaped = mysqli_real_escape_string($db, $passr);
        $q= mysqli_query($db, 'SELECT * FROM users WHERE username="'.$user_escaped.'"');
        if(mysqli_num_rows($q) > 0) {
            echo '<p class="error">Такъв потребител вече съществува, опитайте пак!</p>';
            session_destroy();
            header('location: register.php');            
        } else {
            echo '<p class="correct">Потребителското име е свободно!</p>';
            if ($pass_escaped === $passrep_escaped) {
                $sql='INSERT INTO users (username, pass, isactive) VALUES ("'.$user_escaped.'", "'.$pass_escaped.'", 0)';
                if (mysqli_query($db, $sql)) {
                    echo '<p class="correct">Записан сте успешно като нов потребител!</p>';
                    session_destroy();
                    header('location: index.php');
                    exit;
                } else {
                    echo '<p class="error">Грешка в базата с данни!</p>';
                    session_destroy();
                    header('location: register.php');
                }
            } else {
                echo '<p class="error">Моля попълнете паролата отново!</p>';
            }
        }
    }
}

include './includes/footer.php';
?>