using Microsoft.AspNetCore.Identity;

namespace Lab8UsersAndRoles.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string? Descriptions;
    }
}
