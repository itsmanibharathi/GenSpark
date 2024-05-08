Create DataBase dbHospital;

use dbHospital;

create table Doctors(
	DoctorID int constraint PK_DoctorID primary key,
	DoctorName varchar(30),
	DoctorSpecialization varchar(30)
)

Create table Patients(
	PatientID int Constraint PK_PatientID primary key,
	PatientName varchar(30),
	PatientAge int,
	PatientGender varchar(5),
	PatientAddress varchar(50),
	PatientPhoneNumber varchar(30)
)

create table Appointments(
	AppointmentID int Constraint PK_AppintmentID primary key,
	PatientID int Constraint FK_PatientID Foreign key References Patients(PatientID),
	DoctorID int Constraint FK_DoctorID Foreign key References Doctors(DoctorID),
	_AppointmentDate date,
	AppointmentBookDateTime date
)














