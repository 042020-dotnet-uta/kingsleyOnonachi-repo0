USE [revature]
GO


INSERT INTO [dbo].[Department]
           ([ID],
		   [Name]
           ,[Location])
     VALUES
           (1,
		   'Markteing'
           ,'New York')
GO

INSERT INTO [dbo].[Department]
           ([ID],
		   [Name]
           ,[Location])
     VALUES
           (2,
		   'Engineering'
           ,'Taxas')
GO

INSERT INTO [dbo].[Department]
           ([ID]
           ,[Name]
           ,[Location])
     VALUES
           (3,
		   'Reseach'
           ,'Utah')
GO

INSERT INTO [dbo].[Department]
           ([ID],
		   [Name]
           ,[Location])
     VALUES
           (4,
		   'Markteing',
           'New York');
GO

INSERT INTO [dbo].[Department]
           ([ID],
		   [Name]
           ,[Location])
     VALUES
           (5,
		   'Markteing',
           'Affa');
GO

INSERT INTO [dbo].[Department]
           ([ID],
		   [Name]
           ,[Location])
     VALUES
           (4,
		   'Markteing',
           'New York');


Select *
from Department
Order by Name;