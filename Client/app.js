$(document).ready(function() {
    $(function() {
        $.get("https://localhost:44325/api/movie", function(data){
        data.map(function(el){
            // loop over the data and print it
            $("#movieList").append(`<div class="row-md">
            <div>Title: ${JSON.stringify(el.title)}</div>
            <div>Title: ${JSON.stringify(el.director)}</div>
            <div>Title: ${JSON.stringify(el.genre)}</div>
            <div>Title: ${JSON.stringify(el.posterimg)}</div>
            </div>`);
        })    
        })
    });
    
    (function($){
        function processForm( e ){
            var dict = {
                Title : this["title"].value,
                Director: this["director"].value,
                Genre : this["genre"].value,
                PosterImg: this["posterimg"].value
                
            };
    
            $.ajax({
                url: 'https://localhost:44325/api/movie',
                dataType: 'json',
                type: 'post',
                contentType: 'application/json',
                data: JSON.stringify(dict),
                success: function( data, textStatus, jQxhr ){
                    $('#response pre').html( data );
                },
                error: function( jqXhr, textStatus, errorThrown ){
                    console.log( errorThrown );
                }
            });
    
            e.preventDefault();
        }
    
        $('#my-form').submit( processForm );
    })(jQuery);

});

