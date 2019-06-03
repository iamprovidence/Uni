<!DOCTYPE html>
<html lang="en">
<head>
    <?php include_once (ROOT ."/view/user/layout/head.php"); ?>       
</head>
<body>
   
    <!--HEADER-->
    <?php include_once (ROOT ."/view/user/layout/header.php"); ?>   
      
    <!--CART MODAL-->
    <?php include_once (ROOT ."/view/user/layout/cart-modal.php"); ?>   
    
    <!--AUTHENTICATION MODAL-->
    <?php include_once (ROOT ."/view/user/layout/authentication-modal.php"); ?>
   
    <!--CONTENT-->
    <!-- single product -->
    <section id="shop">
        <div class="container">
            <div class="row">

                <!-- product left panel -->
                <div class="col-sm-6 col-md-5 product-sidebar">

                   <!--tabs button-->
                    <nav>
                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                            <a class="nav-item nav-link active" id="nav-info-tab" data-toggle="tab" href="#nav-info" role="tab" aria-controls="nav-info" aria-selected="true">Information</a>
                            <a class="nav-item nav-link" id="nav-comments-tab" data-toggle="tab" data-product-id="<?=$selected_product->id?>" href="#nav-comments" role="tab" aria-controls="nav-comments" aria-selected="false">Comments</a>
                        </div>
                    </nav>
                    
                    <!--tabs-->
                    <div class="tab-content" id="nav-tabContent">
                        <!--info tab-->
                        <div class="tab-pane fade show active" id="nav-info" role="tabpanel" aria-labelledby="nav-info-tab">

                            <div class="product-sidebar-details">
                                <h4><?=$selected_product->name?></h4>
                                <p><?=$selected_product->description?></p>
                                
                                <!--product info-->
                                <div class="product-info">
                                    <div class="info">
                                        <p><i class="lnr lnr-tag"></i><span>Price: $<?=$selected_product->price?></span></p>
                                    </div>
                                    <div class="info">
                                        <p><i class="lnr lnr-menu"></i><span>Category: <a href="<?= $category ? "/shop/category/$category->id/" : '#'?>"><?= $category ? $category->name : 'category is missed'?></a></span></p>
                                    </div>
                                    <div class="info">
                                        <p><i class="lnr lnr-heart"></i><span>Brand: <a href="<?= $brand ? "/shop/brand/$brand->id/" : '#'?>"><?= $brand ? $brand->name : 'brand is missed'?></a></span></p>
                                    </div>
                                    
                                    <?php if ($selected_product->is_new): ?>
                                    
                                    <div class="info">
                                        <p><i class="lnr lnr-magic-wand"></i><span>Is new</span></p>
                                    </div>
                                    
                                    <?php endif; ?>
                                    
                                    <div class="info average-mark">
                                    <p>
                                        <i class="lnr lnr-star"></i>
                                        Mark:
                                        <span>                                            
                                            <?php 
                                            for($i = 0; $i < 5; ++$i)
                                            {
                                                if ($i < $current_mark) 
                                                {
                                                    echo "<i class='fa fa-star'></i>";
                                                }
                                                else 
                                                {
                                                    echo "<i class='far fa-star'></i>";      
                                                }
                                            }                                            
                                            ?>
                                            
                                        </span>
                                    </p>
                                    </div>
                                    
                                    <?php if (isset($is_rating_available) && $is_rating_available): ?>
                                    
                                    <div class="info your-mark">
                                    <p>
                                        <i class="lnr lnr-star"></i>
                                        Your mark: 
                                        <span>                                                                            
                                            <?php 
                                            for($i = 0; $i < 5; ++$i)
                                            {
                                                if ($i < $user_mark) 
                                                {
                                                    echo "<i class='fa fa-star'></i>";
                                                }
                                                else 
                                                {
                                                    echo "<i class='far fa-star'></i>";      
                                                }
                                            }                                            
                                            ?>
                                            
                                        </span>
                                    </p>
                                    </div>
                                    
                                    <?php endif; ?>
                                    
                                </div>

                                <!--buy product-->
                                <div class="buy-product">
                                   
                                    <form id="add-product" data-id="<?=$selected_product->id?>">
                                        <div class="form-group row">
                                            <label for="product-buy-amount" class="col-sm-2 col-form-label">Amount:</label>
                                            <div class="col-sm-10">
                                                <input type="number" step="1" min="1" value="1" class="form-control" id="product-buy-amount"/>
                                            </div>
                                        </div>                                        
                                        
                                        <button class="btn" type="submit"><i class="lnr lnr-cart"></i><span> Add to Cart</span></button>
                                    </form>     
                                    
                                </div>
                            </div>
                        </div>
                        
                        <!--comment tab-->
                        <div class="tab-pane fade" id="nav-comments" role="tabpanel" aria-labelledby="nav-comments-tab">
                            
                            <?php include_once (ROOT ."/view/user/layout/comments.php"); ?>
                       
                        </div>
                    </div>

                </div>
                

                <!--image-->
                <div class="col-sm-6 col-md-7 product-content-area">
                    <img src="<?= $this->GetModel(Models::Product)->GetImage($selected_product->id)?>" alt="Product image"/>
                </div>

            </div>
        </div>
    </section> 
  
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?>
      
    <!--SCRIPT-->
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    <script src="/wwwroot/js/areas/user/product.js"></script>
</body>
</html>
