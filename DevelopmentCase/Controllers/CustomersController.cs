﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevelopmentCase.Models;
using DevelopmentCase.ViewModels;

namespace DevelopmentCase.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerContext _context;
        private readonly CountryContext _context1;

        public CustomersController(CustomerContext context, CountryContext context1)
        {
            _context = context;
            _context1 = context1;
        }

        // GET: Customers
      
       
        public async Task<IActionResult> Index()
        {

            List<CustomerModelView> Customer_list = new List<CustomerModelView>();


            var customers = _context.Customer;

            foreach (Customer c in customers)
            {
                CustomerModelView cust = new CustomerModelView();

                //Get the country name 
                var country = await _context1.Country.SingleOrDefaultAsync(cty => cty.ID == c.Coutryid);
                //assign country to Model View 
               
                cust.fullname = c.fullname;
                cust.ID = c.ID;

                cust.country = country.name.ToString();
                Customer_list.Add(cust);


            }

            return View(Customer_list);
        }

   


        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            var country = await _context1.Country
               .SingleOrDefaultAsync(m => m.ID == customer.Coutryid);
            ViewBag.selectedcountry = country.name;
            return View(customer);
        }


        
        // GET: Customers/Create
        public IActionResult Create()
        {

            ViewBag.listofcountries = _context1.Country.ToList();

            return View();
        }
     


        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,fullname,Coutryid")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,fullname,Coutryid")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.ID == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.ID == id);
        }
    }
}
