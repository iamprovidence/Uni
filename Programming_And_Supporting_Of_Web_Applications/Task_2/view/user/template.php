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
    <section class="container">
        
      <h3><?= $contentTitle ?></h3>
      <p>
          <?=$contentText?>
      </p>
       
   </section>
   
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    
</body>
</html>