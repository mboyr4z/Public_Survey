using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record author_updateDto : surveyUser_updateDto
    {
        public bool? Confirmed { get; set; } = false;
        public int CompanyId{get;set;}
    }
}