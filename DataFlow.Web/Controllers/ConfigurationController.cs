using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataFlow.EdFi.Api.Resources;
using DataFlow.EdFi.Sdk;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;
using RestSharp;

namespace DataFlow.Web.Controllers
{
    public class ConfigurationController : BaseController
    {
        public ConfigurationController(IBaseServices baseService) : base(baseService)
        {
            
        }

        public ActionResult Index()
        {
            var vm = ConfigurationService.GetConfiguration();

            ViewBag.Months = new SelectList(Helpers.Common.MonthSelectList(), "Value", "Text");
            ViewBag.Years = new SelectList(Helpers.Common.YearSelectList(), "Value", "Text");

            return View(vm);
        }

        [HttpPost]
        public bool ConfigurationIsOk(string apiServerUrl, string apiServerKey, string apiServerSecret)
        {
            try
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderLocal, certificate, chain, sslPolicyErrors) => true;

                var oAuthUrl = Helpers.Common.GetUntilOrEmpty(apiServerUrl.Trim(), "/api/");

                var client = new RestClient(apiServerUrl);
                var tokenRetriever = new TokenRetriever(oAuthUrl, apiServerKey, apiServerSecret);
                client.Authenticator = new BearerTokenAuthenticator(tokenRetriever);

                var api = new SchoolsApi(client);
                var apiCall = api.GetSchoolsAll(0, 1);

                return apiCall.IsSuccessful;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DataFlow.Models.ApiConfigurationValues vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.INSTANCE_COMPANY_LOGO) && !vm.INSTANCE_COMPANY_LOGO.HasImageExtension())
            {
                ModelState.AddModelError("INSTANCE_COMPANY_LOGO", "Company logo must end with the following file extensions: jpg, gif, png, or svg.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Months = new SelectList(Helpers.Common.MonthSelectList(), "Value", "Text");
                ViewBag.Years = new SelectList(Helpers.Common.YearSelectList(), "Value", "Text");
                return View(vm);
            }

            var apiServerUrl = ConfigurationService.GetConfigurationByKey(Constants.API_SERVER_URL);
            var apiServerKey = ConfigurationService.GetConfigurationByKey(Constants.API_SERVER_KEY);
            var apiServerSecret = ConfigurationService.GetConfigurationByKey(Constants.API_SERVER_SECRET);
            var defaultsTermMonth = ConfigurationService.GetConfigurationByKey(Constants.DEFAULTS_TERM_MONTH);
            var defaultsTermYear = ConfigurationService.GetConfigurationByKey(Constants.DEFAULTS_TERM_YEAR);
            var instanceCompanyName = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_NAME);
            var instanceCompanyLogo = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_LOGO);
            var instanceCompanyUrl = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_URL);
            var instanceEduUseText = ConfigurationService.GetConfigurationByKey(Constants.INSTANCE_EDU_USE_TEXT);

            apiServerUrl.Value = vm.API_SERVER_URL;
            apiServerKey.Value = vm.API_SERVER_KEY;
            apiServerSecret.Value = vm.API_SERVER_SECRET;
            defaultsTermMonth.Value = vm.DEFAULTS_TERM_MONTH;
            defaultsTermYear.Value = vm.DEFAULTS_TERM_YEAR;
            instanceCompanyName.Value = vm.INSTANCE_COMPANY_NAME;
            instanceCompanyLogo.Value = vm.INSTANCE_COMPANY_LOGO;
            instanceCompanyUrl.Value = vm.INSTANCE_COMPANY_URL;
            instanceEduUseText.Value = vm.INSTANCE_EDU_USE_TEXT;

            var confs = new List<DataFlow.Models.Configuration>
            {
                apiServerUrl,
                apiServerKey,
                apiServerSecret,
                defaultsTermMonth,
                defaultsTermYear,
                instanceCompanyName,
                instanceCompanyLogo,
                instanceCompanyUrl,
                instanceEduUseText
            };

            ConfigurationService.SaveConfiguration(confs);

            return RedirectToAction("Index");
        }
    }
}