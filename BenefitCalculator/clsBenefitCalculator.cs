using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BenefitCalculator
{
    public class clsBenefitCalculator
    {
        private string employeeName;

        private string[] dependentsName;

        private const int NO_OF_PAY_CHK = 26;

        private const int EMP_YR_DEDUC_BEFORE_DISCOUNT = 1000;

        private const int EMP_YR_DEDUC_AFTER_DISCOUNT = 900;

        private const int DEP_YR_DEDUC_BEFORE_DISCOUNT = 500;

        private const int DEP_YR_DEDUC_AFTER_DISCOUNT = 450;

        public clsBenefitCalculator(string empName, string[] depName)
        {
            employeeName = empName;
            dependentsName = depName;
        }


        public decimal CalculatePerChkDeduction()
        {
            int yearlyDeduction = 0;

            int dependentDeduction = 0;

            int employeeDeduction = employeeName.StartsWith("A") ? EMP_YR_DEDUC_AFTER_DISCOUNT : EMP_YR_DEDUC_BEFORE_DISCOUNT;

            int depACount = (from d in dependentsName
                             where d.StartsWith("A")
                             select d).Count();

            int depNACount = dependentsName.Count() - depACount;

            dependentDeduction = (DEP_YR_DEDUC_BEFORE_DISCOUNT * depNACount) + (DEP_YR_DEDUC_AFTER_DISCOUNT * depACount);

            yearlyDeduction = employeeDeduction + dependentDeduction;

            return Convert.ToDecimal(yearlyDeduction) / NO_OF_PAY_CHK;

        }

        

    }
}
