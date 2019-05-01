<!DOCTYPE html>
<html lang="en">
<head>
    <?php include_once (ROOT ."/view/moderator/layout/head.php"); ?> 
</head>
<body>
    
    <!--HEADER-->
    <?php include_once (ROOT ."/view/moderator/layout/header.php"); ?>      
    
    <!--MENU-->
    <?php include_once (ROOT ."/view/moderator/layout/menu.php"); ?>    
    
    <!--CONTENT-->
    <div id="main" class="container-fluid">
      
        <!--CREATE-->
        
        <div id="create">
            <h3>Create</h3>
            
            <div class="text-right mb-3">
                <a href="/moderator/products/create" class="btn btn-info btn-create text-white">Create new</a>
            </div>
        </div>
        
        <!--TABLE-->
        <h3>Products</h3>
        <div id="table-data" >
            <table class="table table-striped">

                <thead>
                    <tr>
                        <th scope="col" class="w-50-px">№</th>
                        <th scope="col" class="w-50-px">Photo</th>
                        <th scope="col">Name</th>                        
                        <th scope="col">Price</th>
                        <th scope="col" class="w-50-px">Availability</th>
                        <th scope="col" class="w-50-px">New</th>
                        <th scope="col" class="w-50-px">Comments</th>

                        <th scope="col" class="text-center">Read</th>
                        <th scope="col" class="text-center">Update</th>
                        <th scope="col" class="text-center">Delete</th>
                    </tr>
                </thead>

                <tbody>
                   
                   <?php foreach ($products as $product): ?>
                   
                    <tr>
                        <th scope="row"><?=$product->id?></th>
                        <td>
                            <img src="<?= $this->GetModel(Models::Product)->GetImage($product->id) ?>" alt="<?=$product->name?> image" height="50" width="50"/>
                        </td>
                        <td>
                            <?=$product->name?>
                            
                        </td>
                        <td>
                            <?=$product->price?> $
                        </td>
                        <td>
                            <input class="form-control" type="checkbox" <?php if($product->is_available) echo 'checked'?> disabled />
                        </td>
                        <td>
                            <input class="form-control" type="checkbox" <?php if($product->is_new) echo 'checked'?> disabled />
                        </td>
                        <td>
                            <input class="form-control" type="checkbox"  <?php if($product->is_comments_available) echo 'checked'?> disabled/>
                        </td>

                        <td class="w-50-px">
                            <a href="/moderator/products/read/<?=$product->id?>/" class="btn btn-warning">Read</a>
                        </td>
                        <td class="w-50-px">
                            <a href="/moderator/products/update/<?=$product->id?>/" class="btn btn-success">Update</a>
                        </td>
                        <td class="w-50-px">
                            <button data-id="<?=$product->id?>" type="button" class="btn btn-danger btn-delete">Delete</button>
                        </td>
                    </tr>
                    
                    <?php endforeach; ?>
                    
                </tbody>
            </table>
        </div>
        
        <!--PAGINATION-->
        <?php echo $pagination->get(); ?>          

    </div>
    
    <!--SCRIPTS-->
    <?php include_once (ROOT ."/view/moderator/layout/scripts.php"); ?>  
    <script>
        
    //delete
    function bind_deleting()
    {    
        $("button.btn-delete").click(function()
        {
            const entity_id = $(this).data("id");
            const page_number = $('ul.pagination li.active a').text();
            
            notie.confirm(
            {
                text: 'Are you sure?',
                submitCallback: function()
                {        
                    // confirm deleting                
                    $.post("/moderator/products/delete/",
                    {
                        entity_id:  entity_id,
                        submit:     true
                    },
                    function(operationStatus)
                    {
                        operationStatus = JSON.parse(operationStatus);

                        notie.alert(
                        {
                            type: operationStatus.isOperationSucceeded ? "success" : "error", 
                            text: operationStatus.message
                        }); 

                        if (operationStatus.isOperationSucceeded) load_view({entity_name: 'products', page_number: page_number});
                        
                    });
                }
            });        
        });
    }    
    </script>

</body>
</html>