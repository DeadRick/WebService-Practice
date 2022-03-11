using System;

namespace ConsoleApp2
{
    internal class Program
    {
        class Person
        {
            public Person()
            {
                Name = "Bob";
                Age = 18;
            }
            public Person(string name)
            {
                Name = name;
                Age = 18;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);

            Person person2 = new Person("John");
            Console.WriteLine(person2.Name);
            Console.WriteLine(person2.Age);
        }
    }
}
