using wijimo.Model;
namespace wijimo.Services
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car Get(int id);

        Task Save(Car car);
    }
}
