using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pozeracze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public enum Kolory
    {
        Czerwony,
        Niebieski,
        Zielony,
        Zolty
    }

    public class Gracz
    {
        public Kolory Kolor { get; set; }
        private int pionkiMale;
        private int pionkiSrednie;
        private int pionkiDuze;
        public Gracz(Kolory kolor) 
        {
            Kolor = kolor; //tutaj daj kolor ktory zostanie wybrany w if()
            pionkiMale = 3;
            pionkiSrednie = 3;
            pionkiDuze = 3;
        }

        public Kolory get_Kolory()
        {
            return Kolor;
        }

        public int get_pionkiMale()
        {
            return pionkiMale;
        }

        public int get_pionkiSrednie()
        {
            return pionkiSrednie;
        }

        public int get_pionkiDuze()
        { 
            return pionkiDuze;
        }

        
    }



    public class Pole_planszy
    {
        public Pole_planszy() 
        {
        
        }
    }


    public class Plansza
    {
        public Plansza()
        {

        }
    }



    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] plansza = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        int aktywnyGracz = 1;



        public void Button_Click(object sender, RoutedEventArgs e)
        {   

            var kolorGr1 = radioKolory1.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            var rodzajPlanszy = radioPlansza.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);
            var kolorGr2 = radioKolory2.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

            MessageBox.Show($"Wybrano: {kolorGr1.Content}");
            MessageBox.Show($"Wybrano: {rodzajPlanszy.Content}");
            MessageBox.Show($"Wybrano: {kolorGr2.Content}");


            menuGlowne.Visibility = Visibility.Collapsed;
            gra4x4.Visibility = Visibility.Visible;

            //Gracz gracz1 = new Gracz(MapujKolor(kolorGr1.Content.ToString()));
            //Gracz gracz2 = new Gracz(MapujKolor(kolorGr2.Content.ToString()));
        }

        private void klikniecie(object sender, RoutedEventArgs e)
        {

            Button btn = e.Source as Button;

            string xd = btn.Name.ToString();

            string pionekGracza1 = "";
            string pionekGracza2 = "";

            //MessageBox.Show(xd);

            foreach (RadioButton r in pionki1Grid.Children)
            {
                if (r.IsChecked == true)
                {
                    pionekGracza1 = r.Content.ToString();
                }

            }

            foreach (RadioButton r in pionki2Grid.Children)
            {
                if (r.IsChecked == true)
                {
                    pionekGracza2 = r.Content.ToString();
                }

            }

            if (pionekGracza1 == "male")
            {
                btn.Content = "1";
            }
            else if (pionekGracza1 == "srednie")
            {
                btn.Content = "2";
            }
            else if (pionekGracza1 == "duze")
            {
                btn.Content = "3";
            }

            //MessageBox.Show(pionekGracza1);
            //MessageBox.Show(pionekGracza2);

        }

        private Kolory mapujKolor(string nazwaKoloru)
        {
            return nazwaKoloru switch
            {
                "Czerwony" => Kolory.Czerwony,
                "Niebieski" => Kolory.Niebieski,
                "Zielony" => Kolory.Zielony,
                "Zolty" => Kolory.Zolty,
                _ => throw new ArgumentException("Nieznany kolor")
            };
        }

    }
}