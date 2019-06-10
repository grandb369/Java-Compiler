%namespace Java_to_Csharp_Compiler
using System
%{
int lines=1;
%}

Digits	[0-9]
FloatTypeSuffix [fFdD]
ExponentIndicator [eE]
Sign [\+\-]
SignedInteger {Sign}*{Digits}+
ExponentPart {ExponentIndicator}{SignedInteger}
DecimalFloatingPointLiteral ({Digits}\.{Digits}?{ExponentPart}?{FloatTypeSuffix}?|\.{Digits}?{ExponentPart}?{FloatTypeSuffix}?|{Digits}\.{Digits}?{ExponentPart}{FloatTypeSuffix}?|{Digits}\.{Digits}?{ExponentPart}?{FloatTypeSuffix})
Identify [a-zA-Z][a-zA-Z0-9]* 
%%




//keywords
if			{ return (int)Tokens.IF; }
else		{ return (int)Tokens.ELSE; }
public		{ return (int)Tokens.PUBLIC;}
static		{ return (int)Tokens.STATIC;}
class		{ return (int)Tokens.CLASS;}
equal		{ return (int)Tokens.Equal;}
add			{ return (int)Tokens.Add;}


true	{yylval.booltype=true; return (int)Tokens.BOOLTYPE; }
false	{yylval.booltype=false; return (int)Tokens.BOOLTYPE; }
{Digits}+	{ yylval.num = int.Parse(yytext); return (int)Tokens.NUMBER; }
{Identify}	{ yylval.name = yytext;   return (int)Tokens.IDENT; }

{DecimalFloatingPointLiteral} {
								if (Char.ToLower(yytext[yytext.Length-1])=='f')
								{
									yylval.fnum=float.Parse(yytext.Substring(0,yytext.Length-1));
									return (int)Tokens.FLOAT;
								}
								else if (Char.ToLower(yytext[yytext.Length-1])=='d')
								{
									yylval.dnum=double.Parse(yytext.Substring(0,yytext.Length-1));
									return (int)Tokens.DOUBLE;
								}
								else
								{
									yylval.dnum=double.Parse(yytext);
									return (int)Tokens.DOUBLE;
								}
							  }


"="			{ return (int)Tokens.Equal;}
"+"			{ return (int)Tokens.Add; }
"<"			{ return '<'; }
"("			{ return '('; }
")"			{ return ')'; }
"{"			{ return '{'; }
"}"			{ return '}'; }
"["			{ return '['; }
"]"			{ return ']'; }
";"			{ return ';'; }



[\n]		{ lines++;    }
[ \t\r]		/* ignore whitespace */ 

.			{ throw new Exception(string.Format("Unexpected character '{0}'", yytext)); }



%%



public override void yyerror( string format, params object[] args )
{
    Console.Error.WriteLine("Error: line {0}, {1}", lines,format);
}
