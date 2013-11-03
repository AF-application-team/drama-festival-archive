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

namespace AF_Desktop_Application
{
    /// <summary>
    /// Interaction logic for PropertiesWindow.xaml
    /// </summary>
    public partial class PropertiesWindow : Window
    {
        public const int ReadMode = 0;
        public const int EditMode = 1;
        public const int AddingMode = 2;

        private void CreateRows(Type T)
        {
            var props = T.GetProperties();
            foreach (var propertyInfo in props)
            {
            }

        }

        public PropertiesWindow(Type T)
        {
            InitializeComponent();

        }
    }
}
