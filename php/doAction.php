<?php
header("content-type:text/html;charset=utf-8");

$redirectUrl='<a href="注册.php">重新注册</a>';
$username=$_POST['username'];
$password=$_POST['password'];
$password1=$_POST['password1'];
$email=$_POST['email'];

$verify=trim(strtolower($_POST['verify']));
$verify1=trim(strtolower($_POST['verify1']));

//检测用户名首字母是否为字母
$char=substr($username,0,1);

$ascii=ord($char);//得到指定字符的ASCII
//检测ASCII是否在65-90（A-Z）或者97-122（a-z）
if (!($ascii>=65&&$ascii<=90||$ascii>=97&&$ascii<=122)){
    die('用户名首字母不是以字母开始'.$redirectUrl);
}
//检测用户名长度是否符合要求
$userlen=strlen($username);
if($userlen<=6||$userlen>=10){
    die('用户名长度不符合要求'.$redirectUrl);
}
//检测密码是否为空
$psdlen=strlen($password);
if ($psdlen==0){
    die('密码不能为空'.$redirectUrl);
}
//检测密码长度是否符合规范
if($psdlen<=6||$psdlen>=10){
    die('密码长度不符合要求'.$redirectUrl);
}

//检测两次密码是否一致
if (strcmp($password,$password1)!==0){
    die('两次密码不一致'.$redirectUrl);
}

//检测邮箱的合法性，字符串中包含@
if (strpos($email,'@')==false){
    die('邮箱不合法'.$redirectUrl);
}

//检测验证码是否符合规范
if ($verify!==$verify1){
    die('验证码错误'.$redirectUrl);
}

echo "好家伙，注册成功了";