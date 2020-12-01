$(function() {
    $.get("https://localhost:44325/api/movie", function(data){
    data.map(function(el){
        // loop over the data and print it
        $("#movieList").append(`<div class="row-md">
        <div>Title: ${JSON.stringify(el.title)}</div>
        <div>Title: ${JSON.stringify(el.director)}</div>
        </div>`);
    })    
    })
})