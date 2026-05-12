using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;


namespace CS_DB_Sample;

class Program
{
    static void Main(string[] args)
    {
        var accessorD = new DepartmentAccessor(new AppDbContext());
        // すべての部署を取得する
        var departments = accessorD.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach (var d in departments)
        {
            Console.WriteLine(d);
        }

        // 指定した部署Idの部署を取得する(存在する部署Id)
        var department = accessorD.FindById(1);
        Console.WriteLine($"存在する部署Id:{department}");

        // 指定した部署Idの部署を取得する(存在しない部署Id)
        department = accessorD.FindById(101);
        if (department == null)
        {
            Console.WriteLine($"部署Id:101の部署は存在しません。");
        }

        var accessorE = new EmployeeAccessor(new AppDbContext());
        // すべての部署を取得する
        var employees = accessorE.FindAll();
        foreach (var d in employees)
        {
            Console.WriteLine(d);
        }
    }
}