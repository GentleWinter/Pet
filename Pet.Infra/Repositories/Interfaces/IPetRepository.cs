using Pet.Domain.Entities;
using System.Linq.Expressions;

namespace Pet.Infra.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<PetEntity> CreatePet(PetEntity petEntity);
        Task<PetEntity?> SearchPet(Expression<Func<PetEntity, bool>> predicated);
        PetEntity UpdatePet(PetEntity petEntity);
        Task<PetEntity> DeletePet(PetEntity petEntity);
        void SaveChanges();
    }
}
