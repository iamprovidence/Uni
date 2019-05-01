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
        <h3>
            Message №<span><?= $message->id ?></span>   
        </h3>
        
        <form>
            <div class="form-group">
                <label for="input-email">User email</label>
                <input disabled type="email" class="form-control" id="input-email" value="<?= $message->user_email ?>">
            </div>
            <div class="form-group">
                <label for="input-date">Date</label>
                <input disabled type="date" class="form-control" id="input-date" value="<?= $message->date ?>">
            </div>
            <div class="form-group">
                <label for="input-subject">Subject</label>
                <input disabled type="text" class="form-control" id="input-subject" value="<?= $message->subject_name?>">
            </div>
            <div class="form-group">
                <label for="textarea-text">Text</label>
                <textarea id="textarea-text" class="form-control" disabled><?= $message->text ?></textarea>
            </div>
        </form>
        
        <!--BUTTONS-->
        <div class="row">
            <div class="col">
                <button type="button" class="btn btn-secondary btn-go-back w-100">Go back</button>
            </div>
            <div class="col">
                <button type="button" data-id="<?= $message->id ?>" class="btn btn-danger btn-delete w-100">Delete</button>
            </div>
        </div>
    </div>
    
    <!--SCRIPTS-->
    <?php include_once (ROOT ."/view/moderator/layout/scripts.php"); ?>    
    <script>      
    function bind_deleting() 
    {
        $("button.btn-delete").click(function()
        {
            const entity_id = $(this).data("id");
            
            notie.confirm(
            {
                text: 'Are you sure?',
                submitCallback: function()
                {        
                    // confirm deleting                
                    $.post("/moderator/messages/delete/",
                    {
                        entity_id:  entity_id,
                        submit:     true
                    },
                    function(operationStatus)
                    {
                        operationStatus = JSON.parse(operationStatus);

                        if (operationStatus.isOperationSucceeded)
                        {
                            go_back_in_history()
                        }
                        else
                        {
                            notie.alert(
                            {
                                type: "error", 
                                text: operationStatus.message
                            }); 
                        }
                    });
                }
            });
        });
    }
    </script>
</body>
</html>