using System;
using Java_to_Csharp_Compiler.AST;
using System.Collections.Generic;
using System.IO;

namespace Java_to_Csharp_Compiler.AST
{

    public class SymbolTable
    {
        private Dictionary<string, Declaration> table;
        private SymbolTable parent;

        public SymbolTable(SymbolTable parent)
        {
            table = new Dictionary<string, Declaration>();
            this.parent = parent;
        }

        public void Add(string identifier, Declaration decl)
        {
            // if the name is already in the table, throw an exception
            //    because we can't have int x; int x;
            // else
            //    add identifier, decl to table
            if (table.ContainsKey(identifier))
            {
                throw new Exception("Identifier is already in Symbol Table!");
            }
            else
            {
                table[identifier] = decl;

            }
        }

        public Declaration ResolveName(string name)
        {
            //if table contain the name, then return the value
            //otherwise return null
            if (table.ContainsKey(name))
            {
                return table[name];
            }
            else
            {
                return null;
            }
        }
        public Declaration LookUpExprName(string name)
        {
            //getting result from ResolveName
            //if the result is not null then return what it got
            // else check the parent symbol table is null or not, if no then check the symbol table in previous level that the expression name assigned or not
            // if all are false, then return False
            Declaration decl = ResolveName(name);
            if (decl != null)
            {
                return decl;
            }
            else if(parent!=null)
            {
                return parent.LookUpExprName(name);
            }
            else
            {
                throw new System.Exception("Undeclare Identifier!"+name);
            }
        }
    }

    

    public abstract class Node
    {
        public abstract void ResolveNames(SymbolTable symbolTable);
        public abstract void TypeCheck();
        public abstract void GenCode(StreamWriter stream);

        public abstract void GenStoreCode(StreamWriter stream);
        void Indent(int n)
        {
            //Print the indent to identify the level of the recursion 
            for (int i = 0; i < n; i++)
                Console.Write("    ");
        }

        public void DumpValue(int indent = 0)
        {
            
            Indent(indent);
            //Get the Current field. e.g. the CompilationUnit or Class Declaration
            Console.WriteLine("{0}", GetType().ToString());
            
            Indent(indent);
            Console.WriteLine("{");

            //Loop every variables declared in the class e.g. symbol table
            //The Instance is getting the non-static methon and the NonPublic is getting the every level of protection without public
            foreach (var field in GetType().GetFields(System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Instance))
            {
                object value = field.GetValue(this);
                Indent(indent + 1);

                // Is this value something we can iterate through?
                // We test that it is a generic type, this way we don't treat strings as IEnumerables.
                if (value is System.Collections.IEnumerable && value.GetType().IsGenericType)
                {
                    Console.WriteLine("{0}:", field.Name);
                    Indent(indent + 1);
                    Console.WriteLine("{");

                    foreach (object item in (System.Collections.IEnumerable)value)
                    {
                        if (item is Node)
                        {
                            ((Node)item).DumpValue(indent + 2);
                        }
                        else
                        {
                            Indent(indent + 2);
                            Console.WriteLine("Enum: {0}", item);
                        }
                    }

                    Indent(indent + 1);
                    Console.WriteLine("}");
                }
                else if (value is Node)
                {
                    Console.WriteLine("{0}:", field.Name);
                    ((Node)value).DumpValue(indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", field.Name, value);
                }
            }

            Indent(indent);
            Console.WriteLine("}");
        }
    };

}
