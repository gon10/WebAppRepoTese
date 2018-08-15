using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_CustomerAdress : AuditableEntity
	{
		public E_CustomerAdress()
		{

		}

		public String Address { get; set; }
		[Key, ForeignKey("E_Customer")]
		public int E_CustomerId { get; set; }
		public String FiscalID { get; set; }
		public String Description { get; set; }

		public E_Customer E_Customer { get; set; }





	}

}
