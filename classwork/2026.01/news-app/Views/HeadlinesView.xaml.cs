using news_app.ViewModels;

namespace news_app.Views;

public partial class HeadlinesView : ContentPage {
	private readonly HeadlinesViewModel viewModel;
	
	public HeadlinesView(HeadlinesViewModel viewModel) {
		this.viewModel = viewModel;
		Task.Run(async () => await Initialize(GetScopeFromRoute()));
        InitializeComponent();
    }

    private async Task Initialize(string scope) {
		BindingContext = viewModel;
		await viewModel.Initialize(scope);
	}

	private string GetScopeFromRoute() {
		var route = Shell.Current.CurrentState.Location
			.OriginalString.Split("/").LastOrDefault();
		return route;
	}
}