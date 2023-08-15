using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace SoundSculptMaui
{
    public class DatabaseHelper : AbstractDatabaseHelper
    {
        // Method to retrieve a list of artists with additional details for a given genre from the database
        public List<ArtistDetails> GetArtistDetailsByGenre(string genre)
        {
            List<ArtistDetails> artistDetailsList = new List<ArtistDetails>();

            // Establish a database connection using the connection string
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Open the database connection

                string query = "SELECT artist, venue, ticket_cost FROM concert WHERE genre = @genre"; // SQL query

                // Execute a parameterized SQL query to retrieve artist details for the specified genre
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@genre", genre); // Set the genre parameter

                    // Execute the query and read the results
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create an ArtistDetails object with the retrieved values
                            ArtistDetails artistDetails = new ArtistDetails
                            {
                                Artist = reader.GetString("artist"),
                                Venue = reader.GetString("venue"),
                                TicketCost = reader.GetDecimal("ticket_cost").ToString("C") // Format ticket cost as currency
                            };

                            artistDetailsList.Add(artistDetails); // Add artist details to the list
                        }
                    }
                }
            }

            return artistDetailsList; // Return the list of artist details
        }
    }
}
