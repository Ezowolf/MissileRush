<?php
$servername = "127.0.0.1";
$username = "SABuwalda";
$password = "Raket";
$dbname = "MissileRushDatabase";
$name = $_POST['name'];
$time = $_POST['time'];
$unlockCode = $_POST['unlockCode'];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} else if($unlockCode == 12421312) {
$sql = "SELECT * FROM Scores WHERE name = '$name'";
if($conn->query($sql)->num_rows > 0) {

    echo "Update Score <br>";

    $oldScore = $conn->query($sql)->fetch_assoc();


    if($oldScore["time"] > $time) {
        $time = $oldScore["time"];
    }

    $sql2 = "UPDATE Scores SET name = '$name', time = '$time' WHERE name = '$name'";

} else {

    echo "TEST Make new Score: " . $result . "<br>" . $conn->error . "<br>";

    $sql2 = "INSERT INTO `$dbname`.`Scores` (name, time) VALUES ('$name', '$time')";
}
if ($conn->query($sql2)) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}

}
$conn->close();
?>
