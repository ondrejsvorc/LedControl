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
using System.IO.Ports;

namespace LedControl
{
    public partial class MainWindow : Window
    {
        SerialPort port;

        public MainWindow()
        {
            InitializeComponent();

            IsDeviceConnected();
            Config();
        }

        void IsDeviceConnected()
        {
            cmbPorts.ItemsSource = SerialPort.GetPortNames();

            if (cmbPorts.Items.Count == 0)
            {
                MessageBox.Show("No device was found.");
                this.Close();
            }
        }

        void Config()
        {
            cmbPorts.ItemsSource = SerialPort.GetPortNames();
            cmbPorts.SelectedIndex = 0;

            cmbBaudRates.SelectedIndex = 4;

            int[] baudRates = new int[]
            {
                300, 1200, 2400,
                4800, 9600, 19200,
                38400, 57600, 74880,
                115200, 230400, 250000,
                500000,  1000000, 2000000
            };

            foreach (int baudRate in baudRates)
            {
                cmbBaudRates.Items.Add(baudRate);
            }
        }

        private void LedState(object sender, RoutedEventArgs e)
        {
            if (btnState.Content.ToString() == "LED ON")
            {
                port.Write("1");
                ledLight.Fill = new SolidColorBrush(Color.FromRgb(247, 147, 147));

                btnState.Content = "LED OFF";
            }
            else
            {
                port.Write("0");
                ledLight.Fill = Brushes.Transparent;

                btnState.Content = "LED ON";
            }
        }

        private void PortChanged(object sender, SelectionChangedEventArgs e)
        {
            port = new SerialPort(cmbPorts.SelectedItem.ToString(), 9600);
            port.Open();
        }

        private void BaudRateChanged(object sender, SelectionChangedEventArgs e)
        {
            port.BaudRate = (int)cmbBaudRates.SelectedItem;

            if (ledLight.Fill == new SolidColorBrush(Color.FromRgb(247, 147, 147)))
            {
                ledLight.Fill = Brushes.Transparent;
                btnState.Content = "LED ON";
            }
        }

        private void WindowIsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                port.Write("0");
                port.Close();
            }
            catch { }
        }
    }
}
