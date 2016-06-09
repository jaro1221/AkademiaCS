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

namespace Spotkanie5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> lista;
        public MainWindow()
        {
            InitializeComponent();
            lista = new List<Person>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Imie = this.textBox1.Text;
        }
    }
}
