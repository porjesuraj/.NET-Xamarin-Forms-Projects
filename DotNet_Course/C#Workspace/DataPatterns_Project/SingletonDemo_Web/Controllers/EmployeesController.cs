﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SingletonDemo_Web.Factory;
using SingletonDemo_Web.Managers;
using SingletonDemo_Web.Models;
using SingletonDemo_Web.Factory.FactoryMethod;
namespace SingletonDemo_Web.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeePortalEntities1 db = new EmployeePortalEntities1();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee_Type);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // using factory pattern 
               BaseEmployeeFactory empFactory = new EmployeeManagerFactory1().CreateFactory(employee);
                empFactory.ApplySalary();


                // using simple factory
                /*   EmployeeManagerFactory employeeManagerFactory = new EmployeeManagerFactory();
                   iEmployeeManager employeeManager = employeeManagerFactory.GetEmployeeManager(employee.EmployeeTypeId);
                   employee.Bonus = employeeManager.GetBonus();
                   employee.HourlyPay = employeeManager.GetPay();*/


                // not using factory
                /*   if(employee.EmployeeTypeId == 1)
                   {
                       employee.HourlyPay = 8;
                       employee.Bonus = 10;
                   }else if(employee.EmployeeTypeId == 2)
                   {
                       employee.HourlyPay = 12;
                       employee.Bonus = 5;
                   }*/
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
