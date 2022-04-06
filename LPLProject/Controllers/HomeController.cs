using LPLProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;


using System.Net.Mail;

namespace LPLProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult add_project()
        {
            var list = new List<String>() { "Kunal Yadav", "Saikrishna", "Ramesh Raja", "Tonny Cherian" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult add_project(Project project)
        {
            try
            {

                LplContext db = new LplContext();

                db.Projects.Add(project);
                //var getlist = db.Managers.ToList();
                //ViewBag.list = new SelectList(getlist, "Project_name", "Manager_name");
                db.SaveChanges();
                ViewBag.Message = "Project Details Added Successfully";
                var list = new List<String>() { "Kunal Yadav", "Saikrishna", "Ramesh Raja", "Tonny Cherian" };
                ViewBag.list = list;
                return View(project);
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Project", "add_project"));
            }

        }

        public ActionResult search_project(string searchBy, string search)
        {
            LplContext db = new LplContext();
            if (searchBy == "Name")
            {
                return View(db.Projects.Where(x => x.Project_name.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "manager")
            {
                return View(db.Projects.Where(x => x.Manager.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Projects.Where(x => x.Start_date.ToString().Contains(search) || search == null).ToList());
            }
        }
        public ActionResult edit_details(string id)
        {
            LplContext db = new LplContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }
        [HttpPost]

        public ActionResult edit_details([Bind(Include = "Project_name,Start_date,End_date,Priority,Manager,number_of_Tasks,Status,User")] Project project)
        {
            try
            {
                LplContext db = new LplContext();
                if (ModelState.IsValid)
                {
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Project Details Updated Successfully";
                }
                return View(project);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Project", "add_project"));
            }
        }
        //public PartialViewResult add_user()
        //{
        //    var model = new AddEmployee();
        //    return PartialView("_adduser", model);
        //}
        //[HttpPost]
        //public PartialViewResult add_user(AddEmployee addEmployee)
        //{

        //    LplContext db = new LplContext();

        //    db.AddEmployees.Add(addEmployee);
            
        //    db.SaveChanges();
            
            
        //    return PartialView("_adduser");

        //}
        //public PartialViewResult getuser()
        //{
        //    LplContext db = new LplContext();
        //    var model1 = new Employee();
        //    db.Employees.ToList();
        //    return PartialView("_getuser",model1);
        //}
        public ActionResult Partial_View()
        {
            LplContext db = new LplContext();
            return View(Tuple.Create<Employee, IEnumerable<Employee>>(new Employee(), db.Employees.ToList())); 
            
        }
        [HttpPost]
        public JsonResult Partial_View(Employee employee)
        {
            
            

            LplContext db = new LplContext();
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);

                db.SaveChanges();
                ViewBag.Message = "Employee Added Successfully";

            }
            return Json("true", JsonRequestBehavior.AllowGet);





        }
        public ActionResult add_task()
        {
            LplContext db = new LplContext();
            var items = db.Employees.ToList();
            ViewBag.datalist = new SelectList(items, "emp_ID", "first_Name");
            return View();
        }
        [HttpPost]
        public ActionResult add_task(Task task)
        {
            LplContext db = new LplContext();
            Random rd = new Random();
            task.task_ID= "TAS" + rd.Next(1001, 9999).ToString();
          
            var items = db.Employees.ToList();
            ViewBag.datalist = new SelectList(items, "emp_ID", "first_Name");

            db.Tasks.Add(task);
            //var list = new List<String>() { "LPL", "ICICI", "Cisco", "Cognizant" };
            //ViewBag.list = list;
            //var userlist = new List<String>() { "Omkar Nade", "Pushkar Bagul", "Snehal Waichal" };
            //ViewBag.userlist = userlist;

            db.SaveChanges();
            ViewBag.Message = "Task Added Successfully";
            return View(task);
        }

        public ActionResult edit_employee(string id)
        {
            LplContext db = new LplContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit_employee([Bind(Include = "emp_ID,first_Name,last_Name,Username,Password,confirm_Password")] Employee employee)
        {
            LplContext db = new LplContext();
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Employee Details Updated Successfully";
            }
            return View(employee);
        }
        [HttpPost]
        public JsonResult getemp(string ename)
        {
            LplContext db = new LplContext();
            var emp=(from x in  db.Projects where x.Project_name.StartsWith(ename) select new { label= x.Project_name }).ToList();
            return Json(emp);
        }
        public ActionResult select_Role()
        {
            return View();
        }
        [HttpPost]
        public ActionResult select_Role(string UserRole)
        {
            if (UserRole == "Manager")
            {
                return RedirectToAction("managerLogin");
            }
            else if (UserRole == "Associate")
            {
                return RedirectToAction("AssociateLogin");
            }
          
            else
            {
                ViewBag.Message = "** Please Choose Your Role **";
            }
            return View();
        }
        public ActionResult managerLogin()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult managerLogin(Manager manager)

        {
            LplContext db = new LplContext();

            {
                var searchmanager = db.Managers.Where(x => x.username == manager.username &&
                  x.password == manager.password).FirstOrDefault();
                if (searchmanager != null) 
                {

                    return RedirectToAction("add_project", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(manager);
        }
        public ActionResult AssociateLogin()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AssociateLogin(Employee employee)

        {
            LplContext db = new LplContext();
            Session["username"] = employee.Username;
            {
                var searchmanager = db.Employees.Where(x => x.Username == employee.Username &&
                  x.Password == employee.Password).FirstOrDefault();
                
                if (searchmanager != null)
                {
                    TempData["UserName"] = searchmanager.Username;
                    return RedirectToAction("user_after_login", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(employee);
        }
        
        public ActionResult user_after_login()
        {
            LplContext db = new LplContext();
            var username = (string)Session["username"];


            return View(db.Employees.ToList().Where(x=>x.Username==username));

            
        }
        public ActionResult add_task_project()
        {
            LplContext db = new LplContext();
            return View(db.Tasks.ToList());
        }
        public ActionResult update_task(string id)
        {
            LplContext db = new LplContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }
        [HttpPost]
        public ActionResult update_task([Bind(Include = "task_ID,Project_tname,start_date,end_date,priority,task_name,parent_task,User")] Task task)
        {
            LplContext db = new LplContext();
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Task Updated Successfully";
            }
            return View(task);
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(EmailModel model)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                if (model.Attachment.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
                }
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent.";
                }
            }

            return View();
        }
        public ActionResult update_password(string id)
        {
            LplContext db = new LplContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult update_password([Bind(Include = "emp_ID,first_Name,last_Name,Username,Password")] Employee employee)
        {
            LplContext db = new LplContext();
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
               
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult logout()
        {
            Session.Remove("username");
            return RedirectToAction("select_Role");
        }
    }
    
}