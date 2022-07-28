using System;
namespace JambRegistrationMVC.Contract
{
    public abstract class AuditableEntity : IAuditableEntity, ISoftDelete
    {
        public int CreatedBy{get; set;}
        public DateTime CreatedOn{get; set;} = DateTime.UtcNow;
        public int LastModifiedBy{get; set;}
        public DateTime? LastModifiedOn{get; set;} = DateTime.UtcNow;
        public int DeletedBy{get; set;}
        public DateTime? DeletedOn{get; set;}
        public bool IsDeleted{get; set;}
    }
}