using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using MikeRobbins.EntityServiceDemo.Interfaces;
using MikeRobbins.EntityServiceDemo.Models;
using Sitecore.Data.Items;
using Sitecore.Services.Core.ComponentModel;

namespace MikeRobbins.EntityServiceDemo.DataAccess
{
    public class FieldUpdater: IFieldUpdater
    {
        public void AddFieldsToItem<T>(Item item, T sourceObject) where T : Sitecore.Services.Core.Model.EntityIdentity 
        {
            try
            {
                item.Editing.BeginEdit();

                var fields = sourceObject.ToDictionary();

                foreach (var key in fields.Keys)
                {
                    object value = null;
                    fields.TryGetValue(key, out value);

                    item[key] = value.ToString();
                }

                item.Editing.AcceptChanges();

            }
            catch (Exception ex)
            {
                item.Editing.CancelEdit();
                Sitecore.Diagnostics.Log.Error(ex.Message, this);
            }

        }
    }
}