using Pet.Domain.DTO;

namespace Pet.Application.Services.Interfaces
{
    public interface IPetServices
    {
        Task<PetDTO> CreatePet(CreatePetDTO petDTO);
        Task<PetDTO> SearchPet(PetDTO petDTO);
        PetDTO UpdatePet(PetDTO petDTO);
        Task<bool> DeletePet(PetDTO petDTO);
    }
}
