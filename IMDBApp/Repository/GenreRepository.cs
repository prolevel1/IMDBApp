using Dapper;
using IMDBApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ConnectionString connectionString;
        public GenreRepository(IOptions<ConnectionString> _connectionString)
        {
            connectionString = _connectionString.Value;

        }

        public void Delete(int id)
        {
            string sql = @"DELETE FROM Genre WHERE Id = @Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new { @Id = id });
            }
        }

        public Genre Get(int id)
        {
            string sql = @"SELECT * FROM Genre WHERE Id = @Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var query = connection.QueryFirst<Genre>(sql, new { Id = id });
                return query;
            }
        }

        public IEnumerable<Genre> Get()
        {
            string sql = @" SELECT * FROM Genre";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var result = connection.Query<Genre>(sql);
                return result;
            }
        }


        public IEnumerable<Genre> GetGenresByMovieId(int id)
        {
            string sql = @"SELECT g.Id [Id],
                                  g.Name [Name]
                           FROM Genre g
                           INNER JOIN MovieGenreMapping m
                           ON g.Id=m.GenreId
                           WHERE m.MovieId=@MovieId";

            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var query = connection.Query<Genre>(sql, new { MovieId = id });
                return query;
            }
        }


        public void Post(Genre genre)
        {
            string sql = @"INSERT INTO Genre(Name) VALUES(@Name)";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new { @Name = genre.Name });
            }
        }

        public void Put(int id, Genre genre)
        {
            string sql = @"UPDATE Genre SET Name=@Name
                        WHERE Id=@Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new { @Id = id, @Name = genre.Name });
            }
        }

    }
}
