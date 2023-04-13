using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using WpfApp9;


namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Peoples> IData = new ObservableCollection<Peoples>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Peoples s = ((Peoples)datagrid.SelectedItem);

            datagrid.Items.Remove(s);
        }

        private void openwindow_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();

            window1.Show();


        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.ShowDialog();
            if (string.IsNullOrEmpty(openFileDialog.FileName))
            {
                return;
            }
            string json = File.ReadAllText(openFileDialog.FileName);

            try
            {
                IData = JsonSerializer.Deserialize<ObservableCollection<Peoples>>(json);
                foreach (Peoples peoples in IData)
                {
                    datagrid.Items.Add(peoples);
                }
            }
            catch (System.Text.Json.JsonException)
            {
                MessageBox.Show("В json файле нет нужного формата");
            }


        }
    }
}
