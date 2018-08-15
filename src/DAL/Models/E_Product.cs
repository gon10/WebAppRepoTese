using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_Product : AuditableEntity
	{
		public E_Product()
		{

		}

		[Key]
		public int ID { get; set; }
		public String Name { get; set; }
		public Decimal ValueWithoutVAT { get; set; }
		public Decimal ValueWithVAT { get; set; }
		[ForeignKey("E_VAT")]
		public int VATClassCode { get; set; }
		public Decimal VATClassValue { get; set; }
		public String Description { get; set; }

		public E_VAT E_VAT { get; set; }



		public ICollection<E_InvoiceLine> E_InvoiceLines { get; set; }


	}

}
