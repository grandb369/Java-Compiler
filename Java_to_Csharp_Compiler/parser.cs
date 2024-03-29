// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  VDI-VL04-018
// DateTime: 10/06/2019 8:32:08 PM
// UserName: n9778977
// Input file <parser.y - 10/06/2019 8:09:47 PM>

// options: conflicts lines gplex conflicts

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using Java_to_Csharp_Compiler.AST;

namespace Java_to_Csharp_Compiler
{
public enum Tokens {
    error=127,EOF=128,BOOLTYPE=129,DOUBLE=130,FLOAT=131,NUMBER=132,
    Class=133,IDENT=134,PUBLIC=135,Private=136,STATIC=137,Int=138,
    String=139,Equal=140,INT=141,IF=142,ELSE=143,CLASS=144,
    Add=145};

public struct ValueType
#line 9 "parser.y"
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
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
  // Verbatim content from parser.y - 10/06/2019 8:09:47 PM
#line 5 "parser.y"
public static AST.CompilationUnit root;
#line default
  // End verbatim content from parser.y - 10/06/2019 8:09:47 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[70];
  private static State[] states = new State[91];
  private static string[] nonTerms = new string[] {
      "Program", "CompilationUnit", "ClassBody", "ClassBodyDeclarations", "typeparameters", 
      "superclass", "superinterfaces", "TypeDeclarations", "PackageDeclarations", 
      "ImportDeclarations", "ClassBodyDeclaration", "NormalClassDeclaration", 
      "MethodDeclaration", "TypeDeclaration", "BlockStatements", "BlockStatement", 
      "LocalVariableDeclarationStatement", "MethodInvocation", "ExpressionStatement", 
      "Block", "ArgumentList", "AssignmentExpression", "IntegerLiteral", "DoubleLiteral", 
      "FloatLiteral", "BoolLiteral", "ExpressionName", "Expression", "Assignment", 
      "LeftHandSide", "ConditionalExpression", "AdditiveExpression", "MultiplicativeExpression", 
      "PostfixExpression", "Primary", "PrimaryNoNewArray", "StatementExpression", 
      "Type", "ArrayType", "IdentifierType", "Result", "FormalParameters", "FormalParameter", 
      "Modifiers", "modifier", "AssignmentOperator", "VariableDeclarators", "VariableDeclaratorList", 
      "VariableDeclarator", "$accept", };

