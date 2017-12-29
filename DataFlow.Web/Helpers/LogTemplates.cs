using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Helpers
{
    public class LogTemplates
    {
        public enum EntityAction
        {
            Added,
            Modified,
            Deleted
        }

        public static string InfoCrud(string entityType, string entityName, int? entityId, EntityAction action) =>
            $"{entityType} named {entityName} with Id {entityId} was {(action).ToString().ToLower()}.";
    }
}