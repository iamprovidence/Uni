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
            <?=$view->title?>
            
        </h3>
        
        <form>
           <!--main info-->
            <div class="form-group">
                <label for="input-product-name"><?$product->name?></label>
                <input <?php if ($view->is_input_disabled) echo 'disabled'; ?> type="text" class="form-control" id="input-product-name" placeholder="product name" value="<?=$product->name?>"/>
            </div>            
            <!--photo-->
            <div class="form-group">
                <label for="input-photo">Photo</label>
                <br/>
                <img src="<?= $this->GetModel(Models::Product)->GetImage(isset($product->id) ? $product->id : -1)?>" alt="Product img" width="150" height="150"/>
                <img id="selected-img" src="<?= $this->GetModel(Models::Product)->GetImage(-1)?>" alt="Sleected product img" width="150" height="150" <?php if ($view->is_input_disabled) echo "style='display:none';"; ?>/>
                <input <?php if ($view->is_input_disabled) echo "disabled style='display:none';"; ?> type="file" class="form-control-file" id="input-photo" accept="image/*"/>
                <label <?php if ($view->is_input_disabled) echo "style='display:none';"; ?>><input <?php if ($view->is_input_disabled) echo "disabled style='display:none';"; ?> type="checkbox" id="reset-image">Do you want to reset avatar?</label>                
            </div>
            <div class="form-group">
                <label for="input-price">Price</label>
                <input <?php if ($view->is_input_disabled) echo 'disabled'; ?> type="number" min="1" step="any" class="form-control" id="input-price" value="<?=$product->price?>" />
            </div>
            
            <!--checkbox statuses-->
            <hr/>
            <div class="form-group">
                <label for="checkbox-available">Availability status</label>
                <input <?php if ($view->is_input_disabled) echo 'disabled'; ?> class="form-control" type="checkbox" id="checkbox-available" <?php if ($product->is_available) echo 'checked'?>  />
            </div>
            <div class="form-group">
                <label for="checkbox-is-new">Is new</label>
                <input <?php if ($view->is_input_disabled) echo 'disabled'; ?> class="form-control" type="checkbox" id="checkbox-is-new" <?php if ($product->is_new) echo 'checked'?>/>
            </div>
            <div class="form-group">
                <label for="checkbox-is-comment-available">Is comment available</label>
                <input <?php if ($view->is_input_disabled) echo 'disabled'; ?> class="form-control" type="checkbox" id="checkbox-is-comment-available" <?php if ($product->is_comments_available) echo 'checked'?>/>
            </div>
            
            <!--brand and category-->
            <hr/>
            <div class="form-group">
                <label for="combo-box-brand">Brand</label>
                <select <?php if ($view->is_input_disabled) echo 'disabled'; ?> class="form-control" id="combo-box-brand">
                   
                    <?php foreach ($brands as $brand): ?>
                    <option data-id="<?=$brand->id?>" <?php if ($brand->id == $product->brand_id) echo 'selected'?>><?=$brand->name?></option>
                    <?php endforeach; ?>
                    
                </select>
            </div>
            <div class="form-group">
                <label for="combo-box-category">Category</label>
                <select <?php if ($view->is_input_disabled) echo 'disabled'; ?> class="form-control" id="combo-box-category">
                   
                    <?php foreach ($categories as $category): ?>
                    <option data-id="<?=$category->id?>" <?php if ($category->id == $product->category_id) echo 'selected'?> ><?=$category->name?></option>
                    <?php endforeach; ?>
                    
                </select>
            </div>
            
            <!--description-->
            <hr/>
            <div class="form-group">
                <label for="textarea-description">Description</label>
                <textarea <?php if ($view->is_input_disabled) echo 'disabled'; ?> id="textarea-description" class="form-control"><?=$product->description?></textarea>
            </div>
        </form>
        
        <!--BUTTONS-->
        <div class="row">
            <div class="col">
                <button type="button" class="btn btn-secondary btn-go-back w-100">Go back</button>
            </div>
            <div class="col">
                <button data-id="<?= isset($product->id) ? $product->id : -1?>" type="button" class="btn <?=$view->button_css_class?> w-100"><?=$view->button_text?></button>
            </div>
        </div>
    </div>
    
      
    <!--SCRIPTS-->
    <?php include_once (ROOT ."/view/moderator/layout/scripts.php"); ?>  
    <script>
    document.getElementById("input-photo").onchange = function()
    {
        preview_image
        ({ 
            file_input_id: 'input-photo', 
            image_preview_id: 'selected-img', 
        });
    };
            
    // delete
    function bind_deleting()
    {
        $(".btn-danger").click(function()
        {
            const entity_id = $(this).data("id");
            
            notie.confirm(
            {
                text: 'Are you sure?',
                submitCallback: function()
                {        
                    // confirm deleting                
                    $.post("/moderator/products/delete/",
                    {
                        entity_id:  entity_id,
                        submit:     true
                    },
                    function(operationStatus)
                    {
                        operationStatus = JSON.parse(operationStatus);

                        if (operationStatus.isOperationSucceeded)
                        {
                            go_back_in_history()
                        }
                        else
                        {
                            notie.alert(
                            {
                                type: "error", 
                                text: operationStatus.message
                            }); 
                        }
                    });
                }
            });
        });
    }
            
    // update
    function bind_updating()
    {
        $(".btn-success").click(function ()
        {        
            // gather data
            var formData = new FormData();
            formData.append('product_id', $(".btn-success").data('id'));
            formData.append('product_name', $("#input-product-name").val());                
            formData.append('product_price', $("#input-price").val());
            formData.append('product_description', $("#textarea-description").val());           
            formData.append('is_product_available', $("#checkbox-available").is(":checked"));
            formData.append('is_product_new', $("#checkbox-is-new").is(":checked"));
            formData.append('is_comments_available', $("#checkbox-is-comment-available").is(":checked"));
            formData.append('brand_id', $("#combo-box-brand").children("option:selected").data("id"));
            formData.append('category_id', $("#combo-box-category").children("option:selected").data("id"));   
            formData.append('product_img', $('#input-photo')[0].files[0]);
            formData.append('do_reset_image', $('#reset-image').is(':checked'))
            formData.append('submit', true);
            
            // send post
            $.ajax({
                url: "/moderator/products/update/",
                type: "POST",
                data: formData,
                processData: false,
                contentType: false
            })
            .always(function (operationStatus)
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
    // create
    function bind_creating()
    {
        $(".btn-info").click(function()
        {
            // gather data
            var formData = new FormData();
            formData.append('product_name', $("#input-product-name").val());                
            formData.append('product_price', $("#input-price").val());
            formData.append('product_description', $("#textarea-description").val());           
            formData.append('is_product_available', $("#checkbox-available").is(":checked"));
            formData.append('is_product_new', $("#checkbox-is-new").is(":checked"));
            formData.append('is_comments_available', $("#checkbox-is-comment-available").is(":checked"));
            formData.append('brand_id', $("#combo-box-brand").children("option:selected").data("id"));
            formData.append('category_id', $("#combo-box-category").children("option:selected").data("id"));   
            formData.append('product_img', $('#input-photo')[0].files[0]);
            formData.append('do_reset_image', $('#reset-image').is(':checked'))
            formData.append('submit', true);
            
            // send post
            $.ajax({
                url: "/moderator/products/add/",
                type: "POST",
                data: formData,
                processData: false,
                contentType: false
            })
            .always(function (operationStatus)
            {
                operationStatus = JSON.parse(operationStatus);
                
                if (operationStatus.isOperationSucceeded) 
                {
                    go_back_in_history()
                }
                else
                {
                    notie.alert(
                    {
                        type: "danger", 
                        text: operationStatus.message
                    }); 
                }
            });
        })
    }
    </script>

</body>
</html>