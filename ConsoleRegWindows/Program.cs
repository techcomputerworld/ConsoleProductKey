using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleRegWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Program that sees the Windows registry, and tell your product key");
                Console.WriteLine("Parameters: -w, your product key Windows 10");
                Console.Read();
            }
            else
            {
                if (args[0] == "-w")
                {
                    string pk ="";
                    string Version = "";
                    string ProductName = "";
                    string verNt = "";
                    string build = "";

                    string keyPath = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\SoftwareProtectionPlatform\\";
                    string keyPath1 = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\";
                    RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, 
                        RegistryView.Registry64);
                    RegistryKey rkProductKey = localKey.OpenSubKey(keyPath);
                    // OS Version 
                    RegistryKey rkVersion = localKey.OpenSubKey(keyPath1);
                    RegistryKey rkProductName = localKey.OpenSubKey(keyPath1);
                    RegistryKey rkVerNt = localKey.OpenSubKey(keyPath1);
                    RegistryKey rkBuild = localKey.OpenSubKey(keyPath1);
                    // ¿Donde esta la clave de registro?.
                    // Parametro false indica que la hemos abierto en modo solo lectura 


                    //rk1 = rk1.OpenSubKey(keyPath, false);



                    pk = (string)rkProductKey.GetValue("BackupProductKeyDefault");
                    Version = (string)rkVersion.GetValue("ReleaseId");
                    ProductName = (string)rkProductName.GetValue("ProductName");
                    verNt = (string)rkVerNt.GetValue("CurrentVersion");
                    build = (string)rkBuild.GetValue("CurrentBuild");

                    Console.WriteLine("Your Product Name: " + ProductName);
                    Console.WriteLine("Your Release ID is: " + Version);
                    Console.WriteLine("Your Version NT is: " + verNt);
                    Console.WriteLine("Your Build Windows is: " + build);
                    Console.WriteLine("Your product key Windows 10 is: " + pk);
                    Console.WriteLine("");
                    Console.WriteLine("Press enter to finish program");
                    Console.Read();
                    
                }
            }
        }
    }
}
