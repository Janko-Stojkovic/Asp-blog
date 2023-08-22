using ASP_Projekat.Application.UseCases;

namespace ASP_Projekat.Application.UseCaseHandling
{
    public interface IQueryHandler
    {
        TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class;
    }
}