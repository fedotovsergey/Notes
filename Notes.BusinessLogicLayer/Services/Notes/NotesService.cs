using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Notes.BusinessLogicLayer.Interfaces;
using Notes.BusinessLogicLayer.Services.Notes.Models;
using Notes.DataAccessLayer;
using Notes.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.BusinessLogicLayer.Services.Notes
{
    public class NotesService : IInjectableService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public NotesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IAsyncEnumerable<NotePreviewModel> List()
        {
            return _context.Notes
                .ProjectTo<NotePreviewModel>(_mapper.ConfigurationProvider)
                .OrderByDescending(n => n.Id)
                .AsAsyncEnumerable();
        }

        public async Task<NoteModel> FindById(int id)
        {
            return await _context.Notes
                .Where(n => n.Id == id)
                .ProjectTo<NoteModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<NoteModel> Add(NoteCreationModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var entry = new NoteEntity()
            {
                Text = model.Text,
                CreatedDate = DateTime.Now
            };

            _context.Add(entry);

            await _context.SaveChangesAsync();

            return _mapper.Map<NoteModel>(entry);
        }
    }
}
