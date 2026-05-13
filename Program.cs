using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Accessor;
using CS_DB_Sample.Infrastructures.Queries;




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
        Exercise09(employeeAccessor, departmentAccessor);
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

    static void Exercise09(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
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
    }

}
