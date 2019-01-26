
using GestaoEficaz.Infraestrutura.Paginacao;
using System;
using System.Collections.Generic;

namespace GPApp.Presenter.Grid
{
    public class GridInfoBuilder<T>
    {
        #region Membros privados

        private string _ordemSql;
        private int _numeroLinhas = 30;
        private IPaginacaoRepository<T> _repo;
        private string _nomeColuna = null;
        private string _tituloColuna = null;
        private int _tamanho = -1;
        private Type _tipo;
        private bool _permitir;
        private string _chavePrimaria = "Id";
        private TipoAlinhamentoColuna _eAlinhamento = TipoAlinhamentoColuna.Esquerda;
        private ColunaTipoAjuste _modo = ColunaTipoAjuste.Nenhum;
        private IList<ColunaInfo> _colunas = new List<ColunaInfo>();

        #endregion

        #region Construtor

        public GridInfoBuilder(string ordemSql)
        {
            _ordemSql = ordemSql;
        }

        #endregion

        #region Métodos builder

        public GridInfoBuilder<T> NumeroLinhas(int numeroLinhas)
        {
            _numeroLinhas = numeroLinhas;
            return this;
        }

        public GridInfoBuilder<T> Repository(IPaginacaoRepository<T> paginacaoRepository)
        {
            _repo = paginacaoRepository;
            return this;
        }
               
        public GridInfoBuilder<T> NomeColuna(string nomeColuna)
        {
            _nomeColuna = nomeColuna;
            return this;
        }
               
        public GridInfoBuilder<T> TituloColuna(string tituloColuna)
        {
            _tituloColuna = tituloColuna;
            return this;
        }

        public GridInfoBuilder<T> TamanhoColuna(int tamanho)
        {
            _tamanho = tamanho;
            return this;
        }

        public GridInfoBuilder<T> TipoColuna(Type tipo)
        {
            _tipo = tipo;
            return this;
        }

        public GridInfoBuilder<T> Alinhada(TipoAlinhamentoColuna tipo)
        {
            _eAlinhamento = tipo;
            return this;
        }

        public GridInfoBuilder<T> AutoSizeMode(ColunaTipoAjuste modo)
        {
            _modo = modo;
            return this;
        }

        public GridInfoBuilder<T> PermitirEditarColunas(bool permitir)
        {
            _permitir = permitir;
            return this;
        }
               
        public GridInfoBuilder<T> colunaChave(string chavePrimaria)
        {
            _chavePrimaria = chavePrimaria;
            return this;
        }

        #endregion

        #region Métodos

        public GridInfoBuilder<T> BuildColuna()
        {
            _colunas.Add(new ColunaInfo
            {
                NomePropriedade = _nomeColuna,
                Tamanho = _tamanho,
                Titulo = _tituloColuna,
                Type = _tipo,
                TipoAlinhamento = _eAlinhamento,
                TipoAjuste = _modo
            });

            DefineValoresPadroesConfColuna();

            return this;
        }

        private void DefineValoresPadroesConfColuna()
        {
            _nomeColuna = null;
            _tituloColuna = null;
            _tipo = null;
            _tamanho = -1;
            _eAlinhamento = TipoAlinhamentoColuna.Esquerda;
            _modo = ColunaTipoAjuste.Nenhum;
        }

        public GridConfig<T> Build()
        {
            _repo.Order = _ordemSql;

            return new GridConfig<T>(_repo, _colunas, _numeroLinhas)
            {
                ModoLeitura = _permitir,
                ColunaChave = _chavePrimaria
            };
        }

        #endregion
    }
}