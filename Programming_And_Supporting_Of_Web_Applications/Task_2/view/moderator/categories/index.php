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
                <button id="btn-create-toggle" type="button" class="btn btn-info btn-create">Create new</button>
            </div>
            
            <table class="table table-striped" style="display: none;">

                <thead>
                    <tr>
                        <th scope="col">Name</th>
                        <th scope="col">Availability</th>
                        <th scope="col">Sort order</th>

                        <th scope="col" class="text-center">Create</th>
                    </tr>
                </thead>

                <tbody>
                    <tr>
                        <td>
                            <input id="category_name" class="form-control" type="text" />
                        </td>
                        <td class="text-center">
                            <input id="is_available" class="form-control" type="checkbox"  />
                        </td>
                        <td>
                            <input id="sort_order" class="form-control" type="number" min="0" value="0" />
                        </td>
                        
                        <td class="w-50-px">
                            <button id="create-btn" type="button" class="btn btn-primary btn-create">Create</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <!--TABLE-->
        <h3>Categories</h3>
        <div id="table-data" >
            <table class="table table-striped">

                <thead>
                    <tr>
                        <th scope="col">№</th>
                        <th scope="col">Name</th>
                        <th scope="col">Availability</th>
                        <th scope="col">Sort order</th>
                        <th scope="col" class="text-center">Update</th>
                        <th scope="col" class="text-center">Delete</th>
                    </tr>
                </thead>

                <tbody>
                  
                   <?php foreach ($categories as $category): ?>
                   
                    <tr>
                        <th scope="row"><?=$category->id?></th>
                        <td>
                            <input class="form-control" type="text" value="<?=$category->name?>"/>
                        </td>
                        <td class="text-center">
                            <input class="form-control" type="checkbox" <?php if ($category->is_available) echo 'checked';?> />
                        </td>
                        <td>
                            <input class="form-control" type="number" min="0" value="<?=$category->sort_order?>" />
                        </td>
                        
                        <td class="w-50-px">
                            <button type="button" class="btn btn-success btn-update">Update</button>
                        </td>
                        <td class="w-50-px">
                            <button data-id="<?=$category->id?>" type="button" class="btn btn-danger btn-delete">Delete</button>
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
    // update
    function bind_updating()
    {
        $("#table-data tbody tr").each(function()
        {
            const row = this;
            
            $(row).find(".btn-update").click(function()
            {
                $.post("/moderator/categories/update/", 
                {
                    id: $(row).find("th").text(),
                    name: $(row).find("input[type='text']").val(),
                    is_available:  $(row).find("input[type='checkbox']").is(":checked"),
                    sort_order: $(row).find("input[type='number']").val(),
                    submit: true
                },
                function (operationStatus)
                {
                    operationStatus = JSON.parse(operationStatus);
                    
                    notie.alert(
                    {
                        type: operationStatus.isOperationSucceeded ? "success" : "error", 
                        text: operationStatus.message
                    }); 

                });
            });
            
        });
    }
    // delete
    function bind_deleting()
    {
        $("button.btn-delete").click(function()
        {
            const entity_id = $(this).data("id");
            const page_number =  $('ul.pagination li.active a').text();

            notie.confirm(
            {
                text: 'Are you sure?',
                submitCallback: function()
                {        
                    // confirm deleting                
                    $.post("/moderator/categories/delete/",
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

                        if (operationStatus.isOperationSucceeded) load_view({entity_name: 'categories', page_number: page_number});
                        
                    });
                }
            });  
        });
    }
    // create
    function bind_creating()
    {
        // toggle button
        $( "#btn-create-toggle" ).click(function() 
        {
            if ($(this).html() === "Close")  $(this).html("Create new");
            else                             $(this).html("Close");
            
            $( "#create table" ).toggle("slow");
        });

        // create
        $("#create-btn").click(function()
        {        
            $.post("/moderator/categories/add/", 
            {
                name: $("#category_name").val(),
                is_available: $("#is_available").is(":checked"),
                sort_order: $("#sort_order").val(),
                submit: true
            }, 
            function(operationStatus)
            {
                operationStatus = JSON.parse(operationStatus);
                
                if (operationStatus.isOperationSucceeded) 
                {
                    const page_number =  $('ul.pagination li.active a').text();

                    load_view({entity_name: 'categories', page_number: page_number});
                }
                
                notie.alert(
                {
                    type: operationStatus.isOperationSucceeded ? "success" : "error", 
                    text: operationStatus.message
                }); 
                
            });
        });
    }
    </script>

</body>
</html>