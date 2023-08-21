using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab8UsersAndRoles.CustomFilters
{
    public class AuthLog: TypeFilterAttribute
    {
        public AuthLog(string actionName, string roleName): base(typeof(AuthorizeAction))
        {
            Arguments = new object[]
            {
            actionName, 
            roleName
            };
        }
    }
    public class AuthorizeAction : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly string _roleName;
        public AuthorizeAction(string actionName, string roleName)
        {
            _actionName = actionName;
            _roleName = roleName;
            View = "AuthorizeFailed";
        }
        public string View { get; set; }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            switch (_actionName)
            {
                case "Create":
                    if (!filterContext.HttpContext.User.IsInRole(_roleName))
                    {
                        var vr = new ViewResult();
                        vr.ViewName = View;
                        filterContext.Result = vr;
                    }
                    break;
            }
        }
    }
}


