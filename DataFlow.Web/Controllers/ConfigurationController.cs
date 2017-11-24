using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.EdFi.Api.Resources;
using DataFlow.EdFi.Sdk;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;
using RestSharp;

namespace DataFlow.Web.Controllers
{
    public class ConfigurationController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public ConfigurationController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var vm = edFiService.GetConfiguration();

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
            if (!ModelState.IsValid)
            {
                ViewBag.Months = new SelectList(Helpers.Common.MonthSelectList(), "Value", "Text");
                ViewBag.Years = new SelectList(Helpers.Common.YearSelectList(), "Value", "Text");
                return View(vm);
            }

            var apiServerUrl = edFiService.GetConfigurationByKey(Constants.API_SERVER_URL);
            var apiServerKey = edFiService.GetConfigurationByKey(Constants.API_SERVER_KEY);
            var apiServerSecret = edFiService.GetConfigurationByKey(Constants.API_SERVER_SECRET);
            var defaultsTermMonth = edFiService.GetConfigurationByKey(Constants.DEFAULTS_TERM_MONTH);
            var defaultsTermYear = edFiService.GetConfigurationByKey(Constants.DEFAULTS_TERM_YEAR);
            var instanceCompanyName = edFiService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_NAME);
            var instanceCompanyLogo = edFiService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_LOGO);
            var instanceCompanyUrl = edFiService.GetConfigurationByKey(Constants.INSTANCE_COMPANY_URL);
            var instanceEduUseText = edFiService.GetConfigurationByKey(Constants.INSTANCE_EDU_USE_TEXT);

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

            edFiService.SaveConfiguration(confs);

            return RedirectToAction("Index");
        }
    }
}