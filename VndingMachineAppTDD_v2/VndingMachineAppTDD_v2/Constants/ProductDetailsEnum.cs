﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VndingMachineAppTDD_v2.Constants
{
    class ProductDetailsEnum
    {
        public static string Product1Name = "Cola";
        static double Product1Price = 1.00;

        public static string Product2Name = "Chips";
        static double Product2Price = 0.50;

        public static string Product3Name = "Candy";
        static double Product3Price = 0.65;

        //public List<string> ProductNames = new List<string> { "Cola", "Chips", "Candy" };
        //public List<double> ProductPrices = new List<double> { 1.00, 0.50, 0.65 };

        public static List<string> ProductNames = new List<string> { Product1Name, Product2Name, Product3Name };
        public static List<double> ProductPrices = new List<double> { Product1Price, Product2Price, Product3Price };
 
        public static Dictionary<string, double> getProductDetails()
        {
            Dictionary<string, double> productNamesAndPrices = new Dictionary<string, double>();
            if (ProductNames.Count == ProductPrices.Count)
            {
                if (productNamesAndPrices.Count <= 0)
                {
                    for (int i = 0; i < ProductNames.Count; i++)
                    {
                        productNamesAndPrices.Add(ProductNames[i], ProductPrices[i]);
                    }
                }
            }
            return productNamesAndPrices;
        }
    }
}
