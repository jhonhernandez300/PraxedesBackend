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
    public class RelativeController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public RelativeController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        //DataContext db = new DataContext();

        [HttpGet]
        public IActionResult GetAllRelatives()
        {
            var message = new Message<List<Relative>>();
            var data = DbClientFactory<RelativeDbClient>.Instance.GetRelative(appSettings.Value.DbConnection);
            message.Data = data;
            message.IsSuccess = true;
            return Ok(message);
        }

        [HttpPost("SaveRelative")]
        public IActionResult SaveRelative([FromBody] Relative model)
        {
            var message = new Message<Relative>();
            var data = DbClientFactory<RelativeDbClient>.Instance.SaveRelative(model, appSettings.Value.DbConnection);

            message.IsSuccess = true;
            message.ReturnMessage = "Relative is saved";
            message.Data = model;

            return Ok(message);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] Relative model)
        {
            var message = new Message<Relative>();
            var data = DbClientFactory<RelativeDbClient>.Instance.UpdateRelative(model, appSettings.Value.DbConnection);

            message.IsSuccess = true;
            message.ReturnMessage = "Relative is saved";
            message.Data = model;

            return Ok(message);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Relative model)
        {
            var message = new Message<Relative>();
            var data = DbClientFactory<RelativeDbClient>.Instance.DeleteRelative(model.Id, appSettings.Value.DbConnection);

            if (data != null || data != "")
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Relative was Deleted";
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
        //    return Ok(db.Goods.Include(s=>s.InventoryRelativees).ToList());
        //}

    }
}
