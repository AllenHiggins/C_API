# CSharpAPIV1
API for user events version one - Test


# DataBase
	CREATE TABLE [dbo].[Events]
	(
		[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
		[StartDate] DATE NULL, 
		[EndDate] DATE NULL, 
		[StartTime] TIMESTAMP NULL, 
		[EndTime] TIMESTAMP NULL, 
		[Category] VARCHAR(50) NULL, 
		[Note] TEXT NULL
	)

# DataBase Troubleshooting 

Right click on App_Data add -> New Item -> SQl Server DataBase and name it EventDBv1
Open Server Exsplore -> right click on Table and copy the database schema above.
Click the upload arrow to save changes to the Table

### Troubleshooting Model

Right click Model -> add -> new item -> data -> ADO.Net entity Model and name it Event and the select Add button.
Choose EF disnger from database -> edit WebCofig to EventDB at end of dialoge box the click next.
Select tables and click next. 


# Run API 

Press the play icon in Visual Studio or f5. When the web browser opens close it as the xml is to hevey to run smootly.
Leave the build running.
Use PostMan or any other web API tool to issue request to the endpoints noted below. 


# EndPoints

### GET
api/v1/Events -> returns a list of all events (Response Code: 200)

api/v1/Events?Category=swimming -> returns a list of all events of a choosen Category (Response Code: 200)

api/v1/Events?Category=walking -> returns a list of all events of a choosen Category (Response Code: 200)

api/v1/Events?Category=cycling -> returns a list of all events of a choosen Category (Response Code: 200)

api/v1/Events?Category=running -> returns a list of all events of a choosen Category (Response Code: 200)

api/v1/Events?Category=weight training -> returns a list of all events of a choosen Category (Response Code: 200)

api/v1/Events/Id -> returns an event choosen by ID (Response Code: 200)


### POST 
api/v1/Events -> Creates a new event (Response Code: 201)

### PUT
api/v1/Events/Id -> updates the existing event (Response Code: 200)


### DELETE
api/v1/Events/Id -> deletes the identified event (Response Code: 200)