%namespace Java_to_Csharp_Compiler
%using Java_to_Csharp_Compiler.AST

%{
public static AST.CompilationUnit root;
%}

%union
{
	public bool booltype;
	public double dnum;
	public float fnum;
	public int num;
	public string name;
    public CompilationUnit compi;
	public List<Declaration> declarations;
	public Declaration declaration;
	public Statement stmt;
	public Expression expr;
	public List<Expression> exprs;
	public Java_to_Csharp_Compiler.AST.Type type;
	public List<Statement> stmtlist;
	public List<Modifier> modlist;
	public Modifier mod;
	public List<FormalParameter> parameters;
	public FormalParameter parameter;
	public Operator oper;
	public List <VariableDeclarator> vars;
	public VariableDeclarator var;
}

%type <compi> Program
%type <compi> CompilationUnit
%type <declarations> ClassBody
%type <declarations> ClassBodyDeclarations
%type <declarations> typeparameters
%type <declarations> superclass
%type <declarations> superinterfaces
%type <declarations> TypeDeclarations
%type <declarations> PackageDeclarations
%type <declarations> ImportDeclarations
%type <declaration> ClassBodyDeclaration
%type <declaration> NormalClassDeclaration
%type <declaration> MethodDeclaration
%type <declaration> TypeDeclaration
%type <stmtlist> BlockStatements
%type <stmt> BlockStatement
%type <stmt> LocalVariableDeclarationStatement
%type <stmt> MethodInvocation
%type <stmt> ExpressionStatement
%type <stmt> BlockStatement
%type <stmt> Block
%type <exprs> ArgumentList
%type <expr> AssignmentExpression
%type <expr> IntegerLiteral
%type <expr> DoubleLiteral
%type <expr> FloatLiteral
%type <expr> BoolLiteral
%type <expr> ExpressionName
%type <expr> MethodInvocation
%type <expr> Expression
%type <expr> AssignmentExpression
%type <expr> Assignment
%type <expr> LeftHandSide
%type <expr> ConditionalExpression
%type <expr> AdditiveExpression
%type <expr> MultiplicativeExpression
%type <expr> PostfixExpression
%type <expr> Primary
%type <expr> PrimaryNoNewArray
%type <expr> StatementExpression
%type <type> Type
%type <type> ArrayType
%type <type> IdentifierType
%type <type> Result
%type <parameters> FormalParameters
%type <parameter> FormalParameter
%type <modlist> Modifiers
%type <mod> modifier
%type <oper> AssignmentOperator
%type <vars> VariableDeclarators VariableDeclaratorList
%type <var> VariableDeclarator

%token <booltype> BOOLTYPE
%token <dnum> DOUBLE
%token <fnum> FLOAT
%token <num> NUMBER
%token <name> Class
%token <name> IDENT
%token PUBLIC Private STATIC Int String Equal INT IF ELSE CLASS Add
%left '=' '+'

%%

Program
	:CompilationUnit																{ root = $1 ; }
	;

CompilationUnit 
	:PackageDeclarations ImportDeclarations TypeDeclarations						{ $$ = new CompilationUnit($3); }
	;

TypeDeclarations
	:TypeDeclaration TypeDeclarations												{ $$ = new List<Declaration>(); $$.Add($1);$$.AddRange($2); }
	|/*empty*/																		{ $$ = new List<Declaration>(); }
	;

PackageDeclarations
	:/* empty */
	;

ImportDeclarations																	
	:/* empty */
	;

TypeDeclaration
	:NormalClassDeclaration															{ $$ = $1; }
	;

NormalClassDeclaration
	:Modifiers CLASS IDENT typeparameters superclass superinterfaces ClassBody 		{ $$ = new ClassDeclaration ( $1, $3, $7); }
	;

IdentifierType
	:IDENT																			{ $$ = new IdentifierType($1); }
	;

typeparameters
	: /* empty */		
	;

superclass
	: /* empty */		
	;

superinterfaces
	: /* empty */		
	;

Modifiers 
	: Modifiers modifier															{ $$ = new List<Modifier>($1); $$.Add($2); }
	| /* empty */																	{ $$ = new List<Modifier>(); }
	;

modifier
	:PUBLIC																			{ $$ = Modifier.Public  ;  }
	|STATIC																			{ $$ = Modifier.Static  ;  }
	|Private																		{ $$ = Modifier.Private  ;  }
	;


ClassBody
	: '{' ClassBodyDeclarations '}'													{ $$ = $2 ; }
	;

ClassBodyDeclarations
	:/* empty */																	{ $$ = new List<Declaration>();}
	|ClassBodyDeclarations ClassBodyDeclaration										{ $$ = new List<Declaration>($1); $$.Add($2);}
	;

