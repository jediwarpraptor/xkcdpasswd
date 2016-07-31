using System;
using System.Text;

namespace xkcdpasswd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numWords = 4;  // default # of words
            int numChoices = Dictionary.EN.Length;
            double Entropy = 0;
            bool doEntropy = false;

            if (args.Length > 0)
                numWords = int.Parse(args[0]);

            if (args.Length > 1) 
                doEntropy = true;

            string sep = "-";
            int i = 0;
            bool alt = true;
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            if (rnd.Next(0, 1) == 1)
                alt = true;

            do
            {
                if (i > 0)
                    sb.Append(sep);

                var n = rnd.Next(0, Dictionary.EN.Length);
                var wrd = Dictionary.EN[n];

                if (alt)
                    wrd = wrd.ToUpper();

                sb.Append(wrd);
                i++;
                alt = !alt;
            } while (i < numWords);

            var newpass = sb.ToString();
            var rs = newpass;
            if (doEntropy)
            {
                Entropy = CalcEntropy(numChoices, numWords);
                var howlong = CalcYears(Entropy, 1000);
                rs = $"Entropy for a password generated with {numWords} words will have\napproximately {Entropy:0.0} bits of Entropy\nand will take {howlong:##,###} years to guess";
            }

            Console.WriteLine(rs);
        }
        
        public static double CalcEntropy(double numWords, double numChoices)
        {
            return Math.Log(Math.Pow(numWords, numChoices), 2);
        }
        public static double CalcYears(double entropy, double guessesPerSecond)
        {
            double howlong = Math.Pow(2, entropy) / guessesPerSecond / 60 / 60 / 24 / 364.25;
            return howlong;

        }
    }
}