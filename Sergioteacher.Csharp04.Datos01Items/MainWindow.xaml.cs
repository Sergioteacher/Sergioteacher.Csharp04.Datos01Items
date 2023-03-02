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
using System.Reflection;

namespace Sergioteacher.Csharp04.Datos01Items
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<TodosLosItems> items = new List<TodosLosItems>();
            items.Add(new TodosLosItems() { Titulo = "Completado el tutorial 6 WPF", Completacion = 45 });
            items.Add(new TodosLosItems() { Titulo = "Aprender C# tema1", Completacion = 80 });
            items.Add(new TodosLosItems() { Titulo = "Lavar el coche 01", Completacion = 0 });
            items.Add(new TodosLosItems() { Titulo = "Completado el tutorial 7 WPF", Completacion = 55 });
            items.Add(new TodosLosItems() { Titulo = "Aprender C# tema2", Completacion = 60 });
            items.Add(new TodosLosItems() { Titulo = "Lavar el coche 02", Completacion = 0 });
            items.Add(new TodosLosItems() { Titulo = "Completado el tutorial 8 WPF", Completacion = 65 });
            items.Add(new TodosLosItems() { Titulo = "Aprender C# tema3", Completacion = 40 });
            items.Add(new TodosLosItems() { Titulo = "Lavar el coche 03", Completacion = 0 });
            items.Add(new TodosLosItems() { Titulo = "Completado el tutorial 9 WPF", Completacion = 95 });
            items.Add(new TodosLosItems() { Titulo = "Aprender C#  tema4", Completacion = 20 });
            items.Add(new TodosLosItems() { Titulo = "Lavar el coche 04", Completacion = 0 });

            UnaRistra.ItemsSource = items;
            LunaLista.ItemsSource = items;
            Clista.ItemsSource = items;
            Ccolor.ItemsSource = typeof(Colors).GetProperties();
        }

        private void BItem_Click(object sender, RoutedEventArgs e)
        {
            SLista.Visibility = Visibility.Visible;
            LunaLista.Visibility = Visibility.Hidden;
            SPaux1.Visibility = Visibility.Hidden;
            SPaux2.Visibility = Visibility.Hidden;
            Clista.Visibility = Visibility.Hidden;
            Ccolor.Visibility = Visibility.Hidden;
            LlimpiaColor.Visibility = Visibility.Hidden;
            Tdebug1.Text = "sólo muestra";
            Tdebug2.Text = "";
            Tdebug3.Text = "";
        }

        private void BList_Click(object sender, RoutedEventArgs e)
        {
            SLista.Visibility = Visibility.Hidden;
            LunaLista.Visibility = Visibility.Visible;
            SPaux1.Visibility = Visibility.Visible;
            SPaux2.Visibility = Visibility.Visible;
            Clista.Visibility = Visibility.Hidden;
            Ccolor.Visibility = Visibility.Hidden;
            LlimpiaColor.Visibility = Visibility.Hidden;
            Tdebug1.Text = "iniciando ...";
            Tdebug2.Text = "";
            Tdebug3.Text = "";
        }

        private void BCombo_Click(object sender, RoutedEventArgs e)
        {
            SLista.Visibility = Visibility.Hidden;
            LunaLista.Visibility = Visibility.Hidden;
            SPaux1.Visibility = Visibility.Hidden;
            SPaux2.Visibility = Visibility.Hidden;
            Clista.Visibility = Visibility.Visible;
            Ccolor.Visibility = Visibility.Visible;
            LlimpiaColor.Visibility = Visibility.Visible;
            Tdebug1.Text = "ComboBox ...";
            Tdebug2.Text = "";
            Tdebug3.Text = "";

        }

        private void LunaLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object var in LunaLista.SelectedItems)
            {
                /*
                 * los objetos seleccionados se muestran:
                 * 
                *MessageBox.Show((var as TodosLosItems).Titulo);
                * equivale a
                *MessageBox.Show(((TodosLosItems) var).Titulo);
                */
            if (LunaLista.SelectedIndex == -1) 
                {
                    Tdebug1.Text = "Na de na...";
                    Tdebug2.Text = "";
                    Tdebug3.Text = "";
                }
                else 
                {
                    Tdebug1.Text = (var as TodosLosItems).Titulo;
                    Tdebug2.Text = (var as TodosLosItems).Completacion.ToString() + "%";
                    Tdebug3.Text = LunaLista.SelectedIndex.ToString() + "/" + (LunaLista.Items.Count - 1).ToString();
                }
                
            }
        }

        private void Llimpia_MouseMove(object sender, MouseEventArgs e)
        {
            LunaLista.SelectedIndex = -1;
            Tdebug1.Text = "Na de na...";
            Tdebug2.Text = "";
            Tdebug3.Text = "";
        }

        private void CMultiple_Click(object sender, RoutedEventArgs e)
        {
            if (CMultiple.IsChecked == true) 
            {
                Btodo.IsEnabled = true;
                LunaLista.SelectionMode = SelectionMode.Extended;
                
            }
            else 
            {
                Btodo.IsEnabled = false;
                LunaLista.SelectionMode = SelectionMode.Single;
                LunaLista.SelectedIndex = -1;
                Tdebug1.Text = "Na de na...";
                Tdebug2.Text = "";
                Tdebug3.Text = "";
            }
        }

        private void Bselecion_Click(object sender, RoutedEventArgs e)
        {
            string sms="";
            //foreach (object var in LunaLista.Items)
            foreach (object var in LunaLista.SelectedItems)
            {
                sms = sms + (var as TodosLosItems).Titulo;
                sms = sms +  "\n";
            }
            MessageBox.Show(sms,"La selección es:");
        }

        private void Btodo_Click(object sender, RoutedEventArgs e)
        {
            LunaLista.SelectedIndex = -1;
            foreach (object var in LunaLista.Items)
                LunaLista.SelectedItems.Add(var);
            LunaLista.Focus();
        }

        private void Bantes_Click(object sender, RoutedEventArgs e)
        {
            if (LunaLista.SelectedIndex > -1)
            {
                LunaLista.SelectedIndex = LunaLista.SelectedIndex - 1;
                LunaLista.Focus();
            }
        }

        private void Bnext_Click(object sender, RoutedEventArgs e)
        {
            if(LunaLista.SelectedIndex < (LunaLista.Items.Count - 1))
                LunaLista.SelectedIndex++ ;
            LunaLista.Focus();
        }

        private void Bcoche_Click(object sender, RoutedEventArgs e)
        {
            foreach(object var in LunaLista.Items)
            {
                if ((var is TodosLosItems) && ((var as TodosLosItems).Titulo.Contains("coche") ) ) 
                {
                    LunaLista.SelectedItem = var;
                    break;
                }
            }
        }

        private void Clista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tdebug1.Text = (Clista.SelectedItem as TodosLosItems).Titulo ;
            Tdebug2.Text = (Clista.SelectedItem as TodosLosItems).Completacion.ToString() + "%";
        }

        private void LlimpiaColor_MouseMove(object sender, MouseEventArgs e)
        {
            Ventana1.Background = LlimpiaColor.Background;
            //Ccolor.Text = "" ;
            Ccolor.SelectedIndex = -1;
        }

        private void Ccolor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Ventana1.Background = Brushes.AliceBlue;
            if (Ccolor.SelectedIndex != -1) 
            {
                Color colorselecionado = (Color)(Ccolor.SelectedItem as PropertyInfo).GetValue(Ccolor, null);
                Ventana1.Background = new SolidColorBrush(colorselecionado);
            }
        }
    }

    public class TodosLosItems 
    { 
        // Al trabajar con datos complejos, hay que indicar el tipo para acceder a las variables.
        public string Titulo { get; set; }
        public int Completacion { get; set; }
    }
}
