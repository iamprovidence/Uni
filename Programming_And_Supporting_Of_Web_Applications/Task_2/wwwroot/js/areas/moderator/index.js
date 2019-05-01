// binding actions
$(document).ready(bind_everything);

// binding
function bind_everything()
{
    if (typeof(bind_creating) === typeof(Function)) bind_creating();
    if (typeof(bind_deleting) === typeof(Function)) bind_deleting();
    if (typeof(bind_updating) === typeof(Function)) bind_updating();
}   

// change view with ajax
function load_view({ entity_name, page_number } = {})
{
    $.pjax(
    {
        type: 'POST',
        url: `/moderator/${entity_name}/page-${page_number}`,
        container: '#main',
        fragment: '#main',
        push: false,
        scrollTo: false
    }).done(bind_everything);
}

$(".btn-go-back").click(function()
{
    go_back_in_history()
});