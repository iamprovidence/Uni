
    <div class="modal fade" id="cart-modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <!--content-->
            <div class="modal-content">
              
               <!--header-->
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Cart</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <!--body-->
                <div class="modal-body" id="modal-cart-body">


                    <div id="shopping-cart">
                        <!-- shopping cart container -->
                        <div class="container">
                                    
                            <?php if (isset($products)): ?>
                                    
                            <table class="shopping-cart">
                                <thead>
                                    <tr>
                                        <th class="image">&nbsp;</th>
                                        <th>Product</th>
                                        <th>Price</th>
                                        <th>Quantity</th>
                                        <th>Total</th>
                                        <th>&nbsp;</th>
                                    </tr>
                                </thead>
                                
                                <!--cart item-->
                                <tbody>
                                    <?php foreach ($products as $product): ?>
                                   
                                    <tr class="cart-item">
                                        <td class="image">
                                            <a href="/product/<?=$product->id?>/"><img src="<?= $this->GetModel(Models::Product)->GetImage($product->id)?>" alt="<?=$product->name?> image"></a>
                                        </td>
                                        <td>
                                            <a href="/product/<?=$product->id?>/"><?=$product->name?></a>
                                        </td>
                                        <td>$<?=$product->price?></td>
                                        <td>
                                            <?=$products_in_cart[$product->id]?>
                                        </td>
                                        <td>$<?=$products_in_cart[$product->id]*$product->price?></td>
                                        <td class="remove">
                                            <a href="#" class="btn btn-danger-filled x-remove" data-id="<?=$product->id?>">×</a>
                                        </td>
                                    </tr>
                                    
                                    <?php endforeach; ?>
                                    
                                </tbody>
                                 
                                <tfoot>
                                    <tr>
                                        <td colspan="4"><b>Total price</b></td>
                                        <td><?=$total_price?>$</td>
                                        <td></td>
                                    </tr>
                                </tfoot>
                            </table>
                                   
                            <?php else: ?>
                            <p>Cart is empty</p>
                            <?php endif;?>

                        </div>
                        
                    </div>

                    <!--footer-->
                    <div class="modal-footer">

                        <?php if (!$this->GetModel(Models::Cart)->IsEmpty()): ?>
                        <a href="/checkout/" class="btn btn-primary">Proceed to Checkout</a>
                        <?php endif; ?>

                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Continue Shopping</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    