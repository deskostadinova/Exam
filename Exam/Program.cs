using Exam;
class Program
{
    static async Task Main(string[] args)
    {
        var countryService = new CountryService();
        var countries = await countryService.GetCountriesAsync();

        var storeManager = new StoreManager(countries);

        storeManager.LoadData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json");

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Add a store");
            Console.WriteLine("2. Remove a store");
            Console.WriteLine("3. Assign types");
            Console.WriteLine("4. Update income");
            Console.WriteLine("5. Save data");
            Console.WriteLine("6. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter store name: ");
                    var storeName = Console.ReadLine();

                    Console.Write("Enter location: ");
                    var location = Console.ReadLine();

                    Console.Write("Enter income: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal income))
                    {
                        storeManager.AddStore(storeName, location, income);
                    }
                    else
                    {
                        Console.WriteLine("Invalid income value.");
                    }
                    break;
                case "2":
                    Console.Write("Enter store name: ");
                    storeManager.RemoveStore(Console.ReadLine());
                    break;
                case "3":
                    Console.Write("Enter store name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter types (comma separated): ");
                    var types = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    storeManager.AssignTypes(name, new List<string>(types));
                    break;
                case "4":
                    Console.Write("Enter store name: ");
                    var updateName = Console.ReadLine();
                    Console.Write("Enter new income: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newIncome))
                    {
                        storeManager.UpdateIncome(updateName, newIncome);
                    }
                    else
                    {
                        Console.WriteLine("Invalid income value.");
                    }
                    break;
                case "5":
                    storeManager.SaveData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json");
                    Console.WriteLine("Data saved successfully.");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
