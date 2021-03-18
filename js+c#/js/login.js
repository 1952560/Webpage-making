function JumpToRegister(){
    window.location.href="注册.html";
}

const url_reg = "https://localhost:44388/WebTest.asmx/Login";

function SendInfo(){
    let data = $("#userInfo").serialize();
    console.log(data);
    console.log(typeof (data));

    $.ajax({
        url: url_reg,
        type: "post",
        contentType: "application/x-www-form-urlencoded",
        dataType: "text",
        data:data,
        success: function (result,status) {
            if (status == "success") {
                if(result.search("yes")!=-1){
                    window.location.href="https://passport.zhihuishu.com/login";
                }
            }
        },
        error: function (error) {
            alert(error);
        }
    });
    return false;
}
