﻿namespace GPApp.Model
{
    public class ProdutoEspecificacao: BaseModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short Ordem { get; set; }
    }
}