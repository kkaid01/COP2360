using System;
using System.Collections.Generic;
using System.Linq;

namespace Module7Assignment
{
    class Program
    {
        // Dictionary from string -> list of string values so each key can have multiple values
        static Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        static void Main(string[] args)
        {
            // Seed with example data to make testing easy
            SeedSampleData();

            bool done = false;
            while (!done)
            {
                ShowMenu();
                Console.Write("Choose an option (1-8): ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        PopulateDictionary();
                        break;
                    case "2":
                        DisplayDictionary();
                        break;
                    case "3":
                        RemoveKey();
                        break;
                    case "4":
                        AddNewKeyAndValue();
                        break;
                    case "5":
                        AddValueToExistingKey();
                        break;
                    case "6":
                        SortKeys();
                        break;
                    case "7":
                        ShowEnumerationMethodsInfo();
                        break;
                    case "8":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 8.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Exiting. Press any key to close.");
            Console.ReadKey();
        }

        static void ShowMenu()
        {
            Console.WriteLine("Dictionary Assignment Menu");
            Console.WriteLine("1. Populate the dictionary (add multiple entries)");
            Console.WriteLine("2. Display dictionary contents (three enumeration methods shown)");
            Console.WriteLine("3. Remove a key");
            Console.WriteLine("4. Add a new key and value");
            Console.WriteLine("5. Add a value to an existing key");
            Console.WriteLine("6. Sort the keys and display");
            Console.WriteLine("7. Show which enumeration methods are demonstrated");
            Console.WriteLine("8. Exit");
        }

        static void SeedSampleData()
        {
            dict.Clear();
            dict["Fruit"] = new List<string> { "Apple", "Banana" };
            dict["Colors"] = new List<string> { "Red", "Blue" };
            dict["Animals"] = new List<string> { "Dog", "Cat" };
        }

        // (a) Populate the Dictionary: allow user to add multiple keys/values interactively
        static void PopulateDictionary()
        {
            Console.WriteLine("Populate dictionary. Enter entries in the form 'key:value1,value2' (or blank to stop).");
            while (true)
            {
                Console.Write("Entry: ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) break;

                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid format. Use key:value1,value2");
                    continue;
                }

                string key = parts[0].Trim();
                var values = parts[1]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .Where(s => s.Length > 0)
                    .ToList();

                if (values.Count == 0)
                {
                    Console.WriteLine("No values provided for key.");
                    continue;
                }

                if (!dict.ContainsKey(key))
                    dict[key] = new List<string>();

                dict[key].AddRange(values);
                Console.WriteLine($"Added/updated key '{key}' with {values.Count} value(s).");
            }
        }

        // (b) Display Dictionary Contents using three enumeration methods
        static void DisplayDictionary()
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            Console.WriteLine("\n--- Display: Method 1 - foreach KeyValuePair<string, List<string>> ---");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} : {string.Join(", ", kvp.Value)}");
            }

            Console.WriteLine("\n--- Display: Method 2 - foreach over Keys ---");
            foreach (var key in dict.Keys)
            {
                Console.WriteLine($"{key} : {string.Join(", ", dict[key])}");
            }

            Console.WriteLine("\n--- Display: Method 3 - IEnumerator ---");
            using (var enumerator = dict.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var kvp = enumerator.Current;
                    Console.WriteLine($"{kvp.Key} : {string.Join(", ", kvp.Value)}");
                }
            }
        }

        // (c) Remove a Key
        static void RemoveKey()
        {
            Console.Write("Enter the key to remove: ");
            string key = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("No key entered.");
                return;
            }

            if (dict.Remove(key))
                Console.WriteLine($"Key '{key}' removed.");
            else
                Console.WriteLine($"Key '{key}' not found.");
        }

        // (d) Add a New Key and Value
        static void AddNewKeyAndValue()
        {
            Console.Write("Enter new key: ");
            string key = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Invalid key.");
                return;
            }

            if (dict.ContainsKey(key))
            {
                Console.WriteLine("Key already exists. Use option 5 to add a value to an existing key.");
                return;
            }

            Console.Write("Enter values (comma-separated): ");
            var values = Console.ReadLine()?
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).Where(s => s.Length > 0).ToList() ?? new List<string>();

            if (values.Count == 0)
            {
                Console.WriteLine("No values entered. Key not added.");
                return;
            }

            dict[key] = values;
            Console.WriteLine($"Key '{key}' added with {values.Count} value(s).");
        }

        // (e) Add a Value to an Existing Key
        static void AddValueToExistingKey()
        {
            Console.Write("Enter the key to append to: ");
            string key = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(key) || !dict.ContainsKey(key))
            {
                Console.WriteLine("Key not found.");
                return;
            }

            Console.Write("Enter value(s) to append (comma-separated): ");
            var values = Console.ReadLine()?
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).Where(s => s.Length > 0).ToList() ?? new List<string>();

            if (values.Count == 0)
            {
                Console.WriteLine("No values entered.");
                return;
            }

            dict[key].AddRange(values);
            Console.WriteLine($"Appended {values.Count} value(s) to key '{key}'.");
        }

        // (f) Sort the Keys
        static void SortKeys()
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            var sortedKeys = dict.Keys.OrderBy(k => k, StringComparer.OrdinalIgnoreCase).ToList();
            Console.WriteLine("--- Sorted keys (ascending) and their values ---");
            foreach (var key in sortedKeys)
            {
                Console.WriteLine($"{key} : {string.Join(", ", dict[key])}");
            }
        }

        static void ShowEnumerationMethodsInfo()
        {
            Console.WriteLine("This program demonstrates three enumeration methods:\n" +
                              "1) foreach (KeyValuePair<,>) over the Dictionary\n" +
                              "2) foreach over Dictionary.Keys and indexing into the Dictionary\n" +
                              "3) Manual enumeration using IEnumerator from GetEnumerator()");
        }
    }
}
