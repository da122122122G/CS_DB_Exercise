using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Accessor;




namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        //var accessor = new EmployeeAccessor(new AppDbContext());
        var context = new AppDbContext();
        var employeeAccessor = new EmployeeAccessor(context);
        Exercise07(employeeAccessor);
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


        }*/
    static void Exercise07(EmployeeAccessor accessor)
    {
        /*Console.Write("部署Idを入力してください->");
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
        }*/

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

        return;
    }
}