<?php

    echo session_start();
    echo '<br>';
    echo $_SERVER['HTTP_REFERER'];
    echo '<br>';
    echo $_SERVER['REQUEST_URI'];
    echo '<br>';
    echo $_POST['ctl00$ContentPlaceHolder1$email'];
    echo '<br>';
    echo $_POST['ctl00$ContentPlaceHolder1$pw'];

	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
        if($_SERVER["HTTP_REFERER"] == "https://wekeafurniture20190329101320.azurewebsites.net/SignUp.aspx")
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

        elseif ($_SERVER["HTTP_REFERER"] == "https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx") 
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