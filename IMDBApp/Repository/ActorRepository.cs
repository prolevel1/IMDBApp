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
    public class ActorRepository : IActorRepository
    {
        private readonly ConnectionString connectionString;
        public ActorRepository(IOptions<ConnectionString> _connectionString)
        {
            connectionString = _connectionString.Value;

        }
        public void Post(Actor actors)
        {
            string sql = @" INSERT INTO Actors (
                    Name
                   ,Dob
                   ,Bio
                   ,Gender
                    )VALUES(
                      @Name
                     ,@DOB
                     ,@Bio
                     ,@Gender
                                );";

            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new
                {
                    Name = actors.Name,
                    Dob = actors.Dob,
                    Bio = actors.Bio,
                    Gender = actors.Gender
                });
            }
        }


        public void Delete(int id)
        {
            string sql = @" DELETE FROM Actors WHERE Id = @Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        public Actor Get(int id)
        {
            string sql = @" SELECT * FROM Actors WHERE Id = @Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var query = connection.QueryFirst<Actor>(sql, new { Id = id });
                return query;
            }
        }
        public IEnumerable<Actor> GetActorsByMovieId(int id)
        {
            string sql = @"SELECT A.Id ,
                                  A.Name ,
                                  A.Dob ,
                                  A.Gender,
                                  A.Bio
                           FROM Actors A
                           INNER JOIN MovieActorMapping M
                           ON A.Id=M.ActorId
                           WHERE M.MovieId=@MovieId";

            var connection = new SqlConnection(connectionString.IMDBDApp);
            
                var query = connection.Query<Actor>(sql, new { MovieId = id });
                return query;
            

        }

        public void Put(int id, Actor actors)
        {
            string sql = @"UPDATE Actors
                           SET
                               Name=@Name,
                               Dob=@Dob,
                               Bio=@Bio,
                               Gender=@Gender
                           WHERE Actors.Id=@id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new
                {
                    
                    actors.Name,
                    actors.Dob,
                    actors.Bio,
                    actors.Gender,
                    id
                });
            }
        }
        
        public IEnumerable<Actor> Get()
        {
            string sql = @" SELECT * FROM Actors";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var result = connection.Query<Actor>(sql);
                return result;
            }
        }
    }
    
}
