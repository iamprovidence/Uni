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
   
    <!-- FEATURES -->
    <section id="features">
        <div class="container">
            <div class="row">
                <div class="col-md-4 feature-center">
                    <div class="feature block">
                        <div class="feature-icon">
                            <i class="lnr lnr-gift"></i>
                        </div>
                        <h5 class="text-uppercase">FREE SHIPPING</h5>
                        <p>Free worldwide shipping</p>
                    </div>
                </div>

                <div class="col-md-4 feature-center">
                    <div class="feature block">
                        <div class="feature-icon">
                            <i class="lnr lnr-clock"></i>
                        </div>
                        <h5 class="text-uppercase">FAST DELIVERY</h5>
                        <p>Fast worldwide delivery</p>
                    </div>
                </div>

                <div class="col-md-4 feature-center">
                    <div class="feature block">
                        <div class="feature-icon">
                            <i class="lnr lnr-exit"></i>
                        </div>
                        <h5 class="text-uppercase">MONEY BACK</h5>
                        <p>30 Days money back</p>
                    </div>
                </div>

            </div>
        </div>
    </section>
 
    <!-- TOP PRODUCTS -->
    <section id="shop">
        <div class="container">
            <div class="page-header no-margin-top text-center">
                <h3 class="text-uppercase">BEST PRODUCTS</h3>
            </div>
            
            <!--products list-->
            <ul class="row shop list-unstyled" id="grid">
                <?php foreach ($best_products as $product): ?>

                <li class="col-xs-6 col-md-4 product m-product">
                    <div class="img-bg-color primary">
                        
                        <!--price, is new-->
                        <span>
                            <h5 class="product-badge product-price">$<?= $product->price?></h5>
                            <?php if ($product->is_new): ?>
                            
                            <h5 class="product-badge product-new">new</h5>                            
                            <?php endif;?>
                            
                        </span>
                        
                        <a href="/product/<?= $product->id?>/" class="product-link">
                            <img src="<?= $this->GetModel(Models::Product)->GetImage($product->id) ?>" alt="<?= $product->name?>">

                            <!-- hover -->
                            <div class="product-hover-tools">
                                <a href="/product/<?= $product->id?>/" class="view-btn" data-toggle="tooltip" title="View Product">
                                <i class="lnr lnr-eye"></i>
                                </a>
                                <a href="#" data-id="<?= $product->id?>" class="cart-btn" data-toggle="tooltip" title="Add to Cart">
                                <i class="lnr lnr-cart"></i>
                                </a>
                            </div>

                            <!-- details -->
                            <div class="product-details">
                                <h5 class="product-title text-uppercase"><?=$product->name?></h5>
                                <p class="product-brands text-uppercase"><?=$product->brand_name?></p>
                            </div>
                        </a>
                    </div>
                </li>

                <?php endforeach; ?>
                
            </ul>
        </div>

    </section>    
  
  
    <!-- BRANDS CAROUSEL -->
    <section id="brands" class="dark primary-background">
        <div class="container">
            <div id="brands-carousel" class="owl-carousel">
                <div class="item"><img src="/wwwroot/images/brands/brand_1.png" alt="Brand №1"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_2.png" alt="Brand №2"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_3.png" alt="Brand №3"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_4.png" alt="Brand №4"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_5.png" alt="Brand №5"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_6.png" alt="Brand №6"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_7.png" alt="Brand №7"></div>
                <div class="item"><img src="/wwwroot/images/brands/brand_8.png" alt="Brand №8"></div>
            </div> 
        </div>
    </section>
  
  
    <!-- FOOTER -->
    <?php include_once (ROOT ."/view/user/layout/footer.php"); ?> 

    <!--SCRIPTS-->    
    <?php include_once (ROOT ."/view/user/layout/scripts.php"); ?> 
    
    <!-- BRAND CAROUSEL -->
    <script src="/wwwroot/lib/owl_carousel/owl.carousel.min.js"></script>
    <script>
    $(document).ready(function() 
    {
        $("#brands-carousel").owlCarousel(
        {
            autoPlay: 5000, // set autoPlay to 5 seconds.
            items : 5,
            itemsDesktop : [1199,3],
            itemsDesktopSmall : [979,3]
        });
    });
    </script>
</body>
</html>