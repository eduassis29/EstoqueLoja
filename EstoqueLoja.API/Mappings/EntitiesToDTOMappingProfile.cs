using AutoMapper;
using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Models;

namespace EstoqueLoja.API.Mappings {
    public class EntitiesToDTOMappingProfile : Profile {
        
        public EntitiesToDTOMappingProfile() { 
            CreateMap<ItensEstoque, ItensEstoqueDTO>().ReverseMap();
        }

    }
}
