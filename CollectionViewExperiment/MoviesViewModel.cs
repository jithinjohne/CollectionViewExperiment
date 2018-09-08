using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CollectionViewExperiment
{
    public class MoviesViewModel : BindableBase
    {
        private readonly ObservableCollection<MovieViewModel> _movies;

        public MoviesViewModel()
        {
            _movies = new ObservableCollection<MovieViewModel>();
            Movies = new ReadOnlyObservableCollection<MovieViewModel>(_movies);
            InitializeMovieCollection();

            AddMovieCommand = new DelegateCommand(AddARandomMovie);
            AddOldMovieCommand = new DelegateCommand(AddOldMovie);
            AddFutureMovieCommand = new DelegateCommand(AddFutureMovie);
        }

        private void AddFutureMovie()
        {
            MovieViewModel movie = new MovieViewModel
            {
                Name = "Future Movie",
                Rating = 0,
                ReleaseDate = DateTime.Now + TimeSpan.FromDays(700)
            };

            _movies.Add(movie);
        }

        private void AddOldMovie()
        {
            MovieViewModel movie = new MovieViewModel
            {
                Name = "Old Movie",
                Rating = 5,
                ReleaseDate = DateTime.Now - TimeSpan.FromDays(800)
            };

            _movies.Add(movie);
        }

        private void InitializeMovieCollection()
        {
            List<MovieViewModel> movies = new List<MovieViewModel>
            {
                new MovieViewModel{ Name="Chitram", Rating=5, ReleaseDate = new DateTime(1985,10,10)},
                new MovieViewModel{ Name="Kilukkam", Rating=5, ReleaseDate = new DateTime(1985,3,1)},
                new MovieViewModel{ Name="Premam", Rating=5, ReleaseDate = new DateTime(2016,12,1)},
                new MovieViewModel{ Name="B.Tech", Rating=1, ReleaseDate = new DateTime(2018,5,5)}
            };

            _movies.AddRange(movies);
        }

        private void AddARandomMovie()
        {
            MovieViewModel movie = new MovieViewModel
            {
                Name = "Random Movie",
                Rating = 5,
                ReleaseDate = DateTime.Now
            };

            _movies.Add(movie);
        }

        public ReadOnlyObservableCollection<MovieViewModel> Movies { get; }

        public ICommand AddMovieCommand { get; set; }
        public ICommand AddOldMovieCommand { get; set; }
        public ICommand AddFutureMovieCommand { get; set; }
    }
}
