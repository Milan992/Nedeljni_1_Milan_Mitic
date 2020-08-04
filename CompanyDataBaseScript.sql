IF DB_ID('Company') IS NULL
CREATE DATABASE Company
GO
USE Company;


if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAccount')
drop table tblAccount;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployee')
drop table tblEmployee;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManager')
drop table tblManager;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblGender')
drop table tblGender;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblMarrigeStatus')
drop table tblMarrigeStatus;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSector')
drop table tblSector;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblPosition')
drop table tblPosition;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAdministrator')
drop table tblAdministrator;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAdministratorType')
drop table tblAdministratorType;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblRequest')
drop table tblRequest;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployeeEdit')
drop table tblEmployeeEdit;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblProject')
drop table tblProject;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblClient')
drop table tblClient;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblDailyReport')
drop table tblDailyReport;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblDailyReportByProject')
drop table tblDailyReportByProject;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployeeOnProject')
drop table tblEmployeeOnProject;

create table tblAccount(
AccountID int identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
JMBG varchar(30) check(len(JMBG) = 13)  not null unique,
GenderID int foreign key (GenderID) references tblGender(GenderID) not null,
City varchar(30),
MarrigeStatusID int foreign key (MarrigeStatusID) references tblMarrigeStatus(MarrigeStatusID) not null,
UserName varchar(30) check(len(UserName) > 5) not null unique,
Pass varchar(30) check(len(Pass) > 5) not null,
constraint checkJMBG check(JMBG not like '%[^0-9]%')
)

create table tblEmployee(
EmployeeID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
ManagerID int foreign key (ManagerID) references tblManager(ManagerID) not null,
SectorID int foreign key (SectorID) references tblSector(SectorID) not null,
PositionID int foreign key (PositionID) references tblPosition(PositionID) not null,
EmploymentDate date not null,
Salary int,
QualificationsLevel varchar(3) check(QualificationsLevel in ('I', 'II', 'III', 'IV', 'V', 'VI', 'VII')) not null
)

create table tblEmployeeEdit(
EmployeeID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID),
ManagerID int foreign key (ManagerID) references tblManager(ManagerID),
SectorID int foreign key (SectorID) references tblSector(SectorID),
PositionID int foreign key (PositionID) references tblPosition(PositionID),
EmploymentDate date,
Salary int,
QualificationsLevel varchar(3) check(QualificationsLevel in ('I', 'II', 'III', 'IV', 'V', 'VI', 'VII'))
)

create table tblManager(
ManagerID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
Email varchar(30),
SparePass varchar(30) check(len(SparePass) > 5) not null,
ResponsibilityLevel int check(ResponsibilityLevel < 4),
NumberOfRealizations int,
Salaty int,
OfficeNumber int
)