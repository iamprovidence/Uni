$(document).ready(function() 
{
    $("tbody tr").each(function ()
    {
        var nickname = $(this).find("td.user-nickname").html();

        var row = this;

        // bind delete
        $(this).find(".btn-delete").on("click", function ()
        {
            const delete_btn = this;
            notie.confirm(
            {
                text: `Are you sure you want to delete ${nickname}?`,
                submitCallback: function()
                {        
                    // confirm deleting
                    $.post('/administrator/delete/',
                    {
                        user_id: $(delete_btn).data('id'),
                        submit:  true,
                    },
                    function(operationStatus)
                    {
                        operationStatus = JSON.parse(operationStatus);

                        notie.alert(
                        {
                            type: operationStatus.isOperationSucceeded ? "success" : "error", 
                            text: operationStatus.message
                        }); 

                        if (operationStatus.isOperationSucceeded) disable_row(row);
                    });
                }
            });
        });

        // bind update
        $(this).find(".btn-update").on("click", function ()
        {
            $.post('/administrator/update/',
            {
                submit  : true,
                user_id : $(this).data('id'),
                new_user_role : $(row).find('select').children("option:selected").data("role")
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
});