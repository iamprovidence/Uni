
    <footer class="light-footer">
        <div class="widget-area">
            <div class="container">
                <div class="row">

                   <!--info-->
                    <div class="col-lg-4">
                        <p>Vivamus consequat lacus quam, nec egestas quam egestas sit amet. Suspendisse et risus gravida tellus aliquam ullamcorper. Pellentesque elit dolor, ornare ut lorem nec, convallis nibh accumsan lacus morbi leo lipsum.</p>
                    </div>

                    <!--brands-->
                    <div class="col-md-2">
                        <div class="widget-title">
                            <h4 class="text-uppercase">BRANDS</h4>
                        </div>
                        <div class="link-widget">
                            
                            <?php foreach ($this->GetRepository(Models::Brand)->GetBestBrands(3) as $brand): ?>
                            
                            <div class="info">
                                <a href="/shop/brand/<?=$brand->id?>/"><?=$brand->name?></a>
                            </div>
                            
                            <?php endforeach; ?>
                            
                        </div>
                    </div>

                    <!--support-->
                    <div class="col-md-2">
                        <div class="widget-title">
                            <h4 class="text-uppercase">SUPPORT</h4>
                        </div>

                        <div class="link-widget">
                            <div class="info">
                                <a href="/about/">About</a>
                            </div>
                            <div class="info">
                                <a href="/contact/">Contact</a>
                            </div>
                            <div class="info">
                                <a href="/privacy/">Privacy</a>
                            </div>
                        </div>
                    </div>

                    <!--contact-->
                    <div class="col-md-4 ">
                        <div class="widget-title">
                            <h4 class="text-uppercase">CONTACT</h4>
                        </div>

                        <div class="contact-widget">
                            <div class="info">
                                <p><i class="lnr lnr-map-marker"></i><span>Orleon nilkford, 23g, 42L</span></p>
                            </div>
                            <div class="info">
                                <a href="tel:+0123456789"><i class="lnr lnr-phone-handset"></i><span>+0123 456 789</span></a>
                            </div>
                            <div class="info">
                                <a href="mailto:hello@world.com"><i class="lnr lnr-envelope"></i><span>payknife@mail.com</span></a>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>

        <!--bottom info-->
        <div class="footer-info">
            <div class="container">
                <div class="pull-left copyright">
                    <p><strong>© GL - Payknife</strong></p>
                </div>
            </div>
        </div>
    </footer>