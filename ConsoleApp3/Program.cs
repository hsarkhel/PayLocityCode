using System;
using System.Linq;
using System.Collections.Generic;
using BenefitCalculator;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            string employeeName = "HIndol";

            List<string> dependentList = new List<string>();

            dependentList.Add("Susmita");
            dependentList.Add("Himanish");
            dependentList.Add("Atest");

            string[] dependents = dependentList.ToArray();

            clsBenefitCalculator objclsBenefitCalculator = new clsBenefitCalculator(employeeName, dependents);

            decimal deduction = objclsBenefitCalculator.CalculatePerChkDeduction();

            string final = deduction.ToString("#.##");


        }
    }
}
