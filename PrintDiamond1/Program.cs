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
            PrintDiamond('A').Should().BeEquivalentTo(new List<string>{"A"});
        }

        [Test]
        public void PrintDiamondShouldReturnABAWhenB()
        {
            PrintDiamond('B').Should().BeEquivalentTo(new List<string> { " A","B B"," A" });
        }

        [Test]
        public void PrintDiamondShouldReturnABCAWhenC()
        {
            PrintDiamond('C').Should().BeEquivalentTo(new List<string> { "  A", " B B", "C   C", " B B", "  A" });
        }

        [Test]
        public void PrintDiamondShouldReturnABCDAWhenD()
        {
            PrintDiamond('D').Should().BeEquivalentTo(new List<string> { "   A", "  B B", " C   C", "D     D", " C   C", "  B B", "   A" });
        }

        [Test]
        public void PrintDiamondShouldReturnABCDEAWhenE()
        {
            PrintDiamond('E').Should().BeEquivalentTo(new List<string> { "    A", "   B B", "  C   C", " D     D", "E       E", " D     D", "  C   C", "   B B", "    A" });
        }

        private static List<string> PrintDiamond(char charcter)
        {
            var diamondArray = new List<string>();
            char seedChar='A';
            bool isReverse = false;
            int prefixSpacers = charcter - 'A';
            while (seedChar <= charcter && seedChar >= 'A')
            {
                if (seedChar=='A')
                    diamondArray.Add(string.Format("{0}{1}",new string(' ',prefixSpacers),seedChar));
                else
                    diamondArray.Add(GetString(charcter, seedChar));

                if (seedChar == charcter)
                    isReverse = true;

                if (isReverse)
                    seedChar--;
                else
                    seedChar++;
            }
            return diamondArray;
        }

        private static string GetString(char charcter, char seedChar)
        {
            return string.Format("{0}{1}{2}{1}", new string(' ', charcter-seedChar), seedChar, new string(' ', ((seedChar - 'A')*2)-1));
        }
    }
}
