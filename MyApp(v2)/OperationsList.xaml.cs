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
    /// Логика взаимодействия для OperationsList.xaml
    /// </summary>
    public partial class OperationsList : Window
    {
        int userID = 0;
        string userName;


        public OperationsList(int id, string userNm)
        {
            userID = id;
            userName = userNm;
            InitializeComponent();
            LoadOperations();

        }

        public class Operations
        {
            public int Id { get; set; }
            public string Operation { get; set; }
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

        void LoadOperations()
        {
            
            SqlConnection sqlcon = new SqlConnection(@"data source=asus\sqlexpress;initial catalog=appdb;integrated security=true");
            string query = "SELECT operation_id, operation_name FROM dbo.Operations WHERE user_id= '" + userID +  "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            for (int i = 0; i < dtbl.Rows.Count; i++) // перебираем данные  
            {
                Operations dataUser = new Operations () // создаём экземпляр класса        
                {
                    Id = dtbl.Rows[i].Field<int>("operation_id"), // указываем изображение из таблицы    
                    Operation = dtbl.Rows[i].Field<string>("operation_name"), // указываем логин         
                    
                };
                listView.Items.Add(dataUser); // выводим строку в список 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow(userID, userName);
            addOperationWindow.Show();
            this.Close();
        }
    }
}
