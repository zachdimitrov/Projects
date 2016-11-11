<!DOCTYPE html>
<html>
    <head>
        <title><?= $data['title']; ?></title>

        <meta charset="UTF-8">       
    </head>
    <body>
            <?php
            echo $data['header'];
            ?>
        </div>
        <div style="border: 1px solid red">
            <?php
            echo $data['result'];
            ?>
        </div>
    </body>
</html>
