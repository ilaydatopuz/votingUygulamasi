using System;
using System.Collections.Generic;

class User
{
    public string Username { get; set; }
    public bool IsRegistered { get; set; }

    public User(string username)
    {
        Username = username;
        IsRegistered = true;
    }
}

class Category
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}

class Program
{
    static List<User> users = new List<User>();
    static List<Category> categories = new List<Category>
    {
        new Category("Film Kategorileri"),
        new Category("Tech Stack Kategorileri"),
        new Category("Spor Kategorileri")
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Hoş geldiniz!");

        while (true)
        {
            Console.WriteLine("\nKategoriler:");
            DisplayCategories();

            Console.Write("\nLütfen oy vermek için kullanıcı adınızı girin: ");
            string username = Console.ReadLine();

            User user = GetUser(username);

            if (user == null)
            {
                Console.WriteLine("Bu kullanıcı kayıtlı değil. Kayıt olmak ister misiniz? (evet/hayır)");
                string response = Console.ReadLine();

                if (response.ToLower() == "evet")
                {
                    user = RegisterUser(username);
                }
                else
                {
                    Console.WriteLine("Oy verme işlemi iptal edildi.");
                    continue;
                }
            }

            Console.WriteLine($"Hoş geldiniz, {user.Username}!");

            // Simulated voting
            SimulateVoting();

            Console.WriteLine("\nOylama sonuçları:");
            DisplayVotingResults();

            Console.WriteLine("Uygulama sonlandırılıyor...");
            break;
        }
    }

    static void DisplayCategories()
    {
        foreach (var category in categories)
        {
            Console.WriteLine(category.Name);
        }
    }

    static User GetUser(string username)
    {
        return users.Find(u => u.Username == username);
    }

    static User RegisterUser(string username)
    {
        User user = new User(username);
        users.Add(user);
        return user;
    }

    static void SimulateVoting()
    {
        // Simulated voting logic
        // In a real application, you would implement actual voting mechanism
        // Here, we'll just display a message for demonstration purposes
        Console.WriteLine("Oy verme işlemi başarıyla tamamlandı.");
    }

    static void DisplayVotingResults()
    {
        // Simulated voting results
        int totalVotes = 100;
        int filmCategoryVotes = 40;
        int techCategoryVotes = 30;
        int sportsCategoryVotes = 30;

        Console.WriteLine($"Film Kategorileri Oyları: {filmCategoryVotes} ({CalculatePercentage(filmCategoryVotes, totalVotes)}%)");
        Console.WriteLine($"Tech Stack Kategorileri Oyları: {techCategoryVotes} ({CalculatePercentage(techCategoryVotes, totalVotes)}%)");
        Console.WriteLine($"Spor Kategorileri Oyları: {sportsCategoryVotes} ({CalculatePercentage(sportsCategoryVotes, totalVotes)}%)");
    }

    static double CalculatePercentage(int part, int whole)
    {
        return ((double)part / whole) * 100;
    }
}
