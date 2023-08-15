using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace SoundSculptMaui
{
    public partial class ArtistPage : ContentPage
    {
        private string selectedGenre;
        private DatabaseHelper dbHelper = new DatabaseHelper();

        // Constructor for ArtistPage class, called when a genre is provided
        public ArtistPage(string genre)
        {
            InitializeComponent();

            // Store the selected genre to be used within the class
            selectedGenre = genre;

            // Load artists associated with the selected genre
            LoadArtists();
        }

        // Load artists based on the selected genre
        private void LoadArtists()
        {
            // Retrieve a list of artists with additional details from the database for the selected genre
            List<ArtistDetails> artistDetailsList = dbHelper.GetArtistDetailsByGenre(selectedGenre);

            // Set the list of artist details as the data source for the ListView
            ArtistListView.ItemsSource = artistDetailsList;

            // Check if no artists were found for the selected genre
            if (artistDetailsList.Count == 0)
            {
                // Display a label indicating no results
                NoResultsLabel.IsVisible = true;
            }
            else
            {
                // Hide the label indicating no results
                NoResultsLabel.IsVisible = false;
            }
        }

    }
}
