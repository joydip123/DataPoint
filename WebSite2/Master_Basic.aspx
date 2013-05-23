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
            width: 103px;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            height: 28px;
            text-align: right;
            width: 103px;
        }
        .style6
        {
            height: 30px;
            width: 47%;
            text-align: left;
        }
        .style9
        {
            text-align: left;
        }
        .style10
        {
            width: 542px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<%@ Page Title="Master Basic" Language="C#" AutoEventWireup="true" CodeFile="Master_Basic.aspx.cs" Inherits="Master_Basic" %>--%>

    <div>

      <table width="84%" cellpadding="0" cellspacing="0" align="center" style="border: solid 1px #3366CC;">

            <tr>

                <td colspan="4" 
                    
                    style="background-color: #f5712b; " 
                    class="style6">

                    <span class="TextTitle" style="color: #FFFFFF;">&nbsp;Basic Form 
                    Entry</span>

                </td>

            </tr>
            </table>
            <table width="84%">
            <tr>
            <td valign="top">
            <table id="TableLogin" class="HomePageControlBGLightGray" cellpadding="4" cellspacing="4"

                        runat="server" width="100%">

                        <tr>

                            <td colspan="2" align="center">

                                <asp:Label ID="LabelMessage" ForeColor="Red" 
                                    runat="server" EnableViewState="False"></asp:Label>

                            </td>

                        </tr>

                        <tr style="font-weight: normal; color: #000000">

                            <td align="right" class="style5" 
                                style="color: #666666">

                                <strong>Id</strong><span><strong>:</strong></span><strong>
                                </strong>

                            </td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                <asp:TextBox ID="TextBoxId" runat="server" 
                                    CssClass="textbox" Width="96px"

                                    MaxLength="32" Height="25px"></asp:TextBox>

                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="TextBoxId" Display="Dynamic" ErrorMessage="Enter ID" 
                                    ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="basic"></asp:RequiredFieldValidator>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <strong>Name</strong><span class="TextTitle"><strong>:</strong></span><strong>
                                </strong>

                            </td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                <asp:TextBox ID="TextBoxName" runat="server" 
                                    CssClass="textbox" Width="182px"

                                    MaxLength="32" Height="25px"></asp:TextBox>

                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="Enter Name" 
                                    ForeColor="#CC0000" SetFocusOnError="True" ValidationGroup="basic"></asp:RequiredFieldValidator>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <span class="TextTitle"><strong>Description:</strong></span><strong>
                                </strong>

                            </td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                <asp:TextBox ID="TextBoxDescription" 
                                    runat="server" CssClass="textbox" Width="232px"

                                    MaxLength="100" Height="44px" 
                                    TextMode="MultiLine"></asp:TextBox>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <span class="TextTitle"><strong>Expire Time:</strong></span><strong>
                                </strong>

                            </td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                <asp:TextBox ID="TextBoxTime" runat="server" 
                                    CssClass="textbox" Width="181px" 
                                    Height="25px"></asp:TextBox>

                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="TextBoxTime" Display="Dynamic" 
                                    ErrorMessage="Enter Expire Time" ForeColor="#CC0000" SetFocusOnError="True" 
                                    ValidationGroup="basic"></asp:RequiredFieldValidator>

                                <br />

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <strong>Expire Size:

                            </strong>

                            </td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                <asp:TextBox ID="TextBoxSize" runat="server" 
                                    CssClass="textbox" Width="180px" 
                                    Height="25px"></asp:TextBox>

                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TextBoxSize" Display="Dynamic" 
                                    ErrorMessage="Enter Expire Size" ForeColor="#CC0000" SetFocusOnError="True" 
                                    ValidationGroup="basic"></asp:RequiredFieldValidator>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <strong>Read:</strong></td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

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

                                <br />
                                <asp:Label ID="lbl_rd" runat="server" 
                                    ForeColor="Red"></asp:Label>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" colspan="2" 
                                style="text-align: center">
                                &nbsp;</td>

                        </tr>

                        <tr>

                            <td align="right" class="style5">

                                <strong>Write:</strong></td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

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

                                <br />
                                <asp:Label ID="lbl_wr" runat="server" 
                                    ForeColor="Red"></asp:Label>

                            </td>

                        </tr>

                        <tr>

                            <td align="right" class="style4" colspan="2">
                                &nbsp;</td>

                        </tr>

                        <tr>

                            <td align="right" class="style1">

                                &nbsp;</td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

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

                                &nbsp;</td>

                            <td align="left" style="padding-left: 10px;" 
                                class="style10">

                                &nbsp;</td>

                        </tr>

                        </table>
            </td>
            <td valign="top">
            <table width="100%">
            <tr>
            <td valign="top" class="style9">
            
             <strong>Details of Basic:</strong></td>
            </tr>
            <tr>
            <td valign="top">
             <asp:TreeView ID="TreeView1" runat="server" 
                                    ImageSet="Contacts" NodeIndent="10" 
                                    Width="242px" ShowLines="True" 
                                    onselectednodechanged="TreeView1_SelectedNodeChanged">
                                    <HoverNodeStyle Font-Underline="False" />
                                    <NodeStyle Font-Names="Verdana" Font-Size="8pt" 
                                        ForeColor="Black" HorizontalPadding="5px" 
                                        NodeSpacing="0px" VerticalPadding="0px" />
                                    <ParentNodeStyle BackColor="#F5F3F8" 
                                        Font-Bold="True" ForeColor="#5555DD" />
                                    <RootNodeStyle BackColor="#FF9933" />
                                    <SelectedNodeStyle BackColor="#CCCCCC" 
                                        Font-Underline="True" HorizontalPadding="0px" 
                                        VerticalPadding="0px" />
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
