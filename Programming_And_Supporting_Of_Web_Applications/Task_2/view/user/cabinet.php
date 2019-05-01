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
    <section class="container bg-white">
      
        <h3>My Account</h3>

        <!--PERSONAL INFO TAB-->    

        <form id="personal-info-form">


            <h4 class="text-dark">Avatar</h4>
            <div class="form-group row">
                <img id="current-avatar" src="<?= $this->GetModel(Models::User)->GetImage($user->id) ?>" alt="Current avatar"/>
                <img id="avatar-preview" src="<?= $this->GetModel(Models::User)->GetImage(-1) ?>" alt="New avatar"/>
                <div class="col-sm">
                    <input type="file" class="form-control-file btn" id="load-new-avatar" accept="image/*"><label><input type="checkbox" id="reset-avatar">Do you want to reset avatar?</label>
                </div>
            </div>

            <div class="form-group">
                <label for="cabinet-nickname">Nickname</label>
                <input type="text" class="form-control" id="cabinet-nickname" value="<?=$user->nickname?>" required>
            </div>

            <hr/>
            <div class="form-group">
                <label for="cabinet-email">Email</label>
                <input type="email" class="form-control" id="cabinet-email" value="<?=$user->email?>" readonly>
            </div>

            <hr/>
            <div class="form-group">
                <label for="cabinet-password">Password</label>
                <input type="password" class="form-control" id="cabinet-password" required>
            </div>

            <div class="form-group">
                <label for="cabinet-new-password">New Password</label>
                <input type="password" class="form-control" id="cabinet-new-password">
            </div>

            <div class="form-group">
                <label for="cabinet-confirm-password">Confirm New Password</label>
                <input type="password" class="form-control" id="cabinet-confirm-password">
            </div>

            <button type="submit" class="btn text-uppercase">UPDATE INFO</button>

        </form>       
   </section>

  
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    <script>
        document.addEventListener('DOMContentLoaded', function(){ 
            document.getElementById("load-new-avatar").onchange = function()
            {
                preview_image
                ({ 
                    file_input_id: 'load-new-avatar', 
                    image_preview_id: 'avatar-preview', 
                });
            }
               
        });
    </script>
</body>
</html>