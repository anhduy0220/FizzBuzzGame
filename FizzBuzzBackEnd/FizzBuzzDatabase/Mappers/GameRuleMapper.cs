using AutoMapper;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Mappers
{
    public class GameRuleMapper : Profile
    {
        public GameRuleMapper()
        {
            // Mapping from GameRule to GameRuleDto
            CreateMap<GameRule, GameRuleDto>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Divisor, opt => opt.MapFrom(src => src.Divisor))
                .ForMember(dest => dest.Replacement, opt => opt.MapFrom(src => src.Replacement));

            // Mapping from GameRuleDto to GameRule
            CreateMap<GameRuleDto, GameRule>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Divisor, opt => opt.MapFrom(src => src.Divisor))
                .ForMember(dest => dest.Replacement, opt => opt.MapFrom(src => src.Replacement));

            // Mapping from CreateGameRuleDTO to GameRule
            CreateMap<CreateGameRuleDTO, GameRule>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.Divisor, opt => opt.MapFrom(src => src.Divisor))
                .ForMember(dest => dest.Replacement, opt => opt.MapFrom(src => src.Replacement));

            // Mapping from UpdateGameRuleDTO to GameRule
            CreateMap<UpdateGameRuleDTO, GameRule>()
                .ForMember(dest => dest.Divisor, opt => opt.MapFrom(src => src.Divisor))
                .ForMember(dest => dest.Replacement, opt => opt.MapFrom(src => src.Replacement));
        }
    }
}
