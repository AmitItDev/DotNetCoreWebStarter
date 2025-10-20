using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SysproConnector.Models.InfrastructureModels
{
	[XmlRoot(ElementName = "postcreditfrominvoice")]
	public class Postcreditfrominvoice
	{

		[XmlElement(ElementName = "Item")]
		public List<Item> Item { get; set; }

		[XmlElement(ElementName = "StatusOfItems")]
		public StatusOfItems StatusOfItems { get; set; }
	}

	[XmlRoot(ElementName = "Item")]
	public class Item
	{

		[XmlElement(ElementName = "ValidationStatus")]
		public ValidationStatus ValidationStatus { get; set; }

		[XmlElement(ElementName = "ItemNumber")]
		public string ItemNumber { get; set; }
	}

	[XmlRoot(ElementName = "ValidationStatus")]
	public class ValidationStatus
	{

		[XmlElement(ElementName = "InvoiceDetails")]
		public InvoiceDetails InvoiceDetails { get; set; }

		[XmlElement(ElementName = "Status")]
		public string Status { get; set; }
	}

	[XmlRoot(ElementName = "InvoiceDetails")]
	public class InvoiceDetails
	{

		[XmlElement(ElementName = "InvoiceNumber")]
		public string InvoiceNumber { get; set; }

		[XmlElement(ElementName = "SalesOrder")]
		public string SalesOrder { get; set; }

		[XmlElement(ElementName = "Customer")]
		public string Customer { get; set; }

		[XmlElement(ElementName = "DispatchNote")]
		public string DispatchNote { get; set; }

		[XmlElement(ElementName = "CreditNoteCreated")]
		public string CreditNoteCreated { get; set; }
	}

	[XmlRoot(ElementName = "StatusOfItems")]
	public class StatusOfItems
	{

		[XmlElement(ElementName = "ItemsProcessed")]
		public string ItemsProcessed { get; set; }

		[XmlElement(ElementName = "ItemsInvalid")]
		public string ItemsInvalid { get; set; }
	}
}
