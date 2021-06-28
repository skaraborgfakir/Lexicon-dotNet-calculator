using System;
using System.Collections.Generic;
using System.Globalization;

//
// RPN bordsräknare i Csharp
//
// stora tal ?? dvs BCD ? med fixed ?
//
// exempel:
//   2+3x4 :                  P3 *4 +2
//   (2+3)/4:                 P2 +3 /4
//   kvadratrot( 2^2 + 3^2):  kvadrat2 2 kvadrat2 3 + kvadratrot
//   kvadratrot( 2^2 + 3^4):  kvadrat2 2 P 3 kvadratX 4 + kvadratrot
//
// X = alias för pos 0 i stacken   X alltid synlig
// Y =  -*-          1
// Z = -*-           2
// T = -*-           3
//
namespace bordsräknare
{
    public class Program
    {
	//
	// kontrollant i MVC
	//
	static void Main(string[] args)
	{
	    bool       notDone=true;
	    Stack<double> talStack = new Stack<double>(); // oändligt stor stack men egentligen är 4 som maximalt djup tillräcklig
	    while ( notDone )
	    {
		string kommand=Meny(talStack);
		switch( kommand )
		{
		    case "P":
		    case "p":
			Push(talStack);
			break;
		    case "+":
			Addition(talStack);
			break;
		    case "-":
			Subtraktion(talStack);
			break;
		    case "*":
			Multiplikation(talStack);
			break;
		    case "/":
			Division(talStack);
			break;
		    case "2":
			kvadreratill2(talStack);
			break;
		    case "X":
		    case "x":
			kvadreratillX(talStack);
			break;
		    case "R":
		    case "r":
			kvadratrot(talStack);
			break;
			// case "L":
			// case "l":
			//	Pop(talStack);
			//	break;
		    case "C":
		    case "c":
			Console.WriteLine( "Rensa stacken (cancel)");
			talStack.Clear();
			break;
		    case "A":
		    case "a":
			Console.WriteLine( "Avslutar");
			notDone = false;
			break;
		    default:
			break;
		}
	    }
	}

	static double läsEttTal()
	{
	    bool okTal=false;
	    double tal=0.0;
	    NumberStyles style = NumberStyles.AllowDecimalPoint|NumberStyles.AllowLeadingSign|NumberStyles.AllowThousands;
	    CultureInfo provider = new CultureInfo("sv-SE");

	    Console.WriteLine( "mata in ett tal (decimalt): ");
	    while( !okTal )
	    {
		// string str=Console.ReadLine();
		try
		{
		    tal=double.Parse(Console.ReadLine(), style, provider);
		    okTal=true;
		}
		catch (FormatException e)
		{
		    Console.WriteLine(e.Message + " ej ett tal ?");
		}
	    }
	    return tal;
	}

	static double läsEttTal(string message)
	{
	    bool okTal=false;
	    double tal=0.0;
	    NumberStyles style = NumberStyles.AllowDecimalPoint|NumberStyles.AllowLeadingSign|NumberStyles.AllowThousands;
	    CultureInfo provider = new CultureInfo("fr-FR");

	    Console.WriteLine( message + ": mata in ett tal (decimalt): ");
	    while( !okTal )
	    {
		// string str=Console.ReadLine();
		try
		{
		    tal=double.Parse(Console.ReadLine(), style, provider);
		    okTal=true;
		}
		catch (FormatException e)
		{
		    Console.WriteLine(e.Message + " ej ett tal ?");
		}
	    }
	    return tal;
	}

	//
	// modell i MVC
	//
	static void Push( Stack<double> talStack )
	{
	    talStack.Push(läsEttTal( "inmatning i stack"));
	}

	//
	// modell i MVC
	//
	static void Addition( Stack<double> talStack)
	{
	    double term1=0;
	    try
	    {
		term1=talStack.Pop();
	    }
	    catch (InvalidOperationException)
	    {
	    }
	    double term2=läsEttTal( "addition" );
	    double summa=term1+term2;
	    talStack.Push(summa);
	}

	//
	// modell i MVC
	//
	// avsedd för xUnit-provning
	//
	public double Addition( double[] termer)
	{
	    double summa=0.0;

	    for (int i=0; i<termer.Length; i++) {
		summa=summa+termer[i];
	    }

	    return summa;
	}

	//
	// modell i MVC - broken, läsEttTal ska inte vara med här !
	//
	static void Subtraktion(Stack<double> talStack)
	{
	    double term1=0;
	    try
	    {
		term1=talStack.Pop();
	    }
	    catch (InvalidOperationException)
	    {
	    }
	    double term2=läsEttTal( "subtraktion");
	    double summa=term1-term2;
	    talStack.Push(summa);
	}

