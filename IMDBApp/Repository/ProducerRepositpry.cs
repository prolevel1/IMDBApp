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
    public class ProducerRepositpry : IProducerRepository
    {
        private readonly ConnectionString connectionString;
        public ProducerRepositpry(IOptions<ConnectionString> _connectionString)
        {
            connectionString = _connectionString.Value;

        }

        public void Delete(int id)
        {
            string sql = @"DELETE FROM Producers WHERE Id = @Id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        public IEnumerable<Producer> Get()
        {
            string sql = @"SELECT Id [Id],
                                  Name [Name],
                                  DOB [DOB],
                                  Bio [Bio],
                                  Gender [Gender]
                           FROM Producers";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                var result = connection.Query<Producer>(sql);
                return result;
            }
        }

        public Producer Get(int id)
        {
            string sql = @"SELECT Id [Id],
                                  Name [Name],
                                  DOB [DOB],
                                  Bio [Bio],
                                  Gender [Gender]
                           FROM Producers
                           WHERE Id = @id";
            using (var connection = new  SqlConnection(connectionString.IMDBDApp))
            {
                var query = connection.QueryFirst<Producer>(sql, new { Id = id });
                return query;
            }
        }

        public void Post(Producer producer)
        {
            string sql = @"INSERT INTO Producers 
                        VALUES (
                       @Name
                       ,@Bio
                       ,@Gender
                       ,@DOB
                     
                                 );";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, producer);
                
            }
        }

        public void Put(int id, Producer producer)
        {
            string sql = @"UPDATE Producers
                           SET
                               Name=@Name,
                               DOB=@DOB,
                               Bio=@Bio,
                               Gender=@Gender
                           WHERE Producers.Id=@id";
            using (var connection = new SqlConnection(connectionString.IMDBDApp))
            {
                connection.Execute(sql, new
                {
                    producer.Name,
                    producer.Dob,
                    producer.Bio,
                    producer.Gender,
                    id
                });
            }
        }

    }
}
