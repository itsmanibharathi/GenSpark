using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace basic.moduls
{
    internal class Employe
    {
        private string _name;
        private string _emiail;
        private double _salary;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Email
        {
            get => _emiail;
            set => _emiail = value;
        }
        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }
        //public Employe(string name, string email, double salary)
        //{
        //    _name = name;
        //    _emiail = email;
        //    _salary = salary;
        //}
        public Employe(string name)
        {
            _name = name.ToString();
        }
        public Employe(string name, string email) : this(name)
        {
            _emiail = email;
        }
        public Employe(string name,string email, double salary) : this(name,email)
        {
            _salary = salary;
        }
        public void PrintEmploye()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Email: {_emiail}");
            Console.WriteLine($"Salary: {_salary}");
        }

        public Employe CreateGetEmaloye()
        {
            Employe employe = new Employe();
            Console.WriteLine("Plase Enter Following Details");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
        }
    }
}
