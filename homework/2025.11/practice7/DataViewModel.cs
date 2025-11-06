using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace practice7 {
    internal class DataViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        public IEnumerable<Sex> Sexes { get; set; } = Enum.GetValues<Sex>();
        private Data data = new Data();
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async Task SaveToFile() {
            using (FileStream fs = new FileStream("out.txt", FileMode.Append, FileAccess.Write)) {
                using StreamWriter writer = new StreamWriter(fs);
                await writer.WriteLineAsync(data.ToString());
            }
        }

        public string LastName {
            get => data.LastName;
            set {
                data.LastName = value;
                OnPropertyChanged();
            }
        }
        public string FirstName {
            get => data.FirstName;
            set {
                data.FirstName = value;
                OnPropertyChanged();
            }
        }
        public string MiddleName {
            get => data.MiddleName;
            set {
                data.MiddleName = value;
                OnPropertyChanged();
            }
        }
        public Sex Sex {
            get => data.Sex;
            set {
                data.Sex = value;
                OnPropertyChanged();
            }
        }
        public DateOnly BirthDate {
            get => data.BirthDate;
            set {
                data.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public bool IsMarried {
            get => data.IsMarried;
            set {
                data.IsMarried = value;
                OnPropertyChanged();
            }
        }
        public string? AdditionalInfo {
            get => data.AdditionalInfo;
            set {
                data.AdditionalInfo = value;
                OnPropertyChanged();
            }
        }
    }
}
