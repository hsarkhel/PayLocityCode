using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BenefitCalculator;
namespace DeductionCalc
{
    public partial class Deduction : System.Web.UI.Page
    {

        List<string> controlList = new List<string>();
        int counter = 0;

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            controlList = (List<string>)ViewState["controlList"];

            foreach(string Id in controlList)
            {
                counter++;
                TextBox tb = new TextBox();
                tb.ID = Id;

                LiteralControl lineBreak = new LiteralControl("<br/><br/>");
                pnlDependents.Controls.Add(tb);
                pnlDependents.Controls.Add(lineBreak);
                
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            counter++;
            TextBox tb = new TextBox();
            tb.ID = "txtDepn" + counter;

            LiteralControl lineBreak = new LiteralControl("<br/><br/>");

            pnlDependents.Controls.Add(tb);
            pnlDependents.Controls.Add(lineBreak);
            controlList.Add(tb.ID);
            ViewState["controlList"] = controlList;
        }

        protected void btnCalcDeduc_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmpName.Text;
            List<string> dependentList = new List<string>();
            int depCount = 0;

            foreach (TextBox tbDep in pnlDependents.Controls.OfType<TextBox>())
            {
                if (!string.IsNullOrEmpty(tbDep.Text))
                {
                    dependentList.Add(tbDep.Text);
                    depCount++;
                }
                    
            }

            string[] dependents = dependentList.ToArray();

            clsBenefitCalculator objclsBenefitCalculator = new clsBenefitCalculator(employeeName, dependents);

            decimal deduction = objclsBenefitCalculator.CalculatePerChkDeduction();

            decimal finalSalary = Convert.ToDecimal(2000 - Convert.ToDecimal(deduction.ToString("#.##")));

            StringBuilder objResult = new StringBuilder();

            objResult.AppendLine("===================  "+ employeeName + "'s Paycheck  ===================<br/>");
            objResult.AppendLine(" Salary Before Deductions : $ 2000.00 <br/>");
            objResult.AppendLine(" Benefit Deduction        : $ " + deduction.ToString("#.##") + " ( No of dependent # "+ depCount.ToString() + " )<br/>");
            objResult.AppendLine("-------------------------------------------------------------------------<br/>");
            objResult.AppendLine(" Salary After Deduction   : $ " + finalSalary.ToString("#.##")+ "<br/>");

            lblResult.Text = objResult.ToString();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            pnlDependents.Controls.Clear();
            lblResult.Text = "";

            counter = 0;
            controlList = new List<string>();
            ViewState["controlList"] = controlList;

        }
    }
}