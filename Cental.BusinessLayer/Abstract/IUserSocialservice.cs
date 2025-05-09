﻿using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IUserSocialservice : IGenericService<UserSocial>
    {
         List<ResultUserSocialDto> TGetSocialsByUserID(int userId);
    }
}
