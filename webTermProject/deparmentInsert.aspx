<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deparmentInsert.aspx.cs" Inherits="webTermProject.deparmentInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Department Operations</title>

    <link rel="stylesheet" href="departmentInsert.css"/>
    
    
</head>
<body>
    <h1 class="baslik">Hospital Department</h1>
    <form id="form1" runat="server">
    
        <asp:HiddenField ID="hfDepartID" runat="server"/>  

        <p>
            <a href ="homePage.aspx">Home Page</a>
        <p/>
       
            <table class="auto-style15">
            <tr>
                <td class="auto-style11">
                    Department Name</td>
                <td class="auto-style13">
                    <asp:TextBox ID="txtDepart" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    
                    </td>
                <td class="auto-style14">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_ClickThesis" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_ClickThesis" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_ClickThesis" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    
                </td>
                <td class="auto-style14">
                    <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
              
            
                <td class="auto-style4">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        </p>
    <div>
        <br />

                <asp:GridView ID="gvInst" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="Department ID" />
                <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="Department Name" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("DEPARTMENT_ID") %>' OnClick="lnk_OnClickInst">View</asp:LinkButton>
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
        <asp:SqlDataSource ID="SqlDataSourceThesis" runat="server" ConnectionString ="<%$ConnectionStrings:myConnectionString %>"></asp:SqlDataSource>

    </div>

    </form>
</body>
</html>
