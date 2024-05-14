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

        private readonly DBManager _dbManager;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            _dbManager = new DBManager(connectionString);

            RefreshData();
        }

        private void InsertData_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string type = txtType.Text;
            string color = txtColor.Text;
            int calories;
            if (!int.TryParse(txtCalories.Text, out calories))
            {
                MessageBox.Show("Please enter a valid number for calories.");
                return;
            }

            bool success = _dbManager.InsertData(name, type, color, calories);

            if (success)
            {
                MessageBox.Show("Data inserted successfully.");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Error occurred while inserting data.");
            }
        }

        private void RefreshData()
        {
            var dataList = _dbManager.SelectAllData();
            dataListView.ItemsSource = dataList;
        }
    }
}