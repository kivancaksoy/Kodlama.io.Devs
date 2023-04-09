using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

            CreateMap<UserOperationClaim, GetByIdUserOperationClaimDto>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, GetAllUserOperationClaimModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetAllUserOperationClaimDto>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(c => $"{c.User.FirstName} {c.User.LastName}"))
                .ForMember(u => u.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
                .ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, GetByUserIdUserOperationClaimModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetByUserIdUserOperationClaimDto>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(c => $"{c.User.FirstName} {c.User.LastName}"))
                .ForMember(u => u.OperationClaimName, opt => opt.MapFrom(c => c.OperationClaim.Name))
                .ReverseMap();
        }
    }
}
