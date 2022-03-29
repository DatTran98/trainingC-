@Code
    ViewData("Title") = "Index"
End Code

<h2>Click here to choose file location</h2>
<div class="buttonContainer">
    @Html.ValidationSummary(True)
    <h2 style=" color :forestgreen"></h2>
    @Using Html.BeginForm("ImportEmp", "Import", FormMethod.Post, New With {.enctype = "multipart/form-data", .class = "input-file-import"})
        @Html.TextBox("postFile", "", New With {.type = "File", .id = "txt-import-file"})
        @<div>&emsp;</div>
        @<div>
             <input type="submit" value="Import file Emloyee" />
        </div>

    End Using
   
</div>

