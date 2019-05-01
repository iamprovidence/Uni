<!DOCTYPE html>
<html lang="en">
<head>    
    <?php include_once (ROOT ."/view/administrator/layout/head.php"); ?>  
</head>
<body>
   
    <!--HEADER-->
    <?php include_once (ROOT ."/view/administrator/layout/header.php"); ?>  
    

    <div class="container-fluid">
        <!--TABLE-->
        <div id="table-data" >
            <table class="table table-striped">

                <thead class="thead-dark">
                    <tr>
                        <th scope="col">№</th>
                        <th scope="col">Avatar</th>
                        <th scope="col">Nickname</th>
                        <th scope="col">Email</th>
                        <th scope="col">Role</th>
                        <th scope="col">Update</th>
                        <th scope="col">Delete</th>
                    </tr>
                </thead>

                <tbody>
                    
                    <?php foreach ($users as $user): ?>
                    
                    <tr <?php if ($this->GetModel(Models::User)->GetUser()->id == $user->id) echo "class='disabled'"; ?>>
                        <th scope="row"><?=$user->id?></th>
                        <td class="w-50-px">
                            <img src="<?php echo $this->GetModel(Models::User)->GetImage($user->id)?>" width="50" height="50" alt="User avatar"/>
                        </td>
                        <td class="user-nickname"><?=$user->nickname?></td>
                        <td><?=$user->email?></td>
                        <td>
                        <select class="form-control" <?php if ($this->GetModel(Models::User)->GetUser()->id == $user->id) echo 'disabled'; ?>>
                                                       
                            <?php foreach ($roles as $key => $name):?>
                            <option data-role="<?=$key?>" <?php if ($user->role == $key) echo 'selected'; ?>><?=$name?></option>
                            <?php endforeach;?>
                            
                        </select>
                        </td>
                        <td>
                            <button <?php if ($this->GetModel(Models::User)->GetUser()->id == $user->id) echo 'disabled'; ?> data-id="<?=$user->id?>" type="button" class="btn btn-primary btn-update">Update</button>
                        </td>
                        <td>
                            <button <?php if ($this->GetModel(Models::User)->GetUser()->id == $user->id) echo 'disabled'; ?> data-id="<?=$user->id?>" type="button" class="btn btn-danger btn-delete">Delete</button>
                        </td>
                    </tr>
                    
                    <?php endforeach; ?>

                </tbody>
            </table>
        </div>
        
        <!--PAGINATION-->
        <?php echo $pagination->get(); ?>
        
    </div>
    
    <script src="/wwwroot/js/lib/jquery-3.3.1.min.js"></script>    
    <script src="/wwwroot/lib/notie/notie.min.js"></script>
    <script src="/wwwroot/js/functions.js"></script>
    <script src="/wwwroot/js/areas/administrator/index.js"></script>
</body>
</html>