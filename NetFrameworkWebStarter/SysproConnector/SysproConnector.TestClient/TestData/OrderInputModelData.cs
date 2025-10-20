using SysproConnector.Infrastructure;
using SysproConnector.Infrastructure.Options;
using SysproConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SysproConnector.TestClient.TestData
{
    internal class OrderInputModelData
    {
        internal OrderInputModel GetSalesInputData() =>
            new OrderInputModel() {

                OrderHeader                     = new OrderHeaderInputModel() {
                    Funder            = "000000000080030", //GET ArCustomer
                    Patient           = "AOL", //GET CrmAccount
                    Clinician         = "120", //GET SalSalesperson
                    Status            = OrderStatusOption.DetermineFunder,
                    IntialAppointment = Convert.ToDateTime("2018-01-18T00:00:00"),
                    Fitting           = null,
                    Casting           = null,
                    FinalFitting      = null,
                    Review            = null,
                    ApprovalNumber    = null, //GET Approval.ApprovalNumber
                    Referrer          = null, //GET Referrer.DoctorsName
                    Clinic            = "01", //GET SalBranch
                    TotalRevenue      = 0.0m,
                    TotalCost         = 0.00m,
                    OrderComments     = null,
                    LineCommand       = LineCommandOptions.Added
                },

                StockedFabricatedDetailLines    = new List<OrderDetailStockedFabricatedInputModel>()
                { },

                StockedNonFabricatedDetailLines = new List<OrderDetailStockedNonFabricatedInputModel>()
                {
                    new OrderDetailStockedNonFabricatedInputModel() {
                        DetailLineNumber = "",
                        StockCode   = "0101",                                                                //GET InvWarehouse
                        Warehouse   = "01",                                                                //GET InvWarehouse
                        Quantity    = 2.0m,
                        UnitPrice   = 200.0m,
                        GstRequired = false,
                        Uom         = "BX",                                                                //GET ?
                        LineCommand = LineCommandOptions.Added
                    }
                },

                LabourChargeableDetailLines     = new List<OrderDetailLabourChargeableInputModel>()
                {
                    new OrderDetailLabourChargeableInputModel()
                    {
                        DetailLineNumber = "",
                        StockCode = "00121",                                                                //GET InvWarehouse
                        Warehouse = "01",                                                                //GET InvWarehouse
                        Quantity = 20.0m,
                        UnitPrice = 120.0m,
                        GstRequired = true,
                        Uom = "EA",                                                                //GET ?
                        LineCommand = LineCommandOptions.Added
                    }
                },

                LabourNonChargeableDetailLines  = new List<OrderDetailLabourNonChargeableInputModel>()
                { }
            };

        internal OrderInputModel GetUpdatedSalesInputData(OrderOutputModel orderOutput)
        {
            var originalInputData = GetSalesInputData();

            //set header review date to 2018
            //set fabricated detail line quantity to 6
            //no further changes

            var updatedData                                                   = originalInputData;
            updatedData.OrderHeader.SalesOrder                                = orderOutput.SalesOrder;
            updatedData.OrderHeader.Review                                    = DateTime.Now.AddYears(1);
            updatedData.StockedFabricatedDetailLines.First().DetailLineNumber =
                orderOutput.DetailLines.Where(x => x.Jobs.Any()).First().LineNumber.ToString();
            updatedData.StockedFabricatedDetailLines.First().Quantity         = 6m;
            updatedData.StockedFabricatedDetailLines.First().LineCommand      = LineCommandOptions.Changed;
            updatedData.StockedNonFabricatedDetailLines                       = new List<OrderDetailStockedNonFabricatedInputModel>();
            updatedData.LabourChargeableDetailLines                           = new List<OrderDetailLabourChargeableInputModel>();
            updatedData.LabourNonChargeableDetailLines                        = new List<OrderDetailLabourNonChargeableInputModel>();

            return updatedData;
        }
    }
}
