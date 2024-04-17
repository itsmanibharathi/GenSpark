using ReqTrackerModelLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerApp
{

    public class TryCollection
    {

        public void TryArrayList()
        {
            ArrayList a = new ArrayList();
            a.Add(1);
            a.Add("Mani");
            a.Add(2.5);
            a.Add(DateTime.Now);
            a.Add(new Employee(101, "Mani", DateTime.MinValue, 2000));
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

        }

        public void TryList()
        {
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
        }

        void UnderstandingDictionary()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Ramu");
            employees.Add(102, "Komu");
            employees.Add(103, "Bimu");
            employees.Add(104, "Ramu");
            foreach (var key in employees.Keys)
            {
                Console.WriteLine(key + " " + employees[key]);
            }
            if (employees.ContainsKey(101))
                Console.WriteLine("employee 101 present and name is " + employees[101]);
            if (employees.ContainsValue("Somu"))
                Console.WriteLine("there is an emploeye with name Somu in teh collection");
        }


        public static void Main()
        {
            new TryCollection().UnderstandingDictionary();

            // Console.WriteLine(new Employee(101, "Mani", DateTime.MinValue, 2000));
        }

    }
}
