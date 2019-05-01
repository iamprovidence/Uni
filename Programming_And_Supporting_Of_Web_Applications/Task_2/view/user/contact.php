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

        <h3>Contact us</h3>

        <form id="contact-form" action="/message/" method="post">
            <div class="form-group">
                <label for="email">Email</label>
                <input type="email" class="form-control" id="email" name="user_email" value="<?=$user_email?>" required>
            </div>
            <div class="form-group">
                <label for="subjects">Subjects</label>
                <select id="subjects" class="form-control">
                   
                    <?php foreach ($subjects as $subject): ?>
                    <option data-id="<?= $subject->id ?>"><?= $subject->name; ?></option>
                    <?php endforeach; ?>
                    
                </select>
            </div>
            <div class="form-group">
                <label for="message">Message</label>
                <textarea id="message" name="message" class="form-control" rows="5" required></textarea>
            </div>

            <button name="submit" class="btn">SUBMIT FORM</button>
        </form>

    </section>
     
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    
</body>
</html>