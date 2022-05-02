using System.Collections.Generic;

namespace BackEnd.Domain.DTOs
{
    public class CompleteDiseasesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SymptomDataDTO> Symptom { get; set; }
    }
}
