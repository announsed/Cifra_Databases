using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using WpfApp7.Models;

namespace WpfApp7.Services
{
    internal class CSVReader
    {
        public List<TitanicPassengers> Passengers { get; set; }

        public CSVReader()
        {
            using (StreamReader reader = new StreamReader("titanic.csv"))
            {
                CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                Passengers = csvReader.GetRecords<TitanicPassengers>().ToList();

            }
        }
    }
}
