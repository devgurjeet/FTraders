using FTraders.Application.Categories.Models;
using FTraders.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FTraders.Application.Categories.Queries
{
    public class GetCategoryPreviewQueryHandler : IRequestHandler<GetCategoryPreviewQuery, List<CategoryPreviewDto>>
    {
        private readonly IFTradersDbContext _context;

        public GetCategoryPreviewQueryHandler(IFTradersDbContext context)
        {
            _context = context;
        }

        public Task<List<CategoryPreviewDto>> Handle(GetCategoryPreviewQuery request, CancellationToken cancellationToken)
        {
            Thread.Sleep(500);

            // BUG: This nested projection results in N + 1
            return _context.Categories
                .Select(CategoryPreviewDto.Projection)
                .ToListAsync(cancellationToken);

            /*
            Temporary Fix - load data into memory and project in-memory.

            var data = await _context.Categories
                .Include(c => c.Products)
                .ToListAsync(cancellationToken);

            return data.AsQueryable()
                .Select(CategoryPreviewDto.Projection)
                .ToList();
             */
        }
    }
}
