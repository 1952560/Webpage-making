<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>注册页面</title>
    <link rel="stylesheet" href="index.css">
</head>
<body>
<h1>慕课网注册页面</h1>
<form action="doAction.php" method="post">
    <table width="100%">
        <tr>
            <td>
                <input type="text" class="item" name="username" placeholder="用户名">
                <p>用户名首字母以字母开始，并且长度6-10位之间</p>
            </td>
        </tr>
        <tr>
            <td>
                <input type="password" class="item" name="password" placeholder="密码">
                <p>密码不能为空，密码长度6~10</p>
            </td>
        </tr>
        <tr>
            <td>
                <input type="password" class="item" name="password1" placeholder="请再次输入密码...">
                <p>两次密码一致</p>
            </td>
        </tr>
        <tr>
            <td>
                <input type="email" class="item" name="email" placeholder="邮箱">
                <p>邮箱必须包含@</p>
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" class="ite" name="verify">
                <?php
                $str='qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789';
                $code='';
                for ($i=1;$i<=4;$i++){
                    $code.='<span style="color: rgb('.mt_rand(0,255).','.mt_rand(0,255).','.mt_rand(0,255).')">'.$str[mt_rand(0,strlen($str)-1)] .'</span>';
                }
                echo $code;
                ?>
                <input type="hidden" name="verify1"  value="<?php echo strip_tags($code); ?>">
            </td>
            </td>
        </tr>
        <tr>
            <td>
                <input class="sub" type="submit" value="立即注册">
            </td>
        </tr>
    </table>
</form>
</body>
</html>