$(function() {
        // MovieWall
        let LeftBtn = $("#LeftBtn");
        let RightBtn = $("#RightBtn");
        let idx = 1;
        LeftBtn.on("click", function() {
            idx--;
            if (idx < 1) {
                idx = 3;
            }
            MovieNews.innerHTML = '<a id="M' + idx + '"><img src="./img/M' + idx + '.png" class="img-fluid" alt="近期沒有電影上映"/></a>';
        });
        RightBtn.on("click", function() {
            idx++;
            if (idx > 3) {
                idx = 1;
            }
            MovieNews.innerHTML = '<a id="M' + idx + '"><img src="./img/M' + idx + '.png" class="img-fluid" alt="近期沒有電影上映"/></a>';
        });
        /*幻燈片，每三秒切換下一張
        setInterval(function(){
            idx++;
            if(idx > 3){
                idx = 1;
            }
            MovieNews.innerHTML = '<a id="M'+idx+'"><img src="./img/M'+idx+'.png" class="img-fluid" alt="近期沒有電影上映"/></a>';
        },3000)
        */


        //Poster ajax
        // $.ajax({
        //     type:"GET",
        //     url:"http://127.0.0.1:8887/js/MovieList.json",
        //     dataType:"json",
        //     success: function(){

        //     }
        // })
    })
    // 登入彈跳視窗
function SignInBtn() {
    $("#SignFace").toggle();
}

function SignClose() {
    $("#SignFace").css("display", "none");
}

    // 註冊頁面跳轉
function SignUpBtn() {
    location.href = "./SignUp.html";
}

function HistoryBack(){
    window.history.go(-1);
}

