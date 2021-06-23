namespace bordsräknare
{
    class Program
    {
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

    }
}
