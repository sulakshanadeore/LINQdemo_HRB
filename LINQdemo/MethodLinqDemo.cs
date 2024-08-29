using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQdemo
{
    internal class MethodLinqDemo
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
                {
            new Employee{Empno=1,Ename="Raj",Salary=50000,City="Kochi" },
            new Employee{Empno=2,Ename="Suresh",Salary=30000,City="Kochi" },
            new Employee{ Empno=3,Ename="Rajesh",Salary=40000,City="Pune" },
            new Employee{ Empno=4,Ename="Girish",Salary=60000,City="Mumbai" },
            new Employee{ Empno=5,Ename="Ajay",Salary=80000,City="Mumbai" }

                };

            // var emp=employees.Where(e => e.Empno == 1).SingleOrDefault();//prints emp1 details using console.write

            //var emp1 = employees.Where(e => e.Empno == 1 || e.Empno == 2);//for each

            var emp2 = employees.GroupBy(e => e.City).Select(e => new {city=e.Key,empdata=e });
            foreach (var item in emp2)
            {
                Console.WriteLine(item.city);
                foreach (var item2 in item.empdata) 
                {
                    Console.WriteLine(item2.Empno);
                    Console.WriteLine(item2.Ename);
                    Console.WriteLine(item2.Salary);
                    Console.WriteLine(item2.City);
                }
            }


         

        }
    }
}
