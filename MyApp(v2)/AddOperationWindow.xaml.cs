﻿using System;
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
    /// Логика взаимодействия для AddOperationWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
    {
        int userID = 0;
        string userName;

        public AddOperationWindow(int id, string userNm)
        {
            InitializeComponent();
            userName = userNm;
            userID = id;
        }
        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
            OperationsList operationsList = new OperationsList(userID, userName);
            operationsList.Show();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (operationNameBox.Text != null && userID != 0)
            {
                SqlConnection sqlcon = new SqlConnection(@"data source=asus\sqlexpress;initial catalog=appdb;integrated security=true");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT dbo.Operations (operation_name, user_id) VALUES ('" + operationNameBox.Text + "' , " + userID + ")";
                cmd.Connection = sqlcon;
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                operationNameBox.Clear();
                MessageBox.Show("Запись добавлена");
            }
            else MessageBox.Show("Вы не ввели ничего");
        }
    }
}
