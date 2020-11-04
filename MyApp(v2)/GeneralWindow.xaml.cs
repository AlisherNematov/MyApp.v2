using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для GeneralWindow.xaml
    /// </summary>
    public partial class GeneralWindow : Window
    {
        int userID = 0;
        string userName;
        
        public GeneralWindow(int id, string userNm)
        {

            InitializeComponent();
            userName = userNm;
            userID = id;
            helloBlock.Text = "Hello, mr " + userNm + " !";
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (userID != 0)
            {

                OperationsList operationsList = new OperationsList(userID, userName);
                operationsList.Show();
                this.Close();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AccountsListWindow accountsListWindow = new AccountsListWindow(userID, userName);
            accountsListWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
