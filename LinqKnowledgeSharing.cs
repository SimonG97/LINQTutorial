using System.Net.NetworkInformation;
using LINQTutorial.Model;

namespace LINQTutorial;

public class LinqKnowledgeSharing
{
    private readonly List<int> numbers = [5, 3, 8, 1, 2, 9, 6, 7, 4];
    private readonly List<string> names = ["Alice", "Bob", "Charlie", "David"];

    public void Basic_Linq_Usage()
    {
        // Filtering: Where()
        // Query syntax
        var queryResult = from name in names
                          where name.StartsWith('A')
                          select name;

        // Method syntax
        var methodResult = names.Where(name => name.StartsWith('A'));

        Console.WriteLine("Query Syntax Result:");
        foreach (var name in queryResult)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("Method Syntax Result:");
        foreach (var name in methodResult)
        {
            Console.WriteLine(name);
        }
    }

    public void Select_Method()
    {
        // Projection: Select()
        var nameLengths = names.Select(n => new { Name = n, Length = n.Length });// Anonymous type
        Console.WriteLine("Names and Lengths:");
        foreach (var item in nameLengths)
        {
            Console.WriteLine($"{item.Name}: {item.Length}");
        }
    }

    public void Sorting_Methods()
    {
        // Sorting: OrderBy(), ThenBy()
        var sortedNumbers = numbers.OrderBy(n => n);
        Console.WriteLine("Sorted Numbers:");
        foreach (var number in sortedNumbers)
        {
            Console.WriteLine(number);
        }

        var sortedNames = names.OrderBy(n => n.Length).ThenBy(n => n);
        Console.WriteLine("Sorted Names by Length, then Alphabetically:");
        foreach (var name in sortedNames)
        {
            Console.WriteLine(name);
        }
    }

    public void Aggregation_Methods()
    {
        // Aggregation: Sum(), Average(), Count()
        var sum = numbers.Sum();
        var average = numbers.Average();
        var count = numbers.Count();

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Count: {count}");
    }

    public void Grouping_Method()
    {
        // Grouping: GroupBy()
        var groupedNumbers = numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");
        foreach (var group in groupedNumbers)
        {
            Console.WriteLine(group.Key);
            foreach (var number in group)
            {
                Console.WriteLine(number);
            }
        }
    }

    public void Join_Method()
    {
        // Join: Join()
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Alice" },
            new() { Id = 2, Name = "Bob" },
            new() { Id = 3, Name = "Charlie" }
        };

        var orders = new List<Order>
        {
            new() { Id = 1, PersonId = 1, Amount = 100 },
            new() { Id = 2, PersonId = 2, Amount = 200 },
            new() { Id = 3, PersonId = 1, Amount = 300 }
        };

        var query = people.Join(orders,
                                person => person.Id, // Key from 'people'
                                order => order.PersonId,
                                (person, order) => new { person.Name, order.Amount });

        foreach (var item in query)
        {
            Console.WriteLine($"{item.Name}: {item.Amount}");
        }
    }


    public void Deferred_Execution()
    {
        var query = numbers.Where(n => n > 2); // Query is built, but NOT executed

        numbers.Add(6); // Data source changes

        var check = query; // check query

        foreach (var number in query) // Execution happens here!
        {
            Console.WriteLine(number); // Output: 3, 4, 5, 6 (reflects the change)
        }

    }

    public void Anonymous_Types_Projections()
    {
        // Anonymous Types and Projections
        var products = new List<Product>
        {
            new() { Name = "Laptop", Price = 1000, Category = "Electronics" },
            new() { Name = "Mobile", Price = 500, Category = "Electronics" },
            new() { Name = "Shirt", Price = 50, Category = "Clothing" },
            new() { Name = "Trousers", Price = 70, Category = "Clothing" }
        };

        var query = products.Select(p => new { p.Name, p.Price }); // Anonymous type
        foreach (var item in query)
        {
            Console.WriteLine($"{item.Name}: {item.Price}");
        }
    }

    public void Chaining_Multiple_LINQ_Queries()
    {
        // Chaining Multiple LINQ Queries
        var query = numbers.Where(n => n > 2)
                           .OrderBy(n => n)
                           .Select(n => n * 2);

        foreach (var number in query)
        {
            Console.WriteLine(number);
        }
    }

    public void Multiple_Enumerations()
    {
        // Bad practice: Multiple Enumerations
        var query = numbers.Where(n => n > 2);

        int count = query.Count(); // Query executed

        foreach (var number in query) // Query executed again
        {
            Console.WriteLine(number);
        }

        // Good practice: Materialize the query
        var materializedQuery = numbers.Where(n => n > 2).ToList(); // Query executed

        int materializedCount = materializedQuery.Count; // No query execution

        foreach (var number in materializedQuery) // No query execution
        {
            Console.WriteLine(number);
        }


    }




}



