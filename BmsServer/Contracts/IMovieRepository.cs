using BmsServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmsServer.Contracts
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<MoviesDto>> GetMovies();

        public Task<MovieDetailDto> GetMovie(int id);

        public Task<MovieDetailDto> AddMovie(MovieDetailDto movie);

        public Task UpdateMovie(int id, MovieDetailDto movie);

        public Task DeleteMovie(int id);
    }
}
