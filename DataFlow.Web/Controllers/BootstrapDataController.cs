using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class BootstrapDataController : BaseController
    {

        public ActionResult Index()
        {
            var bootstrapdata = this.DataFlowDbContext.BootstrapData
                .Include(x => x.Entity)
                .OrderBy(x => x.ProcessingOrder)
                .ToList();

            return View(bootstrapdata);
        }

        public ActionResult Add()
        {
            var bootstrapData = new BootstrapData();
            ViewBag.Entities = GetEntityList;

            return View(bootstrapData);
        }

        public ActionResult Edit(int id)
        {
            var bootstrapData = this.DataFlowDbContext.BootstrapData.FirstOrDefault(x => x.Id == id);
            ViewBag.Entities = GetEntityList;

            return View(bootstrapData);
        }

        public ActionResult Delete(int id)
        {
            var bootstrapData = this.DataFlowDbContext.BootstrapData.FirstOrDefault(x => x.Id == id);
            if (bootstrapData != null)
            {
                LogService.Info(LogTemplates.InfoCrud("BootstrapData", bootstrapData.EntityId.ToString(), bootstrapData.Id, LogTemplates.EntityAction.Deleted));

                var startFrom = bootstrapData.ProcessingOrder;

                this.DataFlowDbContext.BootstrapData.Remove(bootstrapData);
                this.DataFlowDbContext.SaveChanges();

                ReorderBootstrapData(startFrom, 0, true, false);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BootstrapData vm)
        {
            if (!JsonHelper.IsValidJson(vm.Data))
                ModelState.AddModelError("Data", "Please enter valid JSON.");

            if (!ModelState.IsValid)
            {
                ViewBag.Entities = GetEntityList;
                return View(vm);
            }

            SaveBootstrapData(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BootstrapData vm)
        {
            if (!JsonHelper.IsValidJson(vm.Data))
                ModelState.AddModelError("Data", "Please enter valid JSON.");

            if (!ModelState.IsValid)
            {
                ViewBag.Entities = GetEntityList;
                return View(vm);
            }

            SaveBootstrapData(vm);

            return RedirectToAction("Index");
        }

        private BootstrapData SaveBootstrapData(BootstrapData vm)
        {
            var isUpdate = vm.Id > 0;

            var bootstrapData = new BootstrapData();
            var processedOrderChanged = false;

            if (isUpdate)
            {
                bootstrapData = this.DataFlowDbContext.BootstrapData.FirstOrDefault(x => x.Id == vm.Id);
                bootstrapData.Id = vm.Id;

                processedOrderChanged = bootstrapData.ProcessingOrder != vm.ProcessingOrder;
            }

            bootstrapData.EntityId = vm.EntityId;
            bootstrapData.Data = vm.Data;
            bootstrapData.ProcessingOrder = vm.ProcessingOrder;
            bootstrapData.ProcessedDate = isUpdate ? vm.ProcessedDate : null;
            bootstrapData.CreateDate = isUpdate ? vm.CreateDate : DateTime.Now;
            bootstrapData.UpdateDate = DateTime.Now;

            this.DataFlowDbContext.BootstrapData.AddOrUpdate(bootstrapData);
            this.DataFlowDbContext.SaveChanges();

            LogService.Info(LogTemplates.InfoCrud("BootstrapData", bootstrapData.EntityId.ToString(), bootstrapData.Id, LogTemplates.EntityAction.Added));

            ReorderBootstrapData(bootstrapData.ProcessingOrder, bootstrapData.Id, false, isUpdate && processedOrderChanged);

            return bootstrapData;
        }

        private void ReorderBootstrapData(int startFrom, int ignoreId, bool remove, bool edit)
        {
            var updateBootstrap = this.DataFlowDbContext.BootstrapData
                .Where(x => x.ProcessingOrder >= startFrom && x.Id != ignoreId)
                .ToList();

            if (updateBootstrap.Any())
            {
                var reOrder = remove ? startFrom : startFrom + 1;

                updateBootstrap.ForEach(x =>
                {
                    x.ProcessingOrder = reOrder;
                    this.DataFlowDbContext.BootstrapData.AddOrUpdate(x);
                    reOrder++;
                });

                this.DataFlowDbContext.SaveChanges();
            }

            if (edit)
            {
                updateBootstrap = this.DataFlowDbContext.BootstrapData
                    .Where(x => x.ProcessingOrder <= startFrom && x.Id != ignoreId)
                    .ToList();

                if (updateBootstrap.Any())
                {
                    var reOrder = 1;

                    updateBootstrap.ForEach(x =>
                    {
                        x.ProcessingOrder = reOrder;
                        this.DataFlowDbContext.BootstrapData.AddOrUpdate(x);
                        reOrder++;
                    });

                    this.DataFlowDbContext.SaveChanges();
                }
            }
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Select Entity", Value = string.Empty}
                };
                entityList.AddRange(this.DataFlowDbContext.Entities
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));

                return entityList;
            }
        }
    }
}