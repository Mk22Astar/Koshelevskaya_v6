using Koshelevskaya_v6.DBModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Koshelevskaya_v6
{
    public partial class SpisokUslug : Page
    {
        private SchoolClientsDBEntities1 _context;
        private int _clientId;

        public SpisokUslug(int clientId)
        {
            InitializeComponent();
            _context = new SchoolClientsDBEntities1();
            _clientId = clientId;
            LoadServices(); 
        }

        private void LoadServices()
        {
            var services = _context.Services.Where(s => s.ClientID == _clientId).ToList();
            servicesGrid.ItemsSource = services; 
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            var addServiceWindow = new AddServiceWindow();
            if (addServiceWindow.ShowDialog() == true)
            {
                var service = new Services
                {
                    ClientID = _clientId,
                    ServiceName = addServiceWindow.ServiceName,
                    Description = addServiceWindow.Description
                };

                _context.Services.Add(service);
                _context.SaveChanges();
                LoadServices(); 
            }
        }
    }
}