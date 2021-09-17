using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventario01.Models;
using Inventario01.Dto;
using AutoMapper;

namespace Inventario01.Controllers
{
    public class MarcaController : Controller
    {
        private readonly Inventario01Context _context;
        private readonly IMapper _mapper;

        public MarcaController(Inventario01Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marca.Select(x => _mapper.Map<MarcaDto>(x)).ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MarcaDto>(marca));
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] MarcaDto marcaDto)
        {
            if (ModelState.IsValid)
            {
                var marca = _mapper.Map<Marca>(marcaDto);
                _context.Marca.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaDto);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<MarcaDto>(marca));
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] MarcaDto marcaDto)
        {
            if (id != marcaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var marca = _mapper.Map<Marca>(marcaDto);
                    _context.Marca.Update(marca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marcaDto.Id))
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
            return View(marcaDto);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MarcaDto>(marca));
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.Id == id);
        }
    }
}
