using NetFrameworkWebStarter.DataProvider;
using NetFrameworkWebStarter.Models;
using System;
using System.Linq;

namespace NetFrameworkWebStarter.DAL
{
    public class SettingRepository
    {
        private SqlDataProvider Context;
        public SettingRepository()
        {
            this.Context = new SqlDataProvider();
        }

        #region Setting
        public SettingsModel GetSettings()
        {
            var model = new SettingsModel();
            try
            {
                model = Context.SelectQuery<SettingsModel>($@"select top 1 * from Settings order by 1 desc").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        #endregion

    }
}
