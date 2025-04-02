using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using SkiaSharp;

namespace lab3;

public partial class dodawanie : Window


{
    MainWindow main_window;
    
    private string wybrane_stanowisko;
    public dodawanie(MainWindow okno)
    {
        InitializeComponent();
        main_window = okno;
    }
    private void wybor_stanowiska(object sender, RoutedEventArgs args)
    {
        if (STANOWISKA.SelectedItem is ListBoxItem item)
        {
            if (item.Content is StackPanel panel)
            {
                if (panel.Children[0] is TextBlock text)
                {
                    wybrane_stanowisko = Convert.ToString(text.Text);
                }
            }
        }
    }

    private void dodanie_pracownika(object sender, RoutedEventArgs args)
    {
        pracownik nowy_pracownik = new pracownik
        {
            _imie = IMIE.Text, _nazwisko = NAZWISKO.Text, _wiek = WIEK.Text, _stanowisko = wybrane_stanowisko
            
        }; Close(nowy_pracownik);
    }
}