using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCore.Unpoly
{
    public class UpController : Controller
    {
        protected string Theme => Request.Cookies["Theme"] ?? "light";

        public ViewResult UpBadRequest(object? model = null, string? viewName = null)
        {
            var view = View(viewName, model);
            view.StatusCode = StatusCodes.Status400BadRequest;
            return view;
        }

        public ActionResult UpAccept()
        {
            Response.Headers.Add("X-Up-Accept-Layer", "{}");
            return Ok();
        }

        public ActionResult UpView(string? viewName, object? model, string targetSelector)
        {
            Response.Headers.Add("X-Up-Target", targetSelector);
            return View(viewName, model);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["Theme"] = Theme;

            base.OnActionExecuted(context);
        }
    }
}
