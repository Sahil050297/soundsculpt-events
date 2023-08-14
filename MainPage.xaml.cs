using Microsoft.Maui.Controls;

namespace SoundSculptMaui
{
    public partial class MainPage : ContentPage
    {
        // Constructor for MainPage class, called when the page is created
        public MainPage()
        {
            InitializeComponent(); // Initialize the page's components
        }

        // Handle start button click event
        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GenrePage()); // Navigate to the GenrePage when start button is clicked
        }
    }
}
