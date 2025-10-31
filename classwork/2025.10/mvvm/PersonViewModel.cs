using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mvvm {
    internal class PersonViewModel : INotifyPropertyChanged {
        User user = new User() { Name = "Ivan", Age = 20 };
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name {
            get => user.Name;
            set {
                if (user.Name != value) {
                    user.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age {
            get => user.Age;
            set {
                if (user.Age != value) {
                    user.Age = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string? prop = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
