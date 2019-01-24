import { Produto, ProdutoImagem, ProdutoEspecificacao } from './produto-model';
import { ErroValidacao } from '../shared/model/erro';
import { EMPTY_GUID } from '../shared/helpers/guid.helper';
import { DateHelper } from '../shared/helpers/date.helper';

export class ProdutoBo {

    public produto:Produto;

    constructor() {
        this.init();
    }

    private init(){
        this.produto = {
            id: EMPTY_GUID,
            codigo: '',
            nome: '',
            descricao: '',
            custo: 0,
            preco: 0,
            dataCadastro: new DateHelper().geraDataAtual(),
            imagens: new Array<ProdutoImagem>(),
            especificacoes: new Array<ProdutoEspecificacao>(),
            estoqueAtual: {
                id:EMPTY_GUID,
                lancamento : new DateHelper().geraDataAtual(),
                produtoId: EMPTY_GUID,
                quantidade:0
            }
          }
    }

    geraProximaOrdemDaEspecificacao(): number {

        let totalOrdem = 0;
        this.produto.imagens.forEach(imagem => {
            totalOrdem += 1
        });
        return totalOrdem + 1;
    }

    reordenar(itens:Array<any>){
        for (let index = 0; index < itens.length; index++) {
            itens[index].ordem = (index + 1);
        }
    }

    geraProximaOrdemDaImagem(): number {
        let totalOrdem = 0;
        this.produto.imagens.forEach(imagem => {
            totalOrdem += 1
        });
        return totalOrdem + 1;
    }

    excluirImagem(imagem: ProdutoImagem): any {
        const indice = this.produto.imagens.indexOf(imagem);
        this.produto.imagens.splice(indice, 1)
        this.reordenar(this.produto.imagens);
    }

    excluirEspecificacao(especificacao:ProdutoEspecificacao){
        const indice = this.produto.especificacoes.indexOf(especificacao);
        this.produto.especificacoes.splice(indice, 1)
        this.reordenar(this.produto.especificacoes);
    }

    valida():Array<ErroValidacao> {
        let erros = new Array<ErroValidacao>();

        console.log("Preco " + this.produto.preco + " " + this.produto.custo + " " + (this.produto.preco < this.produto.custo));
        console.log("Custo " + this.produto.custo);

        if (this.produto.nome.length == 0){
            erros.push(new ErroValidacao("Nome", "Campo obrigatório"));
        }
        if (this.produto.descricao.length == 0){
            erros.push(new ErroValidacao("Descrição", "Campo obrigatório"));
        }
        if (this.produto.preco == 0){
            erros.push(new ErroValidacao("Preço", "Deve ser maior que zero"));
        }else if (this.produto.preco < this.produto.custo){
            erros.push(new ErroValidacao("Preço", "Deve ser maior que o igual ao custo"));
        }

        if (this.produto.custo == 0){
            erros.push(new ErroValidacao("Custo", "Deve ser maior que zero"));
        }else if (this.produto.custo > this.produto.preco){
            erros.push(new ErroValidacao("Custo", "Deve ser menor ou igual ao preço"));
        }
        
        return erros;
    }
}