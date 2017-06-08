using System;
using System.Collections.Generic;
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
                .Replace(",", ":");
            return dictionaryStringOutput;
        }
    }
}
