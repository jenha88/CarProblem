using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFiles
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public int Mileage { get; set; }

        public Car()
        {
            Manufacturer = "";
            Color = "";
            Year = 0;
            Mileage = 0;
        }
        public Car(string data)
        {
            var file = data.Split(',');
            Year = Convert.ToInt32(file[0]);
            Manufacturer = file[1];
            Color = file[2];
            Mileage = Convert.ToInt32(file[3]);

        }
        public override string ToString()
        {
            return $"{Year} {Manufacturer} {Color} {Mileage}";
        }
    }
    
}
