using System;
using System.CodeDom.Compiler;
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

namespace MyApp_v2_
{
    /// <summary>
    /// Логика взаимодействия для CloseWindowMessage.xaml
    /// </summary>
    public partial class CloseWindowMessage : Window
    {
        int userID = 0;
        string userName, code;

        public CloseWindowMessage(int id, string userNm, string c)
        {
            InitializeComponent();
            userName = userNm;
            userID = id;
            code = c;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            CodeDomProvider provider = null;
            provider = code;

        }
    }
}
