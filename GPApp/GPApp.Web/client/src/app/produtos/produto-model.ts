export interface ProdutoLookup {
    id:string,
    codigo:string,
    nome:string,
    preco:number
    dataCadastro:string
}

export interface Produto extends ProdutoLookup {
    descricao:string,
    custo:number,
    precoPromocional:number,
    imagens : Array<ProdutoImagem>,
    especificacoes: Array<ProdutoEspecificacao>,
    estoqueAtual: ProdutoEstoque
}

export interface ProdutoImagem {
    id:string,
    dados:string,
    preview:string,
    ordem:number,
    sufixo:string
}

export interface ProdutoEspecificacao {
    id: string,
    nome:string,
    descricao:string,
    ordem:number
}

export interface ProdutoEstoque {
    id: string,
    quantidade: number,
    produtoId:string,
    lancamento:string
}