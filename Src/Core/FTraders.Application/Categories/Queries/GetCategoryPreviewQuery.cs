using FTraders.Application.Categories.Models;
using MediatR;
using System.Collections.Generic;

namespace FTraders.Application.Categories.Queries
{
    public class GetCategoryPreviewQuery : IRequest<List<CategoryPreviewDto>>
    {
        public int CategoryId { get; set; }
    }
}
