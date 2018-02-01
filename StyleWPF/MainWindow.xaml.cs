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

namespace StyleWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ItemControl> items;
        public MainWindow()
        {
            InitializeComponent();
            items = new List<ItemControl>();
            listBox.ItemsSource = items;
        }
        private void Change()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = items;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                items.Add(new ItemControl(Change));
            }
            else
            {
                int count;
                if (int.TryParse(countTextBox.Text, out count))
                {
                    (listBox.SelectedItem as ItemControl).Count += count;
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }
            }
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                items.Remove(listBox.SelectedItem as ItemControl);
            }
        }
        private void deleteCountButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                int count;
                if (int.TryParse(countTextBox.Text, out count))
                {
                    if ((listBox.SelectedItem as ItemControl).Count - count >= 0)
                    {
                        (listBox.SelectedItem as ItemControl).Count -= count;
                    }
                    else
                    {
                        MessageBox.Show("Нет такого количества предметов");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }
            }
        }
    }
}
