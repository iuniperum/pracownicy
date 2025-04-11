using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveUI;

namespace lab3;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public ObservableCollection<pracownik> pracownicy { get; } = new ObservableCollection<pracownik>();
    private string plik;

    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }
    public int liczba_pracownikow = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void dodaj(object sender, RoutedEventArgs e) { 
        dodawanie dod = new dodawanie(this);
        var result = await dod.ShowDialog<pracownik>(this); { 
            pracownicy.Add(result);
        }
    }
    private async void usun(object sender, RoutedEventArgs e) {
        if (zbior_pracownikow.SelectedItem is pracownik wybrany) {
            pracownicy.Remove(wybrany);
        }
    }
    private async void zapiscsv(object sender, RoutedEventArgs e) {
        var saveFileDialog = new SaveFileDialog();
        var result = await saveFileDialog.ShowAsync(this);
        if (result != null) {
            using (var stream = new StreamWriter(result)) { 
                foreach (var pracownik in pracownicy) { 
                    await stream.WriteLineAsync($"{pracownik._id},{pracownik._imie},{pracownik._nazwisko},{pracownik._wiek},{pracownik._stanowisko}");
                }
            }
        }
    }
    
    private async void odczytcsv(object sender, RoutedEventArgs e) {
        var saveFileDialog = new SaveFileDialog(); 
        var result = await saveFileDialog.ShowAsync(this);
        if (result != null) {
            using (var stream = new StreamReader(result)) { 
                while ((plik = await stream.ReadLineAsync()) != null)
                {
                    test.InnerRightContent = Convert.ToString(plik);
                    var dane = plik.Split(',');
                    pracownik nowy_pracownik = new pracownik {
                        _id = Convert.ToInt32(dane[0]), _imie = dane[1], _nazwisko = dane[2], _wiek = dane[3],
                        _stanowisko = dane[4]
                    };
                }
            }
        }
    }
} 