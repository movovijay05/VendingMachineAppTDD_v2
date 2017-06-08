using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VndingMachineAppTDD_v2.Functions
{
    class GenericDictionaryFunctions
    {
        public String printAStringIntDictionary(Dictionary<string, int> printableStringIntDictionary)
        {
            String dictionaryStringOutput = "";
            foreach (var item in printableStringIntDictionary)
            {
                dictionaryStringOutput += "\n" + item;
            }
            dictionaryStringOutput = dictionaryStringOutput.Replace("[", "")
                .Replace("]", "")
                .Replace(" ", "")
                .Replace(",", ":")
                .Replace("\n", ":");
            Trace.WriteLine(dictionaryStringOutput);
            return dictionaryStringOutput;
        }

      public bool checkIfTwoStringIntDictionariesAreIdenticalWithoutSorting(
      Dictionary<string, int> oldDict,
      Dictionary<string, int> newDict)
        {
            if (!oldDict.Count.Equals(newDict.Count)) return false;
            foreach (int i in Enumerable.Range(0, oldDict.Count - 1))
            {
                if (!newDict.ElementAt(i).Equals(oldDict.ElementAt(i))) {return false; }
            }
            return true;
        }

        public bool checkIfTwoStringDoubleDictionariesAreIdenticalWithoutSorting(
            Dictionary<string, double> oldDict,
            Dictionary<string, double> newDict)
        {
            if (!oldDict.Count.Equals(newDict.Count)) { return false; }
            else
            {   foreach (int i in Enumerable.Range(0, oldDict.Count - 1))
                {
                   if (!newDict.ElementAt(i).Equals(oldDict.ElementAt(i))) {return false; }
                }
                return true;
            }
        }
    }
}
