using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_Invoice : AuditableEntity
	{
		public E_Invoice()
		{

		}

		[Key]
		public int ID { get; set; }
		[ForeignKey("E_Customer")]
		public int CustomerID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime DateApproval { get; set; }
		public DateTime DatePaid { get; set; }
		public DateTime DateDeleted { get; set; }
		public Boolean IsApproved { get; set; }
		public Decimal TotalValueWithoutVAT { get; set; }
		public Decimal TotalValueWithVAT { get; set; }
		public String Description { get; set; }

		public E_Customer E_Customer { get; set; }



		public ICollection<E_InvoiceLine> E_InvoiceLines { get; set; }


	}

}
