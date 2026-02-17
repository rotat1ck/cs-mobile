using swiper.Utils;

namespace swiper.Controls;

public partial class SwiperControl : ContentView
{
	private readonly double initialRotation;
	private static readonly Random random = new Random();

	private double screenWidth = -1;

	private const double DeadZone = 0.4d;
	private const double DecisionThreshold = 0.4d;

	public event EventHandler OnLike;
	public event EventHandler OnDeny; 
	public SwiperControl()
	{
		InitializeComponent();

		var picture = new Picture();
		descriptionLabel.Text = picture.Description;
		image.Source = new UriImageSource { Uri = picture.Uri };

		loadingLabel.SetBinding(IsVisibleProperty, "IsLoading");
		loadingLabel.BindingContext = image;

		var panGesture = new PanGestureRecognizer();
		panGesture.PanUpdated += OnPanUpdated;
		this.GestureRecognizers.Add(panGesture);

		initialRotation = random.Next(-10, 10);
		photo.RotateTo(initialRotation, 100, Easing.SinOut);
	}

    protected override void OnSizeAllocated(double width, double height) {
        base.OnSizeAllocated(width, height);
		if (Application.Current.MainPage == null) {
			return;
		}

		screenWidth = Application.Current.MainPage.Width;
    }

	private void CalculatePanState(double panX) {
		var width = screenWidth == -1 ? 400 : screenWidth;
		var halfScreenWidth = width / 2;
		var deadZoneEnd = DeadZone * halfScreenWidth;

		if (Math.Abs(panX) < deadZoneEnd) {
			return;
		}

		var passedDeadZone = panX < 0 ? panX + deadZoneEnd : panX - deadZoneEnd;
		var decisionZoneEnd = DecisionThreshold * halfScreenWidth;
		var opacity = passedDeadZone / deadZoneEnd;

		opacity = double.Clamp(opacity, -1d, 1d);
		likeStackLayout.Opacity = opacity;
		denyStackLayout.Opacity = -opacity;
    }

	private bool CheckForExitCriteria() {
		var width = screenWidth == -1 ? 400 : screenWidth;
		var halfScreenWidth = width / 2;
		var decisionBreakpoint = DeadZone * halfScreenWidth;

		return (Math.Abs(photo.TranslationX) > decisionBreakpoint);
	}

	private void Exit() {
		MainThread.BeginInvokeOnMainThread(async () => {
			var direction = photo.TranslationX < 0 ? -1 : 1;
			if (direction > 0) {
				OnLike?.Invoke(this, new EventArgs());
			}
			
			if (direction < 0) {
				OnDeny?.Invoke(this, new EventArgs());
			}

			await photo.TranslateTo(photo.TranslationX + (screenWidth * direction),
				photo.TranslationY, 200, Easing.CubicIn);
			var parent = Parent as Layout;
			parent?.Children.Remove(this);
		});
	}

	private void OnPanUpdated(object sender, PanUpdatedEventArgs e) {
		switch (e.StatusType) {
			case GestureStatus.Started:
				PanStarted();
				break;
            case GestureStatus.Running:
                PanRunning(e);
                break;
            case GestureStatus.Completed:
                PanCompleted();
                break;
        }
	}

	private void PanStarted() {
		photo.ScaleTo(1.1, 100);
	}

	private void PanRunning(PanUpdatedEventArgs e) {
		photo.TranslationX = e.TotalX;
		photo.TranslationY = e.TotalY;
		photo.Rotation = initialRotation + (photo.TranslationX / 25);
		CalculatePanState(e.TotalX);
	}

	private void PanCompleted() {
		if (CheckForExitCriteria()) {
			Exit();
		}

		likeStackLayout.Opacity = 0;
		denyStackLayout.Opacity = 0;

		photo.TranslateTo(0, 0, 250, Easing.SpringOut);
		photo.RotateTo(initialRotation, 250, Easing.SpringOut);
		photo.ScaleTo(1, 250);
	}
}