﻿using GPApp.Shared.Paginacao;
using System;
using System.Collections.Generic;

namespace GPApp.Presenter.Grid
{
    public class GridInfoBuilder<T>
    {
        #region Membros privados

        private readonly string _ordemSql;
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
        private readonly IList<ColunaInfo> _colunas = new List<ColunaInfo>();
        private bool _permitirOrdenar = true;
        private bool _exibir = true;
        private bool _ehChavePrimaria = false;

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
               
        public GridInfoBuilder<T> ColunaChave(string chavePrimaria)
        {
            _chavePrimaria = chavePrimaria;
            return this;
        }

        public GridInfoBuilder<T> PermitirOrdenar(bool permitir)
        {
            _permitirOrdenar = permitir;
            return this;
        }

        public GridInfoBuilder<T> Exibir(bool exibir)
        {
            _exibir = exibir;
            return this;
        }

        public GridInfoBuilder<T> ChavePrimaria()
        {
            _ehChavePrimaria = true;
            return this;
        }

        public GridInfoBuilder<T> IncluiColunaAlteracao()
        {
            _colunas.Add(ColunaInfo.BuildColunaAlteracao());
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
                TipoAjuste = _modo,
                PermitirOrdenar = _permitirOrdenar,
                ChavePrimaria = _ehChavePrimaria,
                Exibir = _exibir
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
            _permitirOrdenar = true;
            _ehChavePrimaria = false;
            _exibir = true;
        }

        public GridConfig<T> Build()
        {
            _repo.Ordem = _ordemSql;

            return new GridConfig<T>(_repo, _colunas, _numeroLinhas)
            {
                ModoLeitura = _permitir,
                ColunaChave = _chavePrimaria
            };
        }

        #endregion
    }
}   