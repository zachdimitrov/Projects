<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Form';
include './includes/header.php';
require './includes/groups.php';
if ($_POST) {
    $username = trim($_POST['username']);
    $username = str_replace('!', '', $username);
    $phone = trim($_POST['phone']);
    $phone = str_replace('!', '', $phone);
    $selectedGroup = (int) $_POST['group'];
    $error = false;
    if (mb_strlen($username) < 4) {
        echo '<p>Name is too short!</p>';
        $error = true;
    }
    if (preg_match("/\D/", $phone)) {
        echo '<p>Phone is wrong!</p>';
        $error = true;
    }
    if (!array_key_exists($selectedGroup, $groups)) {
        echo '<p>Invalid group!</p>';
        $error = true;
    }

    if (!$error) {
      $result=$username.'!'.$phone.'!'.$selectedGroup."\n";
      if(file_put_contents('data.txt', $result, FILE_APPEND)) {
        echo 'Entry is successful!';
      }
    }
}
// echo '<pre>' . print_r($_POST, true) . '</pre>';
?>

  <a href="index.php">Contact List</a>
  <form method="POST">
    <div>
      Name :
      <input type="text" name="username" value="">
    </div>
    <div>
      Phone:
      <input type="text" name="phone" value="">
    </div>
    <div>
      Group:
      <select name="group">

<?php 
foreach ($groups as $key => $value) {
    echo '<option value="' . $key . '">' . $value . '</option>';
}
?>
      </select>
    </div>
    <div>
      <input type="submit" value="Add" />
    </div>
  </form>

<?php 
include './includes/footer.php';