<%@ Page Language="C#" AutoEventWireup="true" CodeFile="N_Question.aspx.cs" Inherits="N_Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Exam Started:: FOCUS</title>
 

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="assets/css/usercustom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="m-4" style="color:#0094ff;font-size:20px;font-weight:900" align="center">Answer all the questions</div>
    <hr />
    <asp:TextBox ID="getstringuser" runat="server" Visible="false"></asp:TextBox>
    <asp:GridView ID="gridview_examquestion" runat="server" AutoGenerateColumns="False" GridLines="None">
        <Columns>
                 <%--<asp:TemplateField ItemStyle-HorizontalAlign="center"  >
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>--%>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="red" Font-Size="15" Text='  <%#Container.DataItemIndex+1%>' Visible="true"></asp:Label>
                  
                    <asp:Label ID="lblid" runat="server"  Text='<%# Eval("question_id") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbl_question" runat="server" Font-Bold="true" ForeColor="red" Font-Size="15" Text='<%# Eval("question_name") %>'></asp:Label>
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("option_one") %>' ID="option_one" runat="server" />
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("option_two") %>' ID="option_two" runat="server" />
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("option_three") %>' ID="option_three" runat="server" />
                    <br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("option_four") %>' ID="option_four" runat="server" />
                    <hr />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btn_submit_Click" />
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel_questshow_warning" runat="server" Visible="false">
                    <br />
                    <div class="alert alert-danger text-center">
                        <asp:Label ID="lbl_questshowwarning" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
