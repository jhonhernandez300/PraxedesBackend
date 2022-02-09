using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PraxedesBackend.Models;
using PraxedesBackend.Repository;
using PraxedesBackend.Utility;

namespace PraxedesBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        
        public UserController(IOptions<MySettingsModel> app)
        {
            appSettings = app;                                    
        }
        
        //Get:User/GetAllUsers
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var message = new Message<List<User>>();
            var data = DbClientFactory<UserDbClient>.Instance.GetUser(appSettings.Value.DbConnection);
            message.Data = data;
            message.IsSuccess = true;
            return Ok(message);
        }

        [HttpPost("SaveUser")]
        public IActionResult SaveUser([FromBody] User model)
        {
            var message = new Message<User>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveUser(model, appSettings.Value.DbConnection);

            message.IsSuccess = true;
            message.ReturnMessage = "User is saved";
            message.Data = model;

            return Ok(message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] User model)
        {
            var message = new Message<User>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateUser(model, appSettings.Value.DbConnection);

            message.IsSuccess = true;
            message.ReturnMessage = "User is saved";
            message.Data = model;

            return Ok(message);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User model)
        {
            var message = new Message<User>();
            var data = DbClientFactory<UserDbClient>.Instance.DeleteUser(model.Id, appSettings.Value.DbConnection);

            if (data != null || data != "")
            {
                message.IsSuccess = true;
                message.ReturnMessage = "User was Deleted";
            }
            else
            {
                message.IsSuccess = false;
                message.ReturnMessage = "Invalid Record";
            }
            return Ok(message);

        }


       

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(db.Goods.Include(s=>s.InventoryUseres).ToList());
        //}

    }
}
