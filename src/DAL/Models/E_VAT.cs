using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_VAT : AuditableEntity
	{
		public E_VAT()
		{

		}

		[Key]
		public int VATCode { get; set; }
		public String VATName { get; set; }
		public Decimal VATValue { get; set; }
		public String Description { get; set; }




		public ICollection<E_Product> E_Products { get; set; }


	}

}
