<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Form';
$success = false;
$warning = '';
include './includes/header.php';
require './includes/types.php';
if ($_POST) {
    $date = (string)date('D, d/m/Y, H:i');
    $name = trim($_POST['name']);
    $name = str_replace('!', '', $name);
    $ammount = floatval(str_replace(',', '.', $_POST['ammount']));
    $selectedType = (int) $_POST['type'];
    $error = false;
    if (mb_strlen($name) < 4) {
        $warning = '<p>Внимание! Твърде кратко име!</p>';
        $error = true;
    }

    if (!array_key_exists($selectedType, $types)) {
        $warning = '<p>Внимание! Невалиден тип!</p>';
        $error = true;
    }

    if (!$error) {
      $result=$date.'!'.$name.'!'.$ammount.'!'.$selectedType."\n";
      if(file_put_contents('data.txt', $result, FILE_APPEND)) {
        $success = true;
      }
    }
}
// echo '<pre>' . print_r($_POST, true) . '</pre>';
?>

  <a href="index.php">Списък с разходите</a>
  <form method="POST">
    <div>
      <span>Име:</span>
      <input type="text" name="name" value="">
    </div>
    <div>
      <span>Сума:</span>
      <input type="number" step="0.01" name="ammount" value="">
    </div>
    <div>
      <span>Тип:</span>
      <select name="type">

<?php 
foreach ($types as $key => $value) {
    echo '<option value="' . $key . '">' . $value . '</option>';
}
?>
      </select>
    </div>
    <div>
      <input type="submit" value="Filter" />
    </div>
  </form>

<?php 
include './includes/footer.php';
if ($success) {
    echo '<p>Entry is successful!</p>';
} else {
    echo $warning;
}
?>