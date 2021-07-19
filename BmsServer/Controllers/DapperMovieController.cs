using BmsServer.Contracts;
using BmsServer.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmsServer.Controllers
{
    [Route("dapper/movie")]
    [ApiController]
    public class DapperMovieController : Controller
    {
        public IMovieRepository _movieRepo { get; set; }
        public DapperMovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovie()
        {
            try
            {
                var movies = await _movieRepo.GetMovies();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}", Name = "MovieById")]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                var movies = await _movieRepo.GetMovie(id);
                if (movies == null)
                    return NotFound();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message+ " HAHAHAHA No movie with this ID \n\n    ____________ change your id ____________");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDetailDto movie)
        {
            try
            {
                var createdMovie = await _movieRepo.AddMovie(movie);
                return CreatedAtRoute("MovieById", new { id = createdMovie.MovieId }, createdMovie);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message + " \n\n cannot show movie :( \n\nsorry");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDetailDto movie)
        {
            try
            {
                var dbCompany = await _movieRepo.GetMovie(id);
                if (dbCompany == null)
                    return NotFound();

                await _movieRepo.UpdateMovie(id, movie);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var dbCompany = await _movieRepo.GetMovie(id);
                if (dbCompany == null)
                    return NotFound();
                await _movieRepo.DeleteMovie(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
    
}