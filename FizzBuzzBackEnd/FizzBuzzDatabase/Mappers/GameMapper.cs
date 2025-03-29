using AutoMapper;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Mappers
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            // Mapping from Game to GameDto
            CreateMap<Game, GameDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Rules, opt => opt.MapFrom(src => src.Rules));

            // Mapping from GameDto to Game
            CreateMap<GameDto, Game>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Rules, opt => opt.MapFrom(src => src.Rules));

            // Mapping from CreateGameDTO to Game
            CreateMap<CreateGameDTO, Game>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Rules, opt => opt.MapFrom(src => src.Rules));

            // Mapping from UpdateGameDTO to Game
            CreateMap<UpdateGameDTO, Game>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Rules, opt => opt.MapFrom(src => src.Rules));
        }
    }
}
