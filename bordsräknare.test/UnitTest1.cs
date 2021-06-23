using System;
using Xunit;
using bordsräknare;

namespace bordsräknare.test
{
    public class Addition
    {
	[Theory]
	[InlineData(1,1,2)]
	[InlineData(1,-1,0)]
	public void TestaAdd(double a, double b, double förväntat)
	{
	    Program prog = new Program();
	    double resultat=prog.Addition(new double[]{a,b});
	    Console.WriteLine( a.ToString(), b.ToString(), resultat);
	    Assert.Equal(förväntat, resultat);
	}
    }
    public class Subtraktion
    {
	[Theory]
	[InlineData(20,1,19)]
	[InlineData(1,1,0)]
	public void TestaSubtraktion(double a, double b, double förväntat)
	{
	    Program prog = new Program();
	    double resultat=prog.Subtraktion(new double[]{a,b});
	    Assert.Equal(förväntat, resultat);
	}
    }

    public class Sinus
    {
	[Theory]
	[InlineData(Math.PI, 0)]
	public void TestaSinus(double a, double förväntat)
	{
	    Program prog = new Program();
	    double resultat=prog.sin(a);
	    Assert.Equal(förväntat, resultat);
	}
    }
}
