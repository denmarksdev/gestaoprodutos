﻿using GPApp.Model;
using GPApp.Model.Helpers;
using GPApp.Repository;
using GPApp.Shared.Paginacao;
using GPApp.Wpf.Modulo.Produtos.ViewModels;
using GPApp.Wrapper;
using Moq;
using Prism.Regions;
using System.Windows;
using Xunit;

namespace GPApp.Wpf.Testes
{
    public class ProdutosView
    {
        private readonly Mock<IRegionNavigationService> _regionService;
        private NavigationContext _navContext;
        private Mock<IProdutoRepository> _produtoRepo;

        public ProdutosViewModel ViewModel { get; }

        public ProdutosView()
        {
            var regionManagerMock = new Mock<IRegionManager>();
            regionManagerMock.SetupAllProperties();
            var paginacaoRepositoryMock = new Mock<IPaginacaoRepository<ProdutoLookupWrapper>>();
            paginacaoRepositoryMock.SetupAllProperties();

            _produtoRepo = new Mock<IProdutoRepository>();
            _produtoRepo.SetupAllProperties();
            _produtoRepo.Setup(f => f.NumeroRegistrosSincronizarAsync())
                .ReturnsAsync( new Resultado<int>(3));

            _regionService = new Mock<IRegionNavigationService>();
            _regionService.SetupAllProperties();
            _navContext = new NavigationContext(_regionService.Object, new System.Uri("http://teste.com"));

            ViewModel = new ProdutosViewModel(
                    regionManagerMock.Object,
                    paginacaoRepositoryMock.Object,
                    _produtoRepo.Object);
        }

        [Fact]
        public void EscondePesquisaAoIniciarViewTeste()
        {
            Assert.Equal(
                Visibility.Hidden,
                ViewModel.ExibirPesquisa);

            Assert.Equal(
                Visibility.Hidden,
                ViewModel.ExibirDesativarFiltro);
        } 
        
        [Fact]
        public void ContarNumeroDeRegistrosParaSincronizacaoTeste()
        {
            ViewModel.OnNavigatedTo(_navContext);
            Assert.Equal(3 , ViewModel.NumeroRegistrosSincronizar);
        }
    }
}