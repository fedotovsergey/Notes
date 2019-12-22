using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.BusinessLogicLayer.Services.Notes;
using Notes.BusinessLogicLayer.Services.Notes.Models;

namespace Notes.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private NotesService _notesService;
        public NotesController(NotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public IAsyncEnumerable<NotePreviewModel> List()
        {
            return _notesService.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteModel>> Get(int id)
        {
            var note = await _notesService.FindById(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<NoteModel>> Add(NoteCreationModel model)
        {
            return await _notesService.Add(model);
        }
    }
}
