using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Java_to_Csharp_Compiler.AST;

namespace Java_to_Csharp_Compiler
{
    /*
    public enum Tokens
    {
        /*
        NUMBER = 258,
        IDENT = 259,
        IF = 260,
        ELSE = 261,
        DO=262,
        WHILE=263,
        FOR=264,
        SWITCH=265,
        THROWS=266,
        NULL=267,
        VOID=268,
        PACKAGE=269,
        BOOL=270,
        BYTE=271,
        SHORT=272,
        INT=273,
        LONG=274,
        CHAR=275,
        FLOAT=276,
        DOUBLE=277,
        VAR=278,
        PUBLIC=279,
        PRIVATE=280,
        PROTECTED=281,
        ABSTRACT=282,
        STATIC=283,
        FINAL=284,
        SYNCHRONIZED=285,
        NATIVE=286,
        STRICTFP=287,
        ENUM=288,
        CLASS=289,
        NEW=290,
        SUPER=291,
        INTERFACE=292,
        BITANDEQUAL=293,
        BITOREQUAL=294,
        CONTINUE=295,
        GOTO=296,
        CONDITIONALOPER=297,
        LAMBDA=298,
        EQUAL=299,
        LARGE=300,
        SMALL=301,
        NOTEQUAL=302,
        ANDAND=303,
        OROR=304,
        INCREMENT=305,
        DECREMENT=306,
        LEFTSHIFT=307,
        RIGHTSHIFT=308,
        FILLZERO=309,
        ADDEQUAL=310,
        SUBEQUAL=311,
        MULEQUAL=312,
        DIVEQUAL=313,
        ANDEQUAL=314,
        OREQUAL=315,
        XOREQUAL=316,
        MODEQUAL=317,
        LEFTSHIFTEQUAL=318,
        RIGHTSHIFTEQUAL=319,
        FILLZEROEQUAL=320,
        THREEPOINTS=321,
        TWOCOLONS=322,
        EOF = 323
    };

    public struct MyValueType
    {
        public int num;
        public string name;
       
    }
    
    public abstract class ScanBase
    {
        public MyValueType yylval;
        public abstract int yylex();
        protected virtual bool yywrap() { return true; }
    }*/
    
