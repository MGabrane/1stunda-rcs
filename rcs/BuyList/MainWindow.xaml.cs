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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public ObservableCollection<string> BuyItemList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            BuyListItemName.Text = "Lūdzu ievadiet pirkumu";
            this.BuyItemList.Add("Āboli");
            this.BuyItemList.Add("Bumbierii");

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
    }
}
