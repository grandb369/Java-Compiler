using System.Collections.Generic;

namespace AST
{

    enum Modifier { Public, Static, Private }
    abstract class Node
    {
    }
    abstract class Declaration : Node
    {
    }
    abstract class Statement : Node
    {
    }
    class Expression : Node
    {
    }
    abstract class Type : Node
    {
    }
    abstract class ArrayType:Node
    {

    }
    abstract class Operator: Node
    {

    }
    class FormalParameter : Declaration
    {

        private Type dataType;
        private string paramName;
    }
    abstract class UnannType : Node
    {
    }


    class IntegerLiteral: Expression
    {
        int value;
        IntegerLiteral(int value)
        {
            this.value = value;
        }
    }
    class CompilationUnit: Declaration
    {
        private List<Declaration> classDeclaration;
    }
    
    class ClassDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private string ClassName;
        private List<Declaration> classbodydeclarations;
    }
    class MethodDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private string MethodName;
        private Type ReturnType;
        private List<FormalParameter> parameters;
        private List<BlockStatement> body;
    }

    class BlockStatement : Statement
    {
        private List<Statement> blocks;
    }

    class LocalVariableDeclarationStatement : Statement
    {
        private Type datatype;
        private List<VariableDeclarator> variables;
    }
    class ExpressionStatement: Statement     
    {
        private Expression expression;
    }
    class VariableDeclarator : Declaration
    {
        private string identifiers;

    }
    class AssignmentExpression:Expression
    {
        private Expression lefthandside;
        private Operator operatortype;
        private Expression righthandside;
    }
}

