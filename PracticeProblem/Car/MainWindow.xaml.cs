using System;
using System.Collections.Generic;
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

namespace Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btb_Click(object sender, RoutedEventArgs e)
        {
            string Manufacturer, Color, Mileage,year;

            int Y = 0;
            double M = 0;
            Manufacturer = txtMan.Text;
            Color = txtColor.Text;
            Mileage = txtMil.Text;
            year = txtYear.Text;

            if (string.IsNullOrEmpty(Manufacturer)==true)
            {
                MessageBox.Show("Sorry that is an invaild Manufacturer");
            }
            if (string.IsNullOrEmpty(Color)==true)
            {
                MessageBox.Show("Sorry that is an invaild Color");
            }

            if (int.TryParse(year, out Y)==false)
            {
                MessageBox.Show("Sorry that is an invaild ");
            }
            if (double.TryParse(Mileage, out M)==false)
            {
                MessageBox.Show("Sorry that is a invaild mileage");
            }

            lstBox.Items.Add($"{Manufacturer}:{Color},{Mileage},{year}");

        }
    }
}
