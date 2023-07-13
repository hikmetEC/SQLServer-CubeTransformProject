<?php
    
    $con = mysqli_connect('localhost', 'root', 'root', 'unitycubeprojectsql'); //localhost connection
    
    if(mysqli_connect_errno()) {
        echo "1: Connection error";
        exit();
    } 

    //variable declaration
    $objectType = $_POST["objectType"];
    $xPos = $_POST["xPos"];
    $yPos = $_POST["yPos"];
    $zPos = $_POST["zPos"];
    //variable declaration

    //object type checked for different objects positions
    $objectcheckQuery = "SELECT objectType FROM cubeinfo WHERE objectType = '". $objectType ."';";
    $objectcheck = mysqli_query($con, $objectcheckQuery)or die("2: Object check failed!");
    //object type checked for different objects positions

    if(mysqli_num_rows($objectcheck) >= 1) { //if object exists and there is info in it
        //Set the already exisiting positions
        $updateQuery = "UPDATE cubeinfo SET xPos = ". $xPos ." WHERE objectType = '". $objectType ."';";
        mysqli_query($con, $updateQuery) or die("3: Setting Failed!");
        $updateQuery = "UPDATE cubeinfo SET yPos = ". $yPos ." WHERE objectType = '". $objectType ."';";
        mysqli_query($con, $updateQuery) or die("3: Setting Failed!");
        $updateQuery = "UPDATE cubeinfo SET zPos = ". $zPos ." WHERE objectType = '". $objectType ."';";
        mysqli_query($con, $updateQuery) or die("3: Setting Failed!");
        //Set the already exisiting positions
    }else {
        //Create the non-exisisten object and set it's position
        $insertQuery = "INSERT INTO cubeinfo (objectType,xPos, yPos, zPos) VALUES ('". $objectType ."','". $xPos ."' , '". $yPos ."' , '". $zPos ."');";
        mysqli_query($con, $insertQuery) or die("4: Insert Failed!");
        //Create the non-exisisten object and set it's position
    }

    echo "0"; //send succes numbercode
?>