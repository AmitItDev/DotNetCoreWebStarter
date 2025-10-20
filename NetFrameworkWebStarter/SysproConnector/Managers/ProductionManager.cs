using SysproConnector.DataProvider;
using SysproConnector.Models.JobModels;
using SysproConnector.Models;
using SysproConnector.SysproObjectFactories;
using System;
using static SysproConnector.Infrastructure.SystemEnum;
using System.Collections.Generic;
using SysproConnector.Models.ProductionModels;
using System.Linq;
using SysproConnector.Models.InfrastructureModels;

namespace SysproConnector.Managers
{
    internal class ProductionManager
    {
        private SysproManager SysproManager;
        private SqlDataProvider SqlDataProvider;
        private ProductionSysproFactory productionSysproFactory;
        private AdjustStockSysproFactory adjustStockSysproFactory;
        internal ProductionManager(SysproManager sysproManager, SqlDataProvider sqlDataProvider, ProductionSysproFactory productionSysproFactory, AdjustStockSysproFactory adjustStockSysproFactory)
        {
            this.SysproManager = sysproManager;
            this.SqlDataProvider = sqlDataProvider;
            this.productionSysproFactory = productionSysproFactory;
            this.adjustStockSysproFactory = adjustStockSysproFactory;
        }
        
        public ResponseModel PostBatch(string sysProPOSessionId, List<SysproBatchLineModel> sysproBatchLines, string sourceKey)
        {
            var parameterXML = productionSysproFactory.PostBatchParameters();
            var documentXML = productionSysproFactory.PostBatchDocument(sysproBatchLines);
            ResponseModel OrderCrationResponse = SysproManager.PostTransaction("INVTBF", parameterXML, documentXML, sysProPOSessionId, "A", sourceKey);
            
            return OrderCrationResponse;
        }

        internal ResponseModel AdjustStock(string sessionId, List<SysoroAdjustModel> sysoroAdjustModels, string sourceKey = "")
        {
            string parameterXML = adjustStockSysproFactory.GetParameters();
            string documentXML = adjustStockSysproFactory.GetDocument(sysoroAdjustModels);
            sourceKey = !string.IsNullOrEmpty(sourceKey) ? sourceKey : string.Join(",", sysoroAdjustModels
                                                                                                            .Select(a => a.StockCode).ToList());
            ResponseModel response = SysproManager.PostTransaction("INVTMA", parameterXML, documentXML, sessionId, string.Empty, sourceKey);
            return response;
        }
    }
}
