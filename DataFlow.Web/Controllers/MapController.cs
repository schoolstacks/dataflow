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
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public MapController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var maps = dataFlowDbContext.DataMaps
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
            var map = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);

            ViewBag.Entities = new SelectList(GetEntityList, "Value", "Text");

            return View(map);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var dataMap = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);
            if (dataMap != null)
            {
                dataFlowDbContext.DataMaps.Remove(dataMap);
                await dataFlowDbContext.SaveChangesAsync();
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

            return RedirectToAction("Index");
        }

        private DataMap SaveDataMap(DataMap vm)
        {
            var isUpdate = vm.Id > 0;

            var dataMap = new DataFlow.Models.DataMap();

            if (isUpdate)
            {
                dataMap = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == vm.Id);
                dataMap.Id = vm.Id;
            }

            dataMap.Name = vm.Name;
            dataMap.EntityId = vm.EntityId;
            dataMap.Map = vm.Map;
            dataMap.CreateDate = isUpdate ? vm.CreateDate : DateTime.Now;
            dataMap.UpdateDate = DateTime.Now;

            dataFlowDbContext.DataMaps.AddOrUpdate(dataMap);
            dataFlowDbContext.SaveChanges();

            return dataMap;
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Entities.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }));

                return entityList;
            }
        }
    }
}