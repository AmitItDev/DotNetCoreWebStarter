using NetFrameworkWebStarter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetFrameworkWebStarter.BAL
{
    public class DropdownManager
    {
        public DropdownManager()
        {
        }
        public List<SelectListItem> GetUserTypeList()
        {
            var model = new List<SelectListItem>();
            try
            {
                var values = Enum.GetValues(typeof(SystemEnum.UserType));
                foreach (var val in values)
                {
                    model.Add(new SelectListItem()
                    {
                        Text = EnumManager.GetEnumDescription((SystemEnum.UserType)val),
                        Value = ((int)((SystemEnum.UserType)val)).ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return model;
        }

    }
}
