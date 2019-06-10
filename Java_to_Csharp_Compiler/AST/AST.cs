using System;
using System.Collections.Generic;
using System.IO;

namespace Java_to_Csharp_Compiler.AST
{
    //Enums
    public enum Modifier
    {
        Public, Static, Private
    }
    public enum Operator
    {
        Equal, Add, Sub, Mul, Mod, Dev
    }
    public enum PrimitiveType
    {
        Double,Float,Short,Long
    }
    //
    
    //Node Declarations
    public abstract class Declaration : Node
    {
        public abstract void AddToSymbolTable(SymbolTable symbolTable);
        public abstract Type GetJavaType();
    }
    public abstract class Statement : Node
    {
    }
    public abstract class Expression : Node
    {
        public Type type;
    }
    public abstract class Type : Node
    {
        public static Type Int = new IdentifierType("int");
        public static Type String= new IdentifierType("String");
        public static Type Float= new IdentifierType("float");
        public static Type Double = new IdentifierType("double");
        public static Type Bool = new IdentifierType("bool");
        public abstract bool Compatible(Type other);
    }
    //

    //Functional Classes
    public class ArrayType: Type
    {
        private Type elementType;

        public ArrayType(Type elementType)
        {
            this.elementType = elementType;
        }

        public override void GenCode(StreamWriter stream)
        {
            elementType.GenCode(stream);
            stream.Write(" [");
            stream.Write("] "); 
        }

        public override void GenStoreCode(StreamWriter stream)
        {
           
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            elementType.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            elementType.TypeCheck();
        }
        public override bool Compatible(Type other)
        {
            if (other is ArrayType)
            {
                return this.elementType.Compatible(((ArrayType)other).elementType);
            }
            else
            {
                return false;
            }
        }
    }
    public class IdentifierType: Type
    {
        private string type;

        public IdentifierType(string type)
        {
            this.type = type;
        }

        public override void GenCode(StreamWriter stream)
        {
            if (type == "String")
            {
                stream.Write("string");
            }
            else if (type == "int")
            {
                stream.Write("int32");
            }
            else if (type == "float")
            {
                stream.Write("float32");
            }
            else if (type == "bool")
            {
                stream.Write("bool");
            }
            else
            {
                stream.Write(type);
            }

        }
        public override string ToString()
        {
            return type;
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            //This is input value and we don't need to resolve the variable
        }

        public override void TypeCheck()
        {
            
        }

        public override bool Compatible(Type other)
        {
            if (other is IdentifierType)
            {
                return this.type == ((IdentifierType)other).type;
            }
            else
            {
                return false;
            }
        }
    }
    public class FormalParameter : Declaration
    {
        private Type dataType;
        private string paramName;

        public FormalParameter(Type dataType, string paramName)
        {
            this.dataType = dataType;
            this.paramName = paramName;
        }

        public string GetName()
        {
            return paramName;
        }
        public override void AddToSymbolTable(SymbolTable symbolTable)
        {
            //For the string variable, we can add it into the symbol table
            symbolTable.Add(paramName,this);
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("(");
            dataType.GenCode(stream);
            stream.Write(paramName);
            stream.WriteLine(")");
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override Type GetJavaType()
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            dataType.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            dataType.TypeCheck();
        }
    }
    public class IntegerLiteral: Expression
    {
        private int value;
        public IntegerLiteral(int value)
        {
            this.value = value;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("\t\tldc.i4 ");
            stream.WriteLine(value.ToString());
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            //Input value
        }

        public override void TypeCheck()
        {
            this.type = Type.Int;
        }
    }

    
    public class FloatLiteral: Expression
    {
        private float value;

        public FloatLiteral(float value)
        {
            this.value = value;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("\t\tldc.r4 ");
            stream.WriteLine(value.ToString());
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
        }

        public override void TypeCheck()
        {
            this.type = Type.Float;
        }
    }

    public class DoubleLiteral : Expression
    {
        private double value;

        public DoubleLiteral(double value)
        {
            this.value = value;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("\t\tldc.r8 ");
            stream.WriteLine(value.ToString());
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
        }

        public override void TypeCheck()
        {
            this.type = Type.Double;
        }
    }

    public class BoolLiteral:Expression
    {
        private bool value;

        public BoolLiteral(bool value)
        {
            this.value = value;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("\t\tldc.i4 ");
            if (value==true)
            {
                stream.WriteLine("1");
            }
            else if (value==false)
            {
                stream.WriteLine("0");
            }
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
        }

        public override void TypeCheck()
        {
            this.type = Type.Bool;
        }
    }
    //

    //Compilation Blocks
    public class CompilationUnit: Node
    {
        private SymbolTable CompilationUnit_SymbolTable;
        private List<Declaration> classDeclaration;

        public CompilationUnit( List<Declaration> classDeclaration)
        {
       
            this.classDeclaration = classDeclaration;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.WriteLine(".assembly HelloWorld");
            stream.WriteLine("{");
            stream.WriteLine("}");
            foreach (var declaration in classDeclaration)
                declaration.GenCode(stream);
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable parent)
        {
            
            //CompilationUint owns a symbol table, thus create a symbol table to store the below variables
            this.CompilationUnit_SymbolTable = new SymbolTable(parent);

            //These two are for Method Invocation which adding the print method into Symbol Table of Compilation Unit by using Method Declaration Format.
            //The format of the Symbol Table is {string:Declaration}, the MethodDeclaration is also a Declaration.
            CompilationUnit_SymbolTable.Add("println", new MethodDeclaration(new List<Modifier> { Modifier.Public }, new IdentifierType("void"), 
                "[mscorlib]System.Console::WriteLine", new List < FormalParameter >{new FormalParameter(Type.Int,"value")},null));

            CompilationUnit_SymbolTable.Add("print", new MethodDeclaration(new List<Modifier> { Modifier.Public }, new IdentifierType("void"), 
                "[mscorlib]System.Console::Write", new List<FormalParameter> { new FormalParameter(Type.Int, "value") }, null));
            
            //For each declaration in declaration list, we need to add all non-empty declarations into the symbol table we just created
            foreach (var declaration in classDeclaration)
                declaration.AddToSymbolTable(CompilationUnit_SymbolTable);
            //After adding into symbol table, resolve each variable
            foreach (var declaration in classDeclaration)
                declaration.ResolveNames(CompilationUnit_SymbolTable);
        }

        public override void TypeCheck()
        {
            
            foreach (var declaration in classDeclaration)
                declaration.TypeCheck();
            
        }
    }
    public class ClassDeclaration : Declaration
    {
        private SymbolTable Class_SymbolTable;
        private List<Modifier> modifiers;
        private string ClassName;
        private List<Declaration> classbodydeclarations;

        public ClassDeclaration(List<Modifier> modifiers, string ClassName, List<Declaration> classbodydeclarations)
        {
            this.modifiers = modifiers;
            this.ClassName = ClassName;
            this.classbodydeclarations = classbodydeclarations;
        }

        public override void AddToSymbolTable(SymbolTable symbolTable)
        {
            //String type variable, using add method
            symbolTable.Add(ClassName, this);
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write(".class ");
            foreach (var modifier in modifiers)
                if (modifier==Modifier.Public)
                {
                    stream.Write("public ");
                }
            stream.WriteLine(ClassName+" ");
            stream.WriteLine("{");
            foreach (var declaration in classbodydeclarations)
                declaration.GenCode(stream);
            stream.WriteLine("}");

        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }
        public string GetName()
        {
            return ClassName;
        }
        public override Type GetJavaType()
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(SymbolTable parent)
        {
            //Class declaration owns a symbol table to store the below variables
            this.Class_SymbolTable = new SymbolTable(parent);
            //There is Declarataion List exist, adding all non-empty declarations
            foreach (var declaration in classbodydeclarations)
                declaration.AddToSymbolTable(Class_SymbolTable);
            //Resolve declarations then
            foreach (var declaration in classbodydeclarations)
                declaration.ResolveNames(Class_SymbolTable);
        }

        public override void TypeCheck()
        {
            foreach (var declaration in classbodydeclarations)
                declaration.TypeCheck();
            
        }
    }
    public class MethodDeclaration : Declaration
    {
        private SymbolTable Method_SymbolTable;
        public List<Modifier> modifiers;
        public Type result;
        public string MethodName;
        public List<FormalParameter> parameters;
        private Statement body;

        public MethodDeclaration(List<Modifier> modifiers, Type result, string methodName, List<FormalParameter> parameters, Statement body)
        {
            this.modifiers = modifiers;
            this.result = result;
            MethodName = methodName;
            this.parameters = parameters;
            this.body = body;
        }

        public override void AddToSymbolTable(SymbolTable symbolTable)
        {
            //String variable using add method
            symbolTable.Add(MethodName, this);
        }

        public override void GenCode(StreamWriter stream)
        {
            string indent = "\t";
            //indent is used to formating.
            stream.Write(indent+".method ");
            foreach (var modifier in modifiers)
                if (modifier==Modifier.Public)
                {
                    stream.Write("public ");
                }
                else if (modifier==Modifier.Static)
                {
                    stream.Write("static ");
                }
            result.GenCode(stream);
            stream.Write(" "+MethodName);
            foreach (var para in parameters)
                para.GenCode(stream);
            stream.WriteLine(indent+"{");
            body.GenCode(stream);
            stream.WriteLine(indent+"\tret");
            stream.WriteLine(indent+"}");
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }


        public override Type GetJavaType()
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(SymbolTable parent)
        {
            //Each methon owns its symbol table
            this.Method_SymbolTable = new SymbolTable(parent);
            //For the List of declarations, add into the symbol table then resolve
            foreach (var para in parameters)
                para.AddToSymbolTable(Method_SymbolTable);
            foreach (var para in parameters)
                para.ResolveNames(Method_SymbolTable);
            //For the List of statements, we can resolve directly
            body.ResolveNames(Method_SymbolTable);
        }

        public override void TypeCheck()
        {
            foreach (var para in parameters)
                para.TypeCheck();

            body.TypeCheck();
            
        }
    }
    public class BlockStatement : Statement
    {
        private SymbolTable Block_SymbolTable;
        private List<Statement> blocks;

        public BlockStatement(List<Statement> blocks)
        {
            this.blocks = blocks;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.WriteLine("\t\t.entrypoint");
            foreach (var block in blocks)
                block.GenCode(stream);
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable parent)
        {
            //Each Block Statement has a symbol talbe as well
            this.Block_SymbolTable = new SymbolTable(parent);
            //The Statement can be resolved directly
            foreach (var block in blocks)
                block.ResolveNames(Block_SymbolTable);
        }

        public override void TypeCheck()
        {
            if (blocks!=null)
            {
                foreach (var block in blocks)
                    block.TypeCheck();
            }
        }
    }
    //

    //Method Block 1
    public class LocalVariableDeclarationStatement : Statement
    {
        private Type datatype;
        private List<VariableDeclarator> variables;
        

        public LocalVariableDeclarationStatement(Type datatype, List<VariableDeclarator> variables)
        {
            this.datatype = datatype;
            this.variables = variables;
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write("\t\t.locals init ");
            stream.Write("( ");
            datatype.GenCode(stream);
            foreach (var variable in variables)
                variable.GenCode(stream);
            stream.WriteLine(")");
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            //The symbol table of this block is created above, we can resolve all the variables directly
            datatype.ResolveNames(symbolTable);
            foreach (var variable in variables)
                variable.AddToSymbolTable(symbolTable);
            foreach (var variable in variables)
                variable.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            datatype.TypeCheck();
            foreach (var variable in variables)
            {
                variable.SetJavaType(datatype);
                variable.TypeCheck();
            }

            // set type of all VariableDeclarators to this.datatype
        }
    }
    public class VariableDeclarator : Declaration
    {
        private string identifiers;

        //initiating the type of the identifiers
        private Type type;
        

        public VariableDeclarator(string identifiers)
        {
            this.identifiers = identifiers;
        }

        public override void AddToSymbolTable(SymbolTable symbolTable)
        {
            symbolTable.Add(identifiers, this);
        }

        public override void GenCode(StreamWriter stream)
        {
            stream.Write(" {0}", identifiers);
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override Type GetJavaType()
        {
            return type;
            //return the type assigned at the SetJavaType
        }
        public void SetJavaType(Type type)
        {
            this.type = type;
            //The type will be assigned in LocalVariableDeclaration, assign the this.type as the formal parameter
        }
        public override void ResolveNames(SymbolTable symbolTable)
        {
            //Only variable is string type and added into symbol table above
        }

        public override void TypeCheck()
        {
            
        }
    }
    //
    
    //Method Block 2
    public class ExpressionStatement: Statement     
    {
        private Expression expression;
        

        public ExpressionStatement(Expression expression)
        {
            this.expression = expression;
        }

        public override void GenCode(StreamWriter stream)
        {

            expression.GenCode(stream);
            if (expression is AssignmentExpression)
            {
                stream.WriteLine("\t\tpop");
            }
        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            expression.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            if (expression!=null)
            {
                expression.TypeCheck();
            }
        }
    }
    public class AssignmentExpression:Expression
    {
        private Expression lefthandside;
        private Operator operatortype;
        private Expression righthandside;

        public AssignmentExpression(Expression lefthandside, Operator operatortype, Expression righthandside)
        {
            this.lefthandside = lefthandside;
            this.operatortype = operatortype;
            this.righthandside = righthandside;
        }

        public override void GenCode(StreamWriter stream)
        {
            
            righthandside.GenCode(stream);
            stream.WriteLine("\t\tdup");
            lefthandside.GenStoreCode(stream);

        }

