using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Урок_93._WPF._Привязки_через_свойства.Services;
using Урок_93._WPF._Привязки_через_свойства.ViewModels;

namespace Урок_93._WPF._Привязки_через_свойства
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MoviesViewModel moviesViewModel = new MoviesViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDowenloadCSVFile_Click(object sender, RoutedEventArgs e)
        {
            CSVFileReader reader = new CSVFileReader();

            foreach (var film in reader.Movies) 
            {
                moviesViewModel.Movies.Add(film);
            }
        }
    }
}