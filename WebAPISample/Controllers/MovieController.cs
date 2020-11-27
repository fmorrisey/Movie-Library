﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            // Create movie in db logic

            _context.Add(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie)
        {
            // Update movie in db logic
            _context.Movies.Update(movie);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            var movieToRemove = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            _context.Remove(movieToRemove);
            _context.SaveChanges();
            return Ok();
        }
    }
}