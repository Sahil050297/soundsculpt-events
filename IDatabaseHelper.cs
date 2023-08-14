using System;
using System.Collections.Generic;

namespace SoundSculptMaui
{
    // Interface for defining database helper functionality related to genres
    public interface IDatabaseHelper
    {
        // Method to retrieve a list of all available genres from the database
        List<string> GetGenres();
    }
}
