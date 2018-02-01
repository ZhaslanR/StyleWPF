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
    /// Логика взаимодействия для ItemControl.xaml
    /// </summary>
    public partial class ItemControl : UserControl
    {
        private string itemName { get; set; }
        public event Action SomethingChanged;
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                countBlock.Text = count.ToString();
                SomethingChanged?.Invoke();
            }
        }
        public ItemControl(Action action)
        {
            InitializeComponent();
            itemName = nameBox.Text;
            SomethingChanged += action;
            Count = 0;
        }

        private void plusCountButton_Click(object sender, RoutedEventArgs e)
        {
            Count++;
        }
    }
}
