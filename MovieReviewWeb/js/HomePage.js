// MovieWall
$(function(){
    let LeftBtn = $("#LeftBtn");
    let RightBtn = $("#RightBtn");
    let idx = 1;
    LeftBtn.on("click",function(){
        idx--;
        if(idx < 1){
            idx = 3;
        }
        MovieNews.innerHTML = '<a id="M'+idx+'"><img src="./img/M'+idx+'.png" class="img-fluid" alt="近期沒有電影上映"/></a>';
    });
    RightBtn.on("click",function(){
        idx++;
        if(idx > 3){
            idx = 1;
        }
        MovieNews.innerHTML = '<a id="M'+idx+'"><img src="./img/M'+idx+'.png" class="img-fluid" alt="近期沒有電影上映"/></a>';
    });
})