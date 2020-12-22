using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.MODELO.Help.Filter
{
    public sealed class FilterAuthorizeAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //To do : before the action executes  
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Security.Claims.ClaimsPrincipal user = context.HttpContext.User;

            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(
                                     new RouteValueDictionary
                                   {
                                         { "action", "Login" },
                                         { "controller", "Account" }
                                   });
            }

        }

    }
}
