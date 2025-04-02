using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab3 {
    public class pracownik : INotifyPropertyChanged {
        private int id;
        private string imie;
        private string nazwisko;
        private string wiek;
        private string stanowisko;
    
        public int _id {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }
        public string _imie {
            get => imie;
            set { imie = value; OnPropertyChanged(); }
        }
        public string _nazwisko {
            get => nazwisko;
            set { nazwisko = value; OnPropertyChanged(); }
        }
        public string _wiek {
            get => wiek;
            set { wiek = value; OnPropertyChanged(); }
        }
        public string _stanowisko {
            get => stanowisko;
            set { stanowisko = value; OnPropertyChanged(); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

