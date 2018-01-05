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

namespace ToDo
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows.Input;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<string> ToDoList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            toDoListName.Text = "";
            this.ToDoListControl.ItemsSource = this.ToDoList;

        }

        private void AddListToDoButton_Click(object sender, RoutedEventArgs e)
        {
            //Izvelkam vertību no teksta lauka
            string enteredThingsToDo = this.toDoListName.Text;

            //Nodzēasam ievadīto tekstu
            this.toDoListName.Text = "";

            //ierakstam iegūto vērtību teksta blokā
            this.ToDoList.Add(enteredThingsToDo);
        }

        private void DeleteToDoButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedThingsToDo = this.ToDoListControl.SelectedItems;
            for (int i = 0; i < selectedThingsToDo.Count; i++)
            {
                var selectedThing = selectedThingsToDo[i] as string;
                this.ToDoList.Remove(selectedThing);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var todosFromFile = File.ReadAllLines(@"C:\Users\Madza\Desktop\Code1_buyList");

            this.ToDoList.Add(todosFromFile);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllLines(@"C:\Users\Madza\Desktop\Code1_buyList", this.ToDoList);
        }

        private void toDoListName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.ToDoList.Add(this.toDoListName.Text);
                //pārskata teksta lauka struktūru ar tukšumu (t.i.nodzēš lauku)
                this.toDoListName.Text = "";
            }
        }
    }
}
