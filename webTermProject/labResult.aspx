<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="labResult.aspx.cs" Inherits="webTermProject.labResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="labResult.css"/>    
    <title>Lab Result</title>
    </head>

<body>   
<form runat="server">
    <h1 class="baslik">Lab Result Page</h1>

         <p>
            <a href ="homePage.aspx">Home Page</a>
        </p>

    <asp:HiddenField ID="hfLabID" runat="server" />

Patient ID:
    <br />
    <asp:DropDownList ID="ddlPatId" runat="server" AutoPostBack="true"></asp:DropDownList>
    <br />
    <br />

Covid Result:<br/>
    <asp:DropDownList ID="ddlRes" runat="server">
        <asp:ListItem Text="POS" />
        <asp:ListItem Text="NEG" />
    </asp:DropDownList>
    <br />
    <br />

    <asp:Button ID="btnSaveLab" runat="server" Text="Save" OnClick="btnSave_ClickGr" />
    <asp:Button ID="btnDeleteLab" runat="server" Text="Delete" OnClick="btnDelete_ClickGr" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_ClickGr" />

    <br />
    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

    <br />
    <br />
    <asp:GridView ID="gvPatientLab" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
         <Columns>

                <asp:BoundField DataField="PATIENT_ID" HeaderText="Patient ID" />
                <asp:BoundField DataField="PATIENT_FNAME" HeaderText="Patient Name" />
                <asp:BoundField DataField="PATIENT_LNAME" HeaderText="Patien Last Name" />
                <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="Department ID" />
                <asp:BoundField DataField="COVID_RESULT" HeaderText="Result" />
                                         
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

  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString ="<%$ConnectionStrings:myConnectionString %>"></asp:SqlDataSource>

</form>
</body>
</html>
