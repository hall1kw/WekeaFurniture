<?php
	if ($_SERVER["REQUEST_METHOD"] == "POST")
	{
        $email = $_POST["email"];
        $pwd = $_POST["pw"];

		if (!filter_var($email, FILTER_VALIDATE_EMAIL)) 
			echo "<h1>Invalid email format</h1>"
        else
            $_POST["email"] = $email;

        //password_hash($pwd, SHA_256);
        $pwd = password_hash($pwd, PASSWORD_DEFAULT);
        $_POST["pw"] = $pwd;
    }
?>