  static Parser() {
    states[0] = new State(-6,new int[]{-1,1,-2,3,-9,4});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(-7,new int[]{-10,5});
    states[5] = new State(new int[]{144,-15,135,-15,137,-15,136,-15,128,-5},new int[]{-8,6,-14,7,-12,9,-44,10});
    states[6] = new State(-3);
    states[7] = new State(new int[]{144,-15,135,-15,137,-15,136,-15,128,-5},new int[]{-8,8,-14,7,-12,9,-44,10});
    states[8] = new State(-4);
    states[9] = new State(-8);
    states[10] = new State(new int[]{144,11,135,88,137,89,136,90},new int[]{-45,86});
    states[11] = new State(new int[]{134,12});
    states[12] = new State(-11,new int[]{-5,13});
    states[13] = new State(-12,new int[]{-6,14});
    states[14] = new State(-13,new int[]{-7,15});
    states[15] = new State(new int[]{123,17},new int[]{-3,16});
    states[16] = new State(-9);
    states[17] = new State(-20,new int[]{-4,18});
    states[18] = new State(new int[]{125,19,134,-15,135,-15,137,-15,136,-15},new int[]{-11,20,-13,21,-44,22});
    states[19] = new State(-19);
    states[20] = new State(-21);
    states[21] = new State(-22);
    states[22] = new State(new int[]{134,87,135,88,137,89,136,90},new int[]{-41,23,-45,86});
    states[23] = new State(new int[]{134,24});
    states[24] = new State(new int[]{40,25});
    states[25] = new State(-24,new int[]{-42,26});
    states[26] = new State(new int[]{41,27,134,85},new int[]{-43,79,-39,80,-40,82});
    states[27] = new State(new int[]{123,29,125,-31,134,-31,135,-31,137,-31,136,-31},new int[]{-20,28});
    states[28] = new State(-23);
    states[29] = new State(new int[]{134,42,125,-33},new int[]{-15,30,-16,32,-17,34,-38,35,-19,73,-37,74,-29,76,-30,69,-27,77,-18,78});
    states[30] = new State(new int[]{125,31});
    states[31] = new State(-30);
    states[32] = new State(new int[]{134,42,125,-33},new int[]{-15,33,-16,32,-17,34,-38,35,-19,73,-37,74,-29,76,-30,69,-27,77,-18,78});
    states[33] = new State(-32);
    states[34] = new State(-34);
    states[35] = new State(new int[]{134,41},new int[]{-48,36,-49,38});
    states[36] = new State(new int[]{59,37});
    states[37] = new State(-36);
    states[38] = new State(-38,new int[]{-47,39});
    states[39] = new State(new int[]{134,41,59,-37},new int[]{-49,40});
    states[40] = new State(-39);
    states[41] = new State(-40);
    states[42] = new State(new int[]{40,43,134,-29,140,-66});
    states[43] = new State(-69,new int[]{-21,44});
    states[44] = new State(new int[]{41,45,132,56,131,58,130,60,129,62,134,64},new int[]{-28,46,-22,47,-31,48,-32,49,-33,66,-34,52,-35,53,-36,54,-23,55,-25,57,-24,59,-26,61,-18,63,-27,67,-29,68,-30,69});
    states[45] = new State(-67);
    states[46] = new State(-68);
    states[47] = new State(-44);
    states[48] = new State(-45);
    states[49] = new State(new int[]{145,50,41,-50,132,-50,131,-50,130,-50,129,-50,134,-50,59,-50});
    states[50] = new State(new int[]{132,56,131,58,130,60,129,62,134,64},new int[]{-33,51,-34,52,-35,53,-36,54,-23,55,-25,57,-24,59,-26,61,-18,63,-27,65});
    states[51] = new State(-52);
    states[52] = new State(-53);
    states[53] = new State(-54);
    states[54] = new State(-56);
    states[55] = new State(-57);
    states[56] = new State(-63);
    states[57] = new State(-58);
    states[58] = new State(-64);
    states[59] = new State(-59);
    states[60] = new State(-65);
    states[61] = new State(-60);
    states[62] = new State(-62);
    states[63] = new State(-61);
    states[64] = new State(new int[]{40,43,145,-66,41,-66,132,-66,131,-66,130,-66,129,-66,134,-66,140,-66,59,-66});
    states[65] = new State(-55);
    states[66] = new State(-51);
    states[67] = new State(new int[]{145,-55,41,-55,132,-55,131,-55,130,-55,129,-55,134,-55,59,-55,140,-49});
    states[68] = new State(-46);
    states[69] = new State(new int[]{140,72},new int[]{-46,70});
    states[70] = new State(new int[]{132,56,131,58,130,60,129,62,134,64},new int[]{-28,71,-22,47,-31,48,-32,49,-33,66,-34,52,-35,53,-36,54,-23,55,-25,57,-24,59,-26,61,-18,63,-27,67,-29,68,-30,69});
    states[71] = new State(-47);
    states[72] = new State(-48);
    states[73] = new State(-35);
    states[74] = new State(new int[]{59,75});
    states[75] = new State(-41);
    states[76] = new State(-42);
    states[77] = new State(-49);
    states[78] = new State(-43);
    states[79] = new State(-25);
    states[80] = new State(new int[]{134,81});
    states[81] = new State(-27);
    states[82] = new State(new int[]{91,83});
    states[83] = new State(new int[]{93,84});
    states[84] = new State(-28);
    states[85] = new State(-10);
    states[86] = new State(-14);
    states[87] = new State(-26);
    states[88] = new State(-16);
    states[89] = new State(-17);
    states[90] = new State(-18);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-50, new int[]{-1,128});
    rules[2] = new Rule(-1, new int[]{-2});
    rules[3] = new Rule(-2, new int[]{-9,-10,-8});
    rules[4] = new Rule(-8, new int[]{-14,-8});
    rules[5] = new Rule(-8, new int[]{});
    rules[6] = new Rule(-9, new int[]{});
    rules[7] = new Rule(-10, new int[]{});
    rules[8] = new Rule(-14, new int[]{-12});
    rules[9] = new Rule(-12, new int[]{-44,144,134,-5,-6,-7,-3});
    rules[10] = new Rule(-40, new int[]{134});
    rules[11] = new Rule(-5, new int[]{});
    rules[12] = new Rule(-6, new int[]{});
    rules[13] = new Rule(-7, new int[]{});
    rules[14] = new Rule(-44, new int[]{-44,-45});
    rules[15] = new Rule(-44, new int[]{});
    rules[16] = new Rule(-45, new int[]{135});
    rules[17] = new Rule(-45, new int[]{137});
    rules[18] = new Rule(-45, new int[]{136});
    rules[19] = new Rule(-3, new int[]{123,-4,125});
    rules[20] = new Rule(-4, new int[]{});
    rules[21] = new Rule(-4, new int[]{-4,-11});
    rules[22] = new Rule(-11, new int[]{-13});
    rules[23] = new Rule(-13, new int[]{-44,-41,134,40,-42,41,-20});
    rules[24] = new Rule(-42, new int[]{});
    rules[25] = new Rule(-42, new int[]{-42,-43});
    rules[26] = new Rule(-41, new int[]{134});
    rules[27] = new Rule(-43, new int[]{-39,134});
    rules[28] = new Rule(-39, new int[]{-40,91,93});
    rules[29] = new Rule(-38, new int[]{134});
    rules[30] = new Rule(-20, new int[]{123,-15,125});
    rules[31] = new Rule(-20, new int[]{});
    rules[32] = new Rule(-15, new int[]{-16,-15});
    rules[33] = new Rule(-15, new int[]{});
    rules[34] = new Rule(-16, new int[]{-17});
    rules[35] = new Rule(-16, new int[]{-19});
    rules[36] = new Rule(-17, new int[]{-38,-48,59});
    rules[37] = new Rule(-48, new int[]{-49,-47});
    rules[38] = new Rule(-47, new int[]{});
    rules[39] = new Rule(-47, new int[]{-47,-49});
    rules[40] = new Rule(-49, new int[]{134});
    rules[41] = new Rule(-19, new int[]{-37,59});
    rules[42] = new Rule(-37, new int[]{-29});
    rules[43] = new Rule(-37, new int[]{-18});
    rules[44] = new Rule(-28, new int[]{-22});
    rules[45] = new Rule(-22, new int[]{-31});
    rules[46] = new Rule(-22, new int[]{-29});
    rules[47] = new Rule(-29, new int[]{-30,-46,-28});
    rules[48] = new Rule(-46, new int[]{140});
    rules[49] = new Rule(-30, new int[]{-27});
    rules[50] = new Rule(-31, new int[]{-32});
    rules[51] = new Rule(-32, new int[]{-33});
    rules[52] = new Rule(-32, new int[]{-32,145,-33});
    rules[53] = new Rule(-33, new int[]{-34});
    rules[54] = new Rule(-34, new int[]{-35});
    rules[55] = new Rule(-34, new int[]{-27});
    rules[56] = new Rule(-35, new int[]{-36});
    rules[57] = new Rule(-36, new int[]{-23});
    rules[58] = new Rule(-36, new int[]{-25});
    rules[59] = new Rule(-36, new int[]{-24});
    rules[60] = new Rule(-36, new int[]{-26});
    rules[61] = new Rule(-36, new int[]{-18});
    rules[62] = new Rule(-26, new int[]{129});
    rules[63] = new Rule(-23, new int[]{132});
    rules[64] = new Rule(-25, new int[]{131});
    rules[65] = new Rule(-24, new int[]{130});
    rules[66] = new Rule(-27, new int[]{134});
    rules[67] = new Rule(-18, new int[]{134,40,-21,41});
    rules[68] = new Rule(-21, new int[]{-21,-28});
    rules[69] = new Rule(-21, new int[]{});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 2: // Program -> CompilationUnit
#line 96 "parser.y"
                                 { root = ValueStack[ValueStack.Depth-1].compi ; }
#line default
        break;
      case 3: // CompilationUnit -> PackageDeclarations, ImportDeclarations, TypeDeclarations
#line 100 "parser.y"
                                                               { CurrentSemanticValue.compi = new CompilationUnit(ValueStack[ValueStack.Depth-1].declarations); }
#line default
        break;
      case 4: // TypeDeclarations -> TypeDeclaration, TypeDeclarations
#line 104 "parser.y"
                                              { CurrentSemanticValue.declarations = new List<Declaration>(); CurrentSemanticValue.declarations.Add(ValueStack[ValueStack.Depth-2].declaration);CurrentSemanticValue.declarations.AddRange(ValueStack[ValueStack.Depth-1].declarations); }
#line default
        break;
      case 5: // TypeDeclarations -> /* empty */
#line 105 "parser.y"
                             { CurrentSemanticValue.declarations = new List<Declaration>(); }
#line default
        break;
      case 8: // TypeDeclaration -> NormalClassDeclaration
#line 117 "parser.y"
                                       { CurrentSemanticValue.declaration = ValueStack[ValueStack.Depth-1].declaration; }
#line default
        break;
      case 9: // NormalClassDeclaration -> Modifiers, CLASS, IDENT, typeparameters, superclass, 
              //                           superinterfaces, ClassBody
#line 121 "parser.y"
                                                                              { CurrentSemanticValue.declaration = new ClassDeclaration ( ValueStack[ValueStack.Depth-7].modlist, ValueStack[ValueStack.Depth-5].name, ValueStack[ValueStack.Depth-1].declarations); }
#line default
        break;
      case 10: // IdentifierType -> IDENT
#line 125 "parser.y"
                          { CurrentSemanticValue.type = new IdentifierType(ValueStack[ValueStack.Depth-1].name); }
#line default
        break;
      case 14: // Modifiers -> Modifiers, modifier
#line 141 "parser.y"
                                    { CurrentSemanticValue.modlist = new List<Modifier>(ValueStack[ValueStack.Depth-2].modlist); CurrentSemanticValue.modlist.Add(ValueStack[ValueStack.Depth-1].mod); }
#line default
        break;
      case 15: // Modifiers -> /* empty */
#line 142 "parser.y"
                               { CurrentSemanticValue.modlist = new List<Modifier>(); }
#line default
        break;
      case 16: // modifier -> PUBLIC
#line 146 "parser.y"
                           { CurrentSemanticValue.mod = Modifier.Public  ;  }
#line default
        break;
      case 17: // modifier -> STATIC
#line 147 "parser.y"
                           { CurrentSemanticValue.mod = Modifier.Static  ;  }
#line default
        break;
      case 18: // modifier -> Private
#line 148 "parser.y"
                           { CurrentSemanticValue.mod = Modifier.Private  ;  }
#line default
        break;
      case 19: // ClassBody -> '{', ClassBodyDeclarations, '}'
#line 153 "parser.y"
                                             { CurrentSemanticValue.declarations = ValueStack[ValueStack.Depth-2].declarations ; }
#line default
        break;
      case 20: // ClassBodyDeclarations -> /* empty */
#line 157 "parser.y"
                              { CurrentSemanticValue.declarations = new List<Declaration>();}
#line default
        break;
      case 21: // ClassBodyDeclarations -> ClassBodyDeclarations, ClassBodyDeclaration
#line 158 "parser.y"
                                                      { CurrentSemanticValue.declarations = new List<Declaration>(ValueStack[ValueStack.Depth-2].declarations); CurrentSemanticValue.declarations.Add(ValueStack[ValueStack.Depth-1].declaration);}
#line default
        break;
      case 22: // ClassBodyDeclaration -> MethodDeclaration
#line 162 "parser.y"
                                   { CurrentSemanticValue.declaration = ValueStack[ValueStack.Depth-1].declaration;}
#line default
        break;
      case 23: // MethodDeclaration -> Modifiers, Result, IDENT, '(', FormalParameters, ')', 
               //                      Block
#line 166 "parser.y"
                                                               { CurrentSemanticValue.declaration = new MethodDeclaration ( ValueStack[ValueStack.Depth-7].modlist, ValueStack[ValueStack.Depth-6].type, ValueStack[ValueStack.Depth-5].name, ValueStack[ValueStack.Depth-3].parameters, ValueStack[ValueStack.Depth-1].stmt); }
#line default
        break;
      case 24: // FormalParameters -> /* empty */
#line 170 "parser.y"
                              { CurrentSemanticValue.parameters = new List<FormalParameter>(); }
#line default
        break;
      case 25: // FormalParameters -> FormalParameters, FormalParameter
#line 171 "parser.y"
                                              { CurrentSemanticValue.parameters = new List<FormalParameter>(ValueStack[ValueStack.Depth-2].parameters); CurrentSemanticValue.parameters.Add(ValueStack[ValueStack.Depth-1].parameter);}
#line default
        break;
      case 26: // Result -> IDENT
#line 175 "parser.y"
                          { CurrentSemanticValue.type = new IdentifierType(ValueStack[ValueStack.Depth-1].name) ; }
#line default
        break;
      case 27: // FormalParameter -> ArrayType, IDENT
#line 179 "parser.y"
                                 { CurrentSemanticValue.parameter = new FormalParameter (ValueStack[ValueStack.Depth-2].type, ValueStack[ValueStack.Depth-1].name); }
#line default
        break;
      case 28: // ArrayType -> IdentifierType, '[', ']'
#line 183 "parser.y"
                                       { CurrentSemanticValue.type = new ArrayType(ValueStack[ValueStack.Depth-3].type); }
#line default
        break;
      case 29: // Type -> IDENT
#line 187 "parser.y"
                          { CurrentSemanticValue.type = new IdentifierType(ValueStack[ValueStack.Depth-1].name); }
#line default
        break;
      case 30: // Block -> '{', BlockStatements, '}'
#line 192 "parser.y"
                                        { CurrentSemanticValue.stmt = new BlockStatement(ValueStack[ValueStack.Depth-2].stmtlist); }
#line default
        break;
      case 32: // BlockStatements -> BlockStatement, BlockStatements
#line 197 "parser.y"
                                              { CurrentSemanticValue.stmtlist = new List<Statement>();CurrentSemanticValue.stmtlist.Add(ValueStack[ValueStack.Depth-2].stmt); CurrentSemanticValue.stmtlist.AddRange(ValueStack[ValueStack.Depth-1].stmtlist); }
#line default
        break;
      case 33: // BlockStatements -> /* empty */
#line 198 "parser.y"
                                 { CurrentSemanticValue.stmtlist = new List<Statement>(); }
#line default
        break;
      case 34: // BlockStatement -> LocalVariableDeclarationStatement
#line 202 "parser.y"
                                                { CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt; }
#line default
        break;
      case 35: // BlockStatement -> ExpressionStatement
#line 203 "parser.y"
                                     { CurrentSemanticValue.stmt = ValueStack[ValueStack.Depth-1].stmt; }
#line default
        break;
      case 36: // LocalVariableDeclarationStatement -> Type, VariableDeclaratorList, ';'
#line 207 "parser.y"
                                              { CurrentSemanticValue.stmt = new LocalVariableDeclarationStatement(ValueStack[ValueStack.Depth-3].type, ValueStack[ValueStack.Depth-2].vars); }
#line default
        break;
      case 37: // VariableDeclaratorList -> VariableDeclarator, VariableDeclarators
#line 211 "parser.y"
                                                     { CurrentSemanticValue.vars = new List<VariableDeclarator>(); CurrentSemanticValue.vars.Add(ValueStack[ValueStack.Depth-2].var); CurrentSemanticValue.vars.AddRange(ValueStack[ValueStack.Depth-1].vars);}
#line default
        break;
      case 38: // VariableDeclarators -> /* empty */
#line 215 "parser.y"
                                { CurrentSemanticValue.vars = new List<VariableDeclarator>();}
#line default
        break;
      case 39: // VariableDeclarators -> VariableDeclarators, VariableDeclarator
#line 216 "parser.y"
                                                    { CurrentSemanticValue.vars = ValueStack[ValueStack.Depth-2].vars; CurrentSemanticValue.vars.Add(ValueStack[ValueStack.Depth-1].var); }
#line default
        break;
      case 40: // VariableDeclarator -> IDENT
#line 220 "parser.y"
                           { CurrentSemanticValue.var = new VariableDeclarator(ValueStack[ValueStack.Depth-1].name); }
#line default
        break;
      case 41: // ExpressionStatement -> StatementExpression, ';'
#line 224 "parser.y"
                                        { CurrentSemanticValue.stmt = new ExpressionStatement(ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 42: // StatementExpression -> Assignment
#line 228 "parser.y"
                               { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 43: // StatementExpression -> MethodInvocation
#line 229 "parser.y"
                                    { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 44: // Expression -> AssignmentExpression
#line 233 "parser.y"
                                       { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 45: // AssignmentExpression -> ConditionalExpression
#line 237 "parser.y"
                                        { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 46: // AssignmentExpression -> Assignment
#line 238 "parser.y"
                               { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 47: // Assignment -> LeftHandSide, AssignmentOperator, Expression
#line 242 "parser.y"
                                                       { CurrentSemanticValue.expr = new AssignmentExpression(ValueStack[ValueStack.Depth-3].expr,ValueStack[ValueStack.Depth-2].oper, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 48: // AssignmentOperator -> Equal
#line 246 "parser.y"
                           { CurrentSemanticValue.oper = Operator.Equal;}
#line default
        break;
      case 49: // LeftHandSide -> ExpressionName
#line 250 "parser.y"
                                  { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 50: // ConditionalExpression -> AdditiveExpression
#line 254 "parser.y"
                                     { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 51: // AdditiveExpression -> MultiplicativeExpression
#line 258 "parser.y"
                                          { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 52: // AdditiveExpression -> AdditiveExpression, Add, MultiplicativeExpression
#line 259 "parser.y"
                                                           { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr, Operator.Add, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 53: // MultiplicativeExpression -> PostfixExpression
#line 263 "parser.y"
                                     { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 54: // PostfixExpression -> Primary
#line 267 "parser.y"
                             { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 55: // PostfixExpression -> ExpressionName
#line 268 "parser.y"
                                  { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 56: // Primary -> PrimaryNoNewArray
#line 272 "parser.y"
                                     { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr; }
#line default
        break;
      case 57: // PrimaryNoNewArray -> IntegerLiteral
#line 276 "parser.y"
                                  { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr ; }
#line default
        break;
      case 58: // PrimaryNoNewArray -> FloatLiteral
#line 277 "parser.y"
                                 { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr ; }
#line default
        break;
      case 59: // PrimaryNoNewArray -> DoubleLiteral
#line 278 "parser.y"
                                                                                     { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr ; }
#line default
        break;
      case 60: // PrimaryNoNewArray -> BoolLiteral
#line 279 "parser.y"
                                { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr ; }
#line default
        break;
      case 61: // PrimaryNoNewArray -> MethodInvocation
#line 280 "parser.y"
                                    { CurrentSemanticValue.expr = ValueStack[ValueStack.Depth-1].expr ; }
#line default
        break;
      case 62: // BoolLiteral -> BOOLTYPE
#line 284 "parser.y"
                            { CurrentSemanticValue.expr = new BoolLiteral(ValueStack[ValueStack.Depth-1].booltype); }
#line default
        break;
      case 63: // IntegerLiteral -> NUMBER
#line 287 "parser.y"
                           { CurrentSemanticValue.expr = new IntegerLiteral(ValueStack[ValueStack.Depth-1].num); }
#line default
        break;
      case 64: // FloatLiteral -> FLOAT
#line 291 "parser.y"
                          { CurrentSemanticValue.expr = new FloatLiteral(ValueStack[ValueStack.Depth-1].fnum); }
#line default
        break;
      case 65: // DoubleLiteral -> DOUBLE
#line 295 "parser.y"
                           { CurrentSemanticValue.expr = new DoubleLiteral(ValueStack[ValueStack.Depth-1].dnum); }
#line default
        break;
      case 66: // ExpressionName -> IDENT
#line 299 "parser.y"
                          { CurrentSemanticValue.expr = new ExpressionName(ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 67: // MethodInvocation -> IDENT, '(', ArgumentList, ')'
#line 303 "parser.y"
                                          { CurrentSemanticValue.expr = new MethodInvocation(ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].exprs);}
#line default
        break;
      case 68: // ArgumentList -> ArgumentList, Expression
#line 308 "parser.y"
                                       { CurrentSemanticValue.exprs = new List<Expression>(ValueStack[ValueStack.Depth-2].exprs); CurrentSemanticValue.exprs.Add(ValueStack[ValueStack.Depth-1].expr);}
#line default
        break;
      case 69: // ArgumentList -> /* empty */
#line 309 "parser.y"
                               { CurrentSemanticValue.exprs = new List<Expression>();}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 315 "parser.y"

int yywrap()
{
    return 1;
}

public Parser(Scanner scanner) : base(scanner)
{
}
#line default
}
}
