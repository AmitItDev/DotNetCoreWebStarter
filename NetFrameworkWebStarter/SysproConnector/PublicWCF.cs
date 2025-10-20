using SysproConnector.DataProvider;
using SysproConnector.Managers;
using SysproConnector.Models;
using SysproConnector.Models.InfrastructureModels;
using SysproConnector.Models.JobModels;
using SysproConnector.Models.ProductionModels;
using SysproConnector.SysproObjectFactories;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SysproConnector
{
    public class PublicWCF
    {
        private LoginInputModel LoginInputModel;

        private SqlDataProvider SqlDataProvider;
        private SysproManager SysproManager;
        private AuthenticationManager AuthenticationManager;

        private ProductionManager productionManager;
        private ProductionSysproFactory productionSysproFactory;
        private AdjustStockSysproFactory adjustStockSysproFactory;

        public PublicWCF(string webServiceUrl, string company, string companyPassword, string user, string password, string wmsUser = "", int? SysproWCFBinding=null)
        {
            this.LoginInputModel = new LoginInputModel()
            {
                CompanyCode = company,
                CompanyPassword = companyPassword,
                Operator = user,
                OperatorPassword = password,
                WebServiceUrl = webServiceUrl,
                WMSUser = wmsUser
            };

            SqlDataProvider = new SqlDataProvider();
            SysproManager = new SysproManager(LoginInputModel, SysproWCFBinding);
            AuthenticationManager = new AuthenticationManager(SysproManager);

            productionSysproFactory = new ProductionSysproFactory();
            adjustStockSysproFactory = new AdjustStockSysproFactory();
            productionManager = new ProductionManager(SysproManager, SqlDataProvider, productionSysproFactory, adjustStockSysproFactory);
        }

        public ResponseModel Logon(bool isTest = false) => AuthenticationManager.Logon(isTest);

        public bool IsLoggedOn(string sessionId) => AuthenticationManager.IsLoggedIn(sessionId);

        public void LogOff(string sessionId) => AuthenticationManager.LogOff(sessionId);

        #region Production
        public ResponseModel PostBatch(string sysProPOSessionId, List<SysproBatchLineModel> sysproBatchLines, string sourceKey) => productionManager.PostBatch(sysProPOSessionId, sysproBatchLines, sourceKey);

        public ResponseModel AdjustStock(string sessionId, List<SysoroAdjustModel> sysoroAdjustModels, string sourcekey = "")
           => productionManager.AdjustStock(sessionId, sysoroAdjustModels, sourcekey);
        #endregion
    }
}
