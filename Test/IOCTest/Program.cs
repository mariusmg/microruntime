using System;
using System.Collections.Specialized;
using System.Configuration;
using voidsoft.MicroRuntime;

namespace testioc
{
    class Program
    {
        static void Main(string[] args)
        {

             //NameValueCollection devSection = (NameValueCollection)ConfigurationManager.GetSection("Microruntime.IOC");

             //for (int i = 0; i < devSection.Count; i++)
             //{
             //    Console.WriteLine(devSection.GetKey(i));
             //    Console.WriteLine(devSection.Get(devSection.GetKey(i)));

             //}


            InversionOfControl ic = new InversionOfControl();


            IBlah ib = (IBlah) ic.GetInstance("inst");
            ib.DoStuff();

            Console.ReadLine();
        }
    }
}
