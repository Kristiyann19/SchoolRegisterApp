namespace SchoolRegisterApp.Models.Common
{
    public interface IFilter<T>
    {
        IQueryable<T> WhereBuilder(IQueryable<T> query);
    }
}
