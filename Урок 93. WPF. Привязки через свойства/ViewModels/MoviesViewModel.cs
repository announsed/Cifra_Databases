using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Урок_93._WPF._Привязки_через_свойства.Models;
using Урок_93._WPF._Привязки_через_свойства.ViewModels.Base;

namespace Урок_93._WPF._Привязки_через_свойства.ViewModels
{
    internal class MoviesViewModel : ViewModelBase
    {
        private ObservableCollection<Movies> _movies;
        public ObservableCollection<Movies> Movies
        {
            get { return _movies; }
            set
            {
                if (_movies != value)
                {
                    _movies = value;
                    OnPropertyChanged(nameof(Movies));
                }
            }
        }
        public MoviesViewModel()
        {
            Movies = new ObservableCollection<Movies>();
        }


        private Movies _selectedMovie;
        public Movies SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                if (_selectedMovie != value)
                {
                    _selectedMovie = value;
                    OnPropertyChanged(nameof(SelectedMovie));
                }
            }
        }


    }
}
