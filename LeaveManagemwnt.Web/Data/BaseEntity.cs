﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagemwnt.Web.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
 
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
