using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEficaz.Infraestrutura.Paginacao
{
    public class DataRetriever<T> : IDataPageRetriever<T>
    {
        private IPaginacaoRepository<T> _repo;

        public string Order
        {
            get => _repo.Order;
            set => _repo.Order = value;
        }

        public string WhereFiltro { get ; set ; }
        public string Pesquisa
        {
            get => _repo.Pesquisa;
            set => _repo.Pesquisa = value;
        }

        public int NumeroRegistros  => _repo.Count;

        public List<object> RegistrosMarcados { get; set; }
        

        public int GetPosicaoLinha(object id)
        {
            return _repo.GetPosicaoLinha(id);
        }

        public List<T> SupplyPageOfData(int offset, int limit)
        {
            return _repo.GetItens(limit, offset).ToList();
        }

        public IList<T> GetItens()
        {
           return _repo.GetItens().ToList();
        }

        public IList<M> Getids<M>()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<T>> GetItensAsync()
        {
           return  Task.Run< IList<T>>(()=> _repo.GetItens().ToList());
        }

        public DataRetriever(IPaginacaoRepository<T> paginacaoRepository )
        {
            _repo = paginacaoRepository;
        }
    }
}
