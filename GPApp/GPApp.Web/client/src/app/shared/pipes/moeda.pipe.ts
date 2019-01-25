import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'moeda'
})
export class MoedaPipe implements PipeTransform {

  transform(value: number, casasDecimais:number= 2 ): any {

    if (!value) return '0';
    return "R$" + value.toFixed(casasDecimais).replace(".",",")
  }
}
