using Microsoft.EntityFrameworkCore.Migrations;

namespace GadgetsAndGizmos.DataAccessLayer.Migrations
{
    public partial class AddStoredProcedureForCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetCategories
                                                AS
                                                BEGIN
                                                    Select * FROM dbo.Categories
                                                END");
            
            migrationBuilder.Sql(@"CREATE PROC usp_GetCategory
                                                @Id int
                                                AS
                                                BEGIN
                                                    Select * FROM dbo.Categories WHERE (Id = @Id)
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCategory_PI
                                                @Id int
                                                @Name varchar(50)
                                                @ParentId int
                                                AS
                                                BEGIN
                                                    UPDATE dbo.Categories
                                                    SET Name = @Name, ParentId = @ParentId
                                                    Where Id = @Id
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCategory_PN
                                                @Id int
                                                @Name varchar(50)
                                                @ParentName varchar(50)
                                                AS
                                                BEGIN
                                                    UPDATE dbo.Categories
                                                    SET Name = @Name, ParentId = (SELECT Id FROM dbo.Categories WHERE Name = @ParentName)
                                                    Where Id = @Id
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCategory_PNI
                                                @Id int
                                                @Name varchar(50)
                                                @ParentName varchar(50)
                                                @ParentId
                                                AS
                                                BEGIN
                                                    UPDATE dbo.Categories
                                                    SET Name = @Name, ParentId = (SELECT Id FROM dbo.Categories WHERE Name = @ParentName, Id = @ParentId)
                                                    Where Id = @Id
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateCategory
                                                @Name varchar(50)
                                                @ParentName varchar(50)
                                                @ParentId int
                                                AS
                                                BEGIN
                                                    INSERT INTO dbo.Categories(
                                                        Name,
                                                        ParentId
                                                    ) VALUES (
                                                        @Name,
                                                        (SELECT Id from dbo.Categories WHERE Id = @ParentId, Name = @ParentName)
                                                    )
                                                    UPDATE dbo.Categories
                                                    SET Name = @Name, ParentId = (SELECT Id FROM dbo.Categories WHERE Name = @ParentName)
                                                    Where Id = @Id
                                                END");

                                                /*
                                                Below Works in SQL Server .. 
                                                INSERT INTO dbo.Categories (Name, ParentId) 
                                                Values ('Child2of2', (SELECT Id FROM dbo.Categories WHERE Name = 'Parent2'))
                                                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
