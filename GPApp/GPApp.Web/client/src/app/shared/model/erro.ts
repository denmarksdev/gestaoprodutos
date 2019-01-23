export class ErroValidacao {

    constructor(campo:string, descricao:string) {
        this._campo = campo;
        this._descricao = descricao;
    }

    private _campo:string;
    get campo ():string {
        return this._campo;
    }

    private _descricao:string;
    get descricao():string {
        return this._descricao;
    }
}