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
using System.Windows.Shapes;
using System.Windows.Shapes;
using WpfApp1.pudgeDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        productsTableAdapter metahook = new productsTableAdapter();
        order_TableAdapter order = new order_TableAdapter();
        public Window1()
        {
            InitializeComponent();
            Daubi.ItemsSource = metahook.GetData();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            metahook.InsertQuery( Convert.ToInt32(Texbx1.Text), Convert.ToInt32(Texbx2.Text), Convert.ToInt32(Texbx2.Text));
            Daubi.ItemsSource = metahook.GetData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (Daubi.SelectedItem as DataRowView).Row[0];
                metahook.DeleteQuery(Convert.ToInt32(id));
                Daubi.ItemsSource = metahook.GetData();
            }
            catch
            {
                MessageBox.Show("ОШИБКА!!!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            object id = (Daubi.SelectedItem as DataRowView).Row[0];
            metahook.UpdateQuery(Convert.ToInt32(id), Convert.ToInt32(Texbx1.Text), Convert.ToInt32(Texbx2.Text), Convert.ToInt32(id));
            Daubi.ItemsSource = metahook.GetData();

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
