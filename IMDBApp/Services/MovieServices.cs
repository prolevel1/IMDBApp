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
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorRepository actorRepository;
        private readonly IProducerRepository producerRepository;
        private readonly IGenreRepository genreRepository;
       
        public MovieServices(IMovieRepository _moviesRepository, IActorRepository _actorRepository, IProducerRepository _producerRepository, IGenreRepository _genreRepository)
        {
            movieRepository = _moviesRepository;
            actorRepository = _actorRepository;
            producerRepository = _producerRepository;
            genreRepository = _genreRepository;
        }

        public void Delete(int id)
        {
            movieRepository.Delete(id);
        }

        public IEnumerable<MovieResponse> Get()
        {
            var movies = movieRepository.Get();
            var movieList = new List<MovieResponse>();

            movies.ToList().ForEach(m =>
            {
                var actors = actorRepository.GetActorsByMovieId(m.Id);
                var genres = genreRepository.GetGenresByMovieId(m.Id);
                var producer = producerRepository.Get(m.ProducerId);

                var movie = new MovieResponse
                {
                    Id = m.Id,
                    Name = m.Name,
                    YOR = m.YOR,
                    Plot = m.Plot,
                    
                    Actor = actors.ToList(),
                    Genre = genres.ToList(),
                    Producer = producer
                };
                movieList.Add(movie);
            });
            return movieList;
        }

        public MovieResponse Get(int Id)
        {
            var m = movieRepository.Get(Id);
            var movie = new MovieResponse
            {
                Id = m.Id,
                Name = m.Name,
                YOR = m.YOR,
                Plot = m.Plot,
                Actor = actorRepository.GetActorsByMovieId(m.Id).ToList(),
                Genre = genreRepository.GetGenresByMovieId(m.Id).ToList(),
                Producer = producerRepository.Get(m.ProducerId)
            };
            return movie;
        }

        public void Post(MovieRequest movieRequest)
        {
            var m = new Movie
            {
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                 YOR = movieRequest.YOR,
                
                ProducerId = movieRequest.ProducerId
            };
           
            string Actor = String.Join(",", movieRequest.Actor);
            string Genre = String.Join(",", movieRequest.Genre);
          
            movieRepository.Post(m, Actor, Genre);
        }

        public void Put(int id, MovieRequest movieRequest)
        {
            var m = new Movie
            {
                Id = id,
                Name = movieRequest.Name,
                Plot = movieRequest.Plot,
                YOR = movieRequest.YOR,
                ProducerId = movieRequest.ProducerId,
            };
            string Actor = String.Join(",", movieRequest.Actor);
            string Genre = String.Join(",", movieRequest.Genre);
  
            movieRepository.Put(id,m, Actor, Genre);

        }
    }
}
