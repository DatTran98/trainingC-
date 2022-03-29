@ModelType ManageUser.EmployeeModel
@Code
    ViewData("Title") = "CreateEmployee"
End Code

<h2>CreateEmployee</h2>
<h2 style=" color :greenyellow">@ViewData("message") </h2>
<fieldset>

    @Using (Html.BeginForm("AddEmployee", "AddEmployee", FormMethod.Post))
        @Html.AntiForgeryToken()
        @<div class="form-horizontal">
            <hr />
            @Html.ValidationSummary(True, "", New With {.Class = "text-danger"})
            <div Class="form-group">
                <div Class="col-md-offset-2 col-md-10">
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
                            @*<select id="jobTitle" name="JobTitle">

            <option value="" --->Choose Job Title---</option>

            <option value="DESIGNER">DESIGNER</option>

            <option value="DEVELOPER">DEVELOPER</option>

            <option value="TESTER">
                TESTER
            </option>
        </select>*@
                            @Html.DropDownList("JobTitle", TryCast(ViewData("List"), SelectList), Model.JobTitle)
                        </div>
                    </div>
                    <div class="clearStyle"></div>
                    <div class="formRowContainer">
                        <div class="labelContainer">Address</div>
                        <div class="valueContainer">
                            @Html.TextBoxFor(Function(Model) Model.Address, New With {.Name = "Address"})
                            @Html.ValidationMessage("Require")
                        </div>
                    </div>

                    <div class="clearStyle"></div>
                    <div>&nbsp;</div>
                    <div class="buttonContainer">
                        <button>Add Emloyee</button>
                    </div>
                </div>
            </div>
        </div>

    End Using
</fieldset>
<div>
    @Html.ActionLink("Back to List", "../ListUsers/GetListUsers")
</div>
