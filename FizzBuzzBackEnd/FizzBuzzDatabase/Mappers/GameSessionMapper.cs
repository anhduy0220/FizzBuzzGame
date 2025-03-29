using AutoMapper;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Models;

namespace Backend.Mappers
{
    public class GameSessionMapper : Profile
    {
        public GameSessionMapper()
        {
            // Mapping from GameSession to GameSessionDto
            CreateMap<GameSession, GameSessionDto>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.CorrectAnswers, opt => opt.MapFrom(src => src.CorrectAnswers))
                .ForMember(dest => dest.IncorrectAnswers, opt => opt.MapFrom(src => src.IncorrectAnswers));

            // Mapping from GameSessionDto to GameSession
            CreateMap<GameSessionDto, GameSession>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.CorrectAnswers, opt => opt.MapFrom(src => src.CorrectAnswers))
                .ForMember(dest => dest.IncorrectAnswers, opt => opt.MapFrom(src => src.IncorrectAnswers));

            // Mapping from InitialGameSessionDTO to GameSession
            CreateMap<InitialGameSessionDTO, GameSession>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId));

            // Mapping from GameSessionAnswerDTO to GameSession (if needed)
            CreateMap<GameSessionAnswerDTO, GameSession>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameSessionId));
        }
    }
}
