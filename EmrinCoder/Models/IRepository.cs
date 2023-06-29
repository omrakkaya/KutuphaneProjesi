using System.Linq.Expressions;

namespace EmrinCoder.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filtre);
        void Ekle(T entity);//Add
        void Sil(T entity);//Remove
        void SilAralik(IEnumerable<T> entities);//RemoveRange
        //Allah aşkına burayı çokca tekrar et ve anla
    }
}
