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
      
        <!--ORDERS-->
        <h3>Orders</h3>
        <div id="table-data" >
            <table class="table table-striped">

                <thead>
                    <tr>
                        <th scope="col">№</th>
                        <th scope="col">User email</th>
                        <th scope="col">Total price</th>
                        <th scope="col">Date</th>
                        <th scope="col">Status</th>
                        <th scope="col" class="text-center">Read</th>
                        <th scope="col" class="text-center">Update</th>
                    </tr>
                </thead>

                <tbody>
                    <?php foreach ($orders as $order): ?>
                    
                    <tr>
                        <th scope="row">
                            <?=$order->id?>

                        </th>
                        <td>
                            <?=$order->user_email?>

                        </td>                   
                        <td>
                            <?=$order->total_price?>$                            
                        </td>                      
                        <td>
                            <?=$order->date?>

                        </td>                  
                        <td>
                            <?=OrderStatus::GetStatusText($order->status)?>
                            
                        </td>
                        
                        <td class="w-50-px">
                            <a href="/moderator/orders/read/<?=$order->id?>/" class="btn btn-warning">Read</a>
                        </td>
                        <td class="w-50-px">
                            <a href="/moderator/orders/update/<?=$order->id?>/" class="btn btn-success btn-update">Update</a>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                    
                </tbody>
            </table>
        </div>
        
        <!--PAGINATION-->
        <?php echo $pagination->get(); ?>

    </div>
    

</body>
</html>