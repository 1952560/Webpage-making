function JumpToRegister(){
    window.location.href="注册.html";
}

const url = "https://localhost:44388/WebTest.asmx/HelloWorld2";
const maxuserlen = 10;
const maxpasswdlen = 20;

function SendInfo(){
    let flag = checkUser()&&checkEmail()&&checkPasswd()&&checkPasswd1();
    if(!flag) {
        return false;
    }
    let data = $("#userInfo").serialize();
    console.log(data);
    console.log(typeof (data));

    $.ajax({
        url: url,
        type: "post",
        contentType: "application/x-www-form-urlencoded",
        dataType: "text",
        data:data,
        success: function (result,status) {
            if (status == "success") {
                alert(result);
            }
        },
        error: function (error) {
            alert(error);
        }
    });
    return false;
}

function checkEmail(){
    console.log("checkmail");
    let doc = document.getElementById("email")
    let str = doc.value.toString();
    let text = document.getElementById("mail")

    let flag;
    let regEx1 = "^([a-z0-9A-Z]+[-|\\.]?)+[a-z0-9A-Z]@([a-z0-9A-Z]+(-[a-z0-9A-Z]+)?\\.)+[a-zA-Z]{2,}$";
    flag = str.match(regEx1);

    if(!flag){
        text.innerHTML = "邮箱格式错误";
        return false;
    }
    else{
        text.innerHTML = "OK";
        return true;
    }
}

function checkPasswd(){
    console.log("checkPasswd");
    let doc = document.getElementById("password");
    let str = doc.value;
    let len = getStrlen(str,maxpasswdlen);
    let text = document.getElementById("passwd");
    if(len>maxpasswdlen || len===0 || str==null){
        text.innerHTML = "密码不能为空，密码长度<20";
        return false;
    }
    else{
        text.innerHTML = "OK";
        return true;
    }
}

function checkPasswd1(){
    console.log("checkPasswd1");
    let passwd1 = document.getElementById("password");
    let str1 = passwd1.value;
    let passwd2 = document.getElementById("password1");
    let str2 = passwd2.value;

    let text = document.getElementById("passwd1");
    if(str1 !== str2 || str2==null){
        text.innerHTML = "两次密码须一致";
        return false;
    }
    else{
        text.innerHTML = "OK";
        return true;
    }
}

function checkUser(){
    console.log("checkUser");
    let doc = document.getElementById("username");
    let str = doc.value;
    let len = getStrlen(str,maxuserlen);
    let text = document.getElementById("user",);
    if(len>maxuserlen || len===0 ||str==null){
        text.innerHTML = "用户名长度须<10";
        return false;
    }
    else{
        text.innerHTML = "OK";
        return true;
    }
}

function getStrlen(str,maxstrlen) {
    let myLen = 0;
    for (let index=0; (index < str.length) && (myLen <= maxstrlen); index++) {
        let a=str.charAt(index);
        if(a.match(/[^\x00-\xff]/ig) != null)
            myLen+=2;
        else
            myLen+=1;
    }
    return myLen;
}