        public override void GenStoreCode(StreamWriter stream)
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            //The symbol table is created 
            lefthandside.ResolveNames(symbolTable);
            righthandside.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            lefthandside.TypeCheck();
            righthandside.TypeCheck();
            if (!lefthandside.type.Compatible(righthandside.type))
            {
                throw new System.Exception("Type Check Error!");
            }
            type = righthandside.type;
            
        }
    }
    public class ExpressionName : Expression
    {
        private string expression_name;
        Declaration decl;
        public ExpressionName(string expression_name)
        {
            this.expression_name = expression_name;
        }

        public override void GenCode(StreamWriter stream)
        {
            if (decl is VariableDeclarator)
            {
                stream.Write("\t\tldloc ");
                stream.WriteLine(expression_name);
            }
            else
            {
                throw new System.NotImplementedException("The declaration cannot be found while loading variable location!");
            }
        }

        public override void GenStoreCode(StreamWriter stream)
        {
            if (decl is VariableDeclarator)
            {
                stream.Write("\t\tstloc ");
                stream.WriteLine(expression_name);
            }
            else
            {
                throw new System.NotImplementedException("Cannot store the value to location!");
            }
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            //For this variable, the expression name should be declared otherwise should return error.
            //The left hand side should be declared in local variable declaration class before process the expression.
            //This variable should be found in the current symbol table, otherwise we should check the previous level table.
            //The symbol table is using a string type as a key and declaration as the content.
            //Thus, the logical is :
            //Search the current table, if return declaration thats good
            //If return null, that represents the value might exist in upper level's table
            //Thus, we need to search the parent of current symbol table by using this string
            //If all false, raise the error that the left hand side variable has not declared.
            decl = symbolTable.LookUpExprName(expression_name);
            
        }

        public override void TypeCheck()
        {
            type=decl.GetJavaType();
        }
    }
    public class BinaryExpression : Expression
    {
        private Expression LeftExpression;
        private Operator Operator;
        private Expression RightExpression;

        public BinaryExpression(Expression LeftExpression, Operator Operator, Expression RightExpression)
        {
            this.LeftExpression = LeftExpression;
            this.Operator = Operator;
            this.RightExpression = RightExpression;
        }

        public override void GenCode(StreamWriter stream)
        {
            LeftExpression.GenCode(stream);
            RightExpression.GenCode(stream);
            if (Operator == Operator.Add)
            {
                stream.WriteLine("\t\tadd");
            }

        }

        public override void GenStoreCode(StreamWriter stream)
        {

        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            LeftExpression.ResolveNames(symbolTable);
            RightExpression.ResolveNames(symbolTable);
        }

        public override void TypeCheck()
        {
            LeftExpression.TypeCheck();
            RightExpression.TypeCheck();
            if (!LeftExpression.type.Compatible(RightExpression.type))
            {
                throw new Exception("Additive Expression Type Error!");
            }
            type =RightExpression.type;
        }
    }


    //Block 3
    public class MethodInvocation: Expression
    {
        private string MethodName;
        private List<Expression> ArgumentList;
        private Declaration decl;

        public MethodInvocation(string methodName, List<Expression> argumentList)
        {
            MethodName = methodName;
            ArgumentList = argumentList;
        }

        public override void GenCode(StreamWriter stream)
        {
            //We add print method into Symbol Table of Compilaion Unit, the decl should be the MethodDeclaration that what we declare
            //If decl is not MethodDeclaration that means the method is not the print method because we only add the print method into Symbol Table in Compilation Unit.
            if (decl is MethodDeclaration)
            {
                MethodDeclaration methoddecl = (MethodDeclaration)decl;
                //We can change the default setting by following:
                //methoddecl.result = new IdentifierType("void");
                //methoddecl.modifiers = new List<Modifier> { Modifier.Public, Modifier.Static };
                //methoddecl.MethodName = MethodName;
                //methoddecl.
                
                //The print method will be printed in method declaration part
                foreach (var argu in ArgumentList)
                    argu.GenCode(stream);

                stream.Write("\t\tcall ");

                    methoddecl.result.GenCode(stream);
                    stream.Write(" {0}(",methoddecl.MethodName);
                    foreach (var argu in ArgumentList)
                        argu.type.GenCode(stream);
                    stream.WriteLine(")");
            }
            else
            {
                throw new System.NotSupportedException("Not the method "+MethodName);
            }
        }

        public override void GenStoreCode(StreamWriter stream)
        {

        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            decl = symbolTable.LookUpExprName(MethodName);
            foreach (var argu in ArgumentList)
                argu.ResolveNames(symbolTable);

        }

        public override void TypeCheck()
        {
            foreach (var argu in ArgumentList)
                argu.TypeCheck();
        }
    }
    //
}

