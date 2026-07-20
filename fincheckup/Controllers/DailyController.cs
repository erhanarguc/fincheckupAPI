using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using fincheckup.Models.NKolay.ENTITY;
using fincheckup.Models.NKolay.json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fincheckup.Controllers
{
    [Route("api/[controller]")]
    public class DailyController : Controller
    {
        [HttpGet("GetAll")]
        public object GetAll(DataSourceLoadOptions loadOptions, int tyear)
        {
            var mRequestList = ShedulerMain.Get_Data(tyear);
            return DataSourceLoader.Load(mRequestList, loadOptions);
        }

        [HttpGet("GetPriority")]
        public object GetPriority(DataSourceLoadOptions loadOptions)
        {
            var mRequestList = ShedulerCL.PriorityResources;
            return DataSourceLoader.Load(mRequestList, loadOptions);
        }



        [HttpPost]
        public IActionResult Post(string values)
        {
            var newEmployee = new Appointment();
            JsonConvert.PopulateObject(values, newEmployee);

            if (!TryValidateModel(newEmployee))
                return BadRequest(ModelState.IsValid);
            newEmployee.Text = newEmployee.Description;
            //newEmployee.Save_Company();
            bulten.Save_Apintment(newEmployee);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var employee = bulten.Getapintment(key);
            JsonConvert.PopulateObject(values, employee);

            if (!TryValidateModel(employee))
                return BadRequest(ModelState.IsValid);
            employee.Text = employee.Description;
            bulten.UpdateApintment(employee);

            return Ok();
        }

        [HttpDelete]
        public void Delete(int key)
        {
            bulten.DELETEApintment(key);


        }
    }
}
