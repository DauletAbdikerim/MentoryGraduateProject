namespace GraduateProject.Services.Interfaces
{
    public interface IOrder
    {
        void TakeBook(Guid bookId, Guid userId);
    }
   
}
