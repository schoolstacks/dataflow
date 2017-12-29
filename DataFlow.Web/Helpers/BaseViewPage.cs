using System.Web.Mvc;

namespace DataFlow.Web.Helpers
{
    public abstract class BaseViewPage : WebViewPage
    {
        public string OrganizationLogo => ViewBag.OrganizationLogo;
        public string OrganizationUrl => ViewBag.OrganizationUrl;
        public string EducationText => ViewBag.EducationText;
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public string OrganizationLogo => ViewBag.OrganizationLogo;
        public string OrganizationUrl => ViewBag.OrganizationUrl;
        public string EducationText => ViewBag.EducationText;
    }
}