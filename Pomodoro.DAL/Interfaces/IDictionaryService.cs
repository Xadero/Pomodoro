namespace Pomodoro.DAL.Interfaces
{
    public interface IDictionaryService
    {
        T Get<T>(int id) where T : class;
    }
}
