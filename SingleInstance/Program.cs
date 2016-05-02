using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mut = null;
            const string mutName = "RUNMEONCE";

            try
            {
                mut = Mutex.OpenExisting(mutName);
            }
            catch (WaitHandleCannotBeOpenedException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            if (mut == null)
            {
                mut = new Mutex(true, mutName);
            }
            else
            {
                mut.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.ReadKey();
        }
    }
}
