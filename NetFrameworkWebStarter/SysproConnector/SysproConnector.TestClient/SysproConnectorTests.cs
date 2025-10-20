using OAPL.DAL.Repository;
using SysproConnector.Models;
using SysproConnector.TestClient.TestData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace SysproConnector.TestClient
{
    public class SysproConnectorTests
    {
        private Public SysproConnectionClient;
        private OrderInputModelData OrderInputModelData;
        private PatientInputModelData PatientInputModelData;

        private string SessionId;
        private OrderOutputModel createSalesOrderOutput;
        private string newPatientNumber;


        public SysproConnectorTests()
        {
            //SysproConnectionClient = new Public("http://localhost:90/SysproWebservices", "D", "", "DEV1", "");
            SysproConnectionClient = new Public("http://43.247.127.234:90/SysproWebservices", "D", "", "DEV1", "");        
            OrderInputModelData    = new OrderInputModelData();
            PatientInputModelData  = new PatientInputModelData();
            createSalesOrderOutput = new OrderOutputModel();
        }

        public ResponseModel Logon(string sysproUrl)
        {
            var result = new ResponseModel();

            try
            {
                if (!string.IsNullOrEmpty(sysproUrl))
                    SysproConnectionClient = new Public(sysproUrl, "9", "", "DEV1", "");

                result = SysproConnectionClient.Logon();
                SessionId = ((LoginOutputModel)result.ResponseData).SessionId;
            }
            catch (Exception exception)
            {
                result.ResponseMessages.Add(exception.Message);
            }

            return result;
        }

        public bool IsLoggedOn()
        {
            var result = new bool();

            try
            {
                result = SysproConnectionClient.IsLoggedOn(SessionId);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public void LogOff()
        {
            try
            {
                SysproConnectionClient.LogOff(SessionId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ResponseModel CreateSalesOrder()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.CreateSalesOrder(SessionId, OrderInputModelData.GetSalesInputData());
                createSalesOrderOutput = (result.ResponseData == null || (result.ResponseData.GetType() == typeof(string) && string.IsNullOrWhiteSpace((string)result.ResponseData))) 
                                         ? new OrderOutputModel() : (OrderOutputModel)result.ResponseData;
                MaintainSessionId(result.ResponseMessages);
            }
            catch (Exception exception)
            {
                result.ResponseMessages.Add(exception.Message);
            }

            return result;
        }

        public ResponseModel UpdateSalesOrder()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.UpdateSalesOrder(SessionId, OrderInputModelData.GetUpdatedSalesInputData(createSalesOrderOutput));
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel UpdateOrderStatus()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.UpdateOrderStatus(SessionId, createSalesOrderOutput.SalesOrder, 8);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel ConvertForwardOrderToScheduledOrder()
        {
            var result = new ResponseModel();

            try
            {
                var salesOrder                                            = OrderInputModelData.GetSalesInputData();
                //set sale order number
                salesOrder.OrderHeader.SalesOrder                         = createSalesOrderOutput.SalesOrder;
                //set job number
                salesOrder.StockedFabricatedDetailLines.First().JobNumber = createSalesOrderOutput.DetailLines.First().Jobs.First().Job.ToString();
                //set detail line numbers
                salesOrder.StockedFabricatedDetailLines.ForEach(x => x.DetailLineNumber = createSalesOrderOutput.DetailLines.Where(y => y.stockCode == (x.StockCode + "_F")).First().LineNumber.ToString());
                salesOrder.StockedNonFabricatedDetailLines.ForEach(x => x.DetailLineNumber = createSalesOrderOutput.DetailLines.Where(y => y.stockCode == x.StockCode).First().LineNumber.ToString());
                salesOrder.LabourChargeableDetailLines.ForEach(x => x.DetailLineNumber = createSalesOrderOutput.DetailLines.Where(y => y.stockCode == x.StockCode).First().LineNumber.ToString());

                result = SysproConnectionClient.ConvertForwardOrderToScheduledOrder(SessionId, salesOrder);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel CancelSalesOrder()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.CancelSalesOrder(SessionId, createSalesOrderOutput.SalesOrder);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel CreateUnappliedPayment()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.CreateUnappliedPayment(SessionId, "000000000080031", 200, createSalesOrderOutput.SalesOrder,
                    DateTime.Now, OrderInputModelData.GetSalesInputData().OrderHeader.SalesOrder, "");
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel SaveJobNotes()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.SaveJobNotes(SessionId, "00514942", "test note from endpoint");
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel PlaceJobOnHold()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.PlaceJobOnHold(SessionId, createSalesOrderOutput.DetailLines.First().Jobs.First().Job);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel TakeJobOffOnHold()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.TakeJobOffOnHold(SessionId, createSalesOrderOutput.DetailLines.First().Jobs.First().Job);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel GetUnitPrice()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.GetUnitPrice(SessionId, "000000000080031", "05", "FSX0092", 10m);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel CreatePatient()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.CreatePatient(SessionId, PatientInputModelData.GetPatientInputModelData());
                newPatientNumber = (string)result.ResponseData;
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel UpdatePatient()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.UpdatePatient(SessionId, PatientInputModelData.GetUpdatedPatientInputModelData(newPatientNumber));
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel GetFunderInformation()
        {
            var result = new ResponseModel();

            try
            {
                result = SysproConnectionClient.GetFunderInformation(SessionId, "000000000080031");
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        public ResponseModel GetAttachment(string salesOrder, string host, string category)
        {
            var result = new ResponseModel();
            string step = "1";

            try
            {

                SalesOrderRepository salesOrderRepository = new SalesOrderRepository();
                step = "2";

                var WCFServer = $@"http://{host}:{ConfigurationManager.AppSettings["WCFHostAddress"].ToString()}/";
                step = $@"3-{WCFServer}";

                var WCFServiceLink = ConfigurationManager.AppSettings["WCFServiceRequest"].ToString();
                step = $@"3-{category}-{salesOrder}-{SessionId}";

                var httpClient = new HttpClient();
                step = $@"3-{WCFServiceLink}";
                step = $@"3-{new Uri(WCFServer + string.Format(WCFServiceLink, "ORD", category, salesOrder, SessionId))}";
                var multimediaResponse = httpClient.GetAsync(new Uri(WCFServer + string.Format(WCFServiceLink, "ORD", category, salesOrder, SessionId))).Result;
                step = "4";

                if (multimediaResponse == null)
                {
                    result.RequestStatus = false;
                    result.ResponseMessages.Add("No image");
                }
                else
                {
                    step = "5";
                    result.RequestStatus = true;
                    result.ResponseMessages.Add("Image found");
                    if (multimediaResponse.IsSuccessStatusCode)
                    {
                        step = "6";
                        var binaryResult = multimediaResponse.Content.ReadAsByteArrayAsync().Result;
                        var formattedBinaryResult = Convert.ToBase64String(binaryResult);
                    }
                }

            }
            catch (Exception ex)
            {
                result.RequestStatus = false;
                result.ResponseMessages.Add("Step: " + step + " " + ex.Message);
                //throw new Exception("Step: " + step + " " + ex.Message);
            }
            return result;
        }

        private void MaintainSessionId(List<string> messages) =>
            messages.ForEach(x => SessionId = x.Contains("New Session ID created - ") ?  x.Substring(x.LastIndexOf("-") + 1) : SessionId);
    }
}
