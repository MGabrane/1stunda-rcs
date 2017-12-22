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

namespace BuyList
{
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public ObservableCollection<string> BuyItemList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            BuyListItemName.Text = "";

            //Pasakām BuyListControl, ka jāizmanto mūsu saraksts,
            //rādāmolietu avots(j askatās no saraksta, ko radīt
            this.BuyItemsListControl.ItemsSource = this.BuyItemList;
        }

        private void AddListItemButton_Click(object sender, RoutedEventArgs e)
        {
            //Izvelkam vertību no teksta lauka
           string enteredItemToBuy = this.BuyListItemName.Text;

            //Nodzēasam ievadīto tekstu
            this.BuyListItemName.Text = "";

            //ierakstam iegūto vērtību teksta blokā
            this.BuyItemList.Add(enteredItemToBuy);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(@"C:\Users\Madza\Desktop\Code1_buyList", this.BuyItemList);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var todosFromEile = File.ReadAllLines(@"C:\Users\Madza\Desktop\Code1_buyList");
            for (int i = 0; 1<todosFromEile.Length; i++)
            {
                string curentTodo = todosFromEile[i];
                this.BuyItemList.Add(curentTodo);
            }
            MessageBox.Show("all tems have been loaded");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in this.BuyItemList.selectedItems)
            {
                this.BuyItemList.Remove(selectedItem as string);
            }
            
        }
    }
}