	//
	// modell i MVC
	//
	// avsedd för xUnit-provning
	//
	public double Subtraktion( double[] termer)
	{
	    // assert att array har minstl längden 2 ?
	    double [] termer_teckenbytt = new double[termer.Length];

	    for (int i = 0; i < termer_teckenbytt.Length; i++) {
		termer_teckenbytt[i] = -1 * termer[i];
	    }
	    termer_teckenbytt[0] = termer[0];

	    return Addition( termer_teckenbytt);
	}

	//
	// modell i MVC - broken läsEttTal ska inte vara med här !
	//
	static void Multiplikation(Stack<double> talStack)
	{
	    double faktor1=0;
	    try
	    {
		faktor1=talStack.Pop();
	    }
	    catch (InvalidOperationException)
	    {
	    }
	    double faktor2=läsEttTal( "multiplikation: mata in den ena faktorn");
	    double produkt=faktor1*faktor2;
	    talStack.Push(produkt);
	}

	//
	// modell i MVC
	//
	// avsedd för xUnit-provning
	//
	public double Multiplikation( double[] faktorer)
	{
	    double produkt=1.0;

	    for (int i = 0; i < faktorer.Length; i++) {
		produkt = produkt * faktorer[i];
	    }

	    return produkt;
	}

	//
	// modell i MVC - broken läsEttTal ska inte vara med här !
	//
	static void Division(Stack<double> talStack)
	{
	    double täljare=0;
	    try
	    {
		täljare=talStack.Pop();
	    }
	    catch (InvalidOperationException)
	    {
	    }

	    double nämnare=0;
	    while (nämnare==0)
	    {
		nämnare=läsEttTal( "division: mata in nämnare");
		if (nämnare==0) {
		    Console.WriteLine("nämnare kan inte vara 0.");
		}
	    }

	    double kvot=täljare/nämnare;
	    talStack.Push(kvot);
	}

	//
	// modell i MVC
	//
	public double Division(double[] termer)
	{
	    double täljare=termer[0];
	    double nämnare=termer[1];
	    double kvot=0.0;
		kvot=täljare/nämnare;

	    // catch (InvalidOperationException)
	    // {
	    // }

	    return( kvot);
	}

	static void kvadreratill2(Stack<double> talStack)
	{
	    double bas=talStack.Pop();
	    double resultat = Math.Pow( bas, 2);

	    talStack.Push(resultat);
	}

	static void kvadreratillX(Stack<double> talStack)
	{
	    double bas=0;
	    try
	    {
		bas = talStack.Pop();
	    }
	    catch(InvalidOperationException)
	    {
	    }
	    double exponent=läsEttTal( "exponent till valfritt tal: mata in exponent");
	    double resultat=Math.Pow( bas, exponent);
	    talStack.Push(resultat);
	}
	static void kvadratrot(Stack<double> talStack)
	{
	    double tal=talStack.Pop();
	    double rot=Math.Sqrt(tal);
	    talStack.Push(rot);
	}

	//
	// modell i MVC
	//
	public double Sin(double vinkel) {
	    return Math.Sin(vinkel);
	}

	//
	// modell i MVC
	//
	public void Sin(Stack <double> talStack) {
	    talStack.Push( Math.Sin( talStack.Pop()));
	}

	static string Meny(Stack<double> talStack)
	{
	    string[,] alternativ = new string[10,3]
	    {
		{ "P", "Mata in (x->y)",     "p" },
		{ "+", "Addition (x=x+y)",   "" },
		{ "-", "Subtraktion (x=y-x", "" },
		{ "*", "Multiplikation (x=y/x)", "" },
		{ "/", "Division (x=y/x)",   "" },
		{ "X", "Exponent (x=y^x)",   "x" },
		{ "R", "Kvadratrot (x=Vx)",  "r" },
		{ "2", "2:Exponent (x=x^2)", "" },
		{ "C", "Töm stacken (nollställ)", "c" },
		{ "A", "Avsluta", "a" },
	    };
	    //bool kanskeLegalt=;
	    string kommand="X";
	    bool ok_kommand=false;
	    while ( !ok_kommand ) {
		for (int i=0;  i < alternativ.GetLength(0); i++){
		    if (i==alternativ.GetLength(0)-1) { // beroende på att X (avsluta) är sist i uppräkningen !
			Console.WriteLine("");
		    }
		    Console.WriteLine( alternativ[i,0] + " " + alternativ[i,1] );
		}
		try   // Innan allra första operationen är stack tom - hantera
		{
		    Console.Write( "X: " + talStack.Peek() + "  ");
		}
		catch(InvalidOperationException)
		{
		    Console.Write( "X: " + 0.0 + "  ");
		}
		kommand=Console.ReadLine();
		foreach (string alt in alternativ) {
		    if ( alt!="" && alt==kommand ) {
			ok_kommand=true;
		    }
		}
		if ( !ok_kommand ) {
		    Console.WriteLine("fel val, försök igen");
		}
	    }
	    return kommand;
	}
    }
}
