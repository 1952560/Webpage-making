function JumpToRegister(){
    window.location.href="注册.html";
}

const url_log = "https://localhost:5001/Login";

function SendInfo(){
    let user = $("#userInfo").serializeArray();
    let data ={}
    data["email"]=user[0].value;
    data["password"]=user[1].value;
    console.log(data);

    $.ajax({
        url: url_log,
        type: "post",
        contentType: "application/json",
        dataType: "text",
        data:JSON.stringify(data),
        success: function (result,status) {
            if (status == "success") {
                if(result==="yes")
                    window.location.href="https://www.zhihuishu.com/";
                else if(result==="no"){
                    $("#password_login").next("p").text("密码错误");
                }
            }
        },
        error: function (error) {
            alert(error);
        }
    });
    return false;
}

function getParams(key) {
    var reg = new RegExp("(^|&)" + key + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    }
    return null;
}

document.addEventListener("DOMContentLoaded", function(){
    let email = document.getElementById("email_login");
    let password = document.getElementById("password_login");
    email.value = getParams("email");
    password.value = getParams("password");
});
console.log("参数param1:"+getParams("email"));//输出aa
console.log("参数param2:"+getParams("password"));
