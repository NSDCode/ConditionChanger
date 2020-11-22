using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsChanger
{
    class Program
    {
        enum ErrorCode : ushort
        {
            NullArg = 0x1,
            InvalidExtension = 0x2,
            NoError = 0x0
        }


        static void Main(string[] args)
        {
            Console.Title = "Instructions Editor - Prometheo";
            ModuleDefMD module;
            ErrorCode NullArg = ErrorCode.NullArg;
            try
            {
                module = ModuleDefMD.Load(args[0]);
            }
            catch
            {
                Log((ushort)NullArg);
                Console.Read();
                Environment.Exit(0);
            }
            module = ModuleDefMD.Load(args[0]);
            Console.WriteLine("1 - brfalse -> brtrue");
            Console.WriteLine("2 - brtrue -> brfalse");
            Console.WriteLine("3 - Step by Step");
            Console.WriteLine("4 - Vizualize IL Code");
            Console.Write("->");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Method Name ?");
                    Console.Write("->");
                    string MethodName = Console.ReadLine();
                    ConditionsModifier.Execute(module, MethodName, false);
                    break;
                case 2:
                    Console.WriteLine("Method Name ?");
                    Console.Write("->");
                    MethodName = Console.ReadLine();
                    ConditionsModifier.Execute(module, MethodName, true);
                    break;
                case 3:
                    Console.WriteLine("Method Name ?");
                    Console.Write("->");
                    MethodName = Console.ReadLine();
                    ConditionsModifier.ExecuteSbS(module, MethodName);
                    break;
                case 4:
                    Console.WriteLine("Method Name ?");
                    Console.Write("->");
                    MethodName = Console.ReadLine();
                    Vizualizer.Execute(module, MethodName);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            module.Write($@"{Environment.CurrentDirectory}\assembly-edited.exe");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Module Saved.");

            Console.Read();
        }


        static void Log(ushort errorcode)
        {
            switch (errorcode)
            {
                case 0x0:
                    break;
                case 0x1:
                    Console.WriteLine($"Error occured: Argument is null or invalid. ({errorcode})");
                    break;
                case 0x2:
                    Console.WriteLine($"Error Occured: Invalid Extension. ({errorcode})");
                    break;
            }
        }
    }
}
