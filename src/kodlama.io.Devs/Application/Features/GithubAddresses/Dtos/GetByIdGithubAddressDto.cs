﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Dtos
{
    public class GetByIdGithubAddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
    }
}