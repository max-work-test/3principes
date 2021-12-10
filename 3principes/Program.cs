using System;

namespace _3principes
{
    class Person
    {
        public string Name;
        public int Age;
        public bool Male;
        public string race = "unknown";

        public Person(string name,int age,bool male,string Race)
        {
            Name = name;
            Male = male;
            Age = age;
            race = Race;
        }
        public Person(string name, int age, bool male)
        {
            Name = name;
            Male = male;
            Age = age;
        }
        public string Race
        {
            get
            {
                return race;
            }
            set
            {
                if (race == "unknown")
                {
                    race = value;
                }
                else
                {
                    throw new Exception("Race cannot be changed");
                }
            }
        }
        public int getAge()
        {
                if (Male)
                {
                    return Age;
                }
                else
                {
                    throw new Exception("it's not decent to ask a woman's age");
                }
        }

    }

    class Children : Person
    {
        public string Father { get; set; }
        public string Mother { get; set; }

        public Children(string name, int age, bool male, Person father,Person mother)
            : base(name,age,male)
        {
            Father = father.Name;
            Mother = mother.Name;
            Random rnd = new Random();
            if (rnd.Next(0, 2)==0)
            {
                race = father.race;
            }
            else
            {
                race = mother.race;
            }
            if(age >= father.Age || age >= mother.Age)
            {
                throw new Exception("The child cannot be older than his parents");
            }
            if(father.Male == mother.Male)
            {
                throw new Exception("Its impossible");
            }
        }
        public new int getAge()
        {
             return Age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person Nikolai = new Person("Nikolai",50,true, "Asian");
            Person Vika = new Person("Vika",42,false, "Caucasoid");
            Children Efim = new Children("Efim",12,false,Nikolai,Vika);
            Console.WriteLine("Efim, son of "+Efim.Father+" and "+Efim.Mother+" have race: "+Efim.Race);
        }
    }
}
