using AutoMapper;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Models;

namespace Backend.Mappers
{
    public class PlayerMapper : Profile
    {
        public PlayerMapper()
        {
            // Mapping from Player to PlayerDto
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.GameIds, opt => opt.MapFrom(src => src.GameSessions.Select(gs => gs.GameId).ToList()));

            // Mapping from PlayerDto to Player
            CreateMap<PlayerDto, Player>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.GameSessions, opt => opt.Ignore()); // Ignore GameSessions as it should be handled separately
        }
    }
}