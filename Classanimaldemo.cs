using System;

namespace Module3Assignment
{
    // Base class Animal
    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }
        // Virtual method to be overridden
        public virtual void Speak()
        {
            Console.WriteLine($"{Name} makes a sound.");
        }
    }

    // Derived class Dog that inherits from Animal
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        // Method overriding the base class Speak method
        public override void Speak()
        {
            Console.WriteLine($"{Name} says Woof!");
        }
    }

    // Derived class Cat that inherits from Animal
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        // Method overriding the base class Speak method
        public override void Speak()
        {
            Console.WriteLine($"{Name} says Meow!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Dog and Cat using the derived classes
            Dog dog = new Dog("Buddy");
            Cat cat = new Cat("Whiskers");

            // Call Speak method on both objects, demonstrating polymorphism
            dog.Speak(); // Output: Buddy says Woof!
            cat.Speak(); // Output: Whiskers says Meow!
        }
    }
}
