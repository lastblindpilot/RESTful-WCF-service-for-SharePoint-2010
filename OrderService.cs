using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SPWcfExample
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OrderService : IOrderService
    {
        public Order GetOrder(string customerName)
        {
            Order order = new Order
            {
                CustomerName = "Metro",
                OrderNumber = 101,
                ProductNumber = 100,
                Quantity = 5
            };

            return order;
        }

        public int PlaceOrder(Order order)
        {
            return 101;
        }

        public string Test()
        {
            return "Hello World";
        }

        public List<Employee> GetAllEmployeesMethod()
        {
            List<Employee> mylist = new List<Employee>();

            using (SqlConnection conn = new SqlConnection("Data Source=server;Initial Catalog=Inventory;Integrated Security=SSPI;"))
            {
                conn.Open();

                string cmdStr = String.Format("Select firstname,lastname,salary from dataWcfTest");
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                        mylist.Add(new Employee(rd.GetString(0), rd.GetString(1), rd.GetDecimal(2)));
                }
                conn.Close();
            }

            return mylist;
        }
    }
}