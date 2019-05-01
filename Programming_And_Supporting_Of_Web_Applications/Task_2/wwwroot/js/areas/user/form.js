// LOG IN
$("#log-in-form").submit(function(event) 
{        
    // do not reload page
    event.preventDefault();
    
    // send post
    $.post("/login/", 
    {
        user_email:     $(this).find("#log-in-email").val(),
        user_password:  $(this).find("#log-in-password").val(),
        submit:         true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            window.location.href = '/';// redirect to main
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});

// SIGN UP
$("#sign-up-form").submit(function (event)
{        
    // do not reload page
    event.preventDefault();
    
    const user_password = $(this).find("#sign-up-password").val();
    const user_repeat_password = $(this).find("#sign-up-confirm-password").val();
    
    if (user_password != user_repeat_password)
    {
        notify({message: "Passwords do not match", type: "danger"});
        return;
    }
    
    // send post
    $.post("/signup/", 
    {
        user_nickname:  $(this).find("#sign-up-nickname").val(),
        user_email:     $(this).find("#sign-up-email").val(),
        user_password:  user_password,
        submit:         true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            window.location.href = '/';// redirect to main
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});

// EDIT USER
$("#personal-info-form").submit(function(event) 
{        
    // do not reload page
    event.preventDefault();    
    
    var user_current_password = $(this).find("#cabinet-password");
    var do_reset_avatar = $(this).find('#reset-avatar').is(':checked');
    // checking
    const user_new_password = $(this).find("#cabinet-new-password").val();
    const user_repeat_new_password = $(this).find("#cabinet-confirm-password").val();
    
    if (user_new_password != user_repeat_new_password)
    {
        notify({message: "Passwords do not match", type: "danger"});
        return;
    }
    
    // gather data
    var formData = new FormData();
    formData.append('user_nickname', $(this).find("#cabinet-nickname").val());
    formData.append('user_password', $(user_current_password).val());
    formData.append('user_new_password', user_new_password);
    formData.append('user_new_avatar', $(this).find('#load-new-avatar')[0].files[0]);
    formData.append('user_do_reset_avatar', do_reset_avatar)
    formData.append('submit', true);
    
    // send post
    $.ajax({
        url: "/edit/",
        type: "POST",
        data: formData,
        processData: false,
        contentType: false
    })
    .always(function (operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {   
            // reset password
            $(user_current_password).val('');  
            
            // change images
            if (document.getElementById("load-new-avatar").files.length > 0) 
                swap_image({ first_image_selector_id: 'avatar-preview', second_image_selector_id: 'current-avatar' });
            
            change_image({ image_selector_id: 'avatar-preview', image_path: DEFAULT_USER_IMAGE });
            
            if (do_reset_avatar) 
                change_image({ image_selector_id: 'current-avatar', image_path: DEFAULT_USER_IMAGE });
            
            
            notify({message: operationStatus.message, type: "info"});
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});

// CONTACT
$("#contact-form").submit(function(event) 
{
    // do not reload page
    event.preventDefault();
    
    const subject_option = $("#subjects").children("option:selected");
    const message_area = $("#message");

    // send post
    $.post("/message/", 
    {
        user_email: $("#email").val(),
        message: $(message_area).val(),
        subject: $(subject_option).val(),
        subject_id: $(subject_option).data("id"),
        submit: true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            $(message_area).val('');       
            
            notify({message: operationStatus.message, type: "info"});
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});

// CHECKOUT
$("#checkout-form").submit(function (event)
{    
    // do not reload page
    event.preventDefault();    
    
    const message_area = $("#message");
    
    // send post
    $.post("/cart/checkout/", 
    {
        user_email: $("#email").val(),
        user_address: $("#address").val(),
        user_message: $(message_area).val(),
        submit: true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            $(message_area).val('');
            $('#cart-amount').text(0);
            
            notify({message: operationStatus.message, type: "info"});
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});

// ADD COMMENT
$("#add-comment-form").submit(function (event)
{    
    // do not reload page
    event.preventDefault();    
    const subject_input = $("#product-subject-text");
    const textarea = $("#product-comment-text");
    
    // send post
    $.post("/comment/add/", 
    {
        comment_subject: $(subject_input).val(),
        comment_text: $(textarea).val(),
        product_id: $("#add-comment button").data('product-id'),
        submit: true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            // show comments
            load_comment_view();
            
            // clean
            $(subject_input).val('');
            $(textarea).val('');
            
            notify({message: operationStatus.message, type: "info"});
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});