using System.Web.Mvc;

namespace DataFlow.Web.Helpers
{
    public abstract class BaseViewPage : WebViewPage
    {
        public string CompanyName => ViewBag.CompanyName;
        public string CompanyLogo => ViewBag.CompanyLogo;
        public string CompanyUrl => ViewBag.CompanyUrl;
        public string EducationText => ViewBag.EducationText;
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public string CompanyName => ViewBag.CompanyName;
        public string CompanyLogo => ViewBag.CompanyLogo;
        public string CompanyUrl => ViewBag.CompanyUrl;
        public string EducationText => ViewBag.EducationText;
    }
}