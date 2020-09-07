using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public EditorsController(MyApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editor>>> Index()
        {
            return await _context.Editors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editor>> View(int id)
        {
            Editor editor = await _context.Editors.FindAsync(id);

            if (editor == null)
            {
                return NotFound();
            }

            return editor;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Editor editor)
        {
            _context.Editors.Add(editor);

            await _context.SaveChangesAsync();

            return CreatedAtAction("View", new { id = editor.Id }, editor);
        }
    }
}