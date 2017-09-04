using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace MemoryCacheExample
{
    public class MemoireCache<T> where T : class
    {
        private MemoryCache _cache;

        public MemoireCache()
        {
            _cache = MemoryCache.Default;
        }

        public void AjouterObjet(string cle, T obj)
        {
            _cache.Add(cle, obj, DateTime.Now.AddMinutes(2));
        }

        public void AjouterObjet(string cle, IEnumerable<T> obj)
        {
            _cache.Add(cle, obj, DateTime.Now.AddMinutes(2));
        }

        public T ObtenirOuAjouterObjet(string cle, Func<T> func)
        {
            return _cache.LazyAddOrGetExitingItem<T>(cle, func, DateTime.Now.AddMinutes(2));
        }

        public IEnumerable<T> ObtenirOuAjouterListeObjet(string cle, Func<IEnumerable<T>> func)
        {
            return _cache.LazyAddOrGetExitingItem<IEnumerable<T>>(cle, func, DateTime.Now.AddMinutes(2));
        }

        public T GetObjet(string cle)
        {
            return _cache.Get(cle) as T;
        }

        public IEnumerable<T> GetListe(string cle)
        {
            return _cache.Get(cle) as IEnumerable<T>;
        }
    }
}
