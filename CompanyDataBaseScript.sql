IF DB_ID('Company') IS NULL
CREATE DATABASE Company
GO
USE Company;



if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblDailyReportByProject')
drop table tblDailyReportByProject;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblDailyReport')
drop table tblDailyReport;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblRequest')
drop table tblRequest;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployeeOnProject')
drop table tblEmployeeOnProject;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployeeEdit')
drop table tblEmployeeEdit;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployee')
drop table tblEmployee;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblProject')
drop table tblProject;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblManager')
drop table tblManager;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAdministrator')
drop table tblAdministrator;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAccount')
drop table tblAccount;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblMarrigeStatus')
drop table tblMarrigeStatus;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblClient')
drop table tblClient;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblAdministratorType')
drop table tblAdministratorType;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSector')
drop table tblSector;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblPosition')
drop table tblPosition;
if exists (SELECT name FROM sys.sysobjects WHERE name = 'vwManager')
drop view vwManager;


Create table tblMarrigeStatus (
MarrigeStatusID int identity (1,1) primary key,
MarrigeStatusName varchar(10)
)

Create table tblSector (
SectorID int identity (1,1) primary key,
SectorName varchar(10),
SectorDescription varchar(30)
)

Create table tblPosition (
PositionID int identity (1,1) primary key,
PositionName varchar(10) unique
)

Create table tblClient (
ClientID int identity (1,1) primary key,
ClientName varchar(10)
)

Create table tblAdministratorType (
AdministratorTypeID int identity (1,1) primary key,
AdministratorTypeName varchar(10)
)

create table tblAccount(
AccountID int identity(1,1) primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null,
JMBG varchar(30) check(len(JMBG) = 13)  not null unique,
Gender varchar(2) check(Gender in ('M', 'Z', 'N', 'X')) not null,
City varchar(30),
MarrigeStatusID int foreign key (MarrigeStatusID) references tblMarrigeStatus(MarrigeStatusID) not null,
UserName varchar(30) check(len(UserName) > 5) not null unique,
Pass varchar(30) check(len(Pass) > 5) not null,
constraint checkJMBG check(JMBG not like '%[^0-9]%')
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

create table tblEmployee(
EmployeeID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
ManagerID int foreign key (ManagerID) references tblManager(ManagerID) not null,
SectorID int foreign key (SectorID) references tblSector(SectorID) not null,
PositionID int foreign key (PositionID) references tblPosition(PositionID),
EmploymentDate date not null,
Salary int,
QualificationsLevel varchar(3) check(QualificationsLevel in ('I', 'II', 'III', 'IV', 'V', 'VI', 'VII')) not null
)

create table tblEmployeeEdit(
EmployeeID int primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID),
ManagerID int foreign key (ManagerID) references tblManager(ManagerID),
SectorID int foreign key (SectorID) references tblSector(SectorID),
PositionID int foreign key (PositionID) references tblPosition(PositionID),
EmploymentDate date,
Salary int,
QualificationsLevel varchar(3) check(QualificationsLevel in ('I', 'II', 'III', 'IV', 'V', 'VI', 'VII'))
)

Create table tblAdministrator (
AdministratorID int identity (1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID),
DateOfExpiry date,
AdministratorTypeID int foreign key (AdministratorTypeID) references tblAdministratorType(AdministratorTypeID)
)

create table tblRequest(
RequestID int identity(1,1) primary key,
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
Approved bit,
RequestDate datetime not null,
)

create table tblProject(
ProjectID int identity(1,1) primary key,
ProjectName varchar(30) not null,
ProjectDescription varchar(30),
ClientID int foreign key (ClientID) references tblClient(ClientID) not null,
SigningDate date not null,
ManagerSignedID int foreign key (ManagerSignedID) references tblManager(ManagerID) not null,
StartDate date not null,
EstimatedEndDate date not null,
HourlyWage int,
Realization int check(Realization in (0, 1, 2)),
ManagerRunningID int foreign key (ManagerRunningID) references tblManager(ManagerID) not null,
ClientProjectName varchar(30) not null unique
)

create table tblEmployeeOnProject(
AccountID int foreign key (AccountID) references tblAccount(AccountID) not null,
ProjectID int foreign key (ProjectID) references tblProject(ProjectID) not null
)

create table tblDailyReport(
DailyReportID int identity(1,1) primary key,
EmployeeID int foreign key (EmployeeID) references tblEmployee(EmployeeID) not null,
ReportDate date,
HoursWorking int check(HoursWorking < 17)
)

create table tblDailyReportByProject(
DailyReportID int foreign key (DailyReportID) references tblDailyReport(DailyReportID) not null,
ProjectID int foreign key (ProjectID) references tblProject(ProjectID) not null,
ReportDate date,
ReportDescription varchar(30),
HoursWorking int
)


insert into tblMarrigeStatus (MarrigeStatusName)
values ('married');

insert into tblMarrigeStatus (MarrigeStatusName)
values ('notMarried');

insert into tblMarrigeStatus (MarrigeStatusName)
values ('divorced');

insert into tblAdministratorType(AdministratorTypeName)
values ('team');

insert into tblAdministratorType(AdministratorTypeName)
values ('system');

insert into tblAdministratorType(AdministratorTypeName)
values ('local');

insert into tblSector(SectorName)
values ('default');

insert into tblPosition(PositionName)
values ('default');

USE [Company]
GO

/****** Object:  View [dbo].[vwManager]    Script Date: 8/9/2020 1:37:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwManager]
AS
SELECT        dbo.tblManager.ManagerID, dbo.tblAccount.AccountID, dbo.tblAccount.FirstName, dbo.tblAccount.LastName, dbo.tblAccount.JMBG, dbo.tblAccount.Gender, dbo.tblAccount.City, dbo.tblAccount.UserName, dbo.tblManager.Email, 
                         dbo.tblManager.ResponsibilityLevel, dbo.tblManager.NumberOfRealizations, dbo.tblManager.Salaty, dbo.tblManager.OfficeNumber
FROM            dbo.tblAccount INNER JOIN
                         dbo.tblManager ON dbo.tblAccount.AccountID = dbo.tblManager.AccountID
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblAccount"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "tblManager"
            Begin Extent = 
               Top = 6
               Left = 249
               Bottom = 136
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwManager'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwManager'
GO


