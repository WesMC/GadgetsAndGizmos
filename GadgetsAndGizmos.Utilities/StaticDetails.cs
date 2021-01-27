using System;
using System.Collections.Generic;
using System.Text;

namespace GadgetsAndGizmos.Utilities
{
    public static class StaticDetails
    {
        public const string Proc_Category_GetAll = "usp_GetCategories";
        public const string Proc_Category_Get = "usp_GetCategory";
        public const string Proc_Category_GetNameFromId = "usp_GetCategoryNameFromId";
        public const string Proc_Category_Update = "usp_UpdateCategory";
        public const string Proc_Category_Create = "usp_CreateCategory";
        public const string Proc_Category_Delete = "usp_DeleteCategory";

        public const string Role_User_Ind = "Individual Customer";
        public const string Role_User_Comp = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
    }
}
