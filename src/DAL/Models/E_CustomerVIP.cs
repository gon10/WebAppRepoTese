using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


				
namespace DAL.Models

{
	public class E_CustomerVIP : AuditableEntity
	{
		public E_CustomerVIP()
		{

		}

		[Key]
		public int ID { get; set; }
		public String Phone { get; set; }
		public String Description { get; set; }






	}

}
