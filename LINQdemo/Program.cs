using LINQdemo;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee{Empno=1,Ename="Raj",Salary=50000,City="Kochi" },
            new Employee{Empno=2,Ename="Suresh",Salary=30000,City="Kochi" },
            new Employee{ Empno=3,Ename="Rajesh",Salary=40000,City="Pune" },
            new Employee{ Empno=4,Ename="Girish",Salary=60000,City="Mumbai" },
            new Employee{ Empno=5,Ename="Ajay",Salary=80000,City="Mumbai" }

        };



        //SimpleExample(employees);

        //Group by with anonymous type
        //var empdata = from emp in employees
        //             group emp by emp.City into cityGroup
        //              select new { empcity = cityGroup.Key, newempdata = cityGroup };


        //foreach (var emp in empdata)
        //{
        //    Console.WriteLine("City: " + emp.empcity);
        //    foreach (var item in emp.newempdata)
        //    {
        //        Console.WriteLine(item.Empno);
        //        Console.WriteLine(item.Ename);
        //        Console.WriteLine(item.Salary);
        //        Console.WriteLine(item.City);
        //    }

        //}


        var empdataWithoutAnonymous = from emp in employees
                                      orderby emp.Ename descending
                                      group emp by emp.City into cityGroup
                                      where cityGroup.Count()>1
                                      select cityGroup;
        foreach (var item in empdataWithoutAnonymous)
        {
            Console.WriteLine("City:" + item.Key);
            foreach (var edata in item)
            {
                Console.WriteLine(edata.Empno);
                Console.WriteLine(edata.Ename);
                Console.WriteLine(edata.Salary);
                Console.WriteLine(edata.City);

            }
        }



        Console.ReadKey();

    }

    private static void SimpleExample(List<Employee> employees)
    {
        var empdata = from emp in employees
                      where emp.City == "Kochi"
                      select new { Empempno = emp.Empno, Empename = emp.Ename, Empcity = emp.City };


        employees.Add(new Employee { Empno = 6, Ename = "Surekha", Salary = 56000, City = "Kochi" });


        foreach (var emp1 in empdata)
        {
            Console.WriteLine(emp1.Empempno);
            Console.WriteLine(emp1.Empename);
            Console.WriteLine(emp1.Empcity);
        }
    }
}