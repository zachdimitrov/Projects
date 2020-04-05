
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>

     <form method="post">
    <textarea name="message" id="ta" cols="69" rows="3"></textarea>
    <div><input name="user" type="text"></div>
    <div> <input type="submit" value="submit">  </div>
    </form> 

<?php

// ========== VRYZKA S DATABASE ===========
$connection = mysqli_connect('localhost','root', 'pb1186ch', 'testdb');
if(!$connection) {
    echo 'no database';
    exit;
}

// ========== OPREDELQNE NA CHARSET ===========
mysqli_query($connection, 'SET NAMES utf8'); // pravi se samo vednaj v nachaloto sled connection

/*
// ========== SYZDAVANE NA BUTAFORNA DB ===========
for ($i=1; $i<500; $i++) {
    $sql = 'INSERT INTO users (user_name, pass, age, is_active) VALUES("test'.$i.'", "qwe'.(123*$i).'", '.rand(3, 65).','.rand(0,1).')';
    mysqli_query($connection, $sql);
}
*/
// ========== IZPOLZVANE NA FORMA ZA INPUT NA DANNI ===========

if($_POST) {
    $msg = mysqli_real_escape_string($connection, trim($_POST['message']));
    $name = mysqli_real_escape_string($connection, trim($_POST['user']));
    $sql='INSERT INTO msg (msg_data, user_name) VALUES ("'.$msg.'", "'.$name.'")';
    // echo $sql;
    if (mysqli_query($connection, $sql)) {
        echo 'Data inserted to data base!';
    } else {
        echo 'Error!';
        echo mysqli_error($connection);
    }
}

$qq = mysqli_query($connection, 
'SELECT user_name, msg_data, msg_id FROM msg ORDER BY msg_id ASC');
if(!$qq) {
    echo 'error - no such db exists';
}
if($qq->num_rows>0) {
    echo '<table>
    <tr>
    <th>ID</th>
    <th>MESSAGE</th>
    <th>USER</>
    </tr>
    ';
    while($rr=$qq->fetch_assoc()) {
        echo'<tr>
            <td class="uid">'.$rr['msg_id'].'</td>
            <td>'.$rr['user_name'].'</td>
            <td>'.$rr['msg_data'].'</td>
            </tr>';
    }
    echo '</table>';
} else {
    echo '<div> No Results </div>';
}

// ========== DOSTYP DO DATABASE - ZAQVKI ===========
// update na info
mysqli_query($connection, 'UPDATE users SET is_active=0 WHERE age>=18 AND age<24 AND is_active=1');
echo mysqli_affected_rows($connection);
// display na info
$q = mysqli_query($connection, 
'SELECT user_id, user_name as un, pass, age, is_active 
FROM users 
WHERE age>=18 AND age<=24 AND is_active=0
ORDER BY age
ASC LIMIT 0, 500'
);

if(!$q) {
    echo 'error in db';
}

$count = 0;

if($q->num_rows>0) {

echo '<table>
        <tr>
            <th><a href="#">User ID</a></th>
            <th><a href="#">Username</a></th>
            <th><a href="#">Password</a></th>
            <th><a href="#">Age</a></th>
            <th><a href="#">Active</a></th>
        </tr>';
while($row=$q->fetch_assoc()) {
    echo '<tr>
            <td class="uid">'.$row['user_id'].'</td>
            <td>'.$row['un'].'</td>
            <td>'.$row['pass'].'</td>
            <td>'.$row['age'].'</td>
            <td>'.$row['is_active'].'</td>
        </tr>';
$count++;
}
echo '</table>';

} else {
    echo '<div> No Results </div>';
}
echo '<p>Broi redove: '.$count.'</p>';

?>

</body>
</html>