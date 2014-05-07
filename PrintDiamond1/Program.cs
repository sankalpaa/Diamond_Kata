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
			var printDiamondList = PrintDiamond('G');
			foreach (var line in printDiamondList)
			{
				Console.WriteLine(line);
			}
			Console.ReadLine();
        }

        [Test]
        public void PrintDiamondShouldReturnAWhenA()
        {
            PrintDiamond('A').Should().BeEquivalentTo(new List<string>{"A"});
        }

		[Test]
		public void PrintDiamondShouldReturnABWhenA()
		{
			PrintDiamond('B').Should().BeEquivalentTo(new List<string> { " A","B B"," A" });
		}

		[Test]
		public void PrintDiamondShouldReturnABCWhenC()
		{
			PrintDiamond('C').Should().BeEquivalentTo(new List<string> { "  A", " B B", "C   C", " B B", "  A" });
		}

		[Test]
		public void PrintDiamondShouldReturnABCDWhenD()
		{
			PrintDiamond('D').Should().BeEquivalentTo(new List<string> { "   A", "  B B", " C   C", "D     D", " C   C", "  B B", "   A" });
		}

		[Test]
		public void PrintDiamondShouldReturnABCDEWhenE()
		{
			PrintDiamond('E').Should().BeEquivalentTo(new List<string> { "    A", "   B B", "  C   C", " D     D", "E       E", " D     D", "  C   C", "   B B", "    A" });
		}

	    private static List<string> PrintDiamond(char character)
	    {
		    var primaryList = new List<string>();
		    var buildList = new List<string>();
		    
			 primaryList.Add(string.Format("{0}{1}",new string(' ',character-'A'), "A"));
		    if (character>'A')
		    {
			    char seedChar = 'B';
				while (seedChar <= character)
				{
					primaryList.Add(string.Format("{2}{0}{1}{0}", seedChar, new string(' ', ((seedChar - 'A') * 2 - 1)), new string(' ', character-seedChar)));
					seedChar++;
				}
				buildList.AddRange(primaryList);
				primaryList.Reverse();
			    buildList.AddRange(primaryList.GetRange(1,primaryList.Count-1));
			    return buildList;
		    }
		    return primaryList;
	    }
    }
}
