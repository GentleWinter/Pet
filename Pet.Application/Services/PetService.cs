using Pet.Application.Services.Interfaces;
using Pet.Domain.DTO;
using Pet.Domain.Entities;
using Pet.Infra.Repositories.Interfaces;

namespace Pet.Application.Services
{
    public class PetService : IPetServices
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<PetDTO> CreatePet(PetDTO petDTO)
        {
            PetEntity entity = new PetEntity()
            {
                TutorId = petDTO.TutorId,
                Name = petDTO.Name,
                PetBreed = petDTO.PetBreed,
                Description = petDTO.Description,
                BirthDate = petDTO.BirthDate
            };

            var newPet = await _petRepository.CreatePet(entity);
            _petRepository.SaveChanges();

            return new PetDTO()
            {
                Id = newPet.Id,
                TutorId = newPet.TutorId,
                Name = newPet.Name,
                PetBreed = newPet.PetBreed,
                Description = newPet.Description,
                BirthDate = newPet.BirthDate
            };
        }

        public Task<PetDTO> DeletePet(PetDTO petDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<PetDTO> SearchPet(PetDTO petDTO)
        {
            var petEntity = await _petRepository.SearchPet(t => t.Name == petDTO.Name
                                                            && t.PetBreed == petDTO.PetBreed);

            return new PetDTO()
            {
                Id = petEntity.Id,
                TutorId = petEntity.TutorId,
                Name = petEntity.Name,
                PetBreed = petEntity.PetBreed,
                Description = petEntity.Description,
                BirthDate = petEntity.BirthDate
            };
        }

        public PetDTO UpdatePet(PetDTO petDTO)
        {
            PetEntity entity = new PetEntity()
            {
                Id = petDTO.Id,
                TutorId = petDTO.TutorId,
                Name = petDTO.Name,
                PetBreed = petDTO.PetBreed,
                Description = petDTO.Description,
                BirthDate = petDTO.BirthDate
            };

            var newPet = _petRepository.UpdatePet(entity);
            _petRepository.SaveChanges();

            return new PetDTO()
            {
                Id = newPet.Id,
                TutorId = newPet.TutorId,
                Name = newPet.Name,
                PetBreed = newPet.PetBreed,
                Description = newPet.Description,
                BirthDate = newPet.BirthDate
            };
        }
    }
}
