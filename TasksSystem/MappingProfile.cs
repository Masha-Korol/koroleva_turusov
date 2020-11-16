using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;

namespace TasksSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDb>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name));
            CreateMap<UserDb, User>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name));
            CreateMap<Models.Task, TaskDb>()
                    .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Title", opt => opt.MapFrom(c => c.Title))
                    .ForMember("Text", opt => opt.MapFrom(c => c.Text));
            CreateMap<TaskDb, Models.Task>()
                    .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                    .ForMember("Title", opt => opt.MapFrom(c => c.Title))
                    .ForMember("Text", opt => opt.MapFrom(c => c.Text));
            CreateMap<Project, ProjectDb>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name));
            CreateMap<ProjectDb, Project>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.Name));
            CreateMap<ProjectUsersDb, ProjectUsers>()
                        .ForMember("UserId", opt => opt.MapFrom(c => c.UserId))
                        .ForMember("ProjectId", opt => opt.MapFrom(c => c.ProjectId));
            CreateMap<ProjectUsers, ProjectUsersDb>()
                        .ForMember("UserId", opt => opt.MapFrom(c => c.UserId))
                        .ForMember("ProjectId", opt => opt.MapFrom(c => c.ProjectId));
            CreateMap<CommentDb, Comment>()
                        .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                        .ForMember("text", opt => opt.MapFrom(c => c.text));
            CreateMap<Comment, CommentDb>()
                        .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                        .ForMember("text", opt => opt.MapFrom(c => c.text));
        }
    }
}
