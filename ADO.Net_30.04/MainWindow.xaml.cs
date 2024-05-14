using System.Text;
using Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO.Net_30._04
{
    public partial class MainWindow : Window
    {

        private DBManager dbManager;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            dbManager = new DBManager("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (dbManager.TestConnection())
            {
                ConnectionStatusTextBox.Text = "Connected";
            }
            else
            {
                ConnectionStatusTextBox.Text = "Connection Failed";
            }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectionStatusTextBox.Text = "Disconnected";
        }
    }

    internal class MainViewModel
    {
        public MainViewModel()
        { }
    }
}
