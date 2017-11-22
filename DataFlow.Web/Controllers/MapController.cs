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

            var entityList = new List<SelectListItem>();
            entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
            entityList.AddRange(dataFlowDbContext.Entities.Select(x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }));

            ViewBag.Entities = new SelectList(entityList, "Value", "Text");

            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            var map = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);

            var entityList = new List<SelectListItem>();
            entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
            entityList.AddRange(dataFlowDbContext.Entities.Select(x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }));

            ViewBag.Entities = new SelectList(entityList, "Value", "Text");

            return View(map);
        }

        public ActionResult Delete(int id)
        {
            var dataMap = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == id);
            if (dataMap != null)
            {
                dataFlowDbContext.DataMaps.Remove(dataMap);
                dataFlowDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(DataMap vm)
        {
            var dataMap = new DataMap
            {
                Name = vm.Name,
                EntityId = vm.EntityId,
                Map = vm.Map,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            dataFlowDbContext.DataMaps.AddOrUpdate(dataMap);
            dataFlowDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(DataMap vm)
        {
            var dataMap = dataFlowDbContext.DataMaps.FirstOrDefault(x => x.Id == vm.Id);
            if (dataMap != null)
            {
                dataMap.Name = vm.Name;
                dataMap.EntityId = vm.EntityId;
                dataMap.Map = vm.Map;
                dataMap.UpdateDate = DateTime.Now;
                dataFlowDbContext.DataMaps.AddOrUpdate(dataMap);
                dataFlowDbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}