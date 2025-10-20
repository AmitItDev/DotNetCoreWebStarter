using NetFrameworkWebStarter.DAL;
using NetFrameworkWebStarter.Models;
using System;

namespace NetFrameworkWebStarter.BAL
{
    public class SettingManager
    {
        SettingRepository settingRepository;
        public SettingManager()
        {
            settingRepository = new SettingRepository();
        }

        public SettingsModel GetSettings()
        {
            var model = new SettingsModel();
            try
            {
                model = settingRepository.GetSettings();
                return model;
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
            }
            return model;
        }

    }
}
