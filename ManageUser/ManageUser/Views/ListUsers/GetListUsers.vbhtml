@ModelType List(Of ManageUser.EmployeeModel)
@Code
    ViewData("Title") = "GetListUsers"
End Code
<script>
function myFunction() {
  confirm("Are you sure delete this user!");
}
</script>
<div>
    <h2>Welcome to manager user</h2>
</div>
<div style="align-content:center;float:left;margin-top:50px;">
    <div><form method="post" action="GetListUsers">
    <input type="text" name="SearchValue" placeholder="Search by email" />
    <input type="submit" value="Search" />
</form></div>
    
</div>
<div style="clear: left; float:right ">
    <p style="clear:right">
        @Html.ActionLink("Import", "../Import/Index")
    </p>
    <p style="clear:right">
        @Html.ActionLink("Export", "../ExportEmployee/ExportEmp")
    </p>
    <p>
        @Html.ActionLink("Create New", "../AddEmployee/CreateEmployee")
    </p>
</div>
<div style="align-content: center; clear: left"><p style=" color :red ">@Session("message") </p></div>
<table class="table">
    <tr>
        <th colspan="6"> List user manager</th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>@item.Fullname</td>
            <td>@item.Email</td>
            <td>@item.Phone</td>
            <td>@item.JobTitle</td>
            <td>@item.Address</td>
            <td>
                @Html.ActionLink("Edit", "../EditEmployee/GetUserEdit", New With {.Value = item.Email}) |
                @Html.ActionLink("Delete", "../DeleteEmployee/DeleteEmployee", New With {.Value = item.Email, .Onclick = "myFunction()"})|
            </td>
        </tr>
    Next

</table>
