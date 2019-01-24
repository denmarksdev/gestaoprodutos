import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImagemService {

  constructor() { }

  comprimir(file: File , width = 600) : Observable<string> {
    console.log("Comprimindo ...")

    const reader = new FileReader();
    reader.readAsDataURL(file);
    return Observable.create(observer => {
      reader.onload = ev => {
        const img = new Image();
        img.src = (ev.target as any).result;
        (img.onload = () => {
          const elem = document.createElement('canvas'); // Use Angular's Renderer2 method
          const scaleFactor = width / img.width;
          elem.width = width;
          elem.height = img.height * scaleFactor;
          const ctx = <CanvasRenderingContext2D>elem.getContext('2d');
          ctx.drawImage(img, 0, 0, width, img.height * scaleFactor);
          var dados = ctx.canvas.toDataURL("image/png");
          observer.next(dados);
        }),
          (reader.onerror = error => observer.error(error));
      };
    });
  }

  converBase64TotBytes(base64:string):Uint8Array{
    var bytes = new Uint8Array(new ArrayBuffer(base64.length));
    for (var i = 0; i < base64.length; i++) {
      bytes[i] = base64.charCodeAt(i);
    }
    return  bytes;
  }
  
  // comprimir(file: File , width = 600): Observable<any> {
    
  //   const reader = new FileReader();
  //   reader.readAsDataURL(file);
  //   return Observable.create(observer => {
  //     reader.onload = ev => {
  //       const img = new Image();
  //       img.src = (ev.target as any).result;
  //       (img.onload = () => {
  //         const elem = document.createElement('canvas'); // Use Angular's Renderer2 method
  //         const scaleFactor = width / img.width;
  //         elem.width = width;
  //         elem.height = img.height * scaleFactor;
  //         const ctx = <CanvasRenderingContext2D>elem.getContext('2d');
  //         ctx.drawImage(img, 0, 0, width, img.height * scaleFactor);
  //         ctx.canvas.toBlob(
  //           blob => {
  //             observer.next(
  //               new File([blob], file.name, {
  //                 type: 'image/jpeg',
  //                 lastModified: Date.now(),
  //               }),
  //             );
  //           },
  //           'image/jpeg',
  //           1,
  //         );
  //       }),
  //         (reader.onerror = error => observer.error(error));
  //     };
  //   });
  // }

  convertFileBase64(file:File): Observable<any> {
    console.log("Convertendo ...")

    const reader = new FileReader();
    reader.readAsDataURL(file);
    return Observable.create( (observer) => {
      reader.onload = (ev:any) =>{
        observer.next(ev.target.result);
      }
    })

  }

}