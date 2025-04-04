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
    private int liczba_pracownikow = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void klik(object sender, RoutedEventArgs e) {
        if (sender is Button button) {
            if (button.Content.ToString() == "Dodaj") {
                
                
                dodawanie dod = new dodawanie(this);
                var result = await dod.ShowDialog<pracownik>(this); {
                    pracownicy.Add(result);
                }
                
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

    
    