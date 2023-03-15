<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="webTermProject.homePage" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="homePage.css">
    <title>Hospital Information System</title>
</head>

<body>

    <img class="logo" src="Images/newlogo.png" />


    <h1 class="Headtext">Hospital Information System</h1>

  <div class="row">
      <div class="column">
        <h1 class="Patient">Patient Record</h1>
        <img class="PatientPhoto" src="Images/patient.png" />
          <br>
        <a href="patientRecord.aspx" class="PatientOperations">Patient Operations</a>
        </div>

    <div class="column">
        <h1 class="Doctor">Doctor Record</h1>
        <img class="doctorsphoto" src="Images/doctors.png" />
        <br>
        <a href="doctorRegist.aspx" class="DoctorOperations">Doctor Operations</a>

    </div>

    <div class="column">
        <h1 class="Department">Department</h1>
        <img class="departmentphoto" src="Images/department.png" />
        <br>
        <a href="deparmentInsert.aspx" class="DepartmentOperations">Department Operations</a>

    </div>

    <div class="column">
       <h1 class="Lab">LAB</h1>
       <img class="labphoto" src="Images/lab.png" />
       <br>
       <a href="labResult.aspx" class="LabOperations">Lab Operations</a>

    </div>

 </div>



</body>
</html>