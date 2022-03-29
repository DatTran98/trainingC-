<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddNewUser.aspx.vb" Inherits="AspSnipet.AddNewUser" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js"></script>
<script src="../Contents/js/AddUser.js"></script>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">
<link rel="stylesheet" href="../Contents/css/AddUser.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script>
        function keepOpenSuggestPlaceModal() {
            $('#myModal').modal('show');
        }
    </script>
    <form id="form1" runat="server">
        <a href="#myModal" class="btn btn-lg btn-primary" data-toggle="modal" style="text-align: center">Add New Employee</a>
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
                                                    placeholder="Address"
                                                    />
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
                                CssClass="btn btn-secondary"
                                 />
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

    </form>
</body>
</html>
