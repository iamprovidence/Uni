$(document).ready(function() 
{
    // product list
    $(".cart-btn").click(function (event)
    {
        // do not reaload page
        event.preventDefault();

        // add to cart   
        add_product_to_cart($(this).data('id'), 1);
        update_cart_amount();
    });
    
    // single product form
    $("#add-product").submit(function (event)
    {
        // do not reaload page
        event.preventDefault();

        // add to cart   
        add_product_to_cart($(this).data('id'), $('#product-buy-amount').val());
        update_cart_amount();
    });
    
    $("#cart-btn").click(load_cart_view);

});

function load_cart_view()
{
    $.pjax({
            type: 'POST',
            url: '/cart/view/',
            container: '#modal-cart-body',
            fragment: '#modal-cart-body',
            push: false,
            data: { submit: true },
        }).done(bind_rows_action);  
}

function bind_rows_action()
{
    // delete button pressed
    $("#shopping-cart .x-remove").click(function (event)
    {
        event.preventDefault();

        delete_product_in_cart($(this).data('id'));
        load_cart_view();
        update_cart_amount();      
    });
}        

function add_product_to_cart(product_id, product_amount)
{            
    $.post('/cart/add/', 
    {
        submit:         true,
        product_id:     product_id,
        product_amount: product_amount
    },
    function (operationStatus)
    {
        operationStatus = JSON.parse(operationStatus);

        notify({message: operationStatus.message, 
               type:     operationStatus.isOperationSucceeded ? 'info' : 'danger'});
    });
}

function update_cart_amount()
{
    $.post('/cart/amount/', 
    {
        submit: true,
    },
    function (productAmount)
    {
        $('#cart-amount').text(productAmount)
    });
}

function delete_product_in_cart(product_id) 
{
    $.post("/cart/delete/", 
    {
        submit: true,
        product_id: product_id,
    });          
}