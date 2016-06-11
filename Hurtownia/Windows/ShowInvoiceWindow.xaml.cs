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
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for ShowInvoiceWindow.xaml
    /// </summary>
    public partial class ShowInvoiceWindow : Window
    {
        private int _index;


        public ShowInvoiceWindow(int index)
        {
            this._index = index;
            InitializeComponent();
            Invoice currInvoice = Invoices.InvoicesList[_index];

        }
    }
}
