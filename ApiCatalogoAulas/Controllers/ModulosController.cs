﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCatalogoAulas.Data;
using ApiCatalogoAulas.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiCatalogoAulas.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModulosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ModulosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Modulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulos()
        {
            return await _context.Modulos.OrderBy(x => x.Nome).ToListAsync();
        }

        // GET: api/Modulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // PUT: api/Modulos/5
        [ClaimsAuthorize("Total", "Editar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(int id, Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Modulos
        [ClaimsAuthorize("Total", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
            _context.Modulos.Add(modulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModulo", new { id = modulo.Id }, modulo);
        }

        // DELETE: api/Modulos/5
        [ClaimsAuthorize("Total", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulo(int id)
        {
            var modulo = await _context.Modulos.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulos.Remove(modulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuloExists(int id)
        {
            return _context.Modulos.Any(e => e.Id == id);
        }
    }
}
