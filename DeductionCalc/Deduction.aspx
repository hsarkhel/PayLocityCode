<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deduction.aspx.cs" Inherits="DeductionCalc.Deduction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Deduction Calculation</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />

</head>
<body>

    <form id="from1" runat="server">
        <h1 class="h2"> Benefit Deduction Calculator</h1>
        <div style="align-content:center">
            <table  >
                <tr>
                    <td >Employee Name :&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="text-primary"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqUserName" ControlToValidate="txtEmpName"
                            runat="server" ErrorMessage="Please enter employee name" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left">
                        <br />
                        <asp:Button ID="btnAddDept" runat="server" Text="Add Dependent(s) Name" OnClick="btnAddDept_Click" CssClass="btn-info" />
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:PlaceHolder ID="pnlDependents" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br /><br />
                        <asp:Button ID="btnCalcDeduc" runat="server" Text="Calculate Benefit Deduction" OnClick="btnCalcDeduc_Click" CssClass="btn-primary" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br /><br />
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn-info" OnClick="btnReset_Click" />

                    </td>
                </tr>
            </table>


        </div>

    </form>


</body>
</html>
