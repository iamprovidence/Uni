    <section id="shop">
        <div class="container">
            <div class="row">

               <!--filter-->
                <div class="col-sm-4 col-md-3 filter">


                    <h4>Filter</h4>
                    <!--price-->
                    <!--
                    <div>
                       <h5 >Price</h5>
                       <p class="info-text">from</p>
                        <input class="form-control" type="number" min="0" step="10"/>
                        <br/>
                       <p class="info-text">to</p>
                        <input class="form-control" type="number" min="0" step="10"/>

                    </div>-->

                    <!--brands-->
                    <div class="brands">
                        <h5>Brands</h5>
                        
                        <?php foreach ($brands as $brand): ?>

                        <p>
                            <a href="/shop/brand/<?=$brand->id?>/" data-id="<?=$brand->id?>" <?php if ($brand->id == $brand_id) echo "class='active'" ?>><?=$brand->name?></a>
                            <span class="float-right">(<?=$brand->amount?>)</span>
                        </p>
                        
                        <?php endforeach; ?>
                        
                    </div>
                    <!--categories-->
                    <div>
                        <h5>Categories</h5>
                        
                        
                        <?php foreach ($categories as $category): ?>

                        <p>
                            <a href="/shop/category/<?=$category->id?>/" <?php if ($category->id == $category_id) echo "class='active'" ?>><?=$category->name?></a>
                            <span class="float-right">(<?=$category->amount?>)</span>
                        </p>
                        
                        <?php endforeach; ?>

                    </div>

                </div>

               <!--products-->
                <div class="col-sm-8 col-md-9">
                    <p>Showing <strong><?=$start_product_number?>-<?=$end_product_number?></strong> of <strong><?= $total?></strong> items. 
                        <span class="float-right">
                            <select class="form-control">
                                <optgroup label="Sort By:">
                                    <option data-id="0" <?php if ($order_id == 0) echo 'selected';?>>Default</option>
                                    <option data-id="1" <?php if ($order_id == 1) echo 'selected';?>>Newness</option>
                                    <option data-id="2" <?php if ($order_id == 2) echo 'selected';?>>Price Low to High</option>
                                    <option data-id="3" <?php if ($order_id == 3) echo 'selected';?>>Price High to Low</option>
                                </optgroup>
                            </select>
                        </span>
                    </p>
                    <ul class="row shop list-unstyled" id="grid">


                        <?php foreach ($products_shop as $product): ?>

                        <li class="col-xs-6 col-md-6 product m-product">
                            <div class="img-bg-color primary">

                                <!--price, is new-->
                                <span>
                                    <h5 class="product-badge product-price">$<?= $product->price?></h5>
                                    
                                    <?php if ($product->is_new): ?>

                                    <h5 class="product-badge product-new">new</h5>                            
                                    <?php endif;?>

                                </span>

                                <a href="/product/<?= $product->id?>/" class="product-link">
                                    <img src="<?= $this->GetModel(Models::Product)->GetImage($product->id)?>" alt="<?= $product->name?>">

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

        <!--PAGINATION-->
        <?php echo $pagination->get(); ?>     


                </div>

            </div>
        </div>
    </section>