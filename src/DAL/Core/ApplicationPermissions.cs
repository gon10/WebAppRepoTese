// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DAL.Core
{
    public static class ApplicationPermissions
    {
        public static ReadOnlyCollection<ApplicationPermission> AllPermissions;


        public const string UsersPermissionGroupName = "User Permissions";
        public static ApplicationPermission ViewUsers = new ApplicationPermission("View Users", "users.view", UsersPermissionGroupName, "Permission to view other users account details");
        public static ApplicationPermission ManageUsers = new ApplicationPermission("Manage Users", "users.manage", UsersPermissionGroupName, "Permission to create, delete and modify other users account details");

        public const string RolesPermissionGroupName = "Role Permissions";
        public static ApplicationPermission ViewRoles = new ApplicationPermission("View Roles", "roles.view", RolesPermissionGroupName, "Permission to view available roles");
        public static ApplicationPermission ManageRoles = new ApplicationPermission("Manage Roles", "roles.manage", RolesPermissionGroupName, "Permission to create, delete and modify roles");
        public static ApplicationPermission AssignRoles = new ApplicationPermission("Assign Roles", "roles.assign", RolesPermissionGroupName, "Permission to assign roles to users");
		
		//feito por mim
		public const string E_InvoicesPermissionGroupName = "E_Invoice Permissions";
		public static ApplicationPermission ViewE_Invoices = new ApplicationPermission("View E_Invoices", "e_invoices.view", E_InvoicesPermissionGroupName, "Permission to view");
		public static ApplicationPermission SearchE_Invoices = new ApplicationPermission("Search E_Invoices", "e_invoices.search", E_InvoicesPermissionGroupName, "Permission to search e_invoices");
		public static ApplicationPermission CreateE_Invoices = new ApplicationPermission("Create E_Invoices", "e_invoices.create", E_InvoicesPermissionGroupName, "Permission to create e_invoices");
		public static ApplicationPermission UpdateE_Invoices = new ApplicationPermission("Update E_Invoices", "e_invoices.update", E_InvoicesPermissionGroupName, "Permission to update e_invoices");
		public static ApplicationPermission DeleteE_Invoices = new ApplicationPermission("Delete E_Invoices", "e_invoices.delete", E_InvoicesPermissionGroupName, "Permission to delete e_invoices");
		
		
		
		
		
		
		
		public const string E_CustomersPermissionGroupName = "E_Customer Permissions";
		public static ApplicationPermission ViewE_Customers = new ApplicationPermission("View E_Customers", "e_customers.view", E_CustomersPermissionGroupName, "Permission to view");
		public static ApplicationPermission SearchE_Customers = new ApplicationPermission("Search E_Customers", "e_customers.search", E_CustomersPermissionGroupName, "Permission to search e_customers");
		public static ApplicationPermission CreateE_Customers = new ApplicationPermission("Create E_Customers", "e_customers.create", E_CustomersPermissionGroupName, "Permission to create e_customers");
		public static ApplicationPermission UpdateE_Customers = new ApplicationPermission("Update E_Customers", "e_customers.update", E_CustomersPermissionGroupName, "Permission to update e_customers");
		public static ApplicationPermission DeleteE_Customers = new ApplicationPermission("Delete E_Customers", "e_customers.delete", E_CustomersPermissionGroupName, "Permission to delete e_customers");
		
		
        static ApplicationPermissions()
        {
            List<ApplicationPermission> allPermissions = new List<ApplicationPermission>()
            {
                ViewUsers,
                ManageUsers,

                ViewRoles,
                ManageRoles,
                AssignRoles,
                
                ViewE_Invoices,
                SearchE_Invoices,
                CreateE_Invoices,
                UpdateE_Invoices,
                DeleteE_Invoices,
                
                
                
                
                
                
                
                ViewE_Customers,
                SearchE_Customers,
                CreateE_Customers,
                UpdateE_Customers,
                DeleteE_Customers
                
            };

            AllPermissions = allPermissions.AsReadOnly();
        }

        public static ApplicationPermission GetPermissionByName(string permissionName)
        {
            return AllPermissions.Where(p => p.Name == permissionName).FirstOrDefault();
        }

        public static ApplicationPermission GetPermissionByValue(string permissionValue)
        {
            return AllPermissions.Where(p => p.Value == permissionValue).FirstOrDefault();
        }

        public static string[] GetAllPermissionValues()
        {
            return AllPermissions.Select(p => p.Value).ToArray();
        }

        public static string[] GetAdministrativePermissionValues()
        {
            return new string[] { ManageUsers, ManageRoles, AssignRoles };
        }
    }



    public class ApplicationPermission
    {
        public ApplicationPermission()
        { }

        public ApplicationPermission(string name, string value, string groupName, string description = null)
        {
            Name = name;
            Value = value;
            GroupName = groupName;
            Description = description;
        }



        public string Name { get; set; }
        public string Value { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }


        public override string ToString()
        {
            return Value;
        }


        public static implicit operator string(ApplicationPermission permission)
        {
            return permission.Value;
        }
    }
}


