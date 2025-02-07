using Newtonsoft.Json;
using Exam;

public class StoreManager
{
    private List<Store> stores = new List<Store>();
    private List<Country> countries;

    public StoreManager(List<Country> countries)
    {
        this.countries = countries;
    }

    public void LoadData(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            stores = JsonConvert.DeserializeObject<List<Store>>(json) ?? new List<Store>();
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
        }
    }

    public void AddStore(string storeName, string location, decimal income)
    {
        if (stores.Exists(s => s.StoreName == storeName))
        {
            Console.WriteLine("Store with the same name already exists.");
            return;
        }

        if (!countries.Exists(c => c.Name.Common == location))
        {
            Console.WriteLine("Invalid location.");
            return;
        }

        var store = new Store
        {
            StoreName = storeName,
            Location = location,
            Income = income,
            AssignedTypes = new List<string>()
        };

        stores.Add(store);
        SaveData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json"); 
        Console.WriteLine("Store added successfully.");
    }

    public void RemoveStore(string storeName)
    {
        var store = stores.Find(s => s.StoreName == storeName);
        if (store != null)
        {
            stores.Remove(store);
            SaveData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json");
            Console.WriteLine("Store removed successfully.");
        }
        else
        {
            Console.WriteLine("Store not found.");
        }
    }

    public void AssignTypes(string storeName, List<string> types)
    {
        var store = stores.Find(s => s.StoreName == storeName);
        if (store != null)
        {
            store.AssignedTypes = types;
            SaveData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json"); 
            Console.WriteLine("Types assigned successfully.");
        }
        else
        {
            Console.WriteLine("Store not found.");
        }
    }

    public void UpdateIncome(string storeName, decimal income)
    {
        var store = stores.Find(s => s.StoreName == storeName);
        if (store != null)
        {
            if (income > 0)
            {
                store.Income = income;
                SaveData("/Users/Desislava.Kostadinova/RiderProjects/Exam/Exam/stores.json"); 
                Console.WriteLine("Income updated successfully.");
            }
            else
            {
                Console.WriteLine("Income must be a positive number.");
            }
        }
        else
        {
            Console.WriteLine("Store not found.");
        }
    }

    public void SaveData(string filePath)
    {
        var json = JsonConvert.SerializeObject(stores, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
