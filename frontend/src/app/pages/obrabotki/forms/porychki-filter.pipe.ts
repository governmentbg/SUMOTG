import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'porychkiFilterPipe',
  pure: false
})
export class PorychkiFilterPipe implements PipeTransform {

  transform (items: any[], searchId: number): any[] {
    if(!items) return [];
    if(!searchId) return items;

    return items.filter(it => it.value.idured == searchId);
  }

}