using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VndingMachineAppTDD_v2.Constants
{
    class VendingMachineCashEnum
    {
        public static int totalNumberOfQuartersInVM = 10;
        public static int totalNumberOfNickelsiInVM = 10;
        public static int totalNumberOfDimesInVM = 10;

        public const string VMNickelsName = CoinDetailsEnum.NickelsName;
        public const string VMDimesName = CoinDetailsEnum.DimesName;
        public const string VMQuartersName = CoinDetailsEnum.QuartersName;

        public Dictionary<string, int> totalRemainingCashInVM { get; set; }
        public Dictionary<string, int> numberOfNickelsDimesAndQuartersRequiredToMakeChange { get; set; }
        public double changeToBeGivenToTheUser { get; set; }
        public double totalValueOfCoinsInsertedByTheUser { get; set; }
        public double totalPriceOfTransaction { get; set; }
        public double balanceToBeDisplayed { get; set; }
    }
}
