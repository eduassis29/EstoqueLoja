using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EstoqueLoja.WEB {
    public class AuthorizeSessionAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext context) {
            var token = context.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token)) {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                { "controller", "Login" },
                { "action", "Login" }
            });
            }
        }
    }

}
