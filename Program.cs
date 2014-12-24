using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace _48
{
    class Program
    {
        static void Main(string[] args)
        {
            int SelectedItem;
            RegistryKey[] regs = new [] {Registry.ClassesRoot,
                                         Registry.CurrentUser,
                                         Registry.LocalMachine,
                                         Registry.Users,
                                         Registry.CurrentConfig};

            do{
                int i = 1;
                Console.WriteLine("Select partitions system registy");
                foreach(RegistryKey reg in regs)
                {
                    Console.WriteLine("{0}. {1}",i++, reg.Name);
                }
                Console.WriteLine("0. Exit");

                Console.WriteLine(">  ");
                SelectedItem = Convert.ToInt32(Console.ReadLine()[0])-48;
                Console.WriteLine();
                if(SelectedItem > 0 && SelectedItem <= regs.GetLength(0))
                    PrintRegKeys(regs[SelectedItem-1]);
            }while(SelectedItem != 0);
        }

        static void PrintRegKeys(RegistryKey rk)
        {
            string[] names = rk.GetSubKeyNames();
            Console.WriteLine("Підрозділи {0}", rk.Name);
            Console.WriteLine("===================================================");
            foreach (string s in names)
                Console.WriteLine(s);
            Console.WriteLine("===================================================");

        }
    }
}
