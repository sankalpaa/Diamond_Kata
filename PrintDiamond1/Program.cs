using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
//18.06 pm
//22.12
namespace PrintDiamond1
{
    class Program
    {
        static void Main()
        {
			var printDiamondList = PrintDiamond('S');
			foreach (var line in printDiamondList)
			{
				Console.WriteLine(line);
			}
			Console.ReadLine();
        }

		[Test]
		public void PrintDiamondShouldReturnAWhenA()
		{
			PrintDiamond('A').Should().BeEquivalentTo(new List<string> {"A"});
		}

		[Test]
		public void PrintDiamondShouldReturnABWhenB()
		{
			PrintDiamond('B').Should().BeEquivalentTo(new List<string> { " A ", "B B", " A " });
		}

		[Test]
		public void PrintDiamondShouldReturnABCWhenC()
		{
			PrintDiamond('C').Should().BeEquivalentTo(new List<string> { "  A  ", " B B ", "C   C", " B B ", "  A  " });
		}

		[Test]
		public void PrintDiamondShouldReturnABCDEAWhenE()
		{
			PrintDiamond('E').Should().BeEquivalentTo(new List<string> { "    A    ", "   B B   ", "  C   C  ", " D     D ", "E       E", " D     D ", "  C   C  ", "   B B   ", "    A    " });
		}

	    private static List<string> PrintDiamond(char character)
	    {
		    var stringDiamond = new List<string>();
		    var stringDiamondJoind = new List<string>();

		    Char seedChar = 'A';
		    while (seedChar <= character)
		    {
				string line = string.Format("{0}{1}{2}", new string(' ', character - seedChar), seedChar, new string(' ', seedChar-'A'));
			    line += GetVerticaleSymmetric(line);
			    stringDiamond.Add(line);
			    seedChar++;
		    }
			if (character != 'A')
			{
				stringDiamondJoind.AddRange(stringDiamond);
				stringDiamond.Reverse();
				stringDiamondJoind.AddRange(stringDiamond.GetRange(1,stringDiamond.Count-1));
			}
			else
			{
				stringDiamondJoind.AddRange(stringDiamond);
			}

			return stringDiamondJoind;
	    }

		private static string GetVerticaleSymmetric(string firstHalf)
		{
			var charArray = firstHalf.ToCharArray();
			Array.Reverse(charArray);
			return (new string(charArray)).Substring(1);
		}
    }
}
