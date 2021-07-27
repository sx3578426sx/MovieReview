$(function(){
    let Home = $("#Home")
    let AddMovieBtn = $("#AddMovieBtn");
    let ReviewBtn = $("#ReviewBtn");
    let AboutUsBtn = $("#AboutUsBtn");

    Home.on("click", function(){
        location.href = "http://127.0.0.1:8887/HomePage.html";
    })
    AddMovieBtn.on("click", function(){
        location.href = "";
    })
    ReviewBtn.on("click", function(){
        location.href = "";
    })
    AboutUsBtn.on("click", function(){
        location.href = "http://127.0.0.1:8887/AboutUs.html";
    })
})