using System;
using System.Reflection;

namespace Assignment22
{
    internal class Program
    {
        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = Array.Find(destinationProperties, p => p.Name == sourceProperty.Name);
                if (destinationProperty != null && destinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }

        public static void Main(string[] args)
        {
            Source source = new Source
            {
                Id = 65,
                Name = "James Cameron",
                Age = 30,
                Address = "1-2-3,River Street,Los Angels"
            };

            Destination destination = new Destination();
            MapProperties(source, destination);

            Console.WriteLine("Destination properties after mapping:");
            Console.WriteLine($"Id: {destination.Id}");
            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"Age: {destination.Age}");
            Console.WriteLine($"City: {destination.City}"); // Should be empty as it doesn't exist in Source
            Console.WriteLine($"Country: {destination.Country}"); // Should be empty as it doesn't exist in Source
            Console.ReadKey();
        }
    }
}
