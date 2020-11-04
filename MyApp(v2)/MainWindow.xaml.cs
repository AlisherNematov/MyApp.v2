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
using System.Data.SqlClient;
using System.Data;

namespace MyApp_v2_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
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
            if(e.ChangedButton == MouseButton.Left)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LeftGrid.Visibility == Visibility.Hidden)
                LeftGrid.Visibility = Visibility.Visible;
            else
                LeftGrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RightGrid.Visibility == Visibility.Hidden)
                RightGrid.Visibility = Visibility.Visible;
            else
                RightGrid.Visibility = Visibility.Hidden;
        }

        private void OnPasswordChanged(object sender)
        {
            //    if(passwordBox.Text.Length > 0)
            //    {
            //        Watermark.Visibility = Visibility.Collapsed;
            //    }
            //    else
            //    {
            //        Watermark.Visibility = Visibility.Visible;
            //    }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"data source=asus\sqlexpress;initial catalog=appdb;integrated security=true");
            string query = "SELECT * FROM dbo.Users WHERE user_login= '" + loginBox.Text.Trim() + "' AND user_password  = '" + passwordBox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                //this.Hide();
                //this.WindowState = WindowState.Minimized;
                int id = dtbl.Rows[0].Field<int>("user_id");
                string userName = dtbl.Rows[0].Field<string>("user_name");
                GeneralWindow generalWindow = new GeneralWindow(id, userName);
                generalWindow.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Sorry(((");
            }
        }
    }
}
