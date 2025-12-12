using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace mvvm {
    internal partialx class MainViewModel : INotifyPropertyChanged {
        int count = 0;
        string textValue = "Click me";

        public string TextValue {
            get => textValue;
            set {
                textValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateTextCommand { get; set; }

        public MainViewModel() {
            UpdateTextCommand = new Command(UpdateText);
        }

        public void UpdateText() {
            count++;
            if (count == 1) {
                TextValue = $"Clicked {count} time";
            } else {
                TextValue = $"Clicked {count} times";
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? prop = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //[ObservableProperty]
        //ObservableCollection<Customer>? customers;

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(InitializeCommand))]
        //bool isInitialized;

        //[RelayCommand(CanExecute = nameof(CanInitialize))]
        //async Task InitializeAsync() {
        //    customers = new ObservableCollection<Customer>(
        //        await DummyService.GetCustomersAsync());
        //    isInitialized = true;
        //}

        //bool CanInitialize() => !isInitialized;
    }

    //public class Customer {
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    //public static class DummyService {
    //    public static async Task<IEnumerable<Customer>> GetCustomersAsync() {
    //        await Task.Delay(5000);
    //        return new List<Customer> {
    //            new Customer {Id = 1, Name = "Ivan"},
    //            new Customer {Id = 2, Name = "Vova"}
    //        };
    //    }
    //}
}
