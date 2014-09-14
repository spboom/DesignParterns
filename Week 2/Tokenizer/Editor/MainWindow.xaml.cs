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

namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inputField.Text = "if(true)\r\n{\r\n\treturn true;\r\n}\r\nelse\r\n{\r\n\treturn false;\r\n}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tokenizer.Tokenize(inputField.Text);
        }
    }
}
