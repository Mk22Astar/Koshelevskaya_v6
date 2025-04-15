using Koshelevskaya_v6.DBModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Koshelevskaya_v6
{
    public partial class Klienti : Page
    {
        private SchoolClientsDBEntities1 _context;

        public Klienti()
        {
            InitializeComponent();
            _context = new SchoolClientsDBEntities1();
            LoadClients(); 
        }

        private void LoadClients(string sortBy = "NameAsc")
        {
            IQueryable<Clients> query = _context.Clients;

            
            switch (sortBy)
            {
                case "NameAsc":
                    query = query.OrderBy(c => c.ClientName);
                    break;
                case "NameDesc":
                    query = query.OrderByDescending(c => c.ClientName);
                    break;
                default:
                    query = query.OrderBy(c => c.ClientID); 
                    break;
            }

            var clients = query.ToList();
            agentGrid.ItemsSource = clients; 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string tag = selectedItem.Tag?.ToString();
                LoadClients(tag); 
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow(_context);
            if (addClientWindow.ShowDialog() == true)
            {
                LoadClients(); 
            }
        }

        private void agentGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (agentGrid.SelectedItem is Clients selectedClient)
            {
               
                NavigationService.Navigate(new SpisokUslug(selectedClient.ClientID));
            }
        }
    }
}