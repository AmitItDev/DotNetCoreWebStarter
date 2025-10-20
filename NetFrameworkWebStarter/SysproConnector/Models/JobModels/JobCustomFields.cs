using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysproConnector.Models.JobModels
{
    public class JobCustomFields
    {
        public string ActionType { get; set; }
        public string FormType { get; set; } = "JOB";
        public string JobNumber { get; set; }
        public string AccessoriesBookedIn { get; set; }
        public string AccessoryList { get; set; }
        public string ClientContactNumber { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string Comments { get; set; }
        public string Fault { get; set; }
        
        public string ProofOfPurchaseDate { get; set; }
        public string ProofOfPurchaseReceived { get; set; }
        public string StoreName { get; set; }// SELECT Description from SalArea WHERE Area = [RetailOutlet]
        public string RetailRepairNumber { get; set; }
        public string SerialNumber { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public string Technician { get; set; }
        public string TSCNumber { get; set; }
        public string UnderWarranty { get; set; }
        public string UnderWarrantyOverride { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string WarrantyRejectionReason { get; set; }
        public string FaultDescription { get; set; }
        public string WorkDone { get; set; }
        public string StoreNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string StoreAddress1 { get; set; }
        public string StoreAddress2 { get; set; }
        public string StoreAddress3 { get; set; }
        public string StoreAddress4 { get; set; }
        public string StoreAddress5 { get; set; }
        public string CancelReasonCode { get; set; }
        public DateTime? RetailerBookIndate { get; set; }
        public DateTime? DateReceivedAtSc { get; set; }
        public DateTime? QuoteAccepted { get; set; }
        public DateTime? BookIntoWorkshop { get; set; }
        public DateTime? Quotation { get; set; }
        public DateTime? ReturnedNotRepaire { get; set; }
        public DateTime? DispatchReady { get; set; }
        public DateTime? Repaired { get; set; }
        public string CommentsCommunicate { get; set; }
    }
}
