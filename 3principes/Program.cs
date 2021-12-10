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
        public string Father;
        public string Mother;
        public string school_grade;
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
            if(father.Male == mother.Male || father == mother)
            {
                throw new Exception("Its impossible");
            }
        }
        public new int getAge()
        {
             return Age;
        }
        public void setGrade(int grade)
        {
            school_grade = grade.ToString()+"th grade";
        }
        public void setGrade(string grade)
        {
            school_grade = grade+" class";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person Nikolai = new Person("Nikolai",50,true, "Asian");
            Person Valentin = new Person("Valentin",55,true, "Cuacasoid");
            Person Vika = new Person("Vika",42,false, "Caucasoid");
            Person Anya = new Person("Anya",32,false, "Asian");
            Children Efim = new Children("Efim",12,true,Nikolai,Vika);
            Children Olya = new Children("Olya",14,false,Valentin,Anya);
            Olya.setGrade("Mathematical");
            Efim.setGrade(9);
            Console.WriteLine("Efim, son of "+Efim.Father+" and "+Efim.Mother+" have race "+Efim.Race+" and studying in "+Efim.school_grade);
            Console.WriteLine("Olya, daughter of " + Olya.Father+" and "+ Olya.Mother+" have race "+ Olya.Race + " and studying in " + Olya.school_grade);
        }
    }
}
