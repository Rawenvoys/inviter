using Inviter.Application.Interfaces.IRepositories;
using Inviter.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Infrastracture.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        public async Task SaveAsync(ResponseDto responseDto)
        {
            
        }
    }
}
