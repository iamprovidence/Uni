<!-- jQuery -->
<script src="css/jquery-3.1.1.js"></script>
<script>
	$(document).scroll (function () 
	{
		if ($(document).scrollTop()> $('header').height () + 14) 
		{
			$('nav').addClass('fixed');
		} 
		else 
		{
			$('nav').removeClass('fixed');
		}
		if ($(document).scrollTop()> $('header').height () + 50) 
		{
			$('.start').addClass('fix');
		} 
		else 
		{
			$('.start').removeClass('fix');
		}		
	});
    
    $('.start').click(function()
    {
        $("html,body").animate({
            scrollTop: 0
        },500);
        return false;
    });
</script> 