using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Platform;

namespace practice7 {
    internal class DataViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        public IEnumerable<Sex> Sexes { get; set; } = Enum.GetValues<Sex>();
        private Data data = new Data();
        public ICommand saveCommand { get; }
        public DataViewModel() {
            saveCommand = new AsyncRelayCommand(SaveToFile);
        }
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async Task SaveToFile() {
            using (FileStream fs = new FileStream("out.txt", FileMode.Append, FileAccess.Write)) {
                using StreamWriter writer = new StreamWriter(fs);
                await writer.WriteLineAsync(data.ToString());
            }
            await Application.Current.MainPage.DisplayAlert("Успех", "Запись добавлена в файл out.txt", "ОК");
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
