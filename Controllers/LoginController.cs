using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppSystem.Models;
using AppSystem.Data;

namespace AppSystem.Controllers;
public  class LoginController : Controller{

    private IConfiguration Configuration{get; set;}
    
   DataContext db = new DataContext();

    public LoginController(IConfiguration _configuration){

            Configuration= _configuration;
    }

    public IActionResult Index()
    {
       string? connString = this.Configuration.GetConnectionString("DbConnect");
        return View();
    }
public IActionResult ProcessLogin(Usern user){
    var data = db.Usern?.First(a => a.UserName == user.UserName && a.Passwrd== user.Passwrd);
    user.UserId=data.UserId;
    try{
    
 if (data?.UserName!=null && data.Passwrd!=null)
        {

            return View("LoginSuccessful", user);

        }
        else
        {
            return View("LoginFailure", user);


        }
    }catch(Exception e){
        Console.WriteLine(e);
        return View("LoginFailure", user);
    }

       
    }

}