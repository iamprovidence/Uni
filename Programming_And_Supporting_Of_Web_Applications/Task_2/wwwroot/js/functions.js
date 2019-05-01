// NOTIFICATION
// type = bootstrap clases (success, info, warning, danger, dark...)
function notify({ message, type } = {})
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
            z_index: 2048,
            animate: 
            {
                enter: "animated fadeInDown",
                exit:  "animated fadeOutLeft"
            }
        }
    );
}

function disable_row(row)
{
    $(row).find("button, select").prop('disabled', true);
    $(row).addClass("disabled text-muted");
}

// FILE UPLOAD
const DEFAULT_USER_IMAGE = '/uploads/images/users/no_image.jpg';
const DEFAULT_PRODUCT_IMAGE = '/uploads/images/users/no_image.jpg';

function preview_image({ file_input_id, image_preview_id } = {}) 
{
    var file = document.getElementById(file_input_id).files[0];
    if (file === undefined) return;
    
    var fileReader = new FileReader();
    fileReader.readAsDataURL(file);

    fileReader.onload = function (fileReaderEvent)
    {
        document.getElementById(image_preview_id).src = fileReaderEvent.target.result;
    };
};

function change_image({ image_selector_id, image_path } = {})
{
    document.getElementById(image_selector_id).src = image_path;
}
function swap_image({ first_image_selector_id, second_image_selector_id } = {})
{
    var temp = document.getElementById(first_image_selector_id).src;    
    document.getElementById(first_image_selector_id).src = document.getElementById(second_image_selector_id).src;
    document.getElementById(second_image_selector_id).src = temp;
}

// SETS MARK
function set_mark(stars_wrapper, amount)
{
    for (var i = 0; i < stars_wrapper.children().size(); ++i) 
    {
        if (i <= amount) 
        {
            stars_wrapper.find('i').eq(i).removeClass('far').addClass('fa');
        } 
        else 
        {
            stars_wrapper.find('i').eq(i).removeClass('fa').addClass('far');
        }
    }
}

// GO BACK
function go_back_in_history()
{
    window.location = document.referrer;
}