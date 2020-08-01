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
                                                    Select c.*, p.Name as ParentName from dbo.Categories c
                                                    LEFT OUTER JOIN dbo.Categories p ON c.ParentId = p.Id
                                                    Order by ParentId asc
                                                END");
            
            migrationBuilder.Sql(@"CREATE PROC usp_GetCategory
                                                @Id int
                                                AS
                                                BEGIN
                                                    Select c.*, p.Name as ParentName from dbo.Categories c
                                                    JOIN dbo.Categories p ON c.ParentId = p.Id 
                                                    WHERE (c.Id = @Id)
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCategoryNameFromId
                                                @Id int
                                                AS
                                                BEGIN
                                                    SELECT Name FROM dbo.Categories WHERE Id = @Id
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCategory
                                                @Id int,
                                                @Name varchar(50),
                                                @ParentId int
                                                AS
                                                BEGIN
                                                    UPDATE dbo.Categories
                                                    SET Name = @Name, ParentId = @ParentId
                                                    Where Id = @Id
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateCategory
                                                @Name varchar(50),
                                                @ParentId int
                                                AS
                                                BEGIN
                                                    INSERT INTO dbo.Categories(
                                                        Name,
                                                        ParentId
                                                    ) VALUES (
                                                        @Name,
                                                        @ParentId
                                                    )
                                                END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteCategory
                                                @Id int
                                                AS
                                                BEGIN
                                                    DELETE FROM dbo.Categories
                                                    WHERE Id = @Id
                                                END");

                                                /*
                                                Succeeded
                                                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCategories");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCategory");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCategoryNameFromId");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCategory");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCategory");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCategory");

        }
    }
}
