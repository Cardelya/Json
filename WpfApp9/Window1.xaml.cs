using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfApp9;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        
            public ObservableCollection<Peoples> IData = new ObservableCollection<Peoples>();

            Guid Guid = Guid.NewGuid();

           

            private void add_Click(object sender, RoutedEventArgs e)
            {
                Peoples peoples = new Peoples()
                {
                    Name = name.Text,
                    phonenumber = phone.Text,
                    Age = years.Text
                };

                IData.Add(peoples);


            }

            private void save_Click(object sender, RoutedEventArgs e)
            {
                string json = JsonSerializer.Serialize<ObservableCollection<Peoples>>(IData);

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Json files (*.json)|*.json";

                saveFileDialog.ShowDialog();
                if (string.IsNullOrEmpty(saveFileDialog.FileName))
                    return;
                File.WriteAllText(saveFileDialog.FileName, json);
            }

        }
    }



