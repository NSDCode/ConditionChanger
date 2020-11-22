using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ConditionsModifier
{


    public static void Execute(ModuleDefMD module, string MethodName, bool br)
    {
        foreach (TypeDef type in module.Types)
            foreach (MethodDef methods in type.Methods)
            {
                if (methods.HasBody)
                    if (methods.Body.HasInstructions)
                    {
                        if (methods.Name == MethodName)
                        {
                            if (br)
                            {
                                for (int i = 0; i < methods.Body.Instructions.Count; i++)
                                {
                                    if (methods.Body.Instructions[i].OpCode == OpCodes.Brtrue || methods.Body.Instructions[i].OpCode == OpCodes.Brtrue_S)
                                    {
                                        methods.Body.Instructions[i].OpCode = OpCodes.Brfalse;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"modifcation applied {methods.Body.Instructions[i].OpCode.Name} [{methods.Body.Instructions[i]}]");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < methods.Body.Instructions.Count; i++)
                                {
                                    if (methods.Body.Instructions[i].OpCode == OpCodes.Brfalse || methods.Body.Instructions[i].OpCode == OpCodes.Brfalse_S)
                                    {
                                        methods.Body.Instructions[i].OpCode = OpCodes.Brtrue;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nmodifcation applied {methods.Body.Instructions[i].OpCode.Name} [{methods.Body.Instructions[i]}]");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                }
                            }

                        }
                    }


            }
    }

    public static void ExecuteSbS(ModuleDefMD module, string MethodName)
    {
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
                                if (methods.Body.Instructions[i].OpCode == OpCodes.Brtrue_S 
                                    || methods.Body.Instructions[i].OpCode == OpCodes.Brfalse_S 
                                    || methods.Body.Instructions[i].OpCode == OpCodes.Brfalse 
                                    || methods.Body.Instructions[i].OpCode == OpCodes.Brtrue)
                                {
                                    Console.WriteLine($@"Bp -> [{i}] ({methods.Body.Instructions[i].OpCode.Name}) change ? (true / false)");
                                    Console.Write("->");
                                    string choice = Console.ReadLine();
                                    switch (choice)
                                    {
                                        case "false":
                                            methods.Body.Instructions[i].OpCode = OpCodes.Brfalse;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"modifcation applied {methods.Body.Instructions[i].OpCode.Name} [{methods.Body.Instructions[i].OpCode}]");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        case "true":
                                            methods.Body.Instructions[i].OpCode = OpCodes.Brtrue;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"modifcation applied {methods.Body.Instructions[i].OpCode.Name} [{methods.Body.Instructions[i]}]");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid argument.");
                                            break;
                                    }
                                }
                            }
                        }
                    }
            }
    }
}
