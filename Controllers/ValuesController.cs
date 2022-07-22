using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAppl.Models;
using System.Data.Entity;

namespace WebApiAppl.Controllers
{
    public class ValuesController : ApiController
    {
        DemoEntities1 demo = new DemoEntities1();
        [Route("Get/EmpDetails")]
        [HttpGet]
        public List<Employee>Index()
        {

            
            var data = demo.Employees.ToList();
            return data;
        }

        [Route("Post/EmpAdd")]
        [HttpPost]
        public HttpResponseMessage AddEmp(Employee employee)
        {
            demo.Employees.Add(employee);
            demo.SaveChanges();

            HttpResponseMessage aa = new HttpResponseMessage(HttpStatusCode.OK);

            return aa;
        }
        [Route("Get/EmpEdit")]
        [HttpGet]
        public Employee EditEmp(int Id)
        {
            var data = demo.Employees.Where(a => a.Id == Id).FirstOrDefault();

            return data;
        }

        [Route("Post/EditEmp")]
        [HttpPut]
        public HttpResponseMessage EditEmp(Employee employee)
        {
            demo.Entry(employee).State =EntityState.Modified;
            demo.SaveChanges();

            HttpResponseMessage edit = new HttpResponseMessage(HttpStatusCode.OK);

            return edit;
        }
        [Route("Get/EmpDelete")]
        [HttpDelete]
        public HttpResponseMessage DeleteEmp(int Id)
        {
            var data = demo.Employees.Find(Id);
            demo.Entry(data).State = EntityState.Deleted;
            demo.SaveChanges();
            HttpResponseMessage del = new HttpResponseMessage(HttpStatusCode.OK);
            return del;
        }

       
    }
}
