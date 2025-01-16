﻿namespace EmployeeManagementSystem.DataAccess.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
