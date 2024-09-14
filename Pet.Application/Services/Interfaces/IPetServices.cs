using Pet.Domain.DTO;

namespace Pet.Application.Services.Interfaces
{
    public interface IPetServices
    {
        Task<PetDTO> CreatePet(PetDTO petDTO);
        Task<PetDTO> SearchPet(PetDTO petDTO);
        PetDTO UpdatePet(PetDTO petDTO);
        Task<PetDTO> DeletePet(PetDTO petDTO);
    }
}
