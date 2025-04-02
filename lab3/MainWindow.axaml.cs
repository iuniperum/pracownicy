using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace lab3;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    public ObservableCollection<pracownik> pracownicy { get; } = new ObservableCollection<pracownik>();

    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }

    public dodawanie dod;
    private int liczba_pracownikow = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void klik(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            if (button.Content.ToString() == "Dodaj") {
                dod = new dodawanie(this);
                dod.Show();
                
            }
            if (button.Content.ToString() == "Usuń") {
                
            }
            if (button.Content.ToString() == "Zapis do .csv") {
                
            }
            if (button.Content.ToString() == "Odczyt z .csv") {
                
            }
        }
    }
} 

    
    