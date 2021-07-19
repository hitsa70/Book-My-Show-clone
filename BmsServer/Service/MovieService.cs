using BmsServer.Context;
using BmsServer.Contracts;
using BmsServer.Core;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BmsServer.Repository
{
    public class MovieService : IMovieRepository
    {
        public DBContext _context { get; set; }
        public MovieService(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MoviesDto>> GetMovies() {
            var query = "SELECT MovieId, Name ,ImageLink ,MovieLanguage FROM MovieInfo";
            using (var connection = _context.CreateConnection())
            {
                var movies = await connection.QueryAsync<MoviesDto>(query);
                return movies.ToList();
            }
        }
        public async Task<MovieDetailDto> GetMovie(int id)
        {
            var query = "SELECT * FROM MovieInfo WHERE movieId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var movies = await connection.QuerySingleOrDefaultAsync<MovieDetailDto>(query, new { id });
                return movies;
            }
        }

        public async Task<MovieDetailDto> AddMovie(MovieDetailDto movie)
        {
            var query = "INSERT INTO MovieInfo (Name, MovieQuality,Length,"+
                "ImageLink,MovieAgeRestriction,MovieLanguage,DateOfRelease,RentPrice,BuyPrice," +
                "About,TrailerLink,MovieCategory,CastId,CrewId) VALUES (@Name,@MovieQuality,@Length," +
                "@ImageLink,@MovieAgeRestriction,@MovieLanguage,@DateOfRelease,@RentPrice,@BuyPrice," +
                "@About,@TrailerLink,@MovieCategory,@CastId,@CrewId)";

            var parameters = new DynamicParameters();

            parameters.Add("Name", movie.Name, DbType.String);
            parameters.Add("MovieQuality", movie.MovieQuality, DbType.String);
            parameters.Add("Length", movie.Length, DbType.String);
            parameters.Add("ImageLink", movie.ImageLink, DbType.String);

            parameters.Add("MovieAgeRestriction", movie.MovieAgeRestriction, DbType.String);
            parameters.Add("MovieLanguage", movie.MovieLanguage, DbType.String);

            parameters.Add("DateOfRelease", movie.DateOfRelease, DbType.Date);

            parameters.Add("BuyPrice", movie.BuyPrice, DbType.Decimal);
            parameters.Add("RentPrice", movie.BuyPrice, DbType.Decimal);

            parameters.Add("About", movie.About, DbType.String);
            parameters.Add("TrailerLink", movie.TrailerLink, DbType.String);

            parameters.Add("MovieCategory", movie.MovieCategory, DbType.String);

            parameters.Add("CastId", movie.CastId, DbType.Int16);
            parameters.Add("CrewId", movie.CrewId, DbType.Int16);



            using (var connection = _context.CreateConnection())
            {
                var movieId = await connection.QuerySingleAsync<int>(query, parameters);
                var createdMovie = new MovieDetailDto
                {
                    MovieId = movie.MovieId,
                    Name = movie.Name,
                    MovieQuality = movie.MovieQuality,
                    Length = movie.Length,
                    ImageLink = movie.ImageLink,
                    MovieAgeRestriction = movie.MovieAgeRestriction,
                    MovieLanguage = movie.MovieLanguage,
                    DateOfRelease = movie.DateOfRelease,
                    RentPrice = movie.RentPrice,
                    BuyPrice = movie.BuyPrice,
                    About = movie.About,
                    TrailerLink = movie.TrailerLink,
                    MovieCategory = movie.MovieCategory,
                    CastId = movie.CastId,
                    CrewId = movie.CrewId
                };
                return createdMovie;
            }
        }
        public async Task UpdateMovie(int updateId, MovieDetailDto movie)
        {
            var query = "UPDATE MovieInfo SET " +
                " Name= @Name, MovieQuality= @MovieQuality,Length= @Length," +
                "ImageLink= @ImageLink,MovieAgeRestriction= @MovieAgeRestriction,MovieLanguage= @MovieLanguage," +
                "DateOfRelease= @DateOfRelease,RentPrice= @RentPrice,BuyPrice= @BuyPrice," +
                "About= @About,TrailerLink= @TrailerLink,MovieCategory= @MovieCategory,CastId= @CastId,CrewId= @CrewId" +
                " WHERE MovieId = @updateId";

            var parameters = new DynamicParameters();

            parameters.Add("updateId", updateId, DbType.Int32);
            parameters.Add("Name", movie.Name, DbType.String);
            parameters.Add("MovieQuality", movie.MovieQuality, DbType.String);
            parameters.Add("Length", movie.Length, DbType.String);
            parameters.Add("ImageLink", movie.ImageLink, DbType.String);

            parameters.Add("MovieAgeRestriction", movie.MovieAgeRestriction, DbType.String);
            parameters.Add("MovieLanguage", movie.MovieLanguage, DbType.String);

            parameters.Add("DateOfRelease", movie.DateOfRelease, DbType.Date);

            parameters.Add("BuyPrice", movie.BuyPrice, DbType.Decimal);
            parameters.Add("RentPrice", movie.BuyPrice, DbType.Decimal);

            parameters.Add("About", movie.About, DbType.String);
            parameters.Add("TrailerLink", movie.TrailerLink, DbType.String);

            parameters.Add("MovieCategory", movie.MovieCategory, DbType.String);

            parameters.Add("CastId", movie.CastId, DbType.Int16);
            parameters.Add("CrewId", movie.CrewId, DbType.Int16);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteMovie(int deleteId) {
            var query = "DELETE FROM MovieInfo WHERE MovieId = @deleteId";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { deleteId });
            }
        }
    }

}

