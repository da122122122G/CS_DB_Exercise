using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS_DB_Exercise.Infrastructures.Entities
{
    [Table("employee")]
    public class EmployeeEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("dept_id")]
        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"従業員ID={Id} 従業員名={Name} 部署ID={DeptId}";
        }
    }
}