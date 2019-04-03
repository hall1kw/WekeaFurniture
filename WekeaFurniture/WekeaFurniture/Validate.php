<?php
 
    echo $_SERVER['PHP_SELF'];
    echo $_POST['email'];
    echo $_POST['pw'];

	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
        if($_SERVER["PHP_SELF"] == "/SignUp.aspx")
        {
            $email = $_POST["email"];
            $pwd = $_POST["pw"];

            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
                echo "<script>alert('email is not valid')</script>";
            else
                $_POST["email"] = $email;

            $pwd = password_hash($pwd, PASSWORD_DEFAULT);
            header("Location: https://wekeafurniture20190329101320.azurewebsites.net/SignUp.aspx.cs");
            exit();
        }

        elseif ($_SERVER["PHP_SELF"] == "/Login.aspx") 
        {
            $email = $_POST["email"];
            $pwd = $_POST["pw"];

            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
                echo "<script>alert('email is not valid')</script>";
            else
                $_POST["email"] = $email;

            $pwd = password_hash($pwd, PASSWORD_DEFAULT);
            header("Location: https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx.cs");
            exit();
        }
    }
?>