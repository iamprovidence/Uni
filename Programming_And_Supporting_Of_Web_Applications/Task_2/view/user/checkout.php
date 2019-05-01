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
    <section class="container form-control bg-white">

        <h3>Checkout</h3>

        <form id="checkout-form" data-toggle="validator">
            <div class="form-group">
                <label for="email">Email</label>
                <input type="email" class="form-control" id="email" value="<?=$user_email?>" required>
            </div>
            <div class="form-group">
                <label for="address">Address</label>
                <input type="text" class="form-control" id="address" required>
            </div>
            <div class="form-group">
                <label for="message">Message</label>
                <textarea id="message" class="form-control" rows="5"></textarea>
            </div>

            <button type="submit" id="form-submit" class="btn">SUBMIT FORM</button>

        </form>

    </section> 
 
  
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?>     

</body>
</html>