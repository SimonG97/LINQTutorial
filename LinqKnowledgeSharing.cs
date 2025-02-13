namespace LINQTutorial;

public class LinqKnowledgeSharing
{
    public void Basic_Linq_Usage()
    {
        List<string> names = ["Alice", "Bob", "Charlie", "David", "Eve"];

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


}
