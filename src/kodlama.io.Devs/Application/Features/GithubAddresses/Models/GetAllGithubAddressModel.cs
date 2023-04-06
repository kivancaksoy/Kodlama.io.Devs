using Application.Features.GithubAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Models
{
    public class GetAllGithubAddressModel : BasePageableModel
    {
        public IList<GetAllGithubAddressDto> Items { get; set; }
    }
}
