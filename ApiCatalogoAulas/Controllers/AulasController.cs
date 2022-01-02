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
    public class AulasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AulasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAulas()
        {
            return await _context.Aulas.OrderBy(x => x.Nome).ToListAsync();
        }

        // GET: api/Aulas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> GetAula(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);

            if (aula == null)
            {
                return NotFound();
            }

            return aula;
        }


        // GET: api/Aulas/aulaspormodulo/5
        [HttpGet("aulaspormodulo/{moduloid}")]
        public async Task<ActionResult<IEnumerable<Aula>>> GetAulasPorModulo(int moduloId)
        {
             return await _context.Aulas.Where(x => x.ModuloId == moduloId).ToListAsync();
        }

        // PUT: api/Aulas/5

        [ClaimsAuthorize("Total","Editar")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAula(int id, Aula aula)
        {
            if (id != aula.Id)
            {
                return BadRequest();
            }

            _context.Entry(aula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AulaExists(id))
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

        // POST: api/Aulas

        [ClaimsAuthorize("Total", "Incluir")]
        [HttpPost]
        public async Task<ActionResult<Aula>> PostAula(Aula aula)
        {
            _context.Aulas.Add(aula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAula", new { id = aula.Id }, aula);
        }

        // DELETE: api/Aulas/5
        
        [ClaimsAuthorize("Total", "Excluir")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAula(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }

            _context.Aulas.Remove(aula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.Id == id);
        }
    }
}
