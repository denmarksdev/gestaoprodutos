export class DateHelper {

    // Formato da data yyyy/mm/dd hh:mm:ss PM|AM
    geraDataAtual(){
        var dataAtual = new Date();
        return `${this.formataValor(dataAtual.getFullYear())}/${ this.formataValor(dataAtual.getMonth() + 1 )}/${this.formataValor(dataAtual.getDay())} ${this.formatAMPM(dataAtual)}`;
    }

    private formatAMPM(date) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0'+minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        return strTime;
     }

     private formataValor(valor:number ){
         return valor.toString().padStart(2, "0");
     }
}