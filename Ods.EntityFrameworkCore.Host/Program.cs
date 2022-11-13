using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Ods.EntityFrameworkCore.Host;

class Program
{
    static void Main(string[] args)
    {
        //#region 线上迁移，最好还是生成sql脚本
        //using (var db = new MigrationsDbContextFactory().CreateDbContext(args))
        //{
        //    var array = db.Database.GetPendingMigrations();
        //    int count = array.Count();
        //    if (count == 0)
        //    {
        //        Console.WriteLine("nothing to migrate,current migrations is up-to-date...");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Pending Migrations：{count}");
        //        foreach (var a in array)
        //        {
        //            Console.WriteLine($"Migrations：{a}");
        //        }

        //        Console.WriteLine("Do you want to continue?(Y/N)");
        //        if (Console.ReadLine().Trim().ToLower() == "y")
        //        {
        //            Console.WriteLine("Migrating...");

        //            try
        //            {
        //                //执行迁移
        //                db.Database.Migrate();
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e);
        //            }
        //        }
        //        Console.WriteLine("Completed!!!");
        //    }
        //}
        //#endregion

        //Console.WriteLine("Press any key to continue...");
        //Console.ReadKey();
    }
}