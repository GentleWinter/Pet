using Microsoft.EntityFrameworkCore;
using Pet.Domain.Entities;
using Pet.Infra.Contexts;
using Pet.Infra.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Pet.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {

        private readonly DbSet<PetEntity> _dbSet;
        private readonly PetContext _dbContext;

        public PetRepository(PetContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<PetEntity>();
        }

        public async Task<PetEntity> CreatePet(PetEntity petEntity)
        {
            var result = await _dbSet.AddAsync(petEntity);

            return result.Entity;
        }

        public async Task<PetEntity> DeletePet(PetEntity petEntity)
        {
            //idk why this is not working at all but i have to sleep rn
            _dbSet.Remove(petEntity);
            await _dbContext.SaveChangesAsync();
            return petEntity;
        }


        public async Task<PetEntity?> SearchPet(Expression<Func<PetEntity, bool>> predicated)
            => await _dbSet.FirstOrDefaultAsync(predicated);

        public PetEntity UpdatePet(PetEntity petEntity)
            => _dbSet.Update(petEntity).Entity;

        public void SaveChanges()
            =>_dbContext.SaveChanges();
    }
}
