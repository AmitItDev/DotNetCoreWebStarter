using SysproConnector.Models.InfrastructureModels;
using SysproConnector.Models.JobModels;
using SysproConnector.Models.ProductionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SysproConnector.SysproObjectFactories
{
    internal class ProductionSysproFactory
    {
        #region Post Batch
        internal string PostBatchParameters()
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateComment(@"version=""1.0"" encoding=""Windows-1252"""));

            XmlNode postParmsNode = document.CreateElement("PostInvBackflushing");
            document.AppendChild(postParmsNode);

            XmlNode paramsNode = document.CreateElement("Parameters");

            paramsNode.AppendChild(document.CreateElement("IgnoreWarnings")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("ValidateOnly")).InnerText = "N"; 
            paramsNode.AppendChild(document.CreateElement("ApplyIfEntireDocumentValid")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("PostZeroQuantityLines")).InnerText = "N";
            paramsNode.AppendChild(document.CreateElement("BackflushLevel")).InnerText = "S";
            paramsNode.AppendChild(document.CreateElement("IssueFromComponentWarehouseToUse")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("ExcludeComponentsIfBoughtOut")).InnerText = "N";
            paramsNode.AppendChild(document.CreateElement("IgnoreBomWh")).InnerText = "N";

            postParmsNode.AppendChild(paramsNode);

            return document.InnerXml;
        }


        internal string PostBatchDocument(List<SysproBatchLineModel> batchLines)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateComment(@"version=""1.0"" encoding=""Windows-1252"""));

            XmlNode rootNode = document.CreateElement("PostInvBackflushing");
            document.AppendChild(rootNode);

            foreach (var line in batchLines)
            {
                XmlNode stockNode = document.CreateElement("Item");

                stockNode.AppendChild(document.CreateElement("Warehouse")).InnerText = line.Warehouse;
                stockNode.AppendChild(document.CreateElement("StockCode")).InnerText = line.StockCode;
                stockNode.AppendChild(document.CreateElement("Quantity")).InnerText = line.Quantity;
                stockNode.AppendChild(document.CreateElement("Reference")).InnerText = line.Reference;
                stockNode.AppendChild(document.CreateElement("Notation")).InnerText = line.Notation;

                rootNode.AppendChild(stockNode);
            }
            return document.InnerXml;
        }

        #endregion

    }
}
