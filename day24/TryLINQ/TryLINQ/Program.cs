namespace TryLINQ
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string dept { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // add 10 student 

            IEnumerable<Student> students = new List<Student>
            {
                new Student { ID = 1, Name = "John", Age = 18, dept = "CSE" },
                new Student { ID = 2, Name = "Steve", Age = 21, dept = "CSE" },
                new Student { ID = 3, Name = "Bill", Age = 25, dept = "EEE" },
                new Student { ID = 4, Name = "Ram", Age = 20, dept = "EEE" },
                new Student { ID = 5, Name = "Ron", Age = 31, dept = "CSE" },
                new Student { ID = 6, Name = "Chris", Age = 17, dept = "EEE" },
                new Student { ID = 7, Name = "Rob", Age = 19, dept = "CSE" },
                new Student { ID = 8, Name = "Robert", Age = 23, dept = "EEE" },
                new Student { ID = 9, Name = "Kim", Age = 22, dept = "CSE" },
                new Student { ID = 10, Name = "Jim", Age = 29, dept = "EEE" }
            };

            //var groupByDept = students.GroupBy(s => s.dept);
            //foreach (var dept in groupByDept)
            //{
            //    Console.WriteLine("Department: " + dept.Key);
            //    foreach (var student in dept)
            //    {
            //        Console.WriteLine("ID: " + student.ID + ", Name: " + student.Name + ", Age: " + student.Age);
            //    }
            //    Console.WriteLine();
            //}

            //var res = students.FirstOrDefault(x => x.dept == "EEE");

            //Console.WriteLine("ID: " + res.ID + ", Name: " + res.Name + ", Age: " + res.Age);

            string str = "hii";
            List<char> ch = str.ToList<char>();

            foreach (var c in ch)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine(ch.SingleOrDefault());
            
        }
    }
}
