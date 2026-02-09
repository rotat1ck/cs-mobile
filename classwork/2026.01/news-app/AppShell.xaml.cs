using news_app.Views;

namespace news_app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("articleview", typeof(ArticleItem));
        }
    }
}
