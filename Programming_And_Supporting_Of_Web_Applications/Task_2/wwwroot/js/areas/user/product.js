function load_comment_view()
{
    $.pjax(
    {
        type: 'POST',
        url: '/comment/view/',
        container: '#comments',
        fragment: '#comments',
        push: false,
        scrollTo: false,
        data: 
        {
            submit: true,
            product_id: $("#nav-comments-tab").data('product-id'),
        },
    });  
}

// load comments on click
$("#nav-comments-tab").click(load_comment_view);
        
// update mark on user clcik        
$('.your-mark span').on("click", "i", function (event) 
{
    const stars_wrapper = $(this).closest("span");
    const clicked_index = $(this).index();         
    
    // send post
    $.post("/rating/add/", 
    {
        user_mark:      clicked_index + 1,
        product_id:     $("#add-product").data('id'),
        submit:         true,
    },
    function(operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        if (operationStatus.isOperationSucceeded) 
        {
            // set user mark
            set_mark(stars_wrapper, clicked_index);
            
            // update average mark
            set_mark($('.average-mark span'), operationStatus.data.newMark-1);
            
            notify({message: operationStatus.message, type: "info"});
        }
        else
        {
            notify({message: operationStatus.message, type: "danger"});
        }
    });
});