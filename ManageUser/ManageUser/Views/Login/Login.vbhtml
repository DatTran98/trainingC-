@Code
    ViewData("Title") = "Login"
End Code
<!DOCTYPE html>
<html>
<head>

</head>
<body>
    <div>
        <h2>
            @ViewBag.WelcomeString
        </h2>
        <form action="../Login/Verify" method="post">
            <table>
                <tr>
                    <td colspan="2" id="message" style="color:red;">@Session("message")</td>
                <tr>
                <tr>
                    <td>Username</td>
                    <td>
                        <input type="text" placeholder="Nhap Username" required id="username" name="UserName"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                <tr>
                <tr>
                    <td>Passord</td>
                    <td colspan="2">
                        <input type="password" placeholder="Nhap Password" required id="password" name="Password">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input colspan="2" type="submit" name="Login" value="Login" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>


