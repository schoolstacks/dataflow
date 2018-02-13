using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class LookupController : BaseController
    {

        public ActionResult Index()
        {
            var vm = this.DataFlowDbContext.Lookups
                .OrderBy(x => x.GroupSet)
                .ThenBy(x => x.Key)
                .ToList();

            return View(vm);
        }

        public ActionResult Add()
        {
            var lookup = new DataFlow.Models.Lookup();

            return View(lookup);
        }

        public ActionResult Edit(int id)
        {
            var lookup = this.DataFlowDbContext.Lookups.FirstOrDefault(x => x.Id == id);

            return View(lookup);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var lookup = this.DataFlowDbContext.Lookups.FirstOrDefault(x => x.Id == id);
            if (lookup != null)
            {
                LogService.Info(LogTemplates.InfoCrud("Lookup", lookup.Key, lookup.Id, LogTemplates.EntityAction.Deleted));
                this.DataFlowDbContext.Lookups.Remove(lookup);
                await this.DataFlowDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataFlow.Models.Lookup vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            SaveLookup(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataFlow.Models.Lookup vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            SaveLookup(vm);

            return RedirectToAction("Index");
        }

        private DataFlow.Models.Lookup SaveLookup(DataFlow.Models.Lookup vm)
        {
            var isUpdate = vm.Id > 0;

            var lookup = new DataFlow.Models.Lookup();

            if (isUpdate)
            {
                lookup = this.DataFlowDbContext.Lookups.FirstOrDefault(x => x.Id == vm.Id);
                lookup.Id = vm.Id;
            }

            lookup.GroupSet = vm.GroupSet;
            lookup.Key = vm.Key;
            lookup.Value = vm.Value;

            this.DataFlowDbContext.Lookups.AddOrUpdate(lookup);
            this.DataFlowDbContext.SaveChanges();

            LogService.Info(LogTemplates.InfoCrud("Lookup", lookup.Key, lookup.Id,
                isUpdate ? LogTemplates.EntityAction.Modified : LogTemplates.EntityAction.Added));

            return lookup;
        }
    }
}