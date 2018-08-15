using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_Customer : AuditableEntity
	{
		public E_Customer()
		{

		}

		[Key]
		public int ID { get; set; }
		public String Name { get; set; }
		public String FiscalID { get; set; }
		public String Description { get; set; }



		public E_CustomerAdress E_CustomerAdress { get; set; }

		public ICollection<E_Invoice> E_Invoices { get; set; }


	}

}
