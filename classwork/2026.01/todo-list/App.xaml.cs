using Microsoft.Extensions.DependencyInjection;
using todo_list.Views;

namespace todo_list {
    public partial class App : Application {
        private readonly MainView mainView;
        public App(MainView mainView) {
            this.mainView = mainView;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(mainView));
        }
    }
}