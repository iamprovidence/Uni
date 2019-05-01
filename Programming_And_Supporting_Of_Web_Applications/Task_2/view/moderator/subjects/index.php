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
                        <th scope="col" class="text-center">Create</th>
                    </tr>
                </thead>

                <tbody>
                    <tr>
                        <td>
                            <input class="form-control" type="text" />
                        </td>
                        
                        <td class="w-50-px">
                            <button id="create-btn" type="button" class="btn btn-primary btn-create">Create</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <!--SUBJECTS-->
        <h3>Subjects</h3>
        <div id="table-data" >
            <table class="table table-striped">

                <thead>
                    <tr>
                        <th scope="col">№</th>
                        <th scope="col">Name</th>
                        <th scope="col" class="text-center">Update</th>
                        <th scope="col" class="text-center">Delete</th>
                    </tr>
                </thead>

                <tbody>
                   <?php foreach ($subjects as $subject): ?>
                   
                    <tr>
                        <th scope="row"><?=$subject->id;?></th>
                        <td>
                            <input class="form-control" type="text" value="<?=$subject->name?>"/>
                        </td>
                        
                        <td class="w-50-px">
                            <button type="button" class="btn btn-success btn-update">Update</button>
                        </td>
                        <td class="w-50-px">
                            <button data-id="<?=$subject->id;?>" type="button" class="btn btn-danger btn-delete">Delete</button>
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
            const id = $(this).find("th").text();
            const row = this;
            
            $(this).find(".btn-update").click(function()
            {
                const new_name = $(row).find("input").val();
                $.post("/moderator/subjects/update/", 
                {
                    id: id,
                    name: new_name
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
            const page_number = $('ul.pagination li.active a').text();
            
            notie.confirm(
            {
                text: 'Are you sure?',
                submitCallback: function()
                {        
                    // confirm deleting                
                    $.post("/moderator/subjects/delete/",
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

                        if (operationStatus.isOperationSucceeded) load_view({entity_name: 'subjects', page_number: page_number});
                        
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

        // creating button
        $("#create-btn").click(function()
        {
            var subject_name = $("#create input").val();
            $.post("/moderator/subjects/add/",
            {
                name: $("#create input").val()
            },       
            function(data)
            {
                if (operationStatus.isOperationSucceeded) 
                {
                    $("#btn-create-toggle").trigger('click');
                }
                
                notie.alert(
                {
                    type: operationStatus.isOperationSucceeded ? "success" : "error", 
                    text: operationStatus.message
                });
                
                if (operationStatus.isOperationSucceeded) 
                {
                    const page_number =  $('ul.pagination li.active a').text();

                    load_view({entity_name: 'subjects', page_number: page_number});
                }
                
            });
            
        });
    }
    </script>

</body>
</html>