using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
//18.06 pm
//22.12
namespace PrintDiamond1
{
	class Program
	{
		static void Main(string[] args)
		{
			var printDiamondList = PrintDiamond('Z');
			foreach (var line in printDiamondList)
			{
				Console.WriteLine(line);
			}
			Console.ReadLine();
		}

		[Test]
		public void PrintDiamond_ShouldReturn_AA_When_A()
		{
			PrintDiamond('A').Should().BeEquivalentTo(new List<string> {"A","A"});
		}

		[Test]
		public void PrintDiamond_ShouldReturn_ABBA_When_B()
		{
			PrintDiamond('B').Should().BeEquivalentTo(new List<string> { " A", "B B", " A" });
		}

		[Test]
		public void PrintDiamond_ShouldReturn_ABCCBA_When_C()
		{
			PrintDiamond('C').Should().BeEquivalentTo(new List<string> { "  A", " B B","C   C", " B B", "  A" });
		}

		[Test]
		public void PrintDiamond_ShouldReturn_ABCDDCBA_When_D()
		{
			PrintDiamond('D').Should().BeEquivalentTo(new List<string> { "   A", "  B B", " C   C","D     D", " C   C", "  B B", "   A" });
		}

		[Test]
		public void PrintDiamond_ShouldReturn_ABCDEEDCBA_When_E()
		{
			PrintDiamond('E').Should().BeEquivalentTo(new List<string> { "    A", "   B B", "  C   C", " D     D", "E       E", " D     D", "  C   C", "   B B", "    A" });
		}

		private static List<string> PrintDiamond(char letter)
		{
			var letterAscillValue = (int) letter;
			int currentLetterAsci = 65;
			var diamondValues = new List<string>();
			int lineLength = (letterAscillValue-65)*2+1;
			int prefixLength = (lineLength-1)/2;

				while (currentLetterAsci <= letterAscillValue)
				{
					if (currentLetterAsci == 65)
						diamondValues.Add(string.Format("{0}{1}", new String(' ', (lineLength - 1)/2), 'A'));
					else
					{
						diamondValues.Add(string.Format("{0}{1}{2}{1}", new String(' ', prefixLength),
														(char)currentLetterAsci, new String(' ', lineLength - prefixLength*2-2)));

					}
					prefixLength--;
					currentLetterAsci++;
				}
			
			prefixLength = 1;
			currentLetterAsci = letterAscillValue;
				while (currentLetterAsci >= 65)
				{
					if (currentLetterAsci == 65)
						diamondValues.Add(string.Format("{0}{1}", new String(' ', (lineLength - 1) / 2), 'A'));
					else if (currentLetterAsci != letterAscillValue)
					{
						diamondValues.Add(string.Format("{0}{1}{2}{1}", new String(' ', prefixLength),
														(char)currentLetterAsci, new String(' ', lineLength - prefixLength * 2 - 2)));
						prefixLength++;
					}

					currentLetterAsci--;
				}
			return diamondValues;
		}
	}
}
