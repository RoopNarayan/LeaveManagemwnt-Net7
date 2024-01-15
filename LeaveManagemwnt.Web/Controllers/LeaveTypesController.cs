using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagemwnt.Web.Data;
using AutoMapper;
using LeaveManagemwnt.Web.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace LeaveManagemwnt.Web.Controllers
{
    [Authorize]
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _context = context;
            this.mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        
        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
              //return _context.LeaveTypes != null ? 
              //            View(mapper.Map<List<LeaveTypeVm>>( await _context.LeaveTypes.ToListAsync())) :
              //            Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");

            var leaveTypesVM = mapper.Map<List<LeaveTypeVm>>(await leaveTypeRepository.GetAllAsync());
            return View(leaveTypesVM);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = mapper.Map<LeaveTypeVm>(leaveType);
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVm leaveTypeVm)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVm);
                await leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVm);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVm =  mapper.Map<LeaveTypeVm>(leaveType);
            return View(leaveTypeVm);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  LeaveTypeVm leaveTypeVm)
        {
            if (id != leaveTypeVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVm);
                    await leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await leaveTypeRepository.Exists(leaveTypeVm.Id))
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
            return View(leaveTypeVm);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private async bool LeaveTypeExists(int id)
        //{
        //    return await leaveTypeRepository.Exists(id);
        //}
    }
}