ClassBodyDeclaration
	:MethodDeclaration																{ $$ = $1;}
	;

MethodDeclaration
	:Modifiers Result IDENT '(' FormalParameters ')'  Block 						{ $$ = new MethodDeclaration ( $1, $2, $3, $5, $7); }
	;

FormalParameters
	:/* empty */																	{ $$ = new List<FormalParameter>(); }
	|FormalParameters FormalParameter												{ $$ = new List<FormalParameter>($1); $$.Add($2);}
	;

Result
	:IDENT																			{ $$ = new IdentifierType($1) ; }
	;

FormalParameter
	:ArrayType IDENT																{ $$ = new FormalParameter ($1, $2); }
	;

ArrayType
	:IdentifierType	'[' ']'															{ $$ = new ArrayType($1); }
	;

Type
	:IDENT																			{ $$ = new IdentifierType($1); }
	;


Block 
	:'{' BlockStatements '}'															{ $$ = new BlockStatement($2); }
	| /* empty */																		
	;

BlockStatements
	:BlockStatement BlockStatements														{ $$ = new List<Statement>();$$.Add($1); $$.AddRange($2); }
	|  /* empty */																		{ $$ = new List<Statement>(); }
	;

BlockStatement
	:LocalVariableDeclarationStatement													{ $$ = $1; }
	|ExpressionStatement																{ $$ = $1; }
	;

LocalVariableDeclarationStatement	
	:Type VariableDeclaratorList ';'													{ $$ = new LocalVariableDeclarationStatement($1, $2); }
	;

VariableDeclaratorList
	: VariableDeclarator VariableDeclarators											 { $$ = new List<VariableDeclarator>(); $$.Add($1); $$.AddRange($2);}
	;

VariableDeclarators
	: /* empty */																		{ $$ = new List<VariableDeclarator>();}
	| VariableDeclarators VariableDeclarator											{ $$ = $1; $$.Add($2); }
	;

VariableDeclarator
	:IDENT																				{ $$ = new VariableDeclarator($1); }
	;

ExpressionStatement
	:StatementExpression ';'															{ $$ = new ExpressionStatement($1); }
	;

StatementExpression
	: Assignment																		{ $$ = $1; }
	| MethodInvocation																	{ $$ = $1; }
	;

Expression
	: AssignmentExpression																{ $$ = $1; }
	;

AssignmentExpression
	: ConditionalExpression																{ $$ = $1; }
	| Assignment																		{ $$ = $1; }
	;

Assignment
	: LeftHandSide AssignmentOperator Expression										{ $$ = new AssignmentExpression($1,$2, $3); }
	;

AssignmentOperator
	:Equal																				{ $$ = Operator.Equal;}
	;

LeftHandSide
	: ExpressionName																	{ $$ = $1; }
	;

ConditionalExpression
	: AdditiveExpression																{ $$ = $1; }
	;

AdditiveExpression
	: MultiplicativeExpression															{ $$ = $1; }
	| AdditiveExpression Add MultiplicativeExpression									{ $$ = new BinaryExpression($1, Operator.Add, $3); }
	;

MultiplicativeExpression
	: PostfixExpression																	{ $$ = $1; }
	;

PostfixExpression
	: Primary																			{ $$ = $1; }
	| ExpressionName																	{ $$ = $1; }
	;

Primary
	: PrimaryNoNewArray																	{ $$ = $1; }
	;

PrimaryNoNewArray
	: IntegerLiteral																	{ $$ = $1 ; }
	| FloatLiteral																		{ $$ = $1 ; }
	| DoubleLiteral                                                                     { $$ = $1 ; }
	| BoolLiteral																		{ $$ = $1 ; }
	| MethodInvocation																	{ $$ = $1 ; }
	;

BoolLiteral
	:BOOLTYPE																		{ $$ = new BoolLiteral($1); }
	;
IntegerLiteral
	:NUMBER																			{ $$ = new IntegerLiteral($1); }
	;

FloatLiteral
	:FLOAT																			{ $$ = new FloatLiteral($1); }
	;

DoubleLiteral
	:DOUBLE																			{ $$ = new DoubleLiteral($1); }
	;

ExpressionName
	:IDENT																			{ $$ = new ExpressionName($1);}
	;

MethodInvocation
	:IDENT '(' ArgumentList ')'														{ $$ = new MethodInvocation($1, $3);}
	;


ArgumentList
	:ArgumentList Expression														{ $$ = new List<Expression>($1); $$.Add($2);}
	| /* empty */																	{ $$ = new List<Expression>();}
	;



%%

int yywrap()
{
    return 1;
}

public Parser(Scanner scanner) : base(scanner)
{
}