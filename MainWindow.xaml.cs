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

namespace WpfZadanie3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ilosc = 0;
        private string format = "format A5";
        private string gramatura = "80g/m²";
        private string kolor = "";
        private int rabacik = 0;
        private double cena_kartki = 0.2;
        private double bonus_za_kolorowe_kartki = 0;
        private double bonus_za_druk_w_kolorze = 0;
        private double bonus_za_druk_dwustronny = 0;
        private double bonus_za_lakier_uv = 0;
        private double bonus_za_gramature = 1;
        private int ekspres = 0;
        private double suma_ceny_kartki;
        private string kolor_bonus = "";
        private string dwustronny = "";
        private string lakier = "";
        private string termin = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AktualizacjaTekstu()
        {
            suma_ceny_kartki = ((cena_kartki + bonus_za_druk_dwustronny + bonus_za_druk_w_kolorze + bonus_za_kolorowe_kartki + bonus_za_lakier_uv) * bonus_za_gramature);
            Podsumowanie.Text = "Przedmiot zamówienia: " + ilosc + " szt., " + format + ", " + gramatura + kolor + kolor_bonus + dwustronny + lakier + termin + "\n";
            Podsumowanie.Text += "Cena przed rabatem: " + Math.Round((ilosc * suma_ceny_kartki) + ekspres,2) + "\n";
            Podsumowanie.Text += "Naliczony rabat: " + rabacik + " %" + "\n";
            Podsumowanie.Text += "Cena po rabacie: " + Math.Round((1 - (double)rabacik / 100) * ((suma_ceny_kartki * ilosc) + ekspres), 2) + "\n";
        }
        
        
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Checkbox.IsChecked == true)
            {
                kolor = ", kolor";
                bonus_za_kolorowe_kartki = 0.5 * cena_kartki;
                combobox.IsEnabled = true;
                AktualizacjaTekstu();
            }
            else
            {
                kolor = "";
                bonus_za_kolorowe_kartki = 0;
                combobox.IsEnabled = false;
                AktualizacjaTekstu();
            }
                


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Przyjęto zamówienie!");
            Checkbox.IsChecked = false;
            Slider.Value = 1;
            
            Opcja_1.IsChecked = true;
            Opcja_2.IsChecked = false;
            Opcja_3.IsChecked = false;
            Opcja_4.IsChecked = false;
            Dodatkowa_opcja_1.IsChecked = false;
            Dodatkowa_opcja_2.IsChecked = false;
            Dodatkowa_opcja_3.IsChecked = false;
            Wybor_1.IsChecked = true;
            Wybor_2.IsChecked = false;
            combobox.IsEnabled = false;
            combobox.SelectedValue = "";
            format = "format A5";
            gramatura = "80g / m²";
            kolor = "";
            kolor_bonus = "";
            dwustronny = "";
            lakier = "";
            termin = "";
            liczba.Text = "0";
            Podsumowanie.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int d;
            if(int.TryParse(liczba.Text.ToString(), out d))
            {
                ilosc = d;
                if(ilosc >=0 && ilosc < 100)
                {
                    rabacik = 0;
                }
                else if(ilosc >= 100 && ilosc < 1000)
                {
                    rabacik = ilosc / 100;
                }
                else if(ilosc >= 1000)
                {
                    rabacik = 10;
                }
                AktualizacjaTekstu();
            }
            else
            {
                MessageBox.Show("Podany napis musi być liczbą całkowitą!");
                ilosc = 0;
                liczba.Text = "0";
            }
           
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Podsumowanie!=null && Coś!=null)
            {
                switch (e.NewValue)
                {
                case 1:
                    cena_kartki = 0.2;
                    Coś.Content = "A5 - cena 20gr/szt.";
                    format = "format A5";
                    AktualizacjaTekstu();
                    break;
                case 2:
                    cena_kartki = 0.5;
                    Coś.Content = "A4 - cena 50gr/szt.";
                    format = "format A4";
                    AktualizacjaTekstu();
                    break;
                case 3:
                    cena_kartki = 1.25;
                    Coś.Content = "A3 - cena 1.25zł/szt.";
                    format = "format A3";
                    AktualizacjaTekstu();
                    break;
                case 4:
                    cena_kartki = 3.13;
                    Coś.Content = "A2 - cena 3.13zł/szt.";
                    format = "format A2";
                    AktualizacjaTekstu();
                    break;
                case 5:
                    cena_kartki = 7.81;
                    Coś.Content = "A1 - cena 7.81zł/szt.";
                    format = "format A1";
                    AktualizacjaTekstu();
                    break;
                case 6:
                    cena_kartki = 19.53;
                    Coś.Content = "A0 - cena 19.53zł/szt.";
                    format = "format A0";
                    AktualizacjaTekstu();
                    break;
                default:
                    AktualizacjaTekstu();
                    break;
                }
            }
            
                
            

            
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(Opcja_1.IsChecked == true)
            {
                gramatura = "80g / m²";
                bonus_za_gramature = 1;
                AktualizacjaTekstu();
            }

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (Opcja_2.IsChecked == true)
            {
                gramatura = "120g / m²";
                bonus_za_gramature = 2;
                AktualizacjaTekstu();
            }
            else
            {
                bonus_za_gramature = 1;
                AktualizacjaTekstu();
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            if (Opcja_3.IsChecked == true)
            {
                gramatura = "200g / m²";
                bonus_za_gramature = 2.5;
                AktualizacjaTekstu();
            }
            else
            {
                bonus_za_gramature = 1;
                AktualizacjaTekstu();
            }
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            if (Opcja_4.IsChecked == true)
            {
                gramatura = "240g / m²";
                bonus_za_gramature = 3;
                AktualizacjaTekstu();
            }
            else
            {
                bonus_za_gramature = 1;
                AktualizacjaTekstu();
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (Dodatkowa_opcja_1.IsChecked == true)
            {
                kolor_bonus = ", druk kolor";
                bonus_za_druk_w_kolorze = 0.3 * cena_kartki;
                AktualizacjaTekstu();
            }
            else
            {
                kolor_bonus = "";
                bonus_za_druk_w_kolorze = 0;
                AktualizacjaTekstu();
            }
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (Dodatkowa_opcja_2.IsChecked == true)
            {
                dwustronny = ", dwustronny";
                bonus_za_druk_dwustronny = 0.5 * cena_kartki;
                AktualizacjaTekstu();
            }
            else
            {
                dwustronny = "";
                bonus_za_druk_dwustronny =0;
                AktualizacjaTekstu();
            }
        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (Dodatkowa_opcja_3.IsChecked == true)
            {
                lakier = ", UV";
                bonus_za_lakier_uv = 0.2 * cena_kartki;
                AktualizacjaTekstu();
            }
            else
            {
                lakier = "";
                bonus_za_lakier_uv = 0;
                AktualizacjaTekstu();
            }
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            if(Wybor_1.IsChecked == true)
            {
                termin = "";
                ekspres=0;
                AktualizacjaTekstu();
            }
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            if (Wybor_2.IsChecked == true)
            {
                termin = ", ekspres";
                ekspres=15;
                AktualizacjaTekstu();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox.SelectedIndex == 0)
            {
                kolor = ", kolor - żółty";
                AktualizacjaTekstu();
            }
            else if (combobox.SelectedIndex == 1)
            {
                kolor = ", kolor - zielony";
                AktualizacjaTekstu();
            }
            if (combobox.SelectedIndex == 2)
            {
                kolor = ", kolor - niebieski";
                AktualizacjaTekstu();
            }
        }
    }
}
