<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListUsers.aspx.vb" Inherits="UserManager.ListUsers" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function keepOpenSuggestPlaceModal() {
            $('#myModal').modal('show');
        }
    </script>
</head>
<body>
    <style>
        .display-none {
            display: none;
        }

        .form-control-borderless {
            border: none;
        }

            .form-control-borderless:hover, .form-control-borderless:active, .form-control-borderless:focus {
                border: none;
                outline: none;
                box-shadow: none;
            }

        .colorgraph {
            height: 5px;
            border-top: 0;
            background: #c4e17f;
            border-radius: 5px;
            background-image: -webkit-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -moz-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: -o-linear-gradient(left, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
            background-image: linear-gradient(to right, #c4e17f, #c4e17f 12.5%, #f7fdca 12.5%, #f7fdca 25%, #fecf71 25%, #fecf71 37.5%, #f0776c 37.5%, #f0776c 50%, #db9dbe 50%, #db9dbe 62.5%, #c49cde 62.5%, #c49cde 75%, #669ae1 75%, #669ae1 87.5%, #62c2e4 87.5%, #62c2e4);
        }

        .deleteButton img {
            margin-right: 3px;
            vertical-align: bottom;
        }
    </style>
    <form id="form1" runat="server">
        <div class="bs-example">

            <div id="myModal" class="modal fade" tabindex="-1">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Confirmation</h5>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="container">

                                <div class="row">
                                    <div class="col-xl-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                                        <h2>Add new Employee Here <small>Let's begin</small></h2>
                                        <hr class="colorgraph" />
                                        <asp:Label runat="server" ID="MessageAdd" ForeColor="Red"></asp:Label>
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server"
                                                        ID="NewFullname"
                                                        TabIndex="3"
                                                        TextMode="SingleLine"
                                                        CssClass="form-control input-lg"
                                                        placeholder="Fullname"
                                                        onpaste="return false;"></asp:TextBox><span class="error" style="display: none">Fullname is required.</span>
                                                </div>
                                            </div>
                                            <div class="col-xs-12 col-sm-6 col-md-6">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server"
                                                        AutoPostBack="True"
                                                        ID="NewEmail" TabIndex="4"
                                                        CssClass="form-control input-lg"
                                                        placeholder="Email"
                                                        TextMode="SingleLine"
                                                        OnTextChanged="Email_TextChange"></asp:TextBox><span class="error" style="display: none">Email is required.</span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:DropDownList
                                                AutoPostBack="False"
                                                OnSelectedIndexChanged="Selection_Change"
                                                runat="server"
                                                TabIndex="5"
                                                CssClass="form-control input-lg"
                                                ID="NewJob">
                                                <asp:ListItem Selected="True" Value=""> --Choose Job--- </asp:ListItem>
                                                <asp:ListItem Value="DEVELOPER"> DEVELOPER </asp:ListItem>
                                                <asp:ListItem Value="DESIGN"> DESIGN </asp:ListItem>
                                                <asp:ListItem Value="TESTER"> TESTER </asp:ListItem>
                                            </asp:DropDownList>
                                            <span class="error" id="errorDropDown" style="display: none">Job Tiltle is required.</span>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="NewPhone"
                                                TabIndex="6" MaxLength="10"
                                                TextMode="Phone"
                                                AutoPostBack="True"
                                                CssClass="form-control input-lg"
                                                placeholder="Phone"
                                                OnTextChanged="Phone_TextChange"
                                                onkeyup="keyUP(event.keyCode)"
                                                onkeydown="return isNumeric(event.keyCode);"
                                                onpaste="return false;"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-group">
                                                <asp:TextBox runat="server"
                                                    ID="NewAddress" TabIndex="7"
                                                    CssClass="form-control input-lg"
                                                    placeholder="Address" />
                                            </div>
                                        </div>
                                        <hr class="colorgraph" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:Button runat="server"
                                Text="Cancel" TabIndex="8"
                                ID="BtnCancel"
                                OnClick="CancelButton_Onclick"
                                CssClass="btn btn-secondary" />
                            <asp:Button runat="server"
                                Text="Save" TabIndex="9"
                                ID="BtnAdd"
                                OnClick="AddButton_Onclick"
                                CssClass="btn btn-primary"
                                OnClientClick="return Validate()" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <h1 style="text-align: center;">List Employees</h1>
            <div class="col-auto" style="float: right;">
                <asp:Button runat="server" ID="BtnLogout" Text="Logout" OnClick="LogButton_Onclick" CssClass="btn btn-warning"></asp:Button>
            </div>
            <br />
            <div class="container">
                <br />
                <div class="row justify-content-center">
                    <div class="col-12 col-md-10 col-lg-8">
                        <%--<form class="card card-sm">--%>
                        <div class="card-body row no-gutters align-items-center">
                            <div class="col-auto">
                                <i class="fas fa-search h4 text-body"></i>
                            </div>
                            <!--end of col-->
                            <div class="col">
                                <asp:TextBox runat="server" TabIndex="1" ID="SearchValue" CssClass="form-control form-control-lg form-control-borderless" AutoCompleteType="Search" placeholder="Search By Email"></asp:TextBox>
                            </div>
                            <!--end of col-->
                            <div class="col-auto">
                                <asp:Button runat="server" TabIndex="2" ID="BtnSearch" Text="Search" OnClick="SearchButton_Onclick" CssClass="btn btn-lg btn-success"></asp:Button>
                            </div>
                            <!--end of col-->
                        </div>
                        <%--</form>--%>
                    </div>
                    <!--end of col-->
                </div>
            </div>
            <div style="margin-bottom: 20px; height: 100%; width: 120%;">
                <div class="container">
                    <asp:Label runat="server" ID="Message" ForeColor="Red"></asp:Label>

                    <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                        <%--<h2>Add new Employee Here <small>Let's begin</small></h2>
                            <hr class="colorgraph">--%>
                        <%--   <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="NewFullname" TabIndex="3" TextMode="SingleLine" CssClass="form-control input-lg" placeholder="Fullname"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="NewEmail" TabIndex="4" CssClass="form-control input-lg" placeholder="Email" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList
                                    AutoPostBack="True"
                                    OnSelectedIndexChanged="Selection_Change"
                                    runat="server"
                                    TabIndex="5"
                                    CssClass="form-control input-lg"
                                    ID="NewJob">
                                    <asp:ListItem Selected="True" Value=""> --Choose Job--- </asp:ListItem>
                                    <asp:ListItem Value="DEVELOPER"> DEVELOPER </asp:ListItem>
                                    <asp:ListItem Value="DESIGN"> DESIGN </asp:ListItem>
                                    <asp:ListItem Value="TESTER"> TESTER </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="NewPhone" TabIndex="6" MaxLength="10" TextMode="Number" CssClass="form-control input-lg" placeholde="Phone"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox runat="server" ID="NewAddress" TabIndex="7" CssClass="form-control input-lg" placeholder="Address" />
                            </div>--%>

                        <%--<hr class="colorgraph">--%>
                        <div class="row">
                            <div class="col-xs-12 col-md-6">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Click choose file Import Emoloyees" />
                                    <asp:FileUpload runat="server" TabIndex="9" ID="ImportFile" CssClass="form-control btn-primary" />
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" TabIndex="10" Text="Import" ID="BtnImport" OnClick="ImportButton_Onclick" CssClass="btn btn-success btn-block btn-lg" />
                                </div>
                            </div>
                            <div class="col-xs-12 col-md-6">
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Click here to add new employee " />
                                    <a href="#myModal" class="btn btn-primary btn-block btn-lg" data-toggle="modal" style="text-align: center">Add New</a>
                                    <%--<asp:Button runat="server" Text="Add New" TabIndex="8" ID="BtnAdd" OnClick="AddButton_Onclick" CssClass="btn btn-primary btn-block btn-lg" />--%>
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" Text="Export Emoloyees" TabIndex="11" ID="BtnExport" OnClick="ExportButton_Click" CssClass="btn btn-success btn-block btn-lg" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: left; width: 90%; margin-left: 5%; padding-bottom: 15%;" class="panel-body text-center">
            <asp:GridView ID="GridViewEmployees" runat="server" Width="100%" DataKeyNames="EMAIL" AutoGenerateColumns="False" OnRowEditing="GridViewEmployees_RowEditing"
                OnRowCancelingEdit="GridViewEmployees_RowCancelingEdit" OnRowUpdating="GridViewEmployees_RowUpdating" AllowPaging="True" OnPageIndexChanging="Grid_PageIndexChanged">
                <Columns>
                    <asp:CommandField ShowEditButton="true" HeaderText="Action" />
                    <%--<asp:BoundField DataField="FULL_NAME" HeaderText="Fullname" />--%>
                    <asp:TemplateField HeaderText="Fullname">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "FULL_NAME") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" TextMode="SingleLine" MaxLength="10" ID="NameEdit" Text='<%# DataBinder.Eval(Container.DataItem, "FULL_NAME") %>' onfocus="let value = this.value;
    this.value = null;
    this.value = value;"
                                autofocus="true"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Job Title">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="JobTitle" ClientIDMode="Static" Text='<%# DataBinder.Eval(Container.DataItem, "JOB_TITLE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList
                                runat="server"
                                TabIndex="5"
                                CssClass="form-control input-lg"
                                ID="EditJobTitle"
                                ToolTip='<%# DataBinder.Eval(Container.DataItem, "JOB_TITLE") %>'
                                ClientIDMode="Static">
                                <asp:ListItem Value=""> --Choose New Job--- </asp:ListItem>
                                <asp:ListItem Value="DEVELOPER"> DEVELOPER </asp:ListItem>
                                <asp:ListItem Value="DESIGN"> DESIGN </asp:ListItem>
                                <asp:ListItem Value="TESTER"> TESTER </asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "PHONE") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" TextMode="Phone" MaxLength="10" ID="PhoneEdit" Text='<%# DataBinder.Eval(Container.DataItem, "PHONE") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="PHONE" HeaderText="Phone" />--%>
                    <asp:BoundField DataField="ADDRESS" HeaderText="Address" />
                    <asp:BoundField DataField="PHONE" HeaderText="Phone" HeaderStyle-CssClass="display-none" ItemStyle-CssClass="display-none">
                        <HeaderStyle CssClass="display-none"></HeaderStyle>

                        <ItemStyle CssClass="display-none"></ItemStyle>
                    </asp:BoundField>
                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="deleteButton" ButtonType="Image" DeleteImageUrl="http://www.prepbootstrap.com/Content/images/template/BootstrapEditableGrid/delete.png" HeaderText="Delete">
                        <ControlStyle CssClass="deleteButton"></ControlStyle>
                    </asp:CommandField>
                </Columns>
                <PagerSettings PageButtonCount="5" />
            </asp:GridView>
            <br />
        </div>

    </form>
</body>
</html>
