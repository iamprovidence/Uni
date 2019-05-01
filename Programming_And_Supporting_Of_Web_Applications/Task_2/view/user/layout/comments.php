
                            <div class="reviews" >
                                <h4>Comments</h4>
                                
                                
                                <div class="comments" id="comments">
                                    
                                    <?php if (isset($comments) && count($comments) > 0): ?>

                                    <?php foreach ($comments as $comment): ?>

                                    <div class="comment">
                                        <!--image-->
                                        <div class="review-author float-left">
                                            <img src="<?= $this->GetModel(Models::User)->GetImage($comment->user_id)?>" alt="User avatar"/>
                                        </div>
                                        <!--content-->
                                        <div>
                                            <h4><?=$comment->subject?></h4>
                                            <br/>
                                            <p><?=$comment->text?></p>
                                            <cite><?=$comment->user_nickname?></cite>
                                        </div>
                                    </div>

                                    <?php endforeach; ?>         
                                    <?php else: ?>

                                    <p>No comments</p>

                                    <?php endif; ?>   

                                </div>                   

                                <!-- add comment -->
                                
                                <?php if (isset($is_comment_available) && $is_comment_available): ?>
                                
                                <div id="add-comment">
                                    <h4>Leave a comment</h4>
                                    <form id="add-comment-form">
                                        <div class="form-group">
                                            <label for="product-subject-text">Subject:</label>
                                            <input type="text" id="product-subject-text" class="form-control" required/>
                                        </div>        
                                        <div class="form-group">
                                            <label for="product-comment-text">Text:</label>
                                            <textarea id="product-comment-text" class="form-control" required></textarea>
                                        </div>                                        

                                        <button class="btn" type="submit" data-product-id="<?=$product_id?>">Add comment</button>
                                    </form>  
                                </div>
                                
                                <?php endif; ?>

                            </div>