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
using VehicleMonitor.Models.Entity;
using VehicleMonitor.Models.Binding;




namespace VehicleDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Vehicle> allVehicles;
        private Vehicle selectedVehicle = new Vehicle();
        public MainWindow()
        {
            InitializeComponent();
            AllVehicles();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void AllVehicles()

        {
            allVehicles = await Services.AllVehicles();
            VehiclesListView.ItemsSource = allVehicles;
        }

        private async void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
           
            var vehicleAddModel = new VehicleDetails
            {
                Humidity = double.Parse(AddVehicleHumidityTextBox.Text),
                Temperature = double.Parse(AddVehicleTemperatureTextBox.Text)
            };
            var addVehicleResponse = await Services.AddVehicle(vehicleAddModel);
            if (addVehicleResponse != null)
                MessageBox.Show($"{addVehicleResponse.Humidity} {addVehicleResponse.Temperature} has been added.");
            AllVehicles();
           
        }

        private void VehiclesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            selectedVehicle =(Vehicle)e.AddedItems[0];
            VehicleHumidityTextBox.Text = selectedVehicle.Humidity.ToString();
            VehicleTemperatureTextBox.Text = selectedVehicle.Temperature.ToString();
            ActionsPanel.Visibility = Visibility.Visible;
        }

        private void DeleteActionButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfirmationStackPanel.Visibility = Visibility.Visible;
        }

        private void UpdateActionButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Visible;
            VehicleHumidityTextBox.Text = selectedVehicle.Humidity.ToString();
            VehicleTemperatureTextBox.Text = selectedVehicle.Temperature.ToString();

        }

        private async void ConfirmDelete_Click(object sender, RoutedEventArgs e)
        {
            var vehicleDeleteResponse = await Services.DeleteVehicle(selectedVehicle.Id);
            MessageBox.Show(vehicleDeleteResponse);
            AllVehicles();
            DeleteConfirmationStackPanel.Visibility = Visibility.Hidden;

        }

        private void CancelDeleteAction_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfirmationStackPanel.Visibility = Visibility.Hidden;
        }

        private async void UpdateVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            var vehicleUpdateModel = new VehicleDetails   
            {
                Humidity = double.Parse(UpdateVehicleHumidityTextBox.Text),
                Temperature = double.Parse(UpdateVehicleTemperatureTextBox.Text)
            };

            var vehicleUpdateResponse = await Services.UpdateVehicle(vehicleUpdateModel, selectedVehicle.Id);
            if (vehicleUpdateResponse != null)
               AllVehicles();
            UpdateStackPanel.Visibility = Visibility.Hidden;

        }

        private void CancelUpdateVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateStackPanel.Visibility = Visibility.Hidden;

        }
    }
    }



