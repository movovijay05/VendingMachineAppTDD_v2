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
            // Simple check, are the counts the same?
            if (!oldDict.Count.Equals(newDict.Count)) return false;

            // iterate through all the keys in oldDict and
            // verify whether the key exists in the newDict
            foreach (int i in Enumerable.Range(0, oldDict.Count - 1))
            {
                if (newDict.ElementAt(i).Equals(oldDict.ElementAt(i)))
                {
                    // iterate through each value for the current key in oldDict and 
                    // verify whether or not it exists for the current key in the newDict
                }
                else { return false; }
            }
            return true;
        }
    }
}
