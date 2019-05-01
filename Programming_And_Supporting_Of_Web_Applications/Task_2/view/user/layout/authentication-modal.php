
   
    <?php if (!$this->GetModel(Models::User)->IsLogged()): ?>
   
    <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabelLI" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
            <div class="modal-content">
                <!--HEADER-->
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabelLI">Authentication</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                
                <!--BODY-->
                <div class="modal-body">
                    
                    <!--NAVIGATION-->
                    <nav>
                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                            <a class="nav-item nav-link active" id="nav-log-in-tab" data-toggle="tab" href="#nav-log-in" role="tab" aria-controls="nav-log-in" aria-selected="true">Log in</a>
                            <a class="nav-item nav-link" id="nav-sign-up-tab" data-toggle="tab" href="#nav-sign-up" role="tab" aria-controls="nav-sign-up" aria-selected="false">Sign up</a>
                        </div>
                    </nav>
                    
                    <!--TABS-->
                    <div class="tab-content" id="nav-tabContent">

                        <!--LOG IN TAB-->
                        <div class="tab-pane fade show active" id="nav-log-in" role="tabpanel" aria-labelledby="nav-log-in-tab">

                            <section class="container bg-white">

                                <form id="log-in-form" method="post">

                                    <h3>Log in</h3>
                                    <div class="form-group">
                                        <label for="log-in-email">Email</label>
                                        <input type="email" class="form-control" id="log-in-email" required>
                                    </div>

                                    <div class="form-group">
                                        <label for="log-in-password">Password</label>
                                        <input type="password" class="form-control" id="log-in-password" required>
                                    </div>
                                    
                                    <button type="submit" class="btn text-uppercase">SUBMIT FORM</button>                                                                
                                   
                                    <a href="<?=$this->GetGoogleClient()->createAuthUrl()?>" class="google btn">
                                        <i class="fab fa-google"></i> Login with Google
                                    </a>

                                </form>
                            </section>

                        </div>
                        
                        <!--SIGN UP TAB-->
                        <div class="tab-pane fade" id="nav-sign-up" role="tabpanel" aria-labelledby="nav-sign-up-tab">

                            <section class="container bg-white">

                                <form id="sign-up-form" method="post">

                                    <h3>Sign up</h3>
                                    <div class="form-group">
                                        <label for="sign-up-nickname">Nickname</label>
                                        <input type="text" class="form-control" id="sign-up-nickname" required>
                                    </div>

                                    <div class="form-group">
                                        <label for="sign-up-email">Email</label>
                                        <input type="email" class="form-control" id="sign-up-email" required>
                                    </div>

                                    <div class="form-group">
                                        <label for="sign-up-password">Password</label>
                                        <input type="password" class="form-control" id="sign-up-password" required>
                                    </div>

                                    <div class="form-group">
                                        <label for="sign-up-confirm-password">Confirm Password</label>
                                        <input type="password" class="form-control" id="sign-up-confirm-password" required>
                                    </div>

                                    <button type="submit" class="btn text-uppercase">SUBMIT FORM</button>

                                </form>
                            </section>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
    
    <?php endif; ?>
    