using Dapper;
using IMDBApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
    public class MovieRepositoty : IMovieRepository
    {
        private readonly ConnectionString connectionString;
        public MovieRepositoty(IOptions<ConnectionString> _connectionString)
        {
            connectionString = _connectionString.Value;
        }

        public void Delete(int id)
        {
            string sql =
                 @"DELETE
                FROM MovieActorMapping
                WHERE MovieId = @id

                DELETE
                FROM MovieGenreMapping
                WHERE MovieId = @id

                DELETE
                FROM Movies
                WHERE Id = @id";

            var connection = new SqlConnection(connectionString.IMDBDApp);
            connection.Execute(sql, new { Id = id });
        }
    

        public IEnumerable<Movie> Get()
        {
            string sql = @" SELECT *
                            FROM Movies";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var query = connection.Query<Movie>(sql);
                return query;
            }
        }

        public Movie Get(int id)
        {
            string sql = @" SELECT *
                            FROM Movies
                            WHERE Id = @Id";
            var connection = new SqlConnection(connectionString.IMDBDApp);
            var result = connection.QuerySingle<Movie>(sql, new { Id = id });
            return result;
        }

   
            public void Post(Movie movie, string  actor, string genre)
            {
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var procedure = @"sp_AddMovie";
                var entity = new
                {
                    Name = movie.Name,
                    YOR = movie.YOR,
                    Plot = movie.Plot,
                    ProducerId = movie.ProducerId,
                    ActorId = actor,
                    GenreId = genre
                };


                connection.Execute(procedure, entity, commandType: CommandType.StoredProcedure);
            }

        }


        public void Put(int id ,Movie movie, string actor, string genre)
        {
           
         
                var procedure = @"UpdateMovieRecord";
                var entity = new
                {
                     
                    Name = movie.Name,
                    YOR = movie.YOR,
                    Plot = movie.Plot,
                    ProducerId = movie.ProducerId,
                    Actors = actor,
                    Genres =  genre,
                    Id = id
                    
                };
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(procedure, entity, commandType: CommandType.StoredProcedure);
            }

           
        }
    }
      
}
