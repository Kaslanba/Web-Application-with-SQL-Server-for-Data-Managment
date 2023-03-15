<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientRecord.aspx.cs" Inherits="webTermProject.patientRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Operations</title>
    <link rel="stylesheet" href="patientRecord.css"/>
    <style type="text/css">


    </style>
</head>
<body>
    <h1 class="baslik">Patient Record Page</h1>
    <form id="form1" runat="server">
        <p>
            <a href ="homePage.aspx">Home Page</a>
        </p>
    <div>
                <asp:HiddenField ID="hfPatientID" runat="server"/>  

        <table class="auto-style2">
            <tr>
                <td class="auto-style8">
                    <br />
                    Patient First Name:<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient Last Name:<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient Medicines:<asp:TextBox ID="txtMedicine" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient Contact Number:<asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient E-MAIL:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Department:<asp:DropDownList ID="ddlDepartment" runat="server">

                    </asp:DropDownList>
                    <br />
                    <br />
                    Patient Examination Illness:<asp:TextBox ID="txtIll" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient Examination Diagnosis:<asp:TextBox ID="txtDia" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Patient Examination Given Medicines:
                    <asp:TextBox ID="txtGiven" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    </td>
                   
            </tr>
            <tr>
                <td class="auto-style11">
                    
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_ClickThesis" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_ClickThesis" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_ClickThesis" />
                    
                    </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    
                </td>
                <td class="auto-style13">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
              
            
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvInst" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="PATIENT_ID" HeaderText="ID" />
                <asp:BoundField DataField="PATIENT_FNAME" HeaderText="First Name" />
                <asp:BoundField DataField="PATIENT_LNAME" HeaderText="Last Name" />
                <asp:BoundField DataField="PATIENT_MEDICINES" HeaderText="Medicine" />
                <asp:BoundField DataField="PATIENT_EMERGENCY_CONTACT_NUMBER" HeaderText="Contact Number" />
                <asp:BoundField DataField="PATIENT_E_MAIL" HeaderText="E-mail" />
                <asp:BoundField DataField="PATIENT_EXAMINATION_ILNESS" HeaderText="Illness" />
                <asp:BoundField DataField="PATIENT_EXAMINATION_DIAGNOSIS" HeaderText="Diagnosis" />
                <asp:BoundField DataField="PATIENT_EXAMINATION_GIVEN_MEDICINES" HeaderText="Medicine" />
                <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="Department ID" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("PATIENT_ID") %>' OnClick="lnk_OnClickInst">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString ="<%$ConnectionStrings:myConnectionString %>"></asp:SqlDataSource>
                 
                </td>
            </tr>
        </table>
    </ItemTemplate>

  </form>
</body>
</html>
