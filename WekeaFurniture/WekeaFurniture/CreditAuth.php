<?php

    if ($_SERVER['REQUEST_METHOD'] == "POST") 
    {
        $number = $_POST['cardnumber'];

        // Strip any non-digits (useful for credit card numbers with spaces and hyphens)
        $number=preg_replace('/\D/', '', $number);
        
        //MasterCard Length and Prefix Check
        //Checks length, then if prefix digits are valid
        $sub_num = substr($number, 0, 2);
        if(strlen($number) == 16 && 
                ( $sub_num == '51' || $sub_num == '52'
                  || $sub_num == '53' || $sub_num == '54')
                  || $sub_num == '55' )
        {
            $valid = luhn_check($number);
        }

        //Visa
        $sub_num = substr($number, 0, 1);

        if((strlen($number) == 13 || strlen($number) == 16) && 
                $sub_num == '4')
        {
            $valid = luhn_check($number);
        }

        //Amex
        $sub_num = substr($number, 0, 2);
        if(strlen($number) == 15 && 
                ( $sub_num == '34' || $sub_num == '37' ))
        {
            $valid = luhn_check($number);
        }

        //Discover
        $sub_num1 = substr($number, 0, 4);
        $sub_num2 = substr($number, 0, 12);
        $sub_num3 = substr($number, 6);
        $sub_num4 = substr($number, 2);
        if(strlen($number) == 16 && 
                ( $sub_num1 == '6011' || $sub_num2 == '622126622925'
                  || $sub_num == '644649' || $sub_num == '65'))
        {
            $valid = luhn_check($number);
        }

        function luhn_check($number) 
        {
            // Set the string length and parity
            $number_length=strlen($number);
            $parity=$number_length % 2;
        
            // Loop through each digit and do the maths
            $total=0;
            for ($i=0; $i<$number_length; $i++) {
            $digit=$number[$i];
            // Multiply alternate digits by two
            if ($i % 2 == $parity) {
                $digit*=2;
                // If the sum is two digits, add them together (in effect)
                if ($digit > 9) {
                $digit-=9;
                }
            }
            // Total up the digits
            $total+=$digit;
            }
        
            // If the total mod 10 equals 0, the number is valid
            return ($total % 10 == 0) ? TRUE : FALSE;   
        }

        $_SESSION["valid"] = $valid;
        header("Location: https://wekeafurniture20190329101320.azurewebsites.net/Checkout.aspx.cs");
        exit();
    }
?>