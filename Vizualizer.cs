using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Vizualizer
    {
        public static void Execute(ModuleDefMD module, string MethodName)
        {
            Console.WriteLine(MethodName);
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (TypeDef type in module.Types)
                    foreach (MethodDef methods in type.Methods)
                    {
                        if (methods.HasBody)
                            if (methods.Body.HasInstructions)
                            {
                                if (methods.Name == MethodName)
                                {
                                    for (int i = 0; i < methods.Body.Instructions.Count; i++)
                                    {
                                        int lenght = $"{methods.Body.Instructions[i]} - {methods.Body.Instructions[i].OpCode.Value}".Length;
                                        Console.WriteLine(GenerateBar(lenght));
                                        Console.WriteLine($"|{methods.Body.Instructions[i]} - {methods.Body.Instructions[i].OpCode.Value}|");
                                        Console.WriteLine(GenerateBar(lenght));
                                        Console.WriteLine("|\n|");
                                    }
                                    
                                }
                            }
                    }
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static string GenerateBar(int force)
        {
            string result = string.Empty;
            for (int i = 0; i < force; i++)
            {
                result += "_";
            }
            return result;
        }
       
    }

