<!DOCTYPE html>
<html lang="en">
<head>
    <?php include_once (ROOT ."/view/user/layout/head.php"); ?>       
</head>
<body>
   
    <!--HEADER-->
    <?php include_once (ROOT ."/view/user/layout/header.php"); ?>   
      
    <!--CART MODAL-->
    <?php include_once (ROOT ."/view/user/layout/cart-modal.php"); ?>   
    
    <!--AUTHENTICATION MODAL-->
    <?php include_once (ROOT ."/view/user/layout/authentication-modal.php"); ?>
   
    <!--CONTENT-->
    <?php include_once (ROOT ."/view/user/layout/shop.php"); ?>
  
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    <script>
        // change lovation on changing sorting mode
        $("#shop select").change(function () 
        {
            const id = $(this).find("option:selected").data("id");
            
            window.location.href = `/shop/sort/${id}/`;
        });
    /*function load_shop_view()
    {
        $.pjax({
                type: 'POST',
                url: '/shop/page-1/',
                container: '#shop',
                fragment: '#shop',
                push: false,
                data: 
                {
                    //brand_id: 16,
                    
                    submit: true 
                },
            });  
    }
    $(document).ready(function() 
    {
            $(".brands a").click(function(event)
                                {
                load_shop_view();
                event.preventDefault();
            });
    });*/
    </script>
    
</body>
</html>