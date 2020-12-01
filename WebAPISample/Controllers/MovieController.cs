using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }

        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            var movie = _context.Movies.ToList(); // Retrieve all movies from db logic
            return Ok(movie);

        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound(new { message = "Movie not found" });
            }

            return Ok(movie);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                // Create movie in db logic
                if (movie == null)
                {
                    return NotFound();
                }

                _context.Add(movie);
                _context.SaveChanges();

               
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT api/movie
        [HttpPut("{id}")]
        //public IActionResult Put([FromBody] Movie movie)
        public IActionResult Put(int id, Movie movie)
        {
            try
            {
                var item = _context.Movies.Find(id);
                if (item == null)
                {
                    return NotFound();
                }

                // Update movie in db logic
                item.Director = movie.Director;
                item.Genre = movie.Genre;
                item.Title = movie.Title;
                item.PosterImg = movie.PosterImg;
                _context.Movies.Update(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            var movie = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();

            try
            {
                _context.Remove(movie);
                _context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}