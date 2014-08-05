namespace MvcApplication2.Controllers
{
    using System.Web.Mvc;

    using BootstrapSupport;

    public class BootstrapBaseController: Controller
    {
        public void Attention(string message)
        {
            this.TempData.Add(Alerts.ATTENTION, message);
        }

        public void Success(string message)
        {
            this.TempData.Add(Alerts.SUCCESS, message);
        }

        public void Information(string message)
        {
            this.TempData.Add(Alerts.INFORMATION, message);
        }

        public void Error(string message)
        {
            this.TempData.Add(Alerts.ERROR, message);
        }
    }
}
