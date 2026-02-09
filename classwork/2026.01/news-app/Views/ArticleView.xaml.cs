using System.Web;

namespace news_app.Views;

[QueryProperty("URL", "url")]
public partial class ArticleView : ContentPage
{
	public ArticleView()
	{
		InitializeComponent();
	}

	public string Url {
		set => BindingContext = new UrlWebViewSource {
			Url = HttpUtility.UrlDecode(value)
		};
	}
}