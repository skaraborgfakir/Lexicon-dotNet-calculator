using System;
using Xunit;
using bordsräknare;

namespace bordsräknare.test
{
    public class Addition
    {
	[Theory]
	[InlineData(  2, (new double[]{ 1, 1}))]
	[InlineData(  1, (new double[]{ 1}))]
	[InlineData( 21, (new double[]{ 20,1}))]
	[InlineData(717, (new double[]{ 234, 435, 43, 5, -1, 1}))]
	[InlineData( 14, (new double[]{ -12, -3, 5, 24}))]
	public void TestaAdd( double förväntat, double[]termer)
	{
	    Program prog = new Program();
	    double summa=prog.Addition( termer);
	    Console.WriteLine( "{0} {1}", summa.ToString(), förväntat.ToString());
	    Assert.Equal( förväntat, summa);
	}
    }
    public class Subtraktion
    {
	[Theory]
	[InlineData(   0, (new double[]{ 1, 1}))]
	[InlineData(   1, (new double[]{ 1}))]
	[InlineData(  -3, (new double[]{ -3}))]
	[InlineData(  19, (new double[]{ 20,1}))]
	[InlineData(-249, (new double[]{ 234, 435, 43, 5, -1, 1}))]
	[InlineData( -38, (new double[]{ -12, -3, 5, 24}))]
	public void TestaSubtraktion(double förväntat, double[] termer)
	{
	    Program prog = new Program();
	    double resultat=prog.Subtraktion(termer);
	    Console.WriteLine( "{0} {1}", resultat.ToString(), förväntat.ToString());
	    Assert.Equal( förväntat, resultat);
	}
    }

    // public class Sinus
    // {
    //	[Theory]
    //	[InlineData(Math.PI, 0)]
    //	public void TestaSinus(double a, double förväntat)
    //	{
    //	    Program prog = new Program();
    //	    double resultat=prog.sin(a);
    //	    Assert.Equal(förväntat, resultat);
    //	}
    // }
}
