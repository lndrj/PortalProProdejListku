﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Portal.Domain.Entities
{
	public class Diskuze : Entity<int>
	{
		public int UserID { get; set; }
		public int AkceID { get; set; }
		public string Komentar { get; set; }

	}
}

