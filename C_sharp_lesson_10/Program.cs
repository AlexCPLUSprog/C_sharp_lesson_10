using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkTime
{
    public class Employer
    {
        private int age;
        private string name;
        private string sex;
        private DateTime DateOfBorn;
        public Employer()
        {
            age = 0;
            name = "Сотрудник";
            sex = "Мужской";
        }
        public Employer(int _age, string _name/*, string _sex, DateTime _dateOfBorn*/)
        {
            if (this.SetAge(_age))
            {
                this.age = _age;
                this.name = _name;
            }
            
        }

        public int Age { get { return age; } }
        public string Name { get { return name; } }
        public bool SetAge(int _age)
        {
            bool flag = false;
            if (_age >= 14 & _age <= 100)
            {
                age = _age;
                flag = true;
            }
            return flag;
        }
        public void SetName(string _name)
        {
            this.name = _name;
        }
        public virtual void PrintWorkTime()
        {
            Console.WriteLine($"Сотрудник {this.name} работает 5/7 8 часов в день");
        }
    }
    public class YoungEmployer : Employer
    {
        public YoungEmployer(int _age, string _name) : base(_age, _name) { }

        public new void PrintWorkTime()
        {
            if (this.Age < 18)
            {
                Console.WriteLine($"Сотрудник {this.Name} работает 5/7 4 часа в день");
            }
            else
            {
                base.PrintWorkTime();
            }
        }
    }
    internal class Program
    {
        static void CheckDataOfEmployer()
        {
            Console.WriteLine("Имя сотрудника: ");
            string _name = Console.ReadLine();
            Console.WriteLine("Пол сотрудника: ");
            string _sex = Console.ReadLine();
            bool IsCorrect = false;
            int year = 0;
            do
            {                
                Console.WriteLine("Год рождения: ");
                try
                {
                    year = int.Parse( Console.ReadLine() );
                }
                catch (Exception)
                {
                    Console.WriteLine("Год вводится цифрой, попробуйте еще");
                }
                int actualAge = DateTime.Now.Year - year;
                if (actualAge > 14 & actualAge < 100)
                {
                    IsCorrect = true;
                }
                
            } while (!IsCorrect);
        }
        static void Main(string[] args)
        {
            Employer staff001 = new Employer(20, "John");
            staff001.PrintWorkTime();
            YoungEmployer staff002 = new YoungEmployer(14, "Bill");
            staff002.PrintWorkTime();
            staff002.SetAge(20);
            staff002.PrintWorkTime();

           /* string input = Console.ReadLine();
            switch (input)
            {
                case "1": 
                    { 
                        Console.WriteLine("Один")
                    };
                    break;
                default:
            }*/

        }
    }
}
