Technologies Used
1.	Classes and Inheritance:
•	MainPage, GenrePage, and ArtistPage are classes that define the behavior and layout of each page. They all inherit from ContentPage, a class provided by the MAUI framework that serves as a base class for creating content pages in the UI. Inheriting from ContentPage grants these classes access to various properties, methods, and events that facilitate creating user interfaces.
•	DatabaseHelper is a concrete class that provides methods to interact with the database. It extends AbstractDatabaseHelper, inheriting the implementation of the GetGenres method, which retrieves available genres from the database. It adds its own implementation of the GetArtistsByGenre method to retrieve artists based on the provided genre.
2.	Interfaces:
•	The IDatabaseHelper interface defines the contract for classes that provide database-related methods.
•	DatabaseHelper implements this interface, ensuring it includes the GetGenres() method.
3.	Abstract Classes:
•	AbstractDatabaseHelper serves as a base class that provides common database functionality and ensures consistent method structure.
•	DatabaseHelper inherits from AbstractDatabaseHelper and provides the concrete implementation of GetArtistsByGenre().
4.	MAUI GUI (Graphical User Interface):
•	ContentPage, Label, Entry, Button, and ListView controls are used to build the UI of each page.
•	Properties like Text, Placeholder, and IsVisible are set on these controls to modify their behavior.
5.	Exception Handling:
•	In GenrePage, a try-catch block captures exceptions when navigating to ArtistPage. If an exception occurs, it's caught and its message is printed to the console.
•	In the AbstractDatabaseHelper class, there's a try-catch block wrapping the database interaction code inside the GetGenres method. If an exception occurs during database connectivity or query execution, it's caught and handled. This ensures that if there's an issue with database connectivity or queries, the application can gracefully handle it and provide feedback to developers.
