using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public record boss_updateDto : surveyUser_updateDto
    {
          public bool Confirmed { get; set; } = false;
        public company_updateDto companyUpdateDto{get;set;}
    }
}