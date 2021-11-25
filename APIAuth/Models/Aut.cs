using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Models
{
	public class Aut
	{
		//TABLE[dbo].[APIAUT]
		//[OID][int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
		//[utente] [nvarchar] (50) NULL,
		//[password] [nvarchar] (50) NULL,
		//[sistema] [nvarchar] (50) NULL,
		//[token] [uniqueidentifier] NULL
		public Guid Token { get; set; }
		[Required]
		public string Utente { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Sistema { get; set; }

	}
}
