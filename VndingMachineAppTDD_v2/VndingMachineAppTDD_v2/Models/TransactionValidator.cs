using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndingMachineAppTDD_v2.Constants;

namespace VndingMachineAppTDD_v2.Models
{
    class TransactionValidator
    {
        Dictionary<string, double> productNamesAndPrices = new Dictionary<string, double>();
        Dictionary<string, double> coinNamesAndValues = new Dictionary<string, double>();
        public double calculateTotalPriceOfASingleUserTransaction(Dictionary<string, int> itemizedInputList, Int32 type)
        {
            double totalPriceOfTransaction = 0.00;
            productNamesAndPrices = ProductDetailsEnum.getProductDetails();
            coinNamesAndValues = CoinDetailsEnum.getCoinDetails();

            for (int i = 0; i < itemizedInputList.Count; i++)
            {
                double itemPrice = 0.00;
                if (type == 1)  //calculating the price of a product
                {
                    itemPrice = productNamesAndPrices[itemizedInputList.ElementAt(i).Key];
                }
                else  // calculating the price of coins
                {
                    itemPrice = coinNamesAndValues[itemizedInputList.ElementAt(i).Key];
                    //Console.WriteLine(genFun.printAStringIntDictionary(vCEnum.totalRemainingCashInVM));
                }
                double itemQuantity = itemizedInputList.ElementAt(i).Value;
                totalPriceOfTransaction += (itemQuantity * itemPrice);
            }
            Trace.WriteLine(totalPriceOfTransaction.ToString());
            return totalPriceOfTransaction;
        }
    }
}
