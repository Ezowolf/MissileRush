
<?php
$servername = "127.0.0.1";
$username = "SABuwalda";
$password = "Raket";
$dbname = "MissileRushDatabase";
$scoreType = $_POST['scoreType'];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
//Read table in sql and order
$sql="SELECT * FROM Scores ORDER BY $scoreType DESC";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo $row["name"]. "_" .$row[$scoreType]. "\n";
    }
} else {
    echo "0 results";
}
$conn->close();
?>
