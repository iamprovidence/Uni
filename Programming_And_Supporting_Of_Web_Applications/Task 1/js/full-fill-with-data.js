function HandlebarsTemplate({templateId, parentNodeSelector, data} = {})
{
    var template = document.getElementById(templateId).innerHTML;

    var interpretator = Handlebars.compile(template);

    var resultHTML = interpretator(data);

    document.querySelector(parentNodeSelector).innerHTML += resultHTML;
}

// PLUSES
HandlebarsTemplate(
{
    templateId: "pluses-comment-template",
    parentNodeSelector: "#pluses .row:nth-child(1)",
    data:
    {
        comments:
        [
            {
                Text: "Pellentesque tristique mollis purus, id eleifend ante iaculis id. Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            {
                Text: "Donec ultricies sed ex bibendum faucibus. Etiam tincidunt sed nibh in faucibus. Aenean consectetur, " +
                        "mi scelerisque sodales porta, erat risus tincidunt enim, ac commodo nisi nisi sed nulla. Fusce imperdiet semper varius."
            }
        ]
    }
})
HandlebarsTemplate(
{
    templateId: "pluses-comment-template",
    parentNodeSelector: "#pluses .row:nth-child(2)",
    data:
    {
        comments:
        [
            {
                Text: "Pellentesque mattis ipsum ligula, ut varius lorem elementum eget. Mauris in rhoncus elit. Donec pretium nisl eu luctus pretium. Ut eu sem nisi."
            },
            {
                Text: "Nullam a tellus non mi suscipit pellentesque. Nam commodo, quam in dapibus ultricies, massa eros egestas erat, sit " +
                        "amet consequat est velit eu ante. Sed sollicitudin ante nec nisi laoreet, id vestibulum ipsum pretium."
            }
        ]
    }
})


// REVIEW
HandlebarsTemplate(
{
    templateId: "review-item-template",
    parentNodeSelector: "#reviews .row:nth-child(1)",
    data:
    {
        review_items:
        [
            {
                AuthorName: "John Doe",
                Avatar: "images/no_avatar_75x75.png",
                Text: "Donec fringilla, justo sit amet venenatis ultricies, nibh velit suscipit dolor, ut sagittis mi ipsum ac nibh. "+
                        "Maecenas aliquam sodales libero et tristique. In mi sapien, ullamcorper sit amet purus ut, euismod pulvinar nulla.  "
            },
            {
                AuthorName: "Jane Doe",
                Avatar: "images/images/avatars/Jane.png",
                Text: "Donec rhoncus risus quis mauris fermentum varius eget nec dui. Suspendisse sapien velit, dapibus quis metus sit amet, ultrices commodo nibh."
            },
        ]
    }
})
HandlebarsTemplate(
{
    templateId: "review-item-template",
    parentNodeSelector: "#reviews .row:nth-child(2)",
    data:
    {
        review_items:
        [
            {
                AuthorName: "Malcolm Clay",
                Avatar: "images/images/avatars/Malcolm.png",
                Text: "In rutrum dui id molestie pulvinar."
            },
            {
                AuthorName: "Sammy Garrison",
                Avatar: "images/images/avatars/Sammy.png",
                Text: "Nullam tempus risus sodales urna eleifend tempus. "
            },
        ]
    }
})

// TOP ITEMS
HandlebarsTemplate(
{
    templateId: "top-item-template", 
    parentNodeSelector: "#top-most .grid", 
    data: 
    {
        top_items: 
        [
            {
                Name: "Ibanez Kikosp2",
                AltImageText: "IBANEZ KIKOSP2", 
                Image: "IBANEZ_KIKOSP2.gif"
            },
            {
                Name: "Gibson Les Paul",
                AltImageText: "Gibson Les Paul",
                Image: "Gibson_Les_Paul.gif"              
            },            
            {
                Name: "Epiphone ES339",
                AltImageText: "Epiphone ES339",
                Image: "EPIPHONE_ES339.png"              
            },   
            {
                Name: "Hagstrom D2H",
                AltImageText: "Hagstrom D2H",
                Image: "HAGSTROM_D2H.jpg"              
            },  
            {
                Name: "Fender Jaguar",
                AltImageText: "Fender Classic Player Jaguar",
                Image: "Fender_Classic_Player_Jaguar.png"              
            },            
            {
                Name: "Yamaha Pacifica 112V",
                AltImageText: "Yamaha Pacifica 112V",
                Image: "Yamaha_Pacifica_112V.gif"              
            },
        ]
    }
})

// BUY ITEMS
HandlebarsTemplate(
{
    templateId: "buy-item-template", 
    parentNodeSelector: "#buy .row", 
    data: 
    {
        buy_items: 
        [
            {
                Name: "Ibanez Kikosp2",
                Price: "600",
                AltImageText: "IBANEZ KIKOSP2", 
                Image: "IBANEZ_KIKOSP2.gif"
            },
            {
                Name: "Gibson Les Paul",
                Price: "25 500",
                AltImageText: "Gibson Les Paul",
                Image: "Gibson_Les_Paul.gif"              
            },            
            {
                Name: "Epiphone ES339",
                Price: "900",
                AltImageText: "EPIPHONE ES339",
                Image: "EPIPHONE_ES339.png"              
            }, 
            {
                Name: "Yamaha Pacifica 112V",
                Price: "600",
                AltImageText: "Yamaha Pacifica 112V",
                Image: "Yamaha_Pacifica_112V.gif"              
            },    
            {
                Name: "Hagstrom D2H",
                Price: "1 000",
                AltImageText: "HAGSTROM D2H",
                Image: "HAGSTROM_D2H.jpg"              
            },  
            {
                Name: "Fender Jaguar",
                Price: "1 800",
                AltImageText: "Fender Classic Player Jaguar",
                Image: "Fender_Classic_Player_Jaguar.png"              
            },
            {
                Name: "Roland G-5 VG",
                Price: "1 750",
                AltImageText: "Roland G-5 VG",
                Image: "Roland_G-5_VG.jpg"              
            },
            {
                Name: "Godin Core CT P90",
                Price: "1 600",
                AltImageText: "GODIN CORE CT P90",
                Image: "GODIN_CORE_CT_P90.jpg"              
            },       
            {
                Name: "Prophecy Futura FX",
                Price: "950",
                AltImageText: "PROPHECY FUTURA_FX",
                Image: "PROPHECY_FUTURA_FX.jpg"              
            }, 
            {
                Name: "Ibanez S7420",
                Price: "1 000",
                AltImageText: "Ibanez S7420",
                Image: "Ibanez_S7420.jpg"              
            },       
            {
                Name: "Epiphone SG G400",
                Price: "800",
                AltImageText: "EPIPHONE SG G400",
                Image: "EPIPHONE_SG_G400.jpg"              
            },  
            {
                Name: "Fender Stratocaster",
                Price: "1 800",
                AltImageText: "FENDER STRATOCASTER",
                Image: "FENDER_STRATOCASTER.jpg"              
            },
        ]
    }
})

