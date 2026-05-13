using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Accessor;
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

    public EmployeeEntity DeleteById(int id)
    {
        EmployeeEntity targetEmployee = _context.Employees.Find(id)!;
        var result = _context.Employees.Remove(targetEmployee);
        _context.SaveChanges();
        return result.Entity;
    }

    public EmployeeEntity? FindByNameJoinDepartment(string name)
    {
        var employee = _context.Employees
        .Include(e => e.Department)
        .Where(e => e.Name == name)
        .SingleOrDefault();
        return employee;
    }

    public List<EmployeeEntity>? FindByNameContainsJoinDepartment(string name)
    {
        var employees = _context.Employees
        .Include(e => e.Department)
        .Where(e => e.Name!.Contains(name))
        .ToList();
        if (employees.Count == 0)
        {
            return null;
        }
        return employees;
    }
}
