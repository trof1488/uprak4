using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.pudgeDataSetTableAdapters;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        productsTableAdapter metahook = new productsTableAdapter();
        order_TableAdapter meathook_ = new order_TableAdapter();
       

        public MainWindow()
        {
            InitializeComponent();
            Daubi.ItemsSource = meathook_.GetData();
            box.ItemsSource = metahook.GetData();
            box.DisplayMemberPath = "Id_products";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {


            meathook_.InsertQuery ((int)(box.SelectedItem as DataRowView).Row[0], Convert.ToInt32(Texbx1.Text), Convert.ToInt32(Texbx2.Text));
            Daubi.ItemsSource = meathook_.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();

            
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (Daubi.SelectedItem as DataRowView).Row[0];
                meathook_.DeleteQuery(Convert.ToInt32(id));
                Daubi.ItemsSource = meathook_.GetData();
            }
            catch {
                MessageBox.Show("ОШИБКА!!!");           
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            object id = (Daubi.SelectedItem as DataRowView).Row[0];
            meathook_.UpdateQuery(Convert.ToInt32(id), Convert.ToInt32(Texbx1.Text), Convert.ToInt32(Texbx2.Text), Convert.ToInt32(id));
            Daubi.ItemsSource = meathook_.GetData();
        }

        private void Daubi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                Texbx1.Text = (Daubi.SelectedItem as DataRowView).Row[2].ToString();
                Texbx2.Text = (Daubi.SelectedItem as DataRowView).Row[3].ToString();
            }
            catch
            {
                Texbx1.Text = null;
                Texbx2.Text = null;
                

            }

        }
    }
   
}
