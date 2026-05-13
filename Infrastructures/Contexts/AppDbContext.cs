using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS_DB_Exercise.Infrastructures.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<DepartmentEntity> Departments { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        public DbSet<ItemEntity> Items { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
            "Host=localhost;Database=cs_db_exercise;Username=postgres;Password=training;";  //接続文字列の定義
            optionsBuilder
            .UseNpgsql(connectionString)    //PostgreSQLを利用することを宣言
            .LogTo(Console.WriteLine, LogLevel.Information) //Logを吐き出す
            .EnableSensitiveDataLogging()  //機密データのログ出力許可
            .EnableDetailedErrors();    //エラーの詳細を表示
        }



    }
}