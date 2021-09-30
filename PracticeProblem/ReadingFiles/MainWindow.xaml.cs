using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReadingFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> C = new List<Car>();
        public MainWindow()
        {
            InitializeComponent();
            var line = File.ReadAllLines("RandCar1.csv").Skip(1);
            
            foreach (var item in line)
            {
                C.Add(new Car(item));
            }
           

            PopulateListBox(C);
            PopulateManufacturer();
            PopulateColor();
            PopulateYear();

            cbManu.SelectedIndex = 0;
            cbColor.SelectedIndex = 0;
            cbYear.SelectedIndex = 0;
       
            
        }
     
        private  void PopulateListBox(List<Car> c)
        {
            lstBox.Items.Clear();
            foreach (var cc in c)
            {
                lstBox.Items.Add(cc);
            }
            
        }
        private void PopulateManufacturer()
        {
            cbManu.Items.Add("all");
            cbManu.SelectedIndex = 0;
            foreach (var item in C)
            {
                if (!cbManu.Items.Contains(item.Manufacturer))
                {
                    cbManu.Items.Add(item.Manufacturer);
                }
            }
        }
        private void PopulateColor()
        {
            cbColor.Items.Add("all");
            cbColor.SelectedIndex = 0;
            foreach (var item in C)
            {
                if (!cbColor.Items.Contains(item.Color))
                {
                    cbColor.Items.Add(item.Color);
                }
            }
        }
        private void PopulateYear()
        {
            cbYear.Items.Add("all");
            cbYear.SelectedIndex = 0;
            foreach (var item in C)
            {
                if (!cbYear.Items.Contains(item.Year))
                {
                    cbYear.Items.Add(item.Year);
                }                
            }
        }

        private void btb_Click(object sender, RoutedEventArgs e)
        {

            cbColor.SelectedIndex = 0;
            cbManu.SelectedIndex= 0;
            cbYear.SelectedIndex = 0;
        }

        private void UpdatedFilter()
        {
            if (cbManu.SelectedValue is null|| cbColor.SelectedValue is null || cbYear.SelectedValue is null)
            {
                return;
            }

            List<Car> filteredCar;
            filteredCar = FilteredManu(C);
            filteredCar = FilteredColor(filteredCar);
           filteredCar = FilteredYear(filteredCar);
            PopulateListBox(filteredCar);
          

        }
        private List<Car> FilteredManu(List<Car> car)
        {
            string m = cbManu.SelectedValue.ToString();

            List<Car> filteredCar = new List<Car>();

            foreach (var item in car)
            {
                if (m.ToLower()=="all")
                {
                    filteredCar.Add(item);
                }
                else if (item.Manufacturer.Contains(m))
                {
                    filteredCar.Add(item);
                }
            }
            return filteredCar;
        }
        private List<Car> FilteredColor(List<Car> car)
        {
            string col = cbColor.SelectedValue.ToString();

            List<Car> filteredCar = new List<Car>();

            foreach (var item in car)
            {
                if (col.ToLower() == "all")

                {
                    filteredCar.Add(item);
                }
                else if (item.Color.Contains(col))
                {
                    filteredCar.Add(item);
                }
            }
            return filteredCar;
        }

        private List<Car> FilteredYear(List<Car> car)
        {
            string y = cbYear.SelectedValue.ToString();

            List<Car> filteredCar = new List<Car>();

            foreach (var item in car)
            {
                if (y.ToLower() == "all")
                {
                    filteredCar.Add(item);
                }
                else if (Convert.ToString(item.Year).Contains(y))
                {
                    filteredCar.Add(item);
                }
            }
            return filteredCar;
        }

        private void cbManu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatedFilter();
        }

        private void cbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatedFilter();
        }

       private void cbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatedFilter();

        }

       
    }
}
