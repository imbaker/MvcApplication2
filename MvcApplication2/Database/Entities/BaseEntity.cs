namespace MvcApplication2.Database.Entities
{
    using System;
    using System.Data.Entity.Core.Objects.DataClasses;

    public class BaseEntity
    {
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string User { get; set; }
    }
}