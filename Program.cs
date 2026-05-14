using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Accessor;
using CS_DB_Sample.Infrastructures.Queries;
using Microsoft.EntityFrameworkCore;
using System.Transactions;




namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        //var accessor = new EmployeeAccessor(new AppDbContext());
        var context = new AppDbContext();
        var employeeAccessor = new EmployeeAccessor(context);
        var departmentAccessor = new DepartmentAccessor(context);

        //Exercise07(employeeAccessor);
        //Exercise08(employeeAccessor);
        //Exercise11(employeeAccessor, departmentAccessor);
        //Exercise13(employeeAccessor, departmentAccessor);
        //Exercise14(employeeAccessor, departmentAccessor);
        //Exercise15(context, departmentAccessor);
        Exercise16(employeeAccessor);
    }
    /*
        var employees = accessor.FindByDeptId();
            Console.WriteLine("すべての部署を取得する");
            foreach (var d in employees)
            {
                Console.WriteLine(d);
            }

            Console.Write("部署Idを入力してください->");

            var department = accessor.FindByDeptId(int.Parse(Console.ReadLine()));
            Console.WriteLine($"存在する部署Id:{department}");


        }
    static void Exercise07(EmployeeAccessor accessor)
    {
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        var employees = accessor.FindByDeptId(deptId);

        if (employees != null)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine($"部署Id:{deptId}の社員は存在しません");
        }
        return;}*/

    /*static void Exercise08(EmployeeAccessor accessor)
    {
        Console.Write("キーワードを入力してください->");
        var keyword = Console.ReadLine()!;
        var employees = accessor.FindByContaintsName(keyword);
        Console.WriteLine("演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");

        if (employees != null)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine($"キーワード:{keyword}を含む社員は存在しません");
        }

    }*/

    /*static void Exercise09(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("社員名を入力してください->");
        string name = Console.ReadLine()!;
        Console.Write("部署idを入力してください->");
        int deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-09 employeeテーブルに新しい社員の情報を登録する");
        if (departmentAccessor.FindById(deptId) == null)
        {
            Console.WriteLine($"部署Id:{deptId}は存在しないため、社員登録できません");
            return;
        }

        var newEmployee = new EmployeeEntity
        {
            Name = name,
            DeptId = deptId
        };

        employeeAccessor.Create(newEmployee);
        Console.WriteLine($"社員名:{name}、部署Id:{deptId}の社員を登録しました");
    }*/

    /*static void Exercise09(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)

    
    {
        while (true)
        {
            Console.Write("社員名を入力してください->");
            string name = Console.ReadLine()!;
                if (name == null)
                {
                    break;
                }

            Console.Write("部署idを入力してください->");
            int deptId = int.Parse(Console.ReadLine()!);
            if (departmentAccessor.FindById(deptId) == null)
            {
                Console.WriteLine($"部署Id:{deptId}は存在しないため、社員登録できません");
                continue;
            }
        }

        Console.WriteLine("演習-09 employeeテーブルに新しい社員の情報を登録する");
        var newEmployees = new EmployeeEntity
        {
            Name = name,
            DeptId = deptId
        };
newEmployees.(newEmployees)
        employeeAccessor.Create(newEmployee);
        Console.WriteLine($"社員名:{name}、部署Id:{deptId}の社員を登録しました");
    }*/

    /*static void Exercise10(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("社員idを入力してください->");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("社員名を入力してください->");
        string name = Console.ReadLine()!;

        Console.WriteLine("演習-10 指定された社員Idの社員名を変更する");
        if (employeeAccessor.FindById(id) == null)
        {
            Console.WriteLine($"社員Id:{id}は存在しないため、変更できません");
            return;
        }
        var targetEmployee = employeeAccessor.FindById(id);
        targetEmployee.Name = name!;
        employeeAccessor.UpdateById(targetEmployee);
        Console.WriteLine($"社員名:を{name}に変更しました");
    }*/

    /*static void Exercise11(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("消去したい社員idを入力してください->");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-10 指定された社員Idの社員名を変更する");
        if (employeeAccessor.FindById(id) == null)
        {
            Console.WriteLine($"社員Id:{id}は存在しないため、変更できません");
            return;
        }
        employeeAccessor.DeleteById(id);
        Console.WriteLine($"社員id:{id}の社員を削除しました");
    }*/


    /*static void Exercise13(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("社員名を入力してください->");
        string name = Console.ReadLine()!;
        Console.WriteLine("演習-13 指定された氏名で社員と所属部署を取得する");
        var employee = employeeAccessor.FindByNameJoinDepartment(name);

        if (employee == null)
        {
            Console.WriteLine($"社員名:{name}の社員は存在しませんでした");
            return;
        }

        Console.WriteLine(employee);
        Console.WriteLine(employee!.Department);
    }*/

    /*static void Exercise14(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-14 指定された部署Idの部署と所属社員を取得する");
        var result = departmentAccessor.FindByIdJoinEmployee(deptId);
        if (result == null)
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しませんでした");
            return;
        }
        Console.WriteLine(result);

        foreach (var employee in result.Employees!)
        {
            Console.WriteLine(employee);
        }
    }*/

    /*private static void Exercise15(DbContext context, DepartmentAccessor departmentAccessor)
    {
        using var transaction = context.Database.BeginTransaction();
        Console.WriteLine("トランザクションを開始しました。");

        Console.Write("新しい部署名を入力してください->");
        var name = Console.ReadLine();
        var entity = new DepartmentEntity
        {
            Id = 0,
            Name = name
        };

        var result = departmentAccessor.Create(entity);
        Console.WriteLine($"新しい部署を登録しました: 部署Id={result.Id} , 部署名={result.Name}");

        Console.Write("トランザクションをコミットしますか？ (y/n)->");
        var input = Console.ReadLine();
        if (input?.ToLower() == "y")
        {
            transaction.Commit();
            Console.WriteLine("トランザクションをコミットしました。");
        }
        else
        {
            transaction.Rollback();
            Console.WriteLine("トランザクションをロールバックしました。");
        }

        var departments = departmentAccessor.FindAll();
        foreach (var department in departments)
        {
            Console.WriteLine($"部署Id={department.Id} , 部署名={department.Name}");
        }
    }*/

    private static void Exercise16(EmployeeAccessor employeeAccessor)
    {
        Console.Write("社員名を入力してください->");
        string name = Console.ReadLine()!;
        var results = employeeAccessor.FindByNameContainsJoinDepartment(name!);
        if (results == null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            foreach (EmployeeEntity? result in results)
                Console.WriteLine($"{name}さんは、{result.Department!.Name}に所属する社員です。");
        }
    }



}