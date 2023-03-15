<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doctorRegist.aspx.cs" Inherits="webTermProject.hospitalRegist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Doctor Operations</title>
    
    <link rel="stylesheet" href="doctorRegist.css"/>

</head>

<body>
    <h1 class="baslik">Doctor Admin Page</h1>
    
    <form id="form1" runat="server">
        
        <p>
            <a href ="homePage.aspx">Home Page</a>
        </p>
    
     <asp:HiddenField ID="hfDoctorID" runat="server"/>  

    <div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style8">
                    Doctor First Name:<br />
                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Doctor Last Name:<br />
                    <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Doctor E-MAIL:<br />
                    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Doctor Contact Number:<asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Doctor Department:<asp:DropDownList ID="ddlDepartment" runat="server">

                                        </asp:DropDownList>
                    <br />
                    <br />
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_ClickThesis" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_ClickThesis" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_ClickThesis" />
                    
                    </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    
                </td>
                <td class="auto-style5">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
              
            
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        
        <asp:GridView ID="gvInst" runat="server" AutoGenerateColumns="False" Width="189px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="DOCTOR_ID" HeaderText="ID" />
                <asp:BoundField DataField="DOCTOR_FNAME" HeaderText="First Name" />
                <asp:BoundField DataField="DOCTOR_LNAME" HeaderText="Last Name" />
                <asp:BoundField DataField="DOCTOR_E_MAIL" HeaderText="E-mail" />
                <asp:BoundField DataField="DOCTOR_CONTACT_NUMBER" HeaderText="Contact Number" />
                <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="Department" />
                <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="Department ID" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("DOCTOR_ID") %>' OnClick="lnk_OnClickInst">View</asp:LinkButton>
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
    
</form>
</body>
</html>