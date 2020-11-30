$(document).ready(function() {
    //pulls all movies from db  -- PULL ID as Well
    $(function() {
        $.get("https://localhost:44325/api/movie", function(data){
        data.map(function(el){
            // loop over the data and print it
            $("#movieList").append(`<div class="row-md">
            <div>MovieId: ${JSON.stringify(el.movieid)}</div>
            <div>Title: ${JSON.stringify(el.title)}</div>
            <div>Director: ${JSON.stringify(el.director)}</div>
            <div>Genre: ${JSON.stringify(el.genre)}</div>
            <div>Poster: ${JSON.stringify(el.posterimg)}</div>
            
            <div id></div>
            <button type="submit" onsubmit="updateMovie(${JSON.stringify(el.movieid)})">Edit</button>
            </div>`);
        })    
        })
    });
    
    $(function() {
        $.get("https://localhost:44325/api/movie", function(data){
        data.map(function(el){
            // loop over the data and print it
            $("updateMovie").append(`<form id="updateMovie">
            <input type="text" name="title" placeholder="Title" />
            <input type="text" name="director" placeholder="Director" />
            <input type="text" name="genre" placeholder="Genre" />
            <input type="text" name="posterimg" placeholder="PosterImg" />

            <button type="submit">Submit</button>
            </form>`);
        })    
        })
    });

    



    // posts a new movie to the db
    (function($){
        function addMovie( e ){
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
    
        $('#addMovie').submit( addMovie );
    })(jQuery);

    (function($){
        function addMovie( e ){
            var dict = {
                MovieId : this["movieId"].value,
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
    
        $('#addMovie').submit( addMovie );
    })(jQuery);

    // edit an item in the db

    // pull an indvidual item from the db
   

});

