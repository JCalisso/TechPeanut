﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TechPeanut.Api.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}