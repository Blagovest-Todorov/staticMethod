using System;
using System.Linq;

namespace _06.OopConstructors  // and static Methods, instance methods waht they are ! 
{

    class Singleton   //Design  Pattern example --helps the private constructor to be used in thoher class;
    {

        public DateTime Date { get; set; }
        private Singleton()  ///private inaccessible from out another class ! accessible only int the same class itself
        {
            this.Date = DateTime.Now;
        }
        private static Singleton instance; //variable field

        public static Singleton Instance  //property field ! 
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    internal class Cat
    {
        private const int MinCatAge = 0; //by rule the fileds are made private in order no outer access, 
        // properties are made so  the fileds can be accesseed only through  check-validation!
        //its kind of encapsulation of the fields, properties provide kind of encapsulation of the fields/what can be acesses and what no/
        private const int MaxCatAge = 20;

        private int age;


        public string Name { get; protected set; } //short properties

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {

                if (MinCatAge <= value && MaxCatAge >= value)
                {
                    this.age = value;
                }
                //if (value < MinCatAge || value > MaxCatAge)
                //{
                //    throw new ArgumentOutOfRangeException("Cat age must be between 0 and 20 range ! ");
                //}
                //this.age = value;
            }

        }//short properties, automatic properties



        public Cat(string name, int age)  //Object Constructor
        {
            this.Name = name;
            this.Age = age;
        }

    }
    internal class Mammal  //internal --accessible only in the currenassembly - ie the project ;
    {
        //protected int age; //member is accesible at the Parent class and all child classes
    }

    class Person : Mammal
    {
        public const int MinAge = 0;
        public const int MaxAge = 200;

        private string name;  //accessible at the class level itself only
        protected int age;

        public Person(string name, int age)
        {
            this.Id = GetNextId();
            this.Name = name;
            this.Age = age;
            Console.WriteLine(this.Name);
        }

        private static int lastPersonId = -1;
        private static int GetNextId()
        {
            return ++lastPersonId;
        }

        public int Id { get; set; }


        public int Useless
        {
            get
            {
                return -1;
            }
        }

        public string NameAndAge
        {
            get
            {
                return this.Name + " " + this.Age;
            }
        }

        public int Age   // We use property to make some check,, to make some validation, its a wrapper for variables
        {
            get //property read only, only we can receive the value,Examople--the lenght of teh array is read-only 
            {
                return this.age;
            }
            set  //write only property, to put some value//for passwords, to write only , not to read, we cant read others paawords
            {
                int newAge = value;
                if (newAge < MinAge || newAge > MaxAge)
                {
                    throw new ArgumentOutOfRangeException("The value must be between 0 and 200 ");
                }
                this.age = value;
            }

        }

        public string Name    // We use properties to make some check, to make some validation
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length >= 3 && value.Length <= 15)
                {
                    this.name = value;
                }
            }
        }

        public void Introduce()
        {
            string name = "Drugi ime";
            Console.WriteLine("Hello! , my name is {0} and i am {1}-years-old.",
                               this.name, this.age);
            //this improves code readability and prevents mistakes, this referes to the object ! 
        }

    }
    class MathExtensions
    {
        public static int Product(params int[] numbers)
        {
            int product = 1;
            foreach (int number in numbers)
            {
                product *= number;
            }
            return product;
        }

    }

    class Program  // we use classes to create an instance of the class call Object and to give him functionallity //
    {                // We have to define the class and his members , and their level of access;

        public static int Product(params int[] numbers)
        {
            int product = 1;
            foreach (int number in numbers)
            {
                product *= number;
            }
            return product;
        }
        static void Main(string[] args) //static menas can not be instantiated, is common for all! 
        {
            var people = Enumerable.Range(1, 15)  // to generate 15 People ! using Lingq
                .Select(X => ("Person #" + X, X % Person.MaxAge)).ToArray();
        }
        // instance method, can be called when first an object of a class is created //we need first object here to be created tehn we can call them
        // static method can be called without instatnce of class -i e  object be created //We need no object here to call eht method 
        //static -means, common, can not be instantiated ! 
        //we can not creat an object of an static class ! can not access static members using an object.
        //keyword static   , static is a type of modifier
        //static methods can only call other static methods and access other static members ! 
    }
}



