using System;

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Person travis = new Person(DateTime.UtcNow.AddDays(-1));
            travis.Name = "Travis";
            travis.HomeTown = "Sandusky";
            
            // Can't do this!! My Birthday can only be set when I'm born!!
            // travis.Birthday = DateTime.UtcNow.AddDays(-365); //Uncomment this line and hover over the squiggly erro

            System.Console.WriteLine("I wasn't born yesterday! Wait... yes I was.");
            Console.WriteLine("Happy Birthday " + travis.Name);

            System.Console.WriteLine(travis.Address);
            travis.Address = "900 Easy St.";
            System.Console.WriteLine("Travis's Address: " + travis.Address );
        }
    }

    public class Person
    {
        // If you leave out the keyword 'set' it cannot be changed outside of the class.
        // Doing this is the same effect as having a private DateTime birthday
        // And then exposing a method to 'get' the Person.Birthday without allowing
        // anyone to change the birthday. (Our birthday is immutable, it cannot change)
        public DateTime Birthday { get; }

        // This is called 'auto-implemented' property
        public string Name { get; set; }

        // You can leave off the get and set keyword. C# will dynamically add them during a build
        // You still won't see them, but they're included in the compiled version of the code
        public string HomeTown;

        private string _address;

        // These get and set properties allow some control over data quality
        public string Address
        {
            // Note: if you implement them, drop the semicolon and using a pair of braces
            // The get keyword has a required return, you have to return something
            get
            {
                if (String.IsNullOrEmpty(_address))
                {
                    return "This person's address was not provided";
                }
                return _address;
            }
            
            set
            {
                // What the heck??? Where'd the 'value' come from?
                // It's a built in keyword representing incoming date. If a programmer uses
                // My set method, whatever is passed into this property to the right of the
                // assignment operator will be substituted for the keyword value;
                _address = value;
            }
        }

        public Person(DateTime birthday)
        {
            // Constructor to create a person
            // There is a mandatory parameter to create an instance of a person
            // This is how you set your Birthday 'public' get with a 'private'
            // Missing 'set' keyword
            this.Birthday = birthday;
        }
    }
}
