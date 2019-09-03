using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
       [AllowAnonymous]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        [HttpGet("{id}", Name = "obtenerPersona")]
        [AllowAnonymous]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            return await context.Personas.FirstOrDefaultAsync(x => x.ID == id);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("obtenerPersona", new { id = persona.ID }, persona);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            context.Entry(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var persona = new Persona { ID = id };
            context.Remove(persona);
            await context.SaveChangesAsync();
            return NoContent();
        }
       
    }
}