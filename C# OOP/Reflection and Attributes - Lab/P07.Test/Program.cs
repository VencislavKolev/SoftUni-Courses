using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P07.Test
{
    [Author("Venci")]
    class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes();

            var typesAndAttributes = types
                .Select(t => new
                {
                    Type = t,
                    Attributes = t.GetCustomAttributes<AuthorAttribute>()
                })
                .Where(a => a.Attributes.Any());

            var result = new Dictionary<string, List<string>>();
            foreach (var typeAndAttribute in typesAndAttributes)
            {
                var type = typeAndAttribute.Type.Name;
                var authors = typeAndAttribute.Attributes.Select(a => a.Name);
                foreach (var author in authors)
                {
                    if (!result.ContainsKey(author))
                    {
                        result[author] = new List<string>();
                    }
                    result[author].Add(type);
                }
            }
            foreach (var author in result)
            {
                var classes = string.Join(", ", author.Value);
                Console.WriteLine($"{author.Key} - {classes}");
            }
        }
    }
}