    class Program
    {
        /*
        static int test(int n)
        {
            if (n == 0)
                return 0;
            else
                return n * 2 + test(n - 1);
        }*/
        static void Main(string[] args)
        {
            /*
            CompilationUnit root = new CompilationUnit(
                new List<Declaration>
                {
                    new ClassDeclaration
                    (
                        new List<Modifier>(){Modifier.Public},
                        "HolloWorld",new List<Declaration>()
                        {
                            new MethodDeclaration
                            (
                                new List<Modifier>(){Modifier.Public,Modifier.Static},
                                new IdentifierType("void"),"main",
                                new List<FormalParameter>
                                {
                                    new FormalParameter(new ArrayType(new IdentifierType("String")),"args")
                                },
                                new BlockStatement(
                                    new List<Statement>
                                    (
                                        new List<Statement>()
                                        {
                                            new LocalVariableDeclarationStatement
                                            (
                                                new IdentifierType("int"),
                                                new VariableDeclarator("x")
                                                
                                            ),
                                            new ExpressionStatement
                                            (
                                                    //new AssignmentExpression(new ExpressionName("x"), Operator.Equal, new IntegerLiteral(42))
                                                    // x=x+5+y
                                                    new AssignmentExpression(new ExpressionName("x"), Operator.Equal,
                                                        new BinaryAdditiveExpression(new ExpressionName("x"), Operator.Add,
                                                            new BinaryAdditiveExpression(new IntegerLiteral(5), Operator.Add, new ExpressionName("y"))))
                                            )
                                        }
                                    )
                                )
                             )
                        }
                    )
                });
            root.DumpValue(0);
            */
            /*
            new ExpressionStatement(
                new MethodInvocation("print", new List<Expression>()
                {
                    new ExpressionName("x")
                })
            );*/
            Scanner scanner = new Scanner(
                new FileStream(args[0], FileMode.Open));

            Parser parser = new Parser(scanner);
            parser.Parse();
            //int x = test(100);
            Parser.root.ResolveNames(null);
            Parser.root.TypeCheck();
            Parser.root.DumpValue(0);

            
            StreamWriter writestream = new StreamWriter("log.txt");
            Parser.root.GenCode(writestream);
            writestream.Close();


            /*
            Tokens token;
            do
            {
                token = (Tokens)scanner.yylex();
                switch (token)
                {
                    case Tokens.NUMBER:
                        Console.WriteLine("NUMBER ({0})", scanner.yylval.num);
                        break;
                    case Tokens.IDENT:
                        Console.WriteLine("IDENT ({0})", scanner.yylval.name);
                        break;
                   
                    case Tokens.IF:
                        Console.WriteLine("IF");
                        break;
                    case Tokens.ELSE:
                        Console.WriteLine("ELSE");
                        break;
                    case Tokens.DO:
                        Console.WriteLine("DO");
                        break;
                    case Tokens.WHILE:
                        Console.WriteLine("WHILE");
                        break;
                    case Tokens.FOR:
                        Console.WriteLine("FOR");
                        break;
                    case Tokens.SWITCH:
                        Console.WriteLine("SWITCH");
                        break;
                    case Tokens.THROWS:
                        Console.WriteLine("THROWS");
                        break;
                    case Tokens.NULL:
                        Console.WriteLine("NULL");
                        break;
                    case Tokens.VOID:
                        Console.WriteLine("VOID");
                        break;
                    case Tokens.PACKAGE:
                        Console.WriteLine("PACKAGE");
                        break;
                    case Tokens.BOOL:
                        Console.WriteLine("BOOL");
                        break;
                    case Tokens.BYTE:
                        Console.WriteLine("BYTE");
                        break;
                    case Tokens.SHORT:
                        Console.WriteLine("SHORT");
                        break;
                    case Tokens.INT:
                        Console.WriteLine("INT");
                        break;
                    case Tokens.LONG:
                        Console.WriteLine("LONG");
                        break;
                    case Tokens.CHAR:
                        Console.WriteLine("CHAR");
                        break;
                    case Tokens.FLOAT:
                        Console.WriteLine("FLOAT");
                        break;
                    case Tokens.DOUBLE:
                        Console.WriteLine("DOUBLE");
                        break;
                    case Tokens.VAR:
                        Console.WriteLine("VAR");
                        break;
                    case Tokens.PUBLIC:
                        Console.WriteLine("PUBLIC");
                        break;
                    case Tokens.PRIVATE:
                        Console.WriteLine("PRIVATE");
                        break;
                    case Tokens.PROTECTED:
                        Console.WriteLine("PROTECTED");
                        break;
                    case Tokens.ABSTRACT:
                        Console.WriteLine("ABSTRACT");
                        break;
                    case Tokens.STATIC:
                        Console.WriteLine("STATIC");
                        break;
                    case Tokens.FINAL:
                        Console.WriteLine("FINAL");
                        break;
                    case Tokens.SYNCHRONIZED:
                        Console.WriteLine("SYNCHRONIZED");
                        break;
                    case Tokens.NATIVE:
                        Console.WriteLine("NATIVE");
                        break;
                    case Tokens.STRICTFP:
                        Console.WriteLine("STRICTFP");
                        break;
                    case Tokens.ENUM:
                        Console.WriteLine("ENUM");
                        break;
                    case Tokens.CLASS:
                        Console.WriteLine("CLASS");
                        break;
                    case Tokens.NEW:
                        Console.WriteLine("NEW");
                        break;
                    case Tokens.SUPER:
                        Console.WriteLine("SUPER");
                        break;
                    case Tokens.INTERFACE:
                        Console.WriteLine("INTERFACE");
                        break;
                    case Tokens.BITANDEQUAL:
                        Console.WriteLine("&&=");
                        break;
                    case Tokens.BITOREQUAL:
                        Console.WriteLine("||=");
                        break;
                    case Tokens.CONTINUE:
                        Console.WriteLine("CONTINUE");
                        break;
                    case Tokens.GOTO:
                        Console.WriteLine("GOTO");
                        break;
                    case Tokens.CONDITIONALOPER:
                        Console.WriteLine("?:");
                        break;
                    case Tokens.LAMBDA:
                        Console.WriteLine("->");
                        break;
                    case Tokens.EQUAL:
                        Console.WriteLine("==");
                        break;
                    case Tokens.LARGE:
                        Console.WriteLine(">=");
                        break;
                    case Tokens.SMALL:
                        Console.WriteLine("<=");
                        break;
                    case Tokens.NOTEQUAL:
                        Console.WriteLine("!=");
                        break;
                    case Tokens.ANDAND:
                        Console.WriteLine("&&");
                        break;
                    case Tokens.OROR:
                        Console.WriteLine("||");
                        break;
                    case Tokens.INCREMENT:
                        Console.WriteLine("++");
                        break;
                    case Tokens.DECREMENT:
                        Console.WriteLine("--");
                        break;
                    case Tokens.LEFTSHIFT:
                        Console.WriteLine("<<");
                        break;
                    case Tokens.RIGHTSHIFT:
                        Console.WriteLine(">>");
                        break;
                    case Tokens.FILLZERO:
                        Console.WriteLine(">>>");
                        break;
                    case Tokens.ADDEQUAL:
                        Console.WriteLine("+=");
                        break;
                    case Tokens.SUBEQUAL:
                        Console.WriteLine("-=");
                        break;
                    case Tokens.MULEQUAL:
                        Console.WriteLine("*=");
                        break;
                    case Tokens.DIVEQUAL:
                        Console.WriteLine("/=");
                        break;
                    case Tokens.ANDEQUAL:
                        Console.WriteLine("&=");
                        break;
                    case Tokens.OREQUAL:
                        Console.WriteLine("|=");
                        break;
                    case Tokens.XOREQUAL:
                        Console.WriteLine("^=");
                        break;
                    case Tokens.MODEQUAL:
                        Console.WriteLine("%=");
                        break;
                    case Tokens.LEFTSHIFTEQUAL:
                        Console.WriteLine("<<=");
                        break;
                    case Tokens.RIGHTSHIFTEQUAL:
                        Console.WriteLine(">>=");
                        break;
                    case Tokens.FILLZEROEQUAL:
                        Console.WriteLine(">>>=");
                        break;
                    case Tokens.THREEPOINTS:
                        Console.WriteLine("...");
                        break;
                    case Tokens.TWOCOLONS:
                        Console.WriteLine("::");
                        break;
                    case Tokens.EOF:
                        Console.WriteLine("EOF");
                        break;
                    default:
                        Console.WriteLine("'{0}'", (char)token);
                        break;
                }
                
            }
            while (token != Tokens.EOF);*/
        }
    }
}
