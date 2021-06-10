using System;

//
// RPN bordsräknare i Csharp
//
// stora tal ?? dvs BCD ? med fixed ?
//

namespace bordsräknare
{
    class Program
    {
	static void Main(string[] args)
	{
	    string[,] alternativ = new string[8,2]
	    {
		{ "P", "Mata in"},

		{ "+", "Addition" },
		{ "-", "Subtraktion" },
		{ "*", "Multiplikation" },
		{ "/", "Division" },

		{ "L", "Läs från stack" },
		{ "T", "Töm stacken" },
		{ "X", "Avsluta" },
	    };
	    Console.WriteLine("Hello World!");

	    for(int i=0;i<8;i++){
		if(i==7) {
		    Console.WriteLine("");
		}
		Console.WriteLine( alternativ[i,0]+ "   " + alternativ[i,1]);
	    }

	    // foreach(String i in alternativ)
	    // {
	    //	Console.WriteLine("{0}", i);
	    // }
	}
    }
}
