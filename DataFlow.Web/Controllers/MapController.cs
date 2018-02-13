using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class MapController : BaseController
    {

        public ActionResult Index()
        {
            var maps = this.DataFlowDbContext.DataMaps
                .Include(x => x.Entity)
                .OrderBy(x => x.Name)
                .ToList();

            return View(maps);
        }

        public ActionResult Add()
        {
            var vm = new DataMap();

            ViewBag.Entities = new SelectList(GetEntityList, "Value", "Text");

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var map = this.DataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);

            ViewBag.Entities = new SelectList(GetEntityList, "Value", "Text");

            return View(map);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var dataMap = this.DataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);
            if (dataMap != null)
            {
                LogService.Info(LogTemplates.InfoCrud("DataMap", dataMap.Name, dataMap.Id, LogTemplates.EntityAction.Deleted));

                this.DataFlowDbContext.DataMaps.Remove(dataMap);
                await this.DataFlowDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataMap vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Entities = new SelectList(GetEntityList, "Value", "Text");
                return View(vm);
            }

            SaveDataMap(vm);

            LogService.Info(LogTemplates.InfoCrud("DataMap", vm.Name, vm.Id, LogTemplates.EntityAction.Added));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataMap vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Entities = new SelectList(GetEntityList, "Value", "Text");
                return View(vm);
            }

            SaveDataMap(vm);

            LogService.Info(LogTemplates.InfoCrud("DataMap", vm.Name, vm.Id, LogTemplates.EntityAction.Deleted));

            return RedirectToAction("Index");
        }

        private DataMap SaveDataMap(DataMap vm)
        {
            var isUpdate = vm.Id > 0;

            var dataMap = new DataFlow.Models.DataMap();

            if (isUpdate)
            {
                dataMap = this.DataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == vm.Id);
                dataMap.Id = vm.Id;
            }

            dataMap.Name = vm.Name;
            dataMap.EntityId = vm.EntityId;
            dataMap.Map = vm.Map;
            dataMap.CreateDate = isUpdate ? vm.CreateDate : DateTime.Now;
            dataMap.UpdateDate = DateTime.Now;

            this.DataFlowDbContext.DataMaps.AddOrUpdate(dataMap);
            this.DataFlowDbContext.SaveChanges();

            return dataMap;
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