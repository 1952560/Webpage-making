function JumpToRegister(){
    window.location.href="register.html";
}

const url_log = "https://localhost:5001/Login";

function SendInfo(){
    let user = $("#userInfo").serializeArray();
    let data ={}
    data["email"]=user[0].value;
    data["password"]=md5(user[1].value);
    console.log(data);

    $.ajax({
        url: url_log,
        type: "post",
        contentType: "application/json",
        dataType: "text",
        data:JSON.stringify(data),
        success: function (result,status) {
            if (status === "success") {
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

//获取get请求url后面的参数
function getParams(key) {
    let reg = new RegExp("(^|&)" + key + "=([^&]*)(&|$)");
    let r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return unescape(r[2]);
    }
    return null;
}

document.addEventListener("DOMContentLoaded", function(){
    let email = document.getElementById("email_login");
    email.value = getParams("email");
});
console.log("参数param1:"+getParams("email"));


// let Request = GetRequest();
// function GetRequest() {
//     let url = location.search; //获取url中含"?"符后的字串
//     let theRequest = {};
//     if (url.indexOf("?") !== -1) {
//         let str = url.substr(1);
//         let strs = str.split("&");
//         for (let i = 0; i < strs.length; i++) {
//             theRequest[strs[i].split("=")[0]] = strs[i].split("=")[1];
//         }
//     }
//     console.log(theRequest)
//     return theRequest;
// }