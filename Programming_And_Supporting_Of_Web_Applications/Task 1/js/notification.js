// type = bootstrap clases (success, info, warning, danger, dark...)
function notify(message, type)
{
    $.notify(
        {
            // options
            message: message
        },
        {
            // settings
            type: type,
            allow_dismiss: true,
            newest_on_top: false,
            placement:     
            {
                from:  "bottom",
                align: "left"
            },
            offset: 20,
            spacing: 10,
            delay: 2000,
            mouse_over:	"pause",
            animate: 
            {
                enter: "animated fadeInDown",
                exit:  "animated fadeOutLeft"
            }
        }
    );
}

function isEmail(email) 
{
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

// bind to buttons
$(document).ready(function($) 
{
    // notification on buying guitar 
    $("#buy .buy-item").each(function ()
    {
        const guitar_name = $(this).find("p").html().split("<br>")[0];
        $(this).find("button").on("click", function ()
        {
            notify("You succesfully buy a " + guitar_name, "success");
        });
    });
    
    // form handling
    $("form").submit(function(event)
    {
        event.preventDefault();// do not reload page on submit
        
        // checking
        if (!$(this).find("#lead_name").val().trim()) // name is empty
        {
            notify("Please, write your name", "danger");
            return false;
        }
        
        let email = $(this).find("#lead_email").val().trim().toLowerCase();
        if (!email)// email is empty
        {
            notify("Please, write your email", "danger");
            return false;
        }
        if (!isEmail(email)) // email is wrong
        {
            notify("Please, write correct email", "danger");
            return false;
        }
        
        if (!$(this).find("#lead_text").val().trim()) // message is empty
        {
            notify("Please, write your message", "danger");
            return false;
        }
        
        // everything is okay
        this.reset(); // clear form
        notify("Your message has been successfully sent", "info");
        return true;         
    });
});
