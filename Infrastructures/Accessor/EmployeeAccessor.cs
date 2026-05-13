using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Accessor;

public class EmployeeAccessor
{
    private readonly AppDbContext _context;

    public EmployeeAccessor(AppDbContext context)
    {
        _context = context;
    }



    public List<EmployeeEntity>? FindByDeptId(int deptId)
    {
        var employees = _context.Employees
        .Where(e => e.DeptId == deptId)
        .ToList();
        if (employees.Count == 0)
        {
            return null;
        }
        return employees;


    }

    public List<EmployeeEntity>? FindByContaintsName(string keyword)
    {
        var employees = _context.Employees
    .Where(e => e.Name!.Contains(keyword))
    .ToList();
        if (employees.Count == 0)
        {
            return null;
        }
        return employees;
    }

    public EmployeeEntity Create(EmployeeEntity employee)
    {
        var result = _context.Employees.Add(employee);
        _context.SaveChanges();
        return result.Entity;
    }
}
