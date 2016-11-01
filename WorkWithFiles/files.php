<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Work With Files</title>
</head>
<body>
    <form method="post" enctype="multipart/form-data">
        <input type="file" name="picture" />
        <input type="submit" value="ДОБАВИ" />
    </form>
    <?php
    if (count($_FILES > 0)) {
        if (move_uploaded_file($_FILES['picture']['tmp_name'], 'test'.DIRECTORY_SEPARATOR.$_FILES['picture']['name'])) {
            echo '<pre>'.print_r($_FILES, true).'</pre>';
            echo 'FILE IS UPLOADED SUCCESSFULLY!';
        } else {
            echo 'ERROR!';
            echo '<pre>'.print_r($_FILES['picture']['error'], true).'</pre>';
        }
    }
    ?>
</body>
</html>
