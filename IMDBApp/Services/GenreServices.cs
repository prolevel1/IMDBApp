using IMDBApp.Models;
using IMDBApp.Models.Request;
using IMDBApp.Models.Response;
using IMDBApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApp.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly IGenreRepository genreRepository;
        public GenreServices(IGenreRepository _genreRepository)
        {
            genreRepository = _genreRepository;
        }

        public void Delete(int id)
        {
            genreRepository.Delete(id);
        }

        public IEnumerable<GenreRequest> Get()
        {
            List<GenreRequest> allGenre = new List<GenreRequest>();
            var genreEntities = genreRepository.Get();
            GenreRequest genreRequestEntity;
            foreach (var genreEntity in genreEntities)
            {
                genreRequestEntity = new GenreRequest
                {
                    Id = genreEntity.Id,
                    Name = genreEntity.Name,

                };
                allGenre.Add(genreRequestEntity);
            }
            return allGenre;
        }

        public GenreRequest Get(int id)
        {
            var genreEntity = genreRepository.Get(id);
            GenreRequest genreRequest =
            new GenreRequest()
            {
                Id = genreEntity.Id,
                Name = genreEntity.Name

            };
            return genreRequest;

        }

        public void Post(GenreRequest genreRequest)
        {
            var genreEntity = new Genre()
            {

                Name = genreRequest.Name,


            };
            genreRepository.Post(genreEntity);
        }

        public void Put(int id, GenreRequest genreRequest)
        {
            var genre = new Genre()
            {
                Id = genreRequest.Id,
                Name = genreRequest.Name,

            };
            genreRepository.Put(id, genre);
        }


    }
}