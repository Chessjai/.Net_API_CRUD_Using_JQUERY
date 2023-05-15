using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeesController : ApiController
    {
       public HttpResponseMessage Get()
        {
            using (ApDbcontext dbcontext=new ApDbcontext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Employees.ToList());
            }
        }
        public  HttpResponseMessage Get(int id)
        {
            using (ApDbcontext dbcontext = new ApDbcontext())
            {
                var emp = dbcontext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp!=null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK,emp);
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "emp id"+id+"not found");
                }

            }

        }
        public HttpResponseMessage Post(Employee employee)
        {
            using (ApDbcontext dbcontext = new ApDbcontext())
            {

            
                if (employee != null)
                {

                    dbcontext.Employees.Add(employee);
                    dbcontext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, employee);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,  "pleasr pronide input data");
                }
            }
        }
        public HttpResponseMessage Put(int id,Employee employee)
        {
            using (ApDbcontext dbcontext = new ApDbcontext()) 
            { 
                var emp = dbcontext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    emp.FirstName = employee.FirstName;
                    emp.Lastname = employee.Lastname;
                    emp.Gender = employee.Gender;
                    emp.City = employee.City;
                    emp.IsActive = employee.IsActive;
                    dbcontext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                        }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id + "not found in database to update failed");
                }

            }
        }
        public HttpResponseMessage Delete(int id)
        {

            using (ApDbcontext dbcontext = new ApDbcontext())
            {
                var emp = dbcontext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    dbcontext.Employees.Remove(emp);
                    dbcontext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id" + id + "not found in database to delete failed");
                }

            }
        }
    }
}
