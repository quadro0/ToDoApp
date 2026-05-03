using AutoMapper;
using Data.Entities;
using ServiceContracts.DTO;

namespace Services
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<CategoryAddRequest, CategoryEntity>()
                .ForMember(ce => ce.UserId, car => car.Ignore());

            CreateMap<CategoryUpdateRequest, CategoryEntity>()
                .ForMember(ce => ce.Id, cur => cur.Ignore())
                .ForMember(ce => ce.UserId, cur => cur.Ignore());

            CreateMap<CategoryEntity, CategoryResponse>();

            CreateMap<UserUpdateRequest, UserEntity>()
                .ForMember(ue => ue.Id, uur => uur.MapFrom(ue => ue.Id))
                .ForMember(ue => ue.Email, uur => uur.MapFrom(ue => ue.Email));

            CreateMap<UserEntity, UserResponse>()
                .ForMember(ur => ur.Id, ue => ue.MapFrom(ue => ue.Id))
                .ForMember(ur => ur.Email, ue => ue.MapFrom(ue => ue.Email))
                .ForMember(ur => ur.PasswordHash, ue => ue.MapFrom(ue => ue.PasswordHash));

            CreateMap<TaskAddRequest, TaskEntity>()
                .ForMember(te => te.Name, tar => tar.MapFrom(tar => tar.Name))
                .ForMember(te => te.Description, tar => tar.MapFrom(tar => tar.Description))
                .ForMember(te => te.IsCompleted, tar => tar.MapFrom(tar => tar.IsCompleted))
                .ForMember(te => te.DateCreated, tar => tar.MapFrom(tar => tar.DateCreated))
                .ForMember(te => te.CategoryId, tar => tar.MapFrom(tar => tar.CategoryId))
                .ForMember(te => te.UserId, tar => tar.MapFrom(tar => tar.UserId));

            CreateMap<TaskUpdateRequest, TaskEntity>()
                .ForMember(te => te.Id, tur => tur.MapFrom(tur => tur.Id))
                .ForMember(te => te.Name, tur => tur.MapFrom(tur => tur.Name))
                .ForMember(te => te.Description, tur => tur.MapFrom(tur => tur.Description))
                .ForMember(te => te.IsCompleted, tur => tur.MapFrom(tur => tur.IsCompleted))
                .ForMember(te => te.DateCreated, tur => tur.MapFrom(tur => tur.DateCreated))
                .ForMember(te => te.CategoryId, tur => tur.MapFrom(tur => tur.CategoryId))
                .ForMember(te => te.UserId, tur => tur.MapFrom(tur => tur.UserId));

            CreateMap<TaskEntity, TaskResponse>()
                .ForMember(tr => tr.Id, te => te.MapFrom(te => te.Id))
                .ForMember(tr => tr.Name, te => te.MapFrom(te => te.Name))
                .ForMember(tr => tr.Description, te => te.MapFrom(te => te.Description))
                .ForMember(tr => tr.IsCompleted, te => te.MapFrom(te => te.IsCompleted))
                .ForMember(tr => tr.DateCreated, te => te.MapFrom(te => te.DateCreated))
                .ForMember(tr => tr.CategoryId, te => te.MapFrom(te => te.CategoryId))
                .ForMember(tr => tr.UserId, te => te.MapFrom(te => te.UserId))
                .ForMember(tr => tr.Category, te => te.MapFrom(te => te.Category));
        }
    }
}
