using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basic.moduls;
namespace basic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // first class

            FirstClass firstClass = new FirstClass();
            firstClass.PrintHelloWorld();
            // Array Print
            firstClass.ArrayPrint();
           

            // Try Get Set

            //TryGetSet tryGetSet = new TryGetSet();
            //tryGetSet.name1 = "John";
            //Console.WriteLine(tryGetSet.name1);
            //tryGetSet.name2 = "Doe";
            //Console.WriteLine(tryGetSet.name2);
            //tryGetSet.name3 = "Jane";
            //Console.WriteLine(tryGetSet.name3);
            //tryGetSet.name4 = "Smith";
            //Console.WriteLine(tryGetSet.name4);

            // Employe

            Employe employe1 = new Employe("mani", "mani@gmail.com", 1000);

            employe1.PrintEmploye();
            employe1.Name = "manibharathi";
            employe1.PrintEmploye();

            //Employe employe2 = new Employe
            //{
            //    Name = "lundena",
            //    Email = "ludena@gmail.com",
            //    Salary = 200
            //};
            //employe2.PrintEmploye();
        }
    }
}
