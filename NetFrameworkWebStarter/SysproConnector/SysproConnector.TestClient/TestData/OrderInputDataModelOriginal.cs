using SysproConnector.Infrastructure;
using SysproConnector.Infrastructure.Options;
using SysproConnector.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SysproConnector.TestClient.TestData
{
    internal class OrderInputDataModelOriginal
    {
        internal OrderInputModel GetSalesInputData() =>
            new OrderInputModel()
            {

                OrderHeader = new OrderHeaderInputModel()
                {
                    Funder = "000000000080030", //GET ArCustomer
                    Patient = "CCP", //GET CrmAccount
                    Clinician = "120", //GET SalSalesperson
                    Status = OrderStatusOption.FollowUp,
                    IntialAppointment = DateTime.Now.AddDays(1),
                    Fitting = DateTime.Now.AddDays(2),
                    Casting = DateTime.Now.AddDays(3),
                    FinalFitting = DateTime.Now.AddDays(5),
                    Review = DateTime.Now.AddDays(7),
                    ApprovalNumber = "12345", //GET Approval.ApprovalNumber
                    Referrer = "test1", //GET Referrer.DoctorsName
                    Clinic = "01", //GET SalBranch
                    TotalRevenue = 15000,
                    TotalCost = 25000,
                    OrderComments = "This is a test",
                    LineCommand = LineCommandOptions.Added
                },

                StockedFabricatedDetailLines = new List<OrderDetailStockedFabricatedInputModel>()
                {
                    new OrderDetailStockedFabricatedInputModel()
                    {
                        StockCode = "FSX0092",                                                             //GET InvWarehouse
                        Warehouse = "05",                                                             //GET InvWarehouse
                        Quantity = 2m,
                        UnitPrice = 4000m,
                        UnitCost = 3000m,
                        GstRequired = true,
                        JobNotes = "This is a test",
                        ProductClass = "0MB",                                                             //GET InvMaster
                        Uom = "EA",
                        LineCommand = LineCommandOptions.Added,
                        MaterialLines = new List<JobMaterialInputModel>() {
                            new JobMaterialInputModel() {
                                StockCode   = "125460",                                                       //GET InvWarehouse
                                Warehouse   = "06",                                                       //GET InvWarehouse
                                Quantity    = 3m,
                                LineCommand = LineCommandOptions.Added
                            }
                        },
                        Labour = new List<JobLabourInputModel>() {
                            new JobLabourInputModel() {
                                LabourTimeAllocation = 0.00m,
                                LabourWorkCenter     = "01",                                               //GET ?
                                LineCommand          = LineCommandOptions.Added
                            }
                        }
                    }
                },

                StockedNonFabricatedDetailLines = new List<OrderDetailStockedNonFabricatedInputModel>()
                {
                    new OrderDetailStockedNonFabricatedInputModel() {
                        StockCode   = "023802",                                                                //GET InvWarehouse
                        Warehouse   = "01",                                                                //GET InvWarehouse
                        Quantity    = 6m,
                        UnitPrice   = 200m,
                        GstRequired = false,
                        Uom         = "PR",                                                                //GET ?
                        LineCommand = LineCommandOptions.Added
                    }
                },

                LabourChargeableDetailLines = new List<OrderDetailLabourChargeableInputModel>()
                {
                    new OrderDetailLabourChargeableInputModel()
                    {
                        StockCode = "68311",                                                                //GET InvWarehouse
                        Warehouse = "01",                                                                //GET InvWarehouse
                        Quantity = 1m,
                        UnitPrice = 225m,
                        GstRequired = false,
                        Uom = "EA",                                                                //GET ?
                        LineCommand = LineCommandOptions.Added
                    }
                },

                LabourNonChargeableDetailLines = new List<OrderDetailLabourNonChargeableInputModel>()
                {
                    new OrderDetailLabourNonChargeableInputModel()
                    {
                        LabourCode = "HT-5080",                                                                //GET QotNonStock
                        Quantity = 3,
                        UnitCost = 50m,
                        Date = DateTime.Now.AddDays(1),
                        Clinician = "03",                                                                //GET SalSalesPerson
                        Comment = "This is a test",
                        ProductClass = "0MB",                                                                //GET InvMaster
                        Uom = "EA",                                                                //GET ?
                        LineCommand = LineCommandOptions.Added
                    }
                }
            };

        internal OrderInputModel GetUpdatedSalesInputData(OrderOutputModel orderOutput)
        {
            var originalInputData = GetSalesInputData();

            //set header review date to 2018
            //set fabricated detail line quantity to 6
            //no further changes

            var updatedData = originalInputData;
            updatedData.OrderHeader.SalesOrder = orderOutput.SalesOrder;
            updatedData.OrderHeader.Review = DateTime.Now.AddYears(1);
            updatedData.StockedFabricatedDetailLines.First().DetailLineNumber =
                orderOutput.DetailLines.Where(x => x.Jobs.Any()).First().LineNumber.ToString();
            updatedData.StockedFabricatedDetailLines.First().Quantity = 6m;
            updatedData.StockedFabricatedDetailLines.First().LineCommand = LineCommandOptions.Changed;
            updatedData.StockedNonFabricatedDetailLines = new List<OrderDetailStockedNonFabricatedInputModel>();
            updatedData.LabourChargeableDetailLines = new List<OrderDetailLabourChargeableInputModel>();
            updatedData.LabourNonChargeableDetailLines = new List<OrderDetailLabourNonChargeableInputModel>();

            return updatedData;
        }
    }
}
