
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace navigation {
    internal class User : INotifyPropertyChanged {
        string name = "";
        int age;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Name {
            get => name;
            set {
                if (name != value) {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age {
            get => age;
            set {
                if (age != value) {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
