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
            Order №<span><?=$order_info->id?></span>
        </h3>
        
        <form>
           
            <h5>Order info</h5>
            <div class="form-group">
                <label for="input-user-emai">User email</label>
                <input type="text" class="form-control" id="input-user-email" value="<?=$order_info->user_email?>" disabled/>
            </div>    
            <div class="form-group">
                <label for="input-user-address">User address</label>
                <input type="text" class="form-control" id="input-user-address" value="<?=$order_info->user_address?>" disabled/>
            </div>    
            <div class="form-group">
                <label for="input-order-status">Order status</label>
                <select class="form-control" id="input-order-status" <?php if ($is_disabled) echo 'disabled';?>>
                   
                    <?php foreach (OrderStatus::GetArray() as $order_status): ?>
                        <option data-status="<?=$order_status?>" <?php if ($order_status == $order_info->status) echo 'selected';?>><?=OrderStatus::GetStatusText($order_status)?></option>
                    <?php endforeach; ?>
                    
                </select>
            </div>          
            
            <div class="form-group">
                <label for="input-user-date">Order date</label>
                <input type="text" class="form-control" id="input-user-date" value="<?=$order_info->date?>" disabled/>
            </div>  
            <div class="form-group">
                <label for="input-user-message">User message</label>
                <textarea class="form-control" id="input-user-message" disabled><?=$order_info->user_message?></textarea>
            </div>    
            
            
            <hr/>
            <h5>Product info</h5>
            
            <table class="w-100 mb-5">
                <thead>
                    <tr>
                        <th>Image</th>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Total</th>
                    </tr>
                </thead>

                <!--cart item-->
                <tbody>

                    <?php foreach ($product_order as $product): ?>

                    <tr class="cart-item">
                        <td class="image">
                            <img src="<?= $this->GetModel(Models::Product)->GetImage($product->id)?>" alt="<?=$product->name?> image">
                        </td>
                        <td><?=$product->name?></td>
                        <td><?=$product->price?>$</td>
                        <td><?=$product->product_count?></td>
                        <td><?=$product->current_price?>$</td>
                    </tr>
                    
                    <?php endforeach; ?>
                    

                </tbody>

                <tfoot>
                    <tr>
                        <td colspan="4"><b>Total price</b></td>
                        <td><?=$total_sum?>$</td>
                    </tr>
                </tfoot>
            </table>
            
        </form>
        
        <!--BUTTONS-->
        <div class="row">
            <div class="col">
                <button type="button" class="btn btn-secondary btn-go-back w-100">Go back</button>
            </div>
            <div class="col" <?php if ($is_disabled) echo "style='display:none;'" ?>>
                <button data-id="<?=$order_info->id?>" type="button" class="btn btn-success btn-update w-100">Update</button>
            </div>
        </div>
    </div>
    
    <!--SCRIPTS-->
    <?php include_once (ROOT ."/view/moderator/layout/scripts.php"); ?>  
    <script>
    function bind_updating()
    {
         // update
         $('.btn-update').click(function()
        {
            $.post("/moderator/orders/update/", 
            {
                order_id: $(this).data('id'),
                order_new_status: $("#input-order-status").children("option:selected").data("status"),
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
    }
    </script>

</body>
</html>