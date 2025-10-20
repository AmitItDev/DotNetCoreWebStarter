using SysproConnector.Models.InfrastructureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SysproConnector.SysproObjectFactories
{
    internal class AdjustStockSysproFactory
    {
        internal string GetParameters()
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateComment(@"version=""1.0"" encoding=""Windows-1252"));

            XmlNode postParmsNode = document.CreateElement("PostInvAdjustments");
            document.AppendChild(postParmsNode);

            XmlNode paramsNode = document.CreateElement("Parameters");

            paramsNode.AppendChild(document.CreateElement("TransactionDate")).InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            paramsNode.AppendChild(document.CreateElement("PhysicalCount")).InnerText = "N";
            paramsNode.AppendChild(document.CreateElement("PostingPeriod")).InnerText = "C";
            paramsNode.AppendChild(document.CreateElement("IgnoreWarnings")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("ApplyIfEntireDocumentValid")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("ValidateOnly")).InnerText = "N";
            paramsNode.AppendChild(document.CreateElement("IgnoreAnalysis")).InnerText = "Y";
            paramsNode.AppendChild(document.CreateElement("AdjustExpiredLots")).InnerText = "N";
            paramsNode.AppendChild(document.CreateElement("UpdateOriginalQuantityReceived")).InnerText = "N";
            postParmsNode.AppendChild(paramsNode);
            return document.InnerXml;
        }

        internal string GetDocument(List<SysoroAdjustModel> sysoroAdjustModels)
        {
            XmlDocument document = new XmlDocument();
            document.AppendChild(document.CreateComment(@"version=""1.0"" encoding=""Windows-1252"));

            XmlNode postParmsNode = document.CreateElement("PostInvAdjustments");
            document.AppendChild(postParmsNode);

            foreach (SysoroAdjustModel sysoroAdjustModel in sysoroAdjustModels)
            {
                XmlNode paramsNode = document.CreateElement("Item");

                paramsNode.AppendChild(document.CreateElement("Warehouse")).InnerText = sysoroAdjustModel.Warehouse;
                paramsNode.AppendChild(document.CreateElement("StockCode")).InnerText = sysoroAdjustModel.StockCode;
                paramsNode.AppendChild(document.CreateElement("Quantity")).InnerText = sysoroAdjustModel.Qty.ToString();
                paramsNode.AppendChild(document.CreateElement("BinLocation")).InnerText = sysoroAdjustModel.Bin;
                paramsNode.AppendChild(document.CreateElement("Reference")).InnerText = sysoroAdjustModel.Reference;
                paramsNode.AppendChild(document.CreateElement("Notation")).InnerText = sysoroAdjustModel.Notation;
                if (!string.IsNullOrEmpty(sysoroAdjustModel.GlCode))
                {
                    paramsNode.AppendChild(document.CreateElement("LedgerCode")).InnerText = sysoroAdjustModel.GlCode;
                }
                postParmsNode.AppendChild(paramsNode);
            }

            return document.InnerXml;
        }
    }
}
