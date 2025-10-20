using System;
using System.ComponentModel;
using System.Reflection;

namespace SysproConnector.Infrastructure
{
    public class SystemEnum
    {
        /// <summary>
        /// Message Type Enum
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// for Success message Class
            /// </summary>
            success,

            /// <summary>
            /// for error message Class
            /// </summary>
            error,

            /// <summary>
            /// for Warning message Class
            /// </summary>
            warning,

            /// <summary>
            /// for Info message Class
            /// </summary>
            info
        }
        public enum ScreenName
        {
            /// <summary>
            /// for Adjust screen 
            /// </summary>
            adjust,
            /// <summary>
            /// for Bim screen 
            /// </summary>
            bintransfer,
            /// <summary>
            /// for SCT screen 
            /// </summary>
            sct,
            /// <summary>
            /// for SCT screen 
            /// </summary>
            invoice,
            /// <summary>
            /// for bulk order import
            /// </summary>
            bulkorder,
            /// <summary>
            /// for Transaction screen 
            /// </summary>
            transaction
        }
        public enum ExcelColumn
        {
            StockCode = 'A',
            Description = 'B',
            Bin = 'C',
            Warehouse = 'D',
            OrigQtyOnHand = 'E',
            Counted = 'F'
        }

        public enum ImportExcelDataColumn
        {
            StockCode = 'A',
            QtyOrdered = 'B',
            EnteredPrice = 'C'
        }

        public enum InvoiceStatus
        {
            Added,
            Changed,
            Cancelled
        }

        public enum UserType
        {
            [Description("SYSPRO User")]
            SYSPROUser = 1,
            [Description("Shared Syspro User")]
            SharedSysproUser = 2,
            [Description("WMS User")]
            WMSUser = 3
        }
        public enum ServiceCentreRole
        {
            [Description("Reverse Logistics")]
            ReverseLogistics = 1,
            [Description("Repair Holding Controller")]
            RepairHoldingController = 2,
            [Description("Service Admin")]
            ServiceAdmin = 3,
            [Description("Inventory Controller")]
            InventoryController = 4,
            [Description("Technician")]
            Technician = 5,
            [Description("Manager")]
            Manager = 6,
            [Description("Dispatch Administrator")]
            DispatchAdmin = 7
        }
        public enum OrderStatus
        {
            All,
            Pending,
            Ready,
            Processed,
            Failed,
            Invalid
        }
        public enum JobStatus
        {
            [Description("Picked Up")]
            PickedUp = 1,
            [Description("Dropped Off")]
            DroppedOff = 2,
            [Description("Received at SC")]
            ReceivedAtSC = 3,
            [Description("To Assess")]
            ToAssess = 4,
            [Description("To Quote")]
            ToQuote = 5,
            [Description("Awaiting Approval")]
            AwaitingApproval = 6,
            [Description("Awaiting Spares")]
            AwaitingSpares = 7,
            [Description("To Repair")]
            ToRepair = 8,
            [Description("To Invoice")]
            ToInvoice = 9,
            [Description("To Dispatch")]
            ToDispatch = 10,
            [Description("To Collect")]
            ToCollect = 11,
            [Description("R&R")]
            R_R = 12,
            [Description("Delivery Scheduled")]
            DeliveryScheduled = 13,
            [Description("Dispatched")]
            Dispatched = 14,
            [Description("Collected")]
            Collected = 15,
            [Description("Cancel")]
            Cancel = 16,
            [Description("Delivered to store")]
            DeliveredToStore = 17
        }
        public enum MaterialLabourStatus
        {
            Add,
            Delete,
            NoChange
        }
        public enum JobTripStatus
        {
            [Description("Pending")]
            Pending = 1,
            [Description("Dispatched")]
            Dispatched = 2,
            [Description("Delivered")]
            Delivered = 3
        }
        public enum EmailReferenceField
        {
            JobCollectionId,
            CustomerEmail,
            AttachmentReminder,
            EnquiryId
        }
        public enum JobType
        {
            WalkIn = 1,
            Pickup = 2
        }

        public enum TripType
        {
            DropOff = 1,
            Pickup = 2
        }


        public enum CostingStatus
        {
            Invalid,
            Pending,
            Processed,
            ManuallyProcessed,
            Failed,
            Cancelled
        }
        public enum Period
        {
            Current = 1,
            Previous = 2,
            [Description("Before Previous")]
            Before_Previous = 3
        }


        public enum ShippingTerms
        {
            [Description("FOB")]
            FOB = 1,
        }


        public enum FreightForwarder
        {
            [Description("None")]
            None = 1,
        }
        public enum SysproAction
        {
            [Description("Add")]
            Add = 'A',
            [Description("Update")]
            Update = 'U',
            [Description("Delete")]
            Delete = 'D',
            [Description("Cancel")]
            Cancel = 'C',
            [Description("Process")]
            Process = 'P',
        }

    }

    public class EnumManager
    {

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
