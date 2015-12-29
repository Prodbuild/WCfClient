using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfClient.CustomerServiceReference;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // GetCusotmer();

            AddCustomer();



            Console.ReadLine();
        }

        private static void AddCustomer()
        {
            try
            {
                using (CustomerServiceClient client = new CustomerServiceClient())
                {
                    int index = client.AddCustomer(new Customer
                    {
                        CustomerId = 101,
                        CustomerName = "Anish",
                        City = "Kolkata",
                        State = "West Bengal"
                    });
                    Console.WriteLine("{0}", index);
                }
            }

            // == Using normal exception and Fault exception ==
            //catch (Exception ex)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(ex.Message);
            //    Console.ForegroundColor = ConsoleColor.White;
            //}

            catch (FaultException<InvalidCustomerEntry> ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}:{1}", ex.Detail.ErrorCode, ex.Detail.ErrorMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void GetCusotmer()
        {
            using (CustomerServiceClient client = new CustomerServiceClient())
            {
                Customer cust = client.GetCustomer(102);
                Console.WriteLine("{0}", cust.CustomerName);
            }
        }
    }
}
