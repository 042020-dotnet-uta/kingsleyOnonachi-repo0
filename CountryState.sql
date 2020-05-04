USE [demo]
GO

/****** Object:  Table [dbo].[State]    Script Date: 4/29/2020 15:57:25 ******/
SET ANSI_NULLS ON
GO
Drop table State;
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[State](
	[stateId] [int] IDENTITY(1,1)NOT NULL,
	[countryId] [int],
	[stateName] [nvarchar](15) NULL
	Primary Key(stateId),
	Foreign Key (countryId) REFERENCES Country(countryId)
);
GO

Insert into Country(country)
values('Nigeria');

Insert into Country(country)
values('USA');

Insert into Country(country)
values('Brazil');

Insert into Country(country)
values('Germany');

Insert into Country(country)
values('Ghana');

-- state
Insert into State(countryId, stateName)
values(1, 'Enugu');

Insert into State(countryId, stateName)
values(2, 'New York');

Insert into State(countryId, stateName)
values(3, 'Sao Paulo');

Insert into State(countryId, stateName)
values(4, 'Hamm');

Insert into State(stateName)
values('Weingarten');


select *
from State s
outer Country c
on s.countryId = c.countryId;