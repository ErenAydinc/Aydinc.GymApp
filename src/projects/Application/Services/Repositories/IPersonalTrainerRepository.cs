using Core.Persistence.Repositories;
using Domain.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories;
public interface IPersonalTrainerRepository:IAsyncRepository<PersonalTrainer<int>,int>,IRepository<PersonalTrainer<int>,int>
{
}
