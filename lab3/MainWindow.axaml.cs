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
        
    }
    private async void odczytcsv(object sender, RoutedEventArgs e) {
        
    }
} 

    
    