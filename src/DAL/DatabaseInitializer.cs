// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Core;
using DAL.Core.Interfaces;

namespace DAL
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }




    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountManager _accountManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
        {
            _accountManager = accountManager;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts");

                const string adminRoleName = "administrator";
                const string userRoleName = "user";
                
                //________feito por mim
               	const string AU_ManagerRoleName = "au_manager";
               	const string AU_OperatorRoleName = "au_operator";
               	const string AU_Operator_CustomersRoleName = "au_operator_customers";
              	//________

                await EnsureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
                await EnsureRoleAsync(userRoleName, "Default user", new string[] { });
                
               	//________feito por mim
               	await EnsureRoleAsync(AU_OperatorRoleName, "Default AU_Operator", new string[] {   ApplicationPermissions.GetPermissionByName("View E_Invoices").Value, });
               	await EnsureRoleAsync(AU_Operator_CustomersRoleName, "Default AU_Operator_Customers", new string[] {   ApplicationPermissions.GetPermissionByName("View E_Customers").Value,    ApplicationPermissions.GetPermissionByName("Create E_Customers").Value,  ApplicationPermissions.GetPermissionByName("Delete E_Customers").Value,   });
               	await EnsureRoleAsync(AU_ManagerRoleName, "Default AU_Manager", new string[] {     ApplicationPermissions.GetPermissionByName("Search E_Invoices").Value,    ApplicationPermissions.GetPermissionByName("Create E_Invoices").Value,    ApplicationPermissions.GetPermissionByName("Update E_Invoices").Value,                  ApplicationPermissions.GetPermissionByName("Delete E_Invoices").Value, });
               	//________

                await CreateUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "admin@ebenmonney.com", "+1 (123) 000-0000", new string[] { adminRoleName });
                await CreateUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "user@ebenmonney.com", "+1 (123) 000-0001", new string[] { userRoleName });

                _logger.LogInformation("Inbuilt account generation completed");
            }



            
        }



        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
            {
                ApplicationRole applicationRole = new ApplicationRole(roleName, description);

                var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

                if (!result.Item1)
                    throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");
            }
        }

        private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

            if (!result.Item1)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Item2)}");


            return applicationUser;
        }
    }
}

