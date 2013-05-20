<%--<%@ Page Title="Master Basic" Language="C#" AutoEventWireup="true" CodeFile="Master_Basic.aspx.cs" Inherits="Master_Basic" %>--%>
<%@ Page Title="Master Basic" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Master_Basic.aspx.cs" Inherits="Master_Basic" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 

<html xmlns="http://www.w3.org/1999/xhtml">--%>

<%--<head id="Head1" runat="server">

    <title></title>

    <style type="text/css">
        .textbox
        {}
        .style1
        {
            width: 462px;
        }
    </style>

</head>--%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            height: 28px;
            text-align: center;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            height: 28px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<%@ Page Title="Master Basic" Language="C#" AutoEventWireup="true" CodeFile="Master_Basic.aspx.cs" Inherits="Master_Basic" %>--%>

    <div>

      <table width="84%" cellpadding="0" cellspacing="0" align="center" style="border: solid 1px #3366CC;">

            <tr>

                <td colspan="4" 
                    style="height: 30px; background-color: #f5712b; text-align: center;">

                    <span class="TextTitle" style="color: #FFFFFF;">&nbsp;Basic Form 
                    Entry</span>

                </td>

            </tr>

            <tr>

                <td height="20px" colspan="0">

                </td>

            </tr>

            <tr>

                <td width="50%" valign="top">

                    <table id="TableLogin" class="HomePageControlBGLightGray" cellpadding="4" cellspacing="4"

                        runat="server" width="100%">

                        <tr>

                            <td colspan="2" align="center">

                                <asp:Label ID="LabelMessage" ForeColor="Red" 
                                    runat="server" EnableViewState="False"></asp:Label><br>

                            </td>

                        </tr>

                        <tr style="font-weight: normal; color: #000000">

                            <td align="right" class="style5">

                                Id<span>:</span>

                            </td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TextBox ID="TextBoxId" runat="server" 
                                    CssClass="textbox" Width="96px"

                                    MaxLength="32" Height="25px"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="TextBoxId" Display="Dynamic" ErrorMessage="Enter ID" 
                                    ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="basic"></asp:RequiredFieldValidator>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                Name<span class="TextTitle">:</span>

                            </td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TextBox ID="TextBoxName" runat="server" 
                                    CssClass="textbox" Width="182px"

                                    MaxLength="32" Height="25px"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="Enter Name" 
                                    ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="basic"></asp:RequiredFieldValidator>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <span class="TextTitle">Description:</span>

                            </td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TextBox ID="TextBoxDescription" 
                                    runat="server" CssClass="textbox" Width="232px"

                                    MaxLength="100" Height="44px" 
                                    TextMode="MultiLine"></asp:TextBox>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <span class="TextTitle">Expire Time:</span>

                            </td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TextBox ID="TextBoxTime" runat="server" 
                                    CssClass="textbox" Width="181px" 
                                    Height="25px"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TextBoxTime" Display="Dynamic" 
                                    ErrorMessage="Enter Expire Time" ForeColor="#CC0000" SetFocusOnError="True" 
                                    ValidationGroup="basic"></asp:RequiredFieldValidator>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                Expire Size:

                            </td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TextBox ID="TextBoxSize" runat="server" 
                                    CssClass="textbox" Width="180px" 
                                    Height="25px"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TextBoxSize" Display="Dynamic" 
                                    ErrorMessage="Enter Expire Size" ForeColor="#CC0000" SetFocusOnError="True" 
                                    ValidationGroup="basic"></asp:RequiredFieldValidator>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                Read:</td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:gridview ID="gv_read" runat="server" ShowFooter="true" 
            AutoGenerateColumns="false" 
                    style="font-size: small">
            <Columns>
            
            
            <asp:TemplateField HeaderText="Value">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" 
                        MaxLength="32"></asp:TextBox>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <asp:Button ID="ButtonAdd" runat="server" Text="Add" onclick="ButtonAdd_Click"/>
                </FooterTemplate>
           </asp:TemplateField>
            </Columns>
        </asp:gridview>
                                                    <asp:Table ID="mytbl" runat="server" 
                                                        Width="389px">
                                                    </asp:Table>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" colspan="2" 
                                style="text-align: center">
                                &nbsp;</td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                Write:</td>

                            <td align="left" style="padding-left: 10px;">

                             <asp:gridview ID="gv_write" runat="server" ShowFooter="true" 
            AutoGenerateColumns="false" 
                    style="font-size: small">
            <Columns>
            
            
            <asp:TemplateField HeaderText="Value">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" 
                        MaxLength="32"></asp:TextBox>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <asp:Button ID="ButtonAdd0" runat="server" Text="Add" onclick="ButtonAdd0_Click" />
                </FooterTemplate>
           </asp:TemplateField>
            </Columns>
        </asp:gridview>
                                                    <asp:Table ID="mytbl1" runat="server" 
                                                        Width="389px">
                                                    </asp:Table>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style4" colspan="2">
                                &nbsp;</td>

                        </tr>

                        <tr>

                            <td align="right" class="style1">

                                &nbsp;</td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:Button ID="btn_save" runat="server" 
                                    Height="32px" onclick="btn_save_Click" 
                                    Text="Save" Width="72px" ValidationGroup="basic" />

                                <asp:Button ID="btn_update" runat="server" 
                                    Height="32px" onclick="btn_update_Click" 
                                    Text="Update" Width="72px" />

                                <asp:Button ID="btn_delete" runat="server" 
                                    Height="32px" onclick="btn_delete_Click" 
                                    Text="Delete" Width="72px" />

                                <asp:Button ID="btn_Clear" runat="server" 
                                    Height="32px" onclick="btn_Clear_Click" 
                                    Text="Clear" Width="72px" />

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <strong>Details of Basic:</strong></td>

                            <td align="left" style="padding-left: 10px;">

                                &nbsp;</td>

                        </tr>

                        <tr>

                            <td align="right" class="style1">

                                &nbsp;</td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:GridView ID="GV_Basic" runat="server" 
                                   
                                    onselectedindexchanged="GV_Basic_SelectedIndexChanged" 
                                    DataKeyNames="basicid">
                                    <Columns>
                                        <asp:CommandField SelectText="Detail" 
                                            ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style1">

                                &nbsp;</td>

                            <td align="left" style="padding-left: 10px;">

                                <asp:TreeView ID="TreeView1" runat="server">
                                </asp:TreeView>

                            </td>

                        </tr>

                    </table>

                </td>

            </tr>

        </table>

    </div>
    </asp:Content>
 <%--   </form>

</body>

</html>--%>
