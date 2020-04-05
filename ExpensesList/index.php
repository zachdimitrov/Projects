<?php
$pagetitle = 'Expenses List';
include './includes/header.php';
require './includes/types.php';
?>
    <a href="form.php">Добави нов разход</a>

    <form method="GET" id="filter">
<div>
      <span>Избери вид и натисни филтър:</span>
      <select name="type">
      <option value="0">Всички</option>
<?php 
foreach ($types as $key => $value) {
    echo '<option';
    if(isset($_GET['type']) && (int)$_GET['type']==$key) {
        echo ' selected="selected"';
    }
    echo ' value="' . $key . '">' . $value . '</option>';
}
?>
      </select>
    </div>
    <span>
      <input type="submit" value="Филтър" />
    </span>
  </form>

    <div class="table">
        <div class="header">
            <p>Дата</p>
            <p>Име</p>
            <p>Сума</p>
            <p>Тип</p>
        </div>
        <?php
        if(file_exists('data.txt')) {
            $result=file('data.txt');
            $totalsum=0;
            foreach ($result as $value) {
                $columns=explode('!', $value);
                if (isset($_GET['type']) && $_GET['type']>0 && (int)$_GET['type']!=(int)$columns[3]) {
                    continue;
                }
                $totalsum+=$columns[2];
                echo '<div class="row">
                <p>'.$columns[0].'</p>
                <p>'.$columns[1].'</p>
                <p>'.$columns[2].'</p>
                <p>'.$types[trim($columns[3])].'</p>
                </div>';
            }
            echo '<div class="res">
                <p><b>Обща сума</b></p>
                <p>...</p>
                <p><b>'.$totalsum.'</b></p>
                <p>Лева</p>
                </div>';
        }
        ?>
    </div>
    <?php
include './includes/footer.php';
?>