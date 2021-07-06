using System;
using Xunit;
using bordsräknare;
using System.Collections;
using System.Collections.Generic;

namespace bordsräknare.test
{
    public class Addition
    {
	[Theory]
	[InlineData(  1, (new double[]{ 1, 2}))]]
	[InlineData(  1, (new double[]{-1, 0}))]
	[InlineData(  2, (new double[]{ 1, 1}))]
	[InlineData(  1, (new double[]{ 1}))]
	[InlineData( 21, (new double[]{ 20,1}))]
	[InlineData(717, (new double[]{ 234, 435, 43, 5, -1, 1}))]
	[InlineData( 14, (new double[]{ -12, -3, 5, 24}))]
	public void RunTest( double förväntat, double[]termer)
	{
	    Program prog = new Program();
	    double summa = prog.Addition( termer);
	    // Console.WriteLine( "add {0} {1}", summa.ToString(), förväntat.ToString());
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
	public void RunTest(double förväntat, double[] termer)
	{
	    Program prog = new Program();
	    double resultat = prog.Subtraktion( termer);
	    // Console.WriteLine( "sub {0} {1}", resultat.ToString(), förväntat.ToString());
	    Assert.Equal( förväntat, resultat);
	}
    }

    public class Multiplikation
    {
	[Theory]
	[InlineData(        1, (new double[]{ 1, 1}))]
	[InlineData(        1, (new double[]{ 1}))]
	[InlineData(       -3, (new double[]{ -3}))]
	[InlineData(       20, (new double[]{ 20,1}))]
	[InlineData(-21884850, (new double[]{ 234, 435, 43, 5, -1, 1}))]
	[InlineData(     4320, (new double[]{ -12, -3, 5, 24}))]
	public void RunTest(double förväntat, double[] faktorer)
	{
	    Program prog = new Program();
	    double resultat = prog.Multiplikation( faktorer);
	    // Console.WriteLine( "mult {0} {1}", resultat.ToString(), förväntat.ToString());
	    Assert.Equal( förväntat, resultat);
	}
    }

    public class Division
    {
	[Theory]
	[InlineData(                  1, (new double[]{   1,   1}))]
	[InlineData(                  1, (new double[]{   3,   3}))]
	[InlineData(                 -1, (new double[]{   3,  -3}))]
	[InlineData(                 20, (new double[]{  20,   1}))]
	[InlineData( 0.5379310344827586, (new double[]{ 234, 435}))]
	[InlineData(                  4, (new double[]{ -12,  -3}))]
	public void RunTest1(double förväntat, double[] faktorer)
	{
	    Program prog = new Program();
	    double resultat = prog.Division( faktorer);
	    // Console.WriteLine( "mult {0} {1}", resultat.ToString(), förväntat.ToString());
	    Assert.Equal( förväntat, resultat);
	}

	//
	//
	[Theory]
	[InlineData( new double[]{    1, 0})]
	[InlineData( new double[]{ 1E10, 0})]
	public void RunTest2(double[] faktorer)
	{
	    Program prog = new Program();
	    double resultat = prog.Division( faktorer);
	    // Console.WriteLine( "div {0}", resultat.ToString());
	    Assert.True(double.IsInfinity(resultat));
	}
    }

    public class Sinus
    {
	// förväntat kan nu skrivas som en beräknad formel, annars skulle det ha skrivits som ett decimaltal
	// lättare att förstå vad testet prövar
	[Theory]
	[ClassData(typeof(SinusTestData))]
	public void RunTest(string text, double a, double förväntat, bool inexaktJämförelse)
	{
	    Program prog = new Program();
	    Stack<double> talStack = new Stack<double>();
	    talStack.Push( a);                            // matar beräkningsrutinen på samma vis som om huvudprogrammet används
	    prog.Sin( talStack);

	    // Vissa punkter på enhetscirkeln kommer igenom det här åtagandet utan avrundningsfel
	    // men Pi punkten beräknas till 1,2246467991473532E−16 vilket är nära noll men ändå inte noll
	    // Assert.Equal(förväntat, talStack.Peek());    // fungerar icke pga detta
	    if (!inexaktJämförelse) {
		Assert.Equal(förväntat, talStack.Peek());
	    } else {  // kontrollera till den 14e decimalen
		Assert.Equal(förväntat, talStack.Peek(), 14);
	    }
	}
    }
    public class SinusTestData : IEnumerable<object[]> {
	public IEnumerator<object[]> GetEnumerator() {
	    yield return new object[] {"Pi       ", Math.PI,              0,                true};
	    yield return new object[] {"Pi/2.0   ", Math.PI/2.0,          1,                false};
	    yield return new object[] {"Pi/4.0   ", Math.PI/4.0,          1/(Math.Sqrt(2)), false};
	    yield return new object[] {"Pi+Pi/4.0", Math.PI+Math.PI/4.0, -1/(Math.Sqrt(2)), false};
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
