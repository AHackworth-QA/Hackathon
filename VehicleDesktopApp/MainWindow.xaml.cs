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
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;
using System.Threading;

namespace VehicleDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;
        private List<Vehicle> allVehicles;
        private Vehicle selectedVehicle = new Vehicle();
        private VehiclePos selectedVehiclePos = new VehiclePos();
        public MainWindow()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44342/vehiclehub")
                .WithAutomaticReconnect(new RandomRetryPolicy())
                .Build();
            connection.Reconnecting += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Reconnecting);
                return Task.CompletedTask;
            };
            connection.Reconnected += connectionId =>
            {
                Debug.Assert(connection.State == HubConnectionState.Connected);
                return Task.CompletedTask;
            };
            connection.Closed += error =>
            {
                Debug.Assert(connection.State == HubConnectionState.Disconnected);
                return Task.CompletedTask;
            };

            AllVehicles();

        }

        public static async Task<bool> ConnectWithRetryAsync(HubConnection connection, CancellationToken token)
        {
            while (true)
            {
                try
                {
                    await connection.StartAsync(token);
                    Debug.Assert(connection.State == HubConnectionState.Connected);
                    return true;
                }
                catch when (token.IsCancellationRequested)
                {
                    return false;
                }
                catch
                {
                    Debug.Assert(connection.State == HubConnectionState.Disconnected);
                    await Task.Delay(3000);
                }
            }
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
            if (e.AddedItems.Count >= 1)
            {
                selectedVehicle = (Vehicle)e.AddedItems[0];
                VehicleHumidityTextBox.Text = selectedVehicle.Humidity.ToString();
                VehicleTemperatureTextBox.Text = selectedVehicle.Temperature.ToString();
                ActionsPanel.Visibility = Visibility.Visible;
            }
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
            VehicleLatitudeTextBox.Text = selectedVehicle.Positions.ToString();
            VehicleLongitudeTextBox.Text = selectedVehicle.Positions.ToString();




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



        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            
                await connection.StartAsync();

                connectButton.IsEnabled = false;

            

            }

        private void VehicleHumidityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            var Humidity = double.Parse(VehicleHumidityTextBox.Text);
            if (Humidity >= 21 && Humidity <= 40)
            {
                VehicleHumidityTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 0, 255, 0));
            }
            else if (Humidity > 40 && Humidity <= 60)
            {
                VehicleHumidityTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 255, 255, 0));
            }
            else
            {
                VehicleHumidityTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 255, 0, 0));
            }
            

        }

        private void VehicleTemperatureTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Temperature = double.Parse(VehicleTemperatureTextBox.Text);
            if (Temperature >= -15 && Temperature <= 15)
            {
                VehicleTemperatureTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 0, 255, 0));
            }
            else if (Temperature > -60  && Temperature <=25)
            {
                VehicleTemperatureTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 255, 255, 0));
            }
            else 
            {
                VehicleTemperatureTextBox.Background = new SolidColorBrush(Color.FromArgb(200, 255, 0, 0));
            }

        }

       // private void UpdateVehicleGpsButton_Click(object sender, RoutedEventArgs e)
       // {
          //  {
             //   var vehicleGpsUpdateModel = new VehiclePosDetails
             //   {
                 //   Longitude = double.Parse(UpdateVehicleLongitudeTextBox.Text),
                 //   Latitude = double.Parse(UpdateVehicleLatitudeTextBox.Text),
                 //   VehicleId = selectedVehiclePos.Id
              //  };

               // var vehicleGpsUpdateResponse = await Services.UpdateVehicleGps(vehicleGpsUpdateModel, selectedVehiclePos.Id);
              //  if (vehicleGpsUpdateResponse != null)
                //    AllVehicles();
              //  UpdateStackPanel.Visibility = Visibility.Hidden;

           // }
       // }
        // HubConnection.On<Alert>("RecieveAlert", (alert)) =>
        //  {
        // this.Dispatcher.Invoke(() =>
        // {







    }
    }



