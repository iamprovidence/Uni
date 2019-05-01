
    <header>
        <!--NAVIGATION MENU-->
        <nav id="menu" class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <a class="navbar-brand" href="/">
                    <img src="/wwwroot/images/logo/payknife.png" alt="Payknife logo image"/>
                </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#menu-navbar" aria-controls="menu-navbar" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-center" id="menu-navbar">
                    
                    <!--menu content-->                    
                    <?php echo $this->GetMenuComponent(MenuGeneratorType::ForUser)->get() ?>

                    <span class="navbar-ico">                       
                       
                        <?php if ($this->GetModel(Models::User)->Is(Role::Administrator)): ?>
                        <a href="/administrator/"><i class="fas fa-user-tie"></i></a>                       
                        <?php endif; ?>
                        
                        <?php if ($this->GetModel(Models::User)->Is(Role::Moderator) || $this->GetModel(Models::User)->Is(Role::Administrator)): ?>
                        <a href="/moderator/"><i class="fa fa-user-cog"></i></a>
                        <?php endif; ?>
                        
                        <?php if ($this->GetModel(Models::User)->IsLogged()): ?>
                        <a href="/cabinet/"><i class="fa fa-user"></i></a>
                        <?php endif; ?>
                        
                        <a href="#" id="cart-btn" data-toggle="modal" data-target="#cart-modal"><i class="fa fa-shopping-cart"></i> <span id="cart-amount"><?=$this->GetModel(Models::Cart)->CountItems()?></span></a>
                        
                        <?php if (!$this->GetModel(Models::User)->IsLogged()): ?>
                        <a href="#" data-toggle="modal" data-target="#loginModal"><i class="fas fa-sign-in-alt"></i></a>
                        <?php endif; ?>
                        
                        <?php if ($this->GetModel(Models::User)->IsLogged()): ?>                        
                        <a href="/logout/"><i class="fas fa-sign-out-alt"></i></a>                        
                        <?php endif; ?>
                        
                    </span>
                    
                </div>
            </div>
        </nav>
    
        <!--HEADER BANNER-->
        <div id="header-banner">
            <div class="banner-content<? if (isset($isLanding) && $isLanding) echo '-landing'; ?> text-center">
                <div class="banner-border">
                    <div class="banner-info">
                        <h1 class="text-uppercase"><?=$title?></h1>
                        <p>worrying on life, better mess with payknife</p>
                    </div>
                </div>
            </div>
        </div>
        
   </header>