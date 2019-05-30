using ExamWpf.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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

namespace ExamWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Earthquake> _earthquakes = new ObservableCollection<Earthquake>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EarthquakeSearchButtonClick(object sender, RoutedEventArgs e)
        {
            int earthquakeCount;

            if (int.TryParse(earthquakeCountTextBox.Text, out earthquakeCount))
            {
                _earthquakes.Clear();
                string result;

                using (var client = new WebClient())
                {
                    result = client.DownloadString($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit={earthquakeCount}");
                }

                EarthquakeData earthquakeData = JsonConvert.DeserializeObject<EarthquakeData>(result);

                foreach(var feature  in earthquakeData.Features)
                {
                    string featureResult;

                    try
                    {
                        using (var client = new WebClient())
                        {
                            featureResult = client.DownloadString(feature.FeatureProperty.Detail);
                        }

                        EarthquakeDetail earthquakeDetail = JsonConvert.DeserializeObject<EarthquakeDetail>(featureResult);

                        _earthquakes.Add(
                            new Earthquake()
                            {
                                Depth = earthquakeDetail.EarthquakeProperty.Products.Origin[0].OriginProperty.Depth,
                                EventTime = earthquakeDetail.EarthquakeProperty.Products.Origin[0].OriginProperty.EventTime.ToString("dd.MM.yyyy hh:mm:ss"),
                                Magnitude = feature.FeatureProperty.Mag,
                                Place = feature.FeatureProperty.Place
                            });
                    }
                    catch (WebException) { }
                }

                earthquakeDataGrid.ItemsSource = _earthquakes;
            }
            else
            {
                MessageBox.Show("Можно вводить только цифры");
                earthquakeCountTextBox.Text = string.Empty;
            }
        }
    }
}
