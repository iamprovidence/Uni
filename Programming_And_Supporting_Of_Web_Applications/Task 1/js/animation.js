// preloader
function stopLoading(time) 
{
    setTimeout(showPage, time);
}

function showPage() 
{
    document.getElementById("preloader").style.display = "none";
    document.getElementById("preloader").outerHTML = "";// remove element if supported
    
    document.getElementById("main-wrapper").style.display = "block";
    document.getElementById("bg-text").style.display = "block";
}

// animation
$(document).ready(function($) 
{
    // APPEARING
    // all headers, except first
    $("h2:not(#presentation h2)").css("opacity", 0).one("inview", function(event, isInView) 
    {
        if (isInView) $(this).addClass("animated fadeInDown");
    });
    
    // PLUSES
    $("#pluses p").css("opacity", 0).one("inview", function(event, isInView) 
    {
        if (isInView) $(this).addClass("animated fadeInDown");
    });
    
    // TOP MOST
    $("#top-most .grid div").css("opacity", 0).one("inview", function(event, isInView) 
    {
        if (isInView) $(this).addClass("animated fadeInLeft");
    });
    
    // REVIEWS
    $("#reviews .row div").css("opacity", 0).one("inview", function(event, isInView) 
    {
        if (isInView) $(this).addClass("animated fadeInLeft");
    });
    
    // BUY ITEMS
    $("#buy .row div").css("opacity", 0).one("inview", function(event, isInView) 
    {
        if (isInView) $(this).addClass("animated fadeInDown");
    });
    
    
    
    // scroll to top button
    $("footer > a").click(function () 
    {
        $("body, html").animate(
        {
            scrollTop: 0
        }, 800);
        return false;
    });
});
