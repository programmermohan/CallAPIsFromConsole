using System;

namespace CallAPIs
{
    class Program
    {
        static void Main(string[] args)
        {
            CallAPIs.Classes.CallAPIs obj = new Classes.CallAPIs();
            
            //obj.RegisterUser();
            //obj.RegisterAdminUser();

            obj.LoginToGetBearerToken();
            obj.GetEmployeesByToken();

            //Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
