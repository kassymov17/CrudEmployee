using System.Linq;
using System.Web.Mvc;
using CrudEmployee.Domain.Entities;
using CrudEmployee.Domain.Abstract;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using CrudEmployee.Web.Models;
using System;
using System.IO;
using CrudEmployee.Domain.Services;

namespace CrudEmployee.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IRepository<Employee> _repo;
        private IRepository<Position> _positionRepo;

        public HomeController(IRepository<Employee> repo, IRepository<Position> positionRepo)
        {
            _repo = repo;
            _positionRepo = positionRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EmployeeList(int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;
            var employees = _repo.GetAll();
            int totalEmployees = new int();

            if (!string.IsNullOrEmpty(filter))
            {
                employees = employees
                    .OrderBy(e => e.Id)
                    .Where(e => e.LastName.ToLower()
                    .Contains(filter.ToLower().Trim()));
            }

            totalEmployees = employees.Count();
            employees = employees.Skip(currentPage * currentPageSize)
                .Take(currentPageSize);



            // [todo] использовать automapper
            PaginationSet<EmployeeViewModel> pagedSet = new PaginationSet<EmployeeViewModel>()
            {
                Page = currentPage,
                TotalCount = totalEmployees,
                TotalPages = (int)Math.Ceiling((decimal)totalEmployees / currentPageSize),
                Items = employees.Select(
                    e => new EmployeeViewModel()
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Patronymic = e.Patronymic,
                        CityId = e.City.Id,
                        City = e.City.Name,
                        CountryId = e.Country.Id,
                        Country = e.Country.Name,
                        Email = e.Email,
                        Phone = e.Phone,
                        Position = e.Position.Name,
                        PositionId = e.Position.Id,
                        Image = e.Image,
                        DateOfBirth = e.DateOfBirth
                    }
                )
            };

            return Json(pagedSet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadImage(int employeeId)
        {
            var employeeOld = _repo.GetOne(employeeId);

            HttpStatusCodeResult response = null;

            if (employeeOld == null)
                response = new HttpStatusCodeResult(HttpStatusCode.NotFound, "Не существует пользователь с данным id");
            else
            {
                var uploadPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/images/employees");

                var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

                string _localFileName = multipartFormDataStreamProvider
                       .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                FileUploadResult fileUploadResult = new FileUploadResult
                {
                    LocalFilePath = _localFileName,

                    FileName = Path.GetFileName(_localFileName),

                    FileLength = new FileInfo(_localFileName).Length
                };

                // обновить данные
                employeeOld.Image = fileUploadResult.FileName;
                _repo.Update(employeeOld);

                response = new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return response;
        }

        public JsonResult GetEmployee(int id)
        {
            Employee employee = _repo.GetOne(id);
            EmployeeViewModel employeeVm = new EmployeeViewModel()
            {
                Id = employee.Id,
                CityId = employee.City.Id,
                City = employee.City.Name,
                Country = employee.Country.Name,
                CountryId = employee.Country.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Email = employee.Email,
                Image = employee.Image,
                Phone = employee.Phone,
                Position = employee.Position.Name,
                PositionId = employee.Position.Id,
                DateOfBirth = employee.DateOfBirth
            };

            return Json(employeeVm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPositions()
        {
            var positions = _positionRepo.GetAll().Select(e => new PositionViewModel()
            {
                Id = e.Id,
                Name = e.Name
            });

            return Json(positions, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(EmployeeViewModel employee)
        {
            var employeeDb = _repo.GetOne(employee.Id);
            employeeDb.FirstName = employee.FirstName;
            employeeDb.LastName = employee.LastName;
            employeeDb.Patronymic = employee.Patronymic;
            employeeDb.Phone = employee.Phone;
            employeeDb.Email = employee.Email;
            employeeDb.DateOfBirth = employee.DateOfBirth;
            employeeDb.Position = _positionRepo.GetOne(employee.PositionId);

            _repo.Update(employeeDb);

            return Json(employee);
        }
    }
}
