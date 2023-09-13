using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Initialise a movie collection binary search tree (BST)
        IMovieCollection movieCollection = new MovieCollection();

        // Empirically analysing NoDVDs method.
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();

        int[] numDVDs = new int[] { 100000, 200000, 400000, 800000, 1600000, 3200000, 6400000, 12800000 };

        /*foreach (int n in numDVDs)
        {
            Console.WriteLine("Empirically analysing " + n + " movies' DVD count using NoDVDs(): ");

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < n; i++)
            {
                movieCollection.Insert(new Movie(generateMovieTitle(), (MovieGenre)random.Next(1, 5), (MovieClassification)random.Next(1, 4), random.Next(0, 200), random.Next(0, 200)));
            }
            stopwatch.Stop();

            Console.WriteLine("The time to add " + n + " movies to the collection is " + stopwatch.ElapsedMilliseconds + " milliseconds.");

            stopwatch.Reset();
            stopwatch.Start();
            movieCollection.NoDVDs();
            stopwatch.Stop();

            Console.WriteLine("The time to count the DVD count for " + n + " movies is " + stopwatch.ElapsedMilliseconds + " milliseconds.");
            Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");
            Console.WriteLine("There are " + movieCollection.NoDVDs() + " total DVDs in the collection.\n");

            movieCollection.Clear();

            Console.WriteLine("---------------------------------------------------------");
        }

        // Sample randomly generated movie.
        Console.WriteLine("Sample randomly generated movie.\n");

        movieCollection.Insert(new Movie(generateMovieTitle(), (MovieGenre)random.Next(1, 5), (MovieClassification)random.Next(1, 4), random.Next(0, 200), random.Next(0, 200)));
        IMovie[] movies = movieCollection.ToArray();
        printArray(movies);

        movieCollection.Clear();

        Console.WriteLine("---------------------------------------------------------");*/

        // Test 1: Check if empty initially using IsEmpty()
        Console.WriteLine("Test 1: Check if the BST is empty initially using the IsEmpty method.\n");
        if (movieCollection.IsEmpty() == true)
        {
            Console.WriteLine("The movie collection is empty.\nThere are " + movieCollection.Number + " movies in the collection.");
        }

        Console.WriteLine("---------------------------------------------------------");

        // Test 2: Use Insert method to insert some Movies into the BST. Use ToArray to
        Console.WriteLine("Test 2: Use Insert method to insert some Movies into the BST.\n");
        IMovie movie1 = new Movie("test", MovieGenre.Action, MovieClassification.G, 12, 12);
        movieCollection.Insert(movie1);
        Console.WriteLine(movieCollection.Insert(new Movie("Shiva Baby", MovieGenre.Comedy, MovieClassification.M, 78, 12)));
        Console.WriteLine(movieCollection.Insert(new Movie("Aftersun", MovieGenre.Drama, MovieClassification.M, 101, 7)));
        Console.WriteLine(movieCollection.Insert(new Movie("The Good, the Bad and the Ugly", MovieGenre.Western, MovieClassification.M15Plus, 161, 18)));
        Console.WriteLine(movieCollection.Insert(new Movie("Come and See", MovieGenre.History, MovieClassification.M, 142, 24)));
        Console.WriteLine(movieCollection.Insert(new Movie("Fallen Angels", MovieGenre.Action, MovieClassification.M, 98, 13)));
        Console.WriteLine(movieCollection.Insert(new Movie("Spider-Man: Into the Spider-Verse", MovieGenre.Action, MovieClassification.PG, 117, 3)));

        Console.WriteLine();
        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection");

        Console.WriteLine("---------------------------------------------------------");

        // Test 3: IsEmpty method on a populated movie collection.
        Console.WriteLine("Test 3: IsEmpty method on a populated movie collection.\n");
        if (movieCollection.IsEmpty() == false)
        {
            Console.WriteLine("The movie collection is not empty.\nThere are " + movieCollection.Number + " movies in the collection");
        }

        Console.WriteLine("---------------------------------------------------------");

        // Test 4: Use ToArray and the printArray helper method to show the movies in the BST.
        Console.WriteLine("Test 4: Use ToArray and the printArray helper method to show the movies in the BST.\n");

        IMovie[] movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine("---------------------------------------------------------");

        // Test 5: Insert existing movies into the BST.
        Console.WriteLine("Test 5: Insert existing movies into the BST.\n");

        if (movieCollection.Insert(new Movie("Aftersun", MovieGenre.Drama, MovieClassification.M, 101, 7)) == false)
            Console.WriteLine("This movie already exists in the collection.");
        if (movieCollection.Insert(new Movie("Spider-Man: Into the Spider-Verse", MovieGenre.Action, MovieClassification.PG, 117, 3)) == false)
            Console.WriteLine("This movie already exists in the collection.");

        Console.WriteLine();

        movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine("\nThere are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 6: Use Search method to search for movies in the BST. Count should not change as per the post-condition.
        Console.WriteLine("Test 6: Use Search method to search for movies in the BST. Count should not change as per the post-condition.\n");
        Console.Write(movieCollection.Search("Fallen Angels").ToString());
        Console.Write(movieCollection.Search("Aftersun").ToString());
        Console.WriteLine();

        movies = movieCollection.ToArray();
        printArray(movies);
        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 7: Search movies that do not exist. Should return a null value as per the post-condition. Count should not change.
        Console.WriteLine("Test 7: Search movies that do not exist. Should return a null value as per the post-condition. Count should not change.\n");
        if (movieCollection.Search("Pride and Prejudice") == null)
            Console.WriteLine("Pride and Prejudice does not exist in the collection. Search method returns a null value.\n");

        movies = movieCollection.ToArray();
        printArray(movies);
        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 8: Use NoDVDs method to count how many total DVDs are available in the collection.
        // Movie collection (using ToArray implementation to check) and count remain unchanged.
        Console.WriteLine("Test 8: Use NoDVDs method to count how many total DVDs are available in the collection. " +
            "Movie collection (using ToArray implementation to check) and count remain unchanged.\n");
        Console.WriteLine("There are " + movieCollection.NoDVDs() + " total DVDs in the collection.\n");

        movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine("\nThere are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        /* Test 9: Use Delete method to delete movies in the BST, then use NoDVDs and ToArray methods and count to check if the correct
        movies are deleted. Delete method should return true. Count should reduce by however many movies are deleted. */
        Console.WriteLine("Test 9: Use Delete method to delete movies in the BST, then use NoDVDs method to check if the correct\n" +
            "movies are deleted. Movie and DVD count should reduce by however many movies are deleted.\n");
        Console.WriteLine(movieCollection.Delete(new Movie("Come and See", MovieGenre.History, MovieClassification.M, 142, 24)));
        Console.WriteLine(movieCollection.Delete(new Movie("Shiva Baby", MovieGenre.Comedy, MovieClassification.M, 78, 12)));
        Console.WriteLine();

        movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine();
        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");
        Console.WriteLine("There are " + movieCollection.NoDVDs() + " total DVDs in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 10: Delete movies that do not exist. Should return false. Count should not change.
        Console.WriteLine("Test 10: Delete movies that do not exist. Count should not change.\n");
        Console.WriteLine(movieCollection.Delete(new Movie("Pride and Prejudice", MovieGenre.Drama, MovieClassification.G, 127, 5)));
        Console.WriteLine();

        movies = movieCollection.ToArray();
        printArray(movies);
        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");
        Console.WriteLine("There are " + movieCollection.NoDVDs() + " total DVDs in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 11: Use ToArray method to convert movie collection to array. Use printArray helper method to print the array.
        Console.WriteLine("Test 11: Use ToArray method to convert movie collection to array. Use printArray helper method to print the array.\n");
        movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine("There are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine("---------------------------------------------------------");

        // Test 12: Use Clear method to clear the binary search tree.
        Console.WriteLine("Test 12: Use Clear method to clear the binary search tree.\n");
        movieCollection.Clear();

        movies = movieCollection.ToArray();
        printArray(movies);

        Console.WriteLine("\nThere are " + movieCollection.Number + " movies in the collection.");

        Console.WriteLine();

        Console.WriteLine("---------------------------------------------------------");

        // Test 13: Use NoDVDs when the movie collection is empty.
        Console.WriteLine("Test 13: Use NoDVDs when the movie collection is empty.\n");

        Console.WriteLine("There are " + movieCollection.NoDVDs() + " total DVDs in the collection.");

        Console.WriteLine("---------------------------------------------------------");
        
        // Test 14: Testing the CompareTo method.
        Console.WriteLine("Test 14: Testing the CompareTo method.\n");
        IMovie test = new Movie("Test Movie", MovieGenre.Comedy, MovieClassification.PG, 13, 29);

        Console.WriteLine("Test Movie".CompareTo(test.Title));
        Console.WriteLine("AAA".CompareTo(test.Title));
        Console.WriteLine("ZZZ".CompareTo(test.Title));
        
        Console.WriteLine("---------------------------------------------------------");


        // Test 15: Testing the ToString method.
        Console.WriteLine("Test 15: Testing the ToString method.\n");

        Console.WriteLine(test.ToString());

        Console.ReadLine();
    }

    // Helper method to print the movies array.
    static void printArray(IMovie[] A)
    {
        for (int i = 0; i < A.Length; i++)
            Console.Write(A[i].ToString());
    }

    // Helper method to generate movie titles to populate the collection for empirical analysis of NoDVDs().
    // Adapted from https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings.
    static string generateMovieTitle()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var stringChars = new char[50];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = letters[random.Next(letters.Length)];
        }

        string movieTitle = new(stringChars);
        return movieTitle;
    }
}