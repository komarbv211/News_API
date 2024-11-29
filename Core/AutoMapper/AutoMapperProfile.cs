using AutoMapper;
using Data.Entities;
using Core.DTOs;
using Core.Dto.DtoAuthorization;
using Core.DTOs.DtoSpec;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NewsDto, News>();
            CreateMap<News, NewsDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.FullName));
            CreateMap<CreateNewsDto, News>();
            CreateMap<UpdateNewsDto, News>()
                .ForMember(dest => dest.Images, opt => opt.Ignore());
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<StatisticsDto, Statistics>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<RefreshTokenDto, RefreshToken>().ReverseMap();
            CreateMap<SearchRequestDto, SearchRequest>().ReverseMap();
            CreateMap<StatisticsDto, Statistics>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserFavoriteNewsDto, UserFavoriteNews>().ReverseMap();

            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); CreateMap<UserDto, User>();
            CreateMap<Category, CategoryWithNewsDto>();


        }
    }
}