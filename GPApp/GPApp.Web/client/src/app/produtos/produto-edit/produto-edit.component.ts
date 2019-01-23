import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar, _MatChipListMixinBase, _MatToolbarMixinBase } from '@angular/material';
import { ImagemService } from 'src/app/shared/helpers/imagem.service';
import { ProdutoImagem, Produto, ProdutoEspecificacao } from '../produto-model';
import { ProdutoBo } from 'src/app/produtos/produto-business';
import { FotoUploadComponent } from 'src/app/shared/componentes/foto-upload/foto-upload.component';
import { ErroValidacao } from 'src/app/shared/model/erro';
import { FotoInfo } from 'src/app/shared/componentes/foto-upload/foto-upload-model';
import createNumberMask from 'text-mask-addons/dist/createNumberMask'
import { ProdutoStoreService } from '../produto-store.service';
import { EMPTY_GUID } from 'src/app/shared/helpers/guid.helper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produto-edit',
  templateUrl: './produto-edit.component.html',
  styleUrls: ['./produto-edit.component.scss']
})
export class ProdutoEditComponent implements OnInit {

  constructor(
    public snack: MatSnackBar,
    public imagemService: ImagemService,
    private _store:ProdutoStoreService,
    private _router:Router
  ) { }

  @ViewChild('fotoUpload') fotoUpload: FotoUploadComponent;

  private _produtoBo: ProdutoBo;
  private _alteracaoImagem: boolean = false;

  get produto(): Produto {
    return this._produtoBo.produto;
  }

  public imagemSelecionada: ProdutoImagem;
  public especificacaoSelecionada: ProdutoEspecificacao;
  public url: string = "";
  public erros: Array<ErroValidacao>;
  public salvandoProduto:boolean;
  public maskDecimal = createNumberMask({
    prefix:'',
    decimalSymbol:',' ,
    period:'.',
    allowDecimal:true
  });  
  public maskInteiro = createNumberMask({
    prefix:'',
    allowDecimal:false,
    thousandsSeparatorSymbol:'.'
  });  

  public quantidade:number = 0;

  ngOnInit() {
    this._produtoBo = new ProdutoBo();
  }

  onSalvar() {
    this.erros = this._produtoBo.valida()
    if (this.erros.length > 0) return;
    this.salvandoProduto = true;

    this._store.post(this.produto)
    .subscribe(()=>{
      this.salvandoProduto = false;
      this._router.navigate(['/produtos']);
    }, error=> {
      console.log(error);
      this.snack.open("Falha ao enviar os dados do produto.")
      this.salvandoProduto = false;
    })
  }

  //#region Imagens
  OnFotoChange(info: FotoInfo) {
    if (info.preview == undefined) return;

    if (this._alteracaoImagem) {
      this.imagemSelecionada.dados = info.byteArray;
      this.imagemSelecionada.preview = info.preview;
      this._alteracaoImagem = false;
    } else {
      let novaImagem: ProdutoImagem = {
        id: EMPTY_GUID,
        dados: info.byteArray,
        ordem: this._produtoBo.geraProximaOrdemDaImagem(),
        preview: info.preview,
      }
      this.imagemSelecionada = novaImagem;
      this.produto.imagens.push(novaImagem);
    }
  }

  defineImagemSelecionada(imagem: ProdutoImagem) {
    this.imagemSelecionada = imagem;
    this.url = imagem.preview;
  }

  onExcluirImagem(imagem: ProdutoImagem) {
    this.snack
      .open("Excluir imagem?", "sim", { duration: 2000 })
      .onAction().subscribe(() => {
        this._produtoBo.excluirImagem(imagem);
        this.url = "";
      })
  }

  onAlterarImagem(imagem: ProdutoImagem) {
    this._alteracaoImagem = true;
    this.fotoUpload.performClick();
  }

  //#endregion

  //#region Especicações
  incluirEspecificacao() {
    let especificacao: ProdutoEspecificacao = {
      id:  EMPTY_GUID,
      nome: "",
      descricao: "",
      ordem: this._produtoBo.geraProximaOrdemDaEspecificacao(),
    }
    this.especificacaoSelecionada = especificacao;
    this.produto.especificacoes.push(especificacao);
  }

  onExcluirEspecificacao(especificacao: ProdutoEspecificacao) {
    this.snack.open("Excluir especificação?", "Sim")
      .onAction()
      .subscribe(() => {
        this._produtoBo.excluirEspecificacao(especificacao);
      });
  }

  //#endregion
}