<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'unitycubeprojectsql'); //locachost connection
    
    if(mysqli_connect_errno()) { //connection check
        echo "1: Connection error";
        exit();
    }

    $query = "SELECT xPos, yPos, zPos FROM cubeinfo"; // creating the position data receiver query

    $result =  mysqli_query($con , $query) or die("2: Query Error"); // executing the query to get data from MySQL server
    
    if(mysqli_num_rows($result) > 0 ) //checking if the info is existent
        while($row = mysqli_fetch_assoc($result)) { //fetching data from the row in order to send them seperatly
            echo $row["xPos"] . "\t" . $row["yPos"] . "\t" . $row["zPos"]; //sending data by echoing it(this could be seen from the UnityWebRequest.Get())
        }

    
?>