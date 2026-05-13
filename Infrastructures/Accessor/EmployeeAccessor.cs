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

    public List<EmployeeEntity>? CreateMultiple(List<EmployeeEntity> employees)
    {
        _context.Employees.AddRange(employees);
        _context.SaveChanges();
        return employees;
    }

    public EmployeeEntity? FindById(int id)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var employee = _context.Employees.Find(id);
        return employee;
    }

    public EmployeeEntity UpdateById(EmployeeEntity employee)
    {
        var result = _context.Employees.Update(employee);
        _context.SaveChanges();
        return result.Entity;
    }

    /*public EmployeeEntity DeleteById(int id)
    {
        var result = _context.Employees.Remove(id);
        _context.SaveChanges();
        return result.Entity;
    }*/
}
