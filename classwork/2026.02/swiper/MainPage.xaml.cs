using swiper.Controls;

namespace swiper
{
    public partial class MainPage : ContentPage
    {
        private int likeCount;
        private int denyCount;

        public MainPage()
        {
            InitializeComponent();
            AddInitialPhotos();
        }

        public void AddInitialPhotos() {
            for (int i = 0; i < 10; i++) {
                InsertPhoto();
            }
        }

        public void InsertPhoto() {
            var photo = new SwiperControl();
            photo.OnDeny += Handle_OnDeny;
            photo.OnLike += Handle_OnLike;

            this.MainGrid.Children.Insert(0, photo);
        }

        public void UpdateGui() {
            likeLabel.Text = likeCount.ToString();  
            denyLabel.Text = denyCount.ToString();
        }

        private void Handle_OnLike(object? sender, EventArgs e) {
            likeCount++;
            InsertPhoto();
            UpdateGui();
        }

        private void Handle_OnDeny(object? sender, EventArgs e) {
            denyCount++;
            InsertPhoto();
            UpdateGui();
        }
    }
}
