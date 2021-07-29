$(function(){
    //Menu按鈕
    let Home = $("#Home")
    let AddMovieBtn = $("#AddMovieBtn");
    let DiscussBtn = $("#DiscussBtn");
    let AboutUsBtn = $("#AboutUsBtn");


    Home.on("click", function(){
        location.href = "http://127.0.0.1:8887/HomePage.html";
    })
    AddMovieBtn.on("click", function(){
        location.href = "http://127.0.0.1:8887/AddMovie.html";
    })
    DiscussBtn.on("click", function(){
        location.href = "http://127.0.0.1:8887/Discuss.html";
    })
    AboutUsBtn.on("click", function(){
        location.href = "http://127.0.0.1:8887/AboutUs.html";
    })
    

})

// 登入/註冊/登出
function SignBtn(){
    $("#SignFace").toggle();
}

function SignClose(){
    $("#SignFace").css("display","none");
}