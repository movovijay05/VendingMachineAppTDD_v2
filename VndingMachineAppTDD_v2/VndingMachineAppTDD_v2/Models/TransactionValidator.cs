using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VndingMachineAppTDD_v2.Constants;
using VndingMachineAppTDD_v2.Functions;

namespace VndingMachineAppTDD_v2.Models
{
    class TransactionValidator
    {
        GenericDictionaryFunctions genFun = new GenericDictionaryFunctions();
        Dictionary<string, double> productNamesAndPrices = new Dictionary<string, double>();
        Dictionary<string, double> coinNamesAndValues = new Dictionary<string, double>();
        public double calculateBalance(double number1, double number2)
        {
            double balance = Math.Round(number2 - number1, 2);
            return balance;
        }
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
            //Trace.WriteLine(totalPriceOfTransaction.ToString());
            return totalPriceOfTransaction;
        }
        public int calculateNumberOfCoinsRequiredToMakeChange(double changeToBeGivenToTheUser, double coinsValue, String coinsName)
        {
            int numberOfCoinsRequiredToMakeChange = 0;
            if (coinsName.Equals(CoinDetailsEnum.NickelsName))
            {
                numberOfCoinsRequiredToMakeChange = Convert.ToInt32(changeToBeGivenToTheUser / coinsValue);
            }
            else
            {
                numberOfCoinsRequiredToMakeChange = (int)Math.Floor(changeToBeGivenToTheUser / coinsValue);
            }
            return numberOfCoinsRequiredToMakeChange;
        }

        public double remainingChangeToBeGivenToTheUser(double coinsValue, String coinsName, VendingMachineCashEnum vCEnum)
        {
            if (vCEnum.changeToBeGivenToTheUser > 0.00)
            {
                int numberOfCoinsRequiredToMakeChange = calculateNumberOfCoinsRequiredToMakeChange(vCEnum.changeToBeGivenToTheUser, coinsValue, coinsName);
                if (vCEnum.totalRemainingCashInVM[coinsName] > numberOfCoinsRequiredToMakeChange)
                {
                    vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange.Add(coinsName, numberOfCoinsRequiredToMakeChange);
                    vCEnum.changeToBeGivenToTheUser = (vCEnum.changeToBeGivenToTheUser - (numberOfCoinsRequiredToMakeChange * coinsValue));
                }
            }
            else { vCEnum.changeToBeGivenToTheUser = 0.00; }
            Trace.WriteLine(vCEnum.changeToBeGivenToTheUser.ToString());
            return vCEnum.changeToBeGivenToTheUser;
        }
   
        public Dictionary<string, int> calculateTheNumberOfNickelsDimesAndQuartersRequiredToMakeChange(VendingMachineCashEnum vCEnum)
        {
            // The order of the below lines is important
            vCEnum.changeToBeGivenToTheUser = remainingChangeToBeGivenToTheUser(CoinDetailsEnum.QuartersValue, CoinDetailsEnum.QuartersName, vCEnum);
            vCEnum.changeToBeGivenToTheUser = remainingChangeToBeGivenToTheUser(CoinDetailsEnum.DimesValue, CoinDetailsEnum.DimesName, vCEnum);
            vCEnum.changeToBeGivenToTheUser = remainingChangeToBeGivenToTheUser(CoinDetailsEnum.NickelsValue, CoinDetailsEnum.NickelsName, vCEnum);
            Trace.WriteLine("1:" + genFun.printAStringIntDictionary(vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange));
            return vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange;
        }

        public bool checkIfThereisEnoughCashInVMAndUpdateRemainingCash(VendingMachineCashEnum vCEnum)
        {
            bool isThereEnoughCashInVMToTendChange = true;
            vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange = calculateTheNumberOfNickelsDimesAndQuartersRequiredToMakeChange(vCEnum);
            if (vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange.Count.Equals(vCEnum.totalRemainingCashInVM))
            {
                foreach (int i in Enumerable.Range(0, vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange.Count - 1))
                {
                    if (vCEnum.totalRemainingCashInVM.ElementAt(i).Value < vCEnum.numberOfNickelsDimesAndQuartersRequiredToMakeChange.ElementAt(i).Value)
                    {
                        isThereEnoughCashInVMToTendChange = false;
                    }
                }
            }
            return isThereEnoughCashInVMToTendChange;
        }

        public string checkIfChangeNeedsToBeProvidedByVMOrUserNeedsToInputMoreCoins(VendingMachineCashEnum vCEnum)
        {
            String messageToBeDisplayed = "";
            vCEnum.balanceToBeDisplayed = calculateBalance(vCEnum.totalPriceOfTransaction, vCEnum.totalValueOfCoinsInsertedByTheUser);
            if (vCEnum.totalPriceOfTransaction > vCEnum.totalValueOfCoinsInsertedByTheUser)
            {
                messageToBeDisplayed = "Please pay the remanining balance of $" + vCEnum.balanceToBeDisplayed.ToString();
            }
            else if (vCEnum.totalPriceOfTransaction < vCEnum.totalValueOfCoinsInsertedByTheUser)
            {
                vCEnum.changeToBeGivenToTheUser = vCEnum.totalValueOfCoinsInsertedByTheUser - vCEnum.totalPriceOfTransaction;
                if (checkIfThereisEnoughCashInVMAndUpdateRemainingCash(vCEnum) == true)
                {
                    messageToBeDisplayed = "Thanks for paying!!! Dispensing change to the amount of $" + vCEnum.balanceToBeDisplayed;//+ "\n Remaining Cash in VM:" + genFun.printAStringIntDictionary(vCEnum.totalRemainingCashInVM);
                }
                else
                {
                    messageToBeDisplayed = "Please tend exact change. Please collect all the coins you deposited";
                }
            }
            else
            {
                messageToBeDisplayed = "Thanks for paying!!! Please collect the product";
            }
            Trace.WriteLine(messageToBeDisplayed);
            return messageToBeDisplayed;
        }
    }
}
