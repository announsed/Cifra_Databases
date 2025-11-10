using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Урок_93._WPF._Привязки_через_свойства.Models
{
    internal class Movies
    {
        [DisplayName("Id")]
        public long Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Год")]
        public DateTime Year { get; set; }
        [DisplayName("Режиссёр")]
        public string DirectorName { get; set; }
        [DisplayName("Жанр")]
        public string Genre { get; set; }
        [DisplayName("Оценка")]
        public float Graduate { get; set; }
    }
}
