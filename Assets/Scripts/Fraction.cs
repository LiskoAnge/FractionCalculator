using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : MonoBehaviour
{
	private int _numerator;
	private int _denominator;

	public Fraction(int fractionNumerator, int fractionDenominator)
	{
		_numerator = fractionNumerator;
		_denominator = fractionDenominator;
	}

	//properties for nominator and denominator
	public int theNumerator
	{
		get
		{
			return _numerator;
		}
	}

	public int theDenominator
	{
		get
		{
			return _denominator;
		}
	}

	//initialize fraction assigning 1 to numerator and 1 to denominator
	public Fraction() : this(1, 1) {

	}
	//finding the greatest common divisor between two numbers, represented in this case by 'a' and 'b'
	private int GreatestCD(int a, int b)
	{
		while (a != 0 && b != 0)
		{
			if (a > b)
				a %= b;
			else
				b %= a;
		}

		if (a == 0)
			return b;
		else
			return a;
	}

	//to simplify a fraction the numerator and the denominator must be divided by the same nonzero whole number
	public Fraction Reduction(int numerator, int denominator)
	{
		//if both negative, converting numerator and denominator to positive sign   
		if (numerator < 0 && denominator < 0)
		{
			numerator *= -1;
			denominator *= -1;

		}
		// if numerator is positive, but the denominator is negative convert the numerator to a negative and the denominator to a positive
		else if (numerator > 0 && denominator < 0)
		{
			numerator *= -1;
			denominator *= -1;
		}
		//declare the variable for the greatest common divisor
		int a = GreatestCD(numerator, denominator);

		//reduction of numerator
		numerator = numerator / a;
		//reduction of denominator
		denominator = denominator / a;

		return new Fraction(numerator, denominator);
	}

	public Fraction Division(Fraction fractionA, Fraction fractionB)
	{
		return new Fraction((fractionA.theNumerator * fractionB.theDenominator), (fractionB.theNumerator * fractionA.theDenominator));

	}
	public Fraction Multiplication(Fraction fractionA, Fraction fractionB)
	{
		int resultNumerator = fractionA.theNumerator * fractionB.theNumerator;
		int resultDenominator = fractionA.theDenominator * fractionB.theDenominator;
		return new Fraction(resultNumerator, resultDenominator);
	}
	public Fraction Subtraction(Fraction fractionA, Fraction fractionB)
	{
		return new Fraction(((fractionA.theNumerator * fractionB.theDenominator) - (fractionB.theNumerator * fractionA.theDenominator)),(fractionA.theDenominator * fractionB.theDenominator));
	}

	public Fraction Addition(Fraction fractionA, Fraction fractionB)
	{
		Fraction result = new Fraction((fractionA.theNumerator * fractionB.theDenominator) + (fractionB.theNumerator * fractionA.theDenominator), fractionA.theDenominator * fractionB.theDenominator);

		return result;
	}
}
