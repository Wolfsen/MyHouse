CREATE TABLE [dbo].[Table]
(
	[Id_Realty] INT NOT NULL PRIMARY KEY, 
    [Id_PropertyType] INT NOT NULL, 
    [Id_Object] INT NOT NULL, 
    [Id_houseType] INT NOT NULL, 
    [numberOfRooms] INT NOT NULL, 
    [totalArea] DECIMAL(10, 2) NOT NULL, 
    [floor] INT NOT NULL, 
    [floors] INT NULL, 
    [price] DECIMAL(10, 2) NOT NULL, 
    [descript] NVARCHAR(1000) NOT NULL, 
    [city] NVARCHAR(100) NOT NULL, 
    [street] NVARCHAR(100) NOT NULL, 
    [numberHouse] NVARCHAR(10) NOT NULL, 
    [apartment] NVARCHAR(10) NULL, 
    [client] INT NOT NULL, 
    [status] NVARCHAR(25) NULL
)
