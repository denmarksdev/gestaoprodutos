import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { FotoInfo } from './foto-upload-model';
import { ImagemService } from '../../helpers/imagem.service';
import { MatButton } from '@angular/material';

@Component({
  selector: 'app-foto-upload',
  templateUrl: './foto-upload.component.html',
  styleUrls: ['./foto-upload.component.scss']
})
export class FotoUploadComponent implements OnInit {

  constructor(
    private _imagemService: ImagemService
  ) {
    this.texto = "Incluir imagem";
  }

  @ViewChild("buttonImage") button: MatButton
  @ViewChild("fileInput") fileInput: HTMLInputElement

  private _url: string = '';
  @Input()
  set url(url: string) {
    this._url = url;
  }
  get url(): string {
    return this._url;
  }

  private _texto: string = '';
  @Input()
  set texto(texto: string) {
    this._texto = texto;
  }
  get texto(): string {
    return this._texto;
  }

  @Output()
  public change: EventEmitter<FotoInfo> = new EventEmitter<FotoInfo>();
  public preview: string;

  ngOnInit() {
    this.preview = 'assets/imagens/sem-imagem.jpeg';
  }

  onFileChanged(event) {

    let file: File = event.target.files[0];
    const reader = new FileReader();
    event.target.value = "";
    reader.onload = (event: any) => {

      let extensaoArquivo = file.name
        .substring(file.name.length - 4)
        .replace('.', '');

      let base64Image = event.target.result;
      this.url = base64Image;
      this._imagemService.comprimir(file).subscribe(base64 => {

        const informacoes: FotoInfo = {
          byteArray: this._imagemService.converBase64TotBytes(base64Image),
          preview: base64,
          extensaoArquivo: extensaoArquivo
        }
        this.change.emit(informacoes)
        event.target.value = "";
      })
    }
    reader.readAsDataURL(file);
  }

  performClick() {
    this.button._elementRef.nativeElement.click();
  }
}