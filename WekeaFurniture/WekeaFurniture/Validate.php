<?php

    echo session_start();
    echo '<br>';
    echo $_POST['ctl00$ContentPlaceHolder1$email'];
    echo '<br>';
    echo $_POST['ctl00$ContentPlaceHolder1$pw'];

	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
        if($_SERVER["HTTP_REFERER"] == "https://wekeafurniture20190329101320.azurewebsites.net/SignUp.aspx")
        {
            $email = $_POST['ctl00$ContentPlaceHolder1$email'];
            $pwd = $_POST['ctl00$ContentPlaceHolder1$pw'];

            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
                echo "<script>alert('email is not valid')</script>";
            else
                $_POST['ctl00$ContentPlaceHolder1$email'] = $email;

            $pwd = password_hash($pwd, PASSWORD_DEFAULT);
            $_POST['ctl00$ContentPlaceHolder1$pw'] = $pwd;
            header("Location: https://wekeafurniture20190329101320.azurewebsites.net/SignUp.aspx.cs");
            exit();
        }

        elseif ($_SERVER["HTTP_REFERER"] == "https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx") 
        {
            $email = $_POST['ctl00$ContentPlaceHolder1$email'];
            $pwd = $_POST['ctl00$ContentPlaceHolder1$pw'];

            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
                echo "<script>alert('email is not valid')</script>";
            else
                $_POST['ctl00$ContentPlaceHolder1$email'] = $email;

            $pwd = password_hash($pwd, PASSWORD_DEFAULT);
            $_POST['ctl00$ContentPlaceHolder1$pw'] = $pwd;
            header("Location: https://wekeafurniture20190329101320.azurewebsites.net/Login.aspx.cs");
            exit();
        }
    }
?>