using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Урок_93._WPF._Привязки_через_свойства.Models;

namespace Урок_93._WPF._Привязки_через_свойства.Services
{
    internal class CSVFileReader
    {
        public List<Movies> Movies { get; set; }

        public CSVFileReader()
        {
            using (StreamReader reader = new StreamReader("Movies.csv"))
            {
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                Movies = csvReader.GetRecords<Movies>().ToList();
            }
        }
    }
}
