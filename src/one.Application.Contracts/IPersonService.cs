using System.Threading.Tasks;

namespace one.Application.Contracts
{
    public interface IPersonService
    {
        Task<PersonDTO> GenerateRandomPersonAsync();
    }
}