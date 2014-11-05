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
        Compiler c = new Compiler();
        LinkedList<Node> compiledList;

        public MainWindow()
        {
            InitializeComponent();
            inputField.Text = "x = 10;\r\n\nif(x < 5)\r\n{\r\nx = 1;\r\n}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            compiledList = c.Compile(Tokenizer.Tokenize(inputField.Text));
            
            foreach (Node node in compiledList)
            {
                Console.WriteLine(node.GetType());
            }
        }
    }
}
