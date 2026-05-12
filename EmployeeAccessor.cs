using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS_DB_Exercise.Infrastructures;

public class EmployeeAccessor
{
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーション用DbContext</param>
    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<EmployeeEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var employee = _context.Employees.ToList();
        return employee;
    }

    /// <summary>
    /// 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="departmentId">部署Id(主キー)</param>
    public EmployeeEntity? FindById(int memberId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var employee = _context.Employees.Find(memberId);
        return employee;
    }
}
