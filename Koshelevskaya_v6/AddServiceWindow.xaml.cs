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
using System.Windows.Shapes;


namespace Koshelevskaya_v6
{
    public partial class AddServiceWindow : Window
    {
        public string ServiceName { get; private set; }
        public string Description { get; private set; }

        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serviceNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название услуги.");
                return;
            }

            ServiceName = serviceNameTextBox.Text;
            Description = descriptionTextBox.Text;
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
