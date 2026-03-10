using shop_app.Views;

namespace shop_app {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute("itemPage", typeof(ItemView));
        }
    }
}
