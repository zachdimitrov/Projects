<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sessions</title>
</head>
<body>
    <?php
    session_start();
    if(array_key_exists('logged', $_SESSION) && $_SESSION['logged'] == true) {
        echo 'Hello, '.$_SESSION['user'].'!';
        echo '<div> <a href="destroy.php"> Log-out! </a></div>';
    } else {
        if ($_POST) {
            $username = trim($_POST['username']);
            $password = trim($_POST['password']);
            if ($username =='Ivan' && $password=='123') {
                $_SESSION['logged'] = true;
                $_SESSION['user'] = 'Ivan Petrov';
                header('location: sessions.php');
                exit;
            } else {
                echo 'Wrong Credentials!';
            }
        }
    // echo '<pre>'.print_r($_SESSION, true).'</pre>';
    echo '
    <form method="post">
        <div>Username: <input type="text" name="username" /> </div>
        <div>Password:<input type="password" name="password" /></div>
        <div><input type="submit" value="ДОБАВИ" /></div>
    </form>';

    }
    ?>

</body>
</html>