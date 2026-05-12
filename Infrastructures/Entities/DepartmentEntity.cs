using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS_DB_Exercise.Infrastructures.Entities
{

    [Table("department")]
    public class DepartmentEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"部署ID={Id},部署名={Name}";
        }
    }
}