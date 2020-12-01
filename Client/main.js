$(function (){
    var $movieList = $('#movieList');
    var MovieTemplate = $('#movie-template').html();
    
   function addMovieList(movie) {
     $movieList.append(
       Mustache.render(MovieTemplate, movie)
     );
   }
   
    $.ajax({
      type: "GET",
      url: "https://localhost:44325/api/movie",
      success: function (movies) {
          $.each(movies,function(i,movie){
            addMovieList(movie);

          })
        //console.log("success", data);
      },
      error: function(){
          alret('error loading  Movie List')
      }
    });
    (function ($) {
      function addMovie(e) {
        var dict = {
          Title: this["title"].value,
          Director: this["director"].value,
          Genre: this["genre"].value,
          PosterImg: this["posterImg"].value,
        };

        $.ajax({
          url: "https://localhost:44325/api/movie",
          dataType: "json",
          type: "post",
          contentType: "application/json",
          data: JSON.stringify(dict),
          success: function (movie, textStatus, jQxhr) {
            //$("#response pre").html(movie);
            addMovieList(movie);
            $("#addMovie").toggle();
            $("#addMovie").trigger("reset");


          },
          error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
          },
        });

        e.preventDefault();
      }

      $("#addMovie").submit(addMovie);
    })(jQuery);

    $movieList.delegate('.delete','click', function(){
        var $li = $(this).closest('li');
        $.ajax({
            type: 'DELETE',
            url: "https://localhost:44325/api/movie/" + $li.attr('data-id'),
            success: function () {

                $li.fadeOut(300,function(){
                    $(this).remove();
                });
            }
        });
    });
    $movieList.delegate('.editMovie','click', function(){
        var $li = $(this).closest("li");
        //$li.find("input.movieId").val($li.find("span.movieId").html());
        $li.find('input.title').val( $li.find('span.title').html() );
        $li.find("input.director").val($li.find("span.director").html());
        $li.find("input.genre").val($li.find("span.genre").html());
        $li.find("input.posterImg").val($li.find("span.posterImg").html());
        $li.addClass('edit');
    });

    $movieList.delegate(".cancelEdit", "click", function () {
      var $li = $(this).closest("li").removeClass('edit');
    });

    $movieList.delegate(".saveMovie", "click", function () {
      var $li = $(this).closest("li");
      var items = {
        //movieId: $li.find("input.movieId").val(),  
        title: $li.find("input.title").val(),
        director: $li.find("input.director").val(),
        genre: $li.find("input.genre").val(),
        posterImg: $li.find("input.posterImg").val()
      };
      $.ajax({
        url: "https://localhost:44325/api/movie/" + $li.attr("data-id"),
        dataType: "json",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(items),
        success: function (items) {
          
        },
        error: function (jqXhr, textStatus, errorThrown) {
          console.log(errorThrown);
        },
      });
      $li.find("span.title").html(items.title);
      $li.find("span.director").html(items.director);
      $li.find("span.genre").html(items.genre);
      //$li.find("span.posterImg").html(items.posterImg);
      $li.removeClass("edit");
    });
    
    $("#formButton").click(function () {
      $("#addMovie").toggle();
    });
    
});

