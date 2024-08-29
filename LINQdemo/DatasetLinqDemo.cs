using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LINQdemo
{
    internal class DatasetLinqDemo
    {
        static void Main(string[] args)
        {


            string sqlSelect = "SELECT * FROM Dept;" + "SELECT * FROM Emp;";

            SqlConnection cn = new SqlConnection("server=.\\sqlexpress;database=HR;Integrated Security=true;Trust Server Certificate=true");
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, cn);
        
            // Create table mappings
            da.TableMappings.Add("Table", "Dept");
            da.TableMappings.Add("Table1", "Emp");

            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataRelation dr = ds.Relations.Add("FK_Employee_Department",
                              ds.Tables["Dept"].Columns["Deptno"],
                              ds.Tables["Emp"].Columns["Deptno"]);

            DataTable department = ds.Tables["Dept"];
            DataTable employee = ds.Tables["Emp"];


            //var query = from c in Categories.AsEnumerable()
            //            join p in Products.AsEnumerable()
            //            on c.Field<int>("CategoryID") equals p.Field<int>("CategoryID")
            //            select new
            //            {
            //                Prodid = p.Field<int>("ProductID"),
            //                PName = p.Field<string>("ProductName"),
            //                CatID =c.Field<int>("CategoryID"),
            //                CatName = c.Field<string>("CategoryName")
            //            };

            var query = from d in department.AsEnumerable()
                        join e in employee.AsEnumerable()
                        on d.Field<int>("Deptno") equals e.Field<int>("Deptno")
                        select new
                        {
                            EmployeeId = e.Field<int>("Empno"),
                            Name = e.Field<string>("Ename"),
                            DepartmentId = d.Field<int>("Deptno"),
                            DepartmentName = d.Field<string>("Dname")
                        };

            foreach (var q in query)
            {
                Console.WriteLine("Employee Id = {0} , Name = {1} , Department Name = {2} , Department No={3}",
                   q.EmployeeId, q.Name, q.DepartmentName,q.DepartmentId);
            }
            Console.ReadLine();
        }
    }
}