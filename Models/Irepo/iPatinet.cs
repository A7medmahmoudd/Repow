using Clinic.Models.Entites;

namespace Clinic.Models.Irepo
{
    public interface iPatinet
    {

        public Task<IEnumerable<Patinet>> Getall();

        public Task adddpa(Patinet patinet);

        public Task updatepa(Patinet patinet);

        public Task deletepa(Patinet patinet);

        public Task<Patinet> getbypa(int id);
    }
}
