using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS_DB_Exercise.Infrastructures.Entities
{

    [Table("item")]
    public class ItemEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("CatId")]
        public int CatId { get; set; }

        public override string ToString()
        {
            return $"商品ID={Id},商品名={Name},値段={Price},カテゴリID={CatId}";
        }
    }
}