import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
    name: 'dateFormatPipe',
})
export class dateFormatPipe implements PipeTransform {
    transform(value: string) {
        value = value + "";
        if (value === 'null' || value.length==0 || value.indexOf('Invalid') > -1) {
           value = '';     
        } else {
            var datePipe = new DatePipe("bg-BG");
            value = datePipe.transform(value, 'dd.MM.yyyy');
        }

        return value;
    }
}