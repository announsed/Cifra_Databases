using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Урок_96._Домашнее_задание._WPF._DataGrid_.Models;
using Урок_96._Домашнее_задание._WPF._DataGrid_.Services;
using Урок_96._Домашнее_задание._WPF._DataGrid_.ViewModel.Base;

namespace Урок_96._Домашнее_задание._WPF._DataGrid_.ViewModel
{
    class GridViewViewModel : ViewModelBase
    {
        private List<Product> _products;
        public List<Product> Products
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }
        public GridViewViewModel()
        {
            Products = ProductListCreator.GetProducts();
        }
    }
}
