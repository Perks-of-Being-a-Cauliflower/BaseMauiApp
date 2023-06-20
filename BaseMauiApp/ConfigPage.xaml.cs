namespace BaseMauiApp
{
    public partial class ConfigPage : ContentPage
    {
        public bool autoNavigateToMain = true;
        public ConfigPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public string selectedEnv = "";

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (autoNavigateToMain)
            {
                autoNavigateToMain = false;
                //Navigation.PushAsync(new MainPage());
                Shell.Current.GoToAsync("MainPage");
            }
        }


        async void OnButtonPressed(object sender, EventArgs args)
        {
            autoNavigateToMain = false;

            await Shell.Current.GoToAsync("MainPage");
        }

    }
}