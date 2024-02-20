using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PersonalTrainer<TId>: Entity<TId>
{
    public int UserId { get; set; }
    public PersonalTrainer()
    {
        
    }
    public PersonalTrainer(int userId)
    {
        UserId = userId;
    }
    public PersonalTrainer(TId id,int userId):base(id)
    {
        UserId = userId;
    }
}
