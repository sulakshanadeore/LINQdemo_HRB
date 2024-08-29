using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQdemo
{
    internal class Customers
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
   }
   internal class Orders 
    {
        public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public int Amt { get; set; }
    }

    internal class Payment 
    {
        public int OrderID { get; set; }
        public string PaymentMode { get; set; }

        public int TranID { get; set; }
    }

    internal class CustApp
    {
        static void Main(string[] args)
        {
            List<Customers> custs = new List<Customers>()
            {
                new Customers {CustID=1,CustName="Bob" },
                new Customers {CustID=2,CustName="John" }
            };

            List<Orders> orders = new List<Orders>()
            {
            new Orders{CustomerID=1,OrderID=101,Amt=1000 },
            new Orders {CustomerID=1,OrderID=111,Amt=10000 },
            new Orders{CustomerID=2,OrderID=908,Amt=1990 },
            new Orders{CustomerID=2,OrderID=19,Amt=3333 },
            new Orders{CustomerID=1,OrderID=88,Amt=6663 }
            };

            List<Payment> payments = new List<Payment>()
            {
            new Payment{OrderID=101,PaymentMode="Debit Card",TranID=100000 },
            new Payment{OrderID=111,PaymentMode="Credit Card",TranID=100001 },
            new Payment{OrderID=908,PaymentMode="Debit Card",TranID=100002},
            new Payment{OrderID=19,PaymentMode="COD",TranID=100003 },
            new Payment{OrderID=88,PaymentMode="UPI",TranID=100004 },
            };

            //var custOrders = custs.Join(orders, c => c.CustID, o => o.CustomerID, (c, o) => new 
            //{   cid=c.CustID,
            //    orderid=o.OrderID,
            //    custname=c.CustName,
            //orderValue=o.Amt
            //});
            //foreach (var item in custOrders)
            //{
            //    Console.WriteLine(item.cid);
            //    Console.WriteLine(item.orderid);
            //    Console.WriteLine(item.custname);
            //    Console.WriteLine(item.orderValue);
            //}

            var orderCustPayments = custs.Join(orders, c => c.CustID, o => o.CustomerID, (c, o) => new { c, o }).
                Join(payments, co => co.o.OrderID, p => p.OrderID, (co, p) => new { cid = co.c.CustID,
                    orderid = co.o.OrderID,
                    custname = co.c.CustName,
                    orderValue = co.o.Amt,
                    paymode = p.PaymentMode,
                    txnId = p.TranID
                });

            foreach (var order in orderCustPayments)
            {
                Console.WriteLine(order.cid);
                Console.WriteLine(order.custname);
                Console.WriteLine(order.orderid);
                Console.WriteLine(order.orderValue);
                Console.WriteLine(order.paymode);
                Console.WriteLine(order.txnId);


            }



        }

}


}
