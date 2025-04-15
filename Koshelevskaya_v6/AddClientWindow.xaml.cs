using Koshelevskaya_v6.DBModel;
using System;
using System.IO;
using System.Windows;

namespace Koshelevskaya_v6
{
    public partial class AddClientWindow : Window
    {
        private SchoolClientsDBEntities1 _context;
        private byte[] _photoBytes;

        public AddClientWindow(SchoolClientsDBEntities1 context)
        {
            InitializeComponent();
            _context = context;
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                photoPathText.Text = filePath;

                // Преобразование файла в массив байтов
                _photoBytes = File.ReadAllBytes(filePath);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            var client = new Clients
            {
                ClientName = nameTextBox.Text,
                ContactInfo = phoneTextBox.Text,
                Photo = _photoBytes
            };

            _context.Clients.Add(client);
            _context.SaveChanges();
            DialogResult = true;
            Close();
        }
    }
}