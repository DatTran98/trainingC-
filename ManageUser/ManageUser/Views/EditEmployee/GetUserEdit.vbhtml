@ModelType ManageUser.EmployeeModel
@Code
    ViewData("Title") = "GetUserEdit"
End Code

<h2>Edit Employee</h2>
<fieldset>
    <div style=" color:orangered">@ViewData("message") </div>
    @Using (Html.BeginForm("EditEmployee", "EditEmployee", FormMethod.Post, New With {.Enctype = "multipart/form-data"}))
        @Html.AntiForgeryToken()
        @<div class="form-horizontal">
            <hr />
            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <div class="formRowContainer">
                        <div class="labelContainer">Fullname</div>
                        <div class="valueContainer">
                            @Html.TextBoxFor(Function(Model) Model.Fullname, New With {.Name = "Fullname"})
                        </div>
                    </div>
                    <div class="clearStyle"></div>
                    <div class="formRowContainer">
                        <div class="labelContainer">Email</div>
                        <div class="valueContainer">@Html.TextBoxFor(Function(Model) Model.Email, New With {.Name = "Email"})</div>
                    </div>
                    <div class="clearStyle"></div>
                    <div class="formRowContainer">
                        <div class="labelContainer">Phone</div>
                        <div class="valueContainer">@Html.TextBoxFor(Function(Model) Model.Phone, New With {.Name = "Phone", .Maxlength = 10})</div>
                    </div>
                    <div class="clearStyle"></div>
                    <div class="formRowContainer">
                        <div class="labelContainer">JobTitle</div>
                        <div class="valueContainer">
                            @Html.DropDownList("JobTitle", TryCast(ViewData("List"), SelectList), Model.JobTitle)

                        </div>
                    </div>
                    <div class="clearStyle"></div>
                    <div class="formRowContainer">
                        <div class="labelContainer">Address</div>
                        <div class="valueContainer">
                            @Html.TextBoxFor(Function(Model) Model.Address, New With {.Name = "Address"})
                        </div>
                    </div>

                    <div class="clearStyle"></div>
                    <div class="buttonContainer">
                        <button>Save</button>
                    </div>
                    <div>&nbsp;</div>
                    @*<input type="submit" value="Save" class="btn btn-default" />*@
                </div>
            </div>
        </div>
    End Using
</fieldset>
<div>
    @Html.ActionLink("Back to List", "../ListUsers/GetListUsers")
</div>
