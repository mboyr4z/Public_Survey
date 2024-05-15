using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record author_createDto : surveyUser_createDto
    {
        public bool Confirmed { get; set; } = false;
        public company_createDto companyCreateDto{get;set;}
    }
}