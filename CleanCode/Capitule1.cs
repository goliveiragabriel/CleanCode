using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class Capitule1
    {
        private List<int> theList = new List<int>();

        public List<int> getThem()
        {
            List<int> list1 = new List<int>();
            foreach (var x in theList)
            {
                if (x % 4 == 0)
                    list1.Add(x);
            }
            return list1;
        }

        /// <summary>
        /// Quando você analisa o método compreende que number, verb e pluralModifier fazem parte do contexto do método GuessStatistics
        /// mas infelizmente este contexto deve ser inferido. Refatorado para classe GuessStatisticsMessage.cs
        /// </summary>
        /// <param name="candidate"></param>
        /// <param name="count"></param>
        private void printGuessStatistics(char candidate, int count) { 
            String number; 
            String verb;
            String pluralModifier; 
            if (count == 0) 
            { 
                number = "no";
                verb = "are";
                pluralModifier = "s"; 
            } 
            else if (count == 1) 
            { 
                number = "1"; 
                verb = "is"; 
                pluralModifier = ""; 
            } 
            else 
            { 
                number = count.ToString(); 
                verb = "are"; 
                pluralModifier = "s"; 
            } 
            String guessMessage = string.Format("There %s %s %s%s", verb, number, candidate, pluralModifier); 
            Console.Write(guessMessage); 
        }
    }
}
