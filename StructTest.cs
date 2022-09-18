using System;

namespace Lab1
{
    struct Person
    {
        public int age;

        public Person(int age)
        {
            this.age = age;
        }

        public int add10years()
        {
            return this.age = this.age + 10;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("This is the initial commit!");

            Person p1 = new Person(3);

            Person p2 = p1;

            p1.age = 2;

            p2.add10years();

            Console.WriteLine(p1.age);
            Console.WriteLine(p2.age);


        }
    }
}
