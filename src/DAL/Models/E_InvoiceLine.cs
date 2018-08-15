using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_InvoiceLine : AuditableEntity
	{
		public E_InvoiceLine()
		{

		}

		[Key]
		public int ID { get; set; }
		[ForeignKey("E_Invoice")]
		public int InvoiceID { get; set; }
		[ForeignKey("E_Product")]
		public int ProductID { get; set; }
		public Decimal ValueWithoutVAT { get; set; }
		public Decimal ValueWithVAT { get; set; }
		public String Description { get; set; }

		public E_Invoice E_Invoice { get; set; }
		public E_Product E_Product { get; set; }





	}

}
