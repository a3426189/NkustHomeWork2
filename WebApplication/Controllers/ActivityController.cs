using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {


            DBManager DB = new DBManager();

            //var service = new ConsoleApp.Services.ImportJsonService();
            //var filePath = ConsoleApp.Utils.FilePath.GetFullPath("高雄活動.txt");
            //List<Activity> datas = service.LoadFormFile(filePath);

            List<Activity> datas = DB.GetActivities();
            //InSertDatas(datas);

            //return Json(datas);

            return View(datas);
        }
        public void InSertDatas(List<Activity> datas)
        {
            DBManager DB = new DBManager();
            foreach (var X in datas)
            {
                DB.NewActivity(X);
            }
        }
    }
}
