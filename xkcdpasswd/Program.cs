using System;
using System.Text;

namespace xkcdpasswd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string arg1 = "4";  // default # of words
            if (args.Length > 0)
                arg1 = args[0];            

            string sep = "-";
            int numWords = int.Parse(arg1);
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

            Console.WriteLine(sb.ToString());
        }        
    }
}