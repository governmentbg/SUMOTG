import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formArrayFilterPipe'
})
export class FormArrayFilterPipe implements PipeTransform {

    public transform(values: any[], filter: string): any[] {         
        if (!values || !values.length)  return []; 
        
        if (filter)         
            return values.filter(v=> v.get('ime').value.toLocaleLowerCase().indexOf(filter.toLocaleLowerCase()) > -1 ||
                                    v.get('unom').value.toLocaleLowerCase().indexOf(filter.toLocaleLowerCase()) > -1);
        else
            return values;
    }
}