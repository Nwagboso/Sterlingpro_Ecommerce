namespace Sterlingpro_Ecommerce.Repositories
{
   
    public interface IOrderRepository
    {
        Task SubmitOrderAsync(int userId);
    }
}
