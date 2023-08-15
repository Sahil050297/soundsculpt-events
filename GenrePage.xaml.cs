using Microsoft.Maui.Controls;
using SoundSculptMaui; // Import the necessary namespace
using System;
using System.Collections.Generic;

namespace SoundSculptMaui
{
    public partial class GenrePage : ContentPage
    {
        private List<string> availableGenres = new List<string>(); // Initialize a list to hold available genres
        private DatabaseHelper dbHelper = new DatabaseHelper(); // Initialize a DatabaseHelper instance

        // Constructor for GenrePage class, called when the page is created
        public GenrePage()
        {
            InitializeComponent(); // Initialize the page's components
            FetchAvailableGenres(); // Fetch and display available genres
        }

        // Fetch and display available genres from the database
        private void FetchAvailableGenres()
        {
            List<string> availableGenres = dbHelper.GetGenres(); // Retrieve available genres
            AvailableGenresLabel.Text = string.Join(", ", availableGenres); // Display genres in the label
        }

        // Handle search button click event
        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string enteredGenre = GenreEntry.Text.Trim(); // Get the entered genre from the input

            // Validate the genre: Ensure it contains only letters
            if (!IsGenreValid(enteredGenre))
            {
                ValidationErrorLabel.Text = "Invalid genre. Please enter letters only."; // Display an error message for invalid genre
                ValidationErrorLabel.IsVisible = true; // Show the error label
                return; // Exit the method
            }

            ValidationErrorLabel.IsVisible = false; // Clear any previous error messages

            try
            {
                await Navigation.PushAsync(new ArtistPage(enteredGenre)); // Navigate to the ArtistPage with entered genre
            }
            catch (Exception ex)
            {
                // Handle exceptions here (e.g., database connection issues)
                Console.WriteLine($"Exception: {ex.Message}"); // Print the exception message to the console
            }
        }

        private bool IsGenreValid(string genre)
        {
            return !string.IsNullOrWhiteSpace(genre) && genre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

    }
}
