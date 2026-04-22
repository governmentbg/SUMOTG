import { AbstractControl, FormArray, FormGroup } from '@angular/forms';

export  function findInvalidControlsRecursive(formToInvestigate:FormGroup|FormArray):string[] {
    var invalidControls:string[] = [];
    let recursiveFunc = (form:FormGroup|FormArray, name: string, parent: string) => {
      Object.keys(form.controls).forEach(field => { 

      const control = form.get(field);
      if (control instanceof FormGroup) {
          recursiveFunc(control, field, name);
        } else if (control instanceof FormArray) {
          recursiveFunc(control, field,name);
        } else if (control.invalid) {
          let preffix = (parent ? parent+':' : '')+
                        (name ? name+':' : '')
          invalidControls.push(preffix+field);
        }    
      });
    }
    recursiveFunc(formToInvestigate,'','');
    return invalidControls;
}


export function getErrorMessage (e: string, prefix: string): string {
  let message = '';
  let fullerror = prefix+e

  if (fullerror.indexOf('lice:ident') > -1)
    message = "Невалидно ЕГН/ЛНЧ на титуляр."
  else if (fullerror.indexOf('lice:ime') > -1)
    message = "Не е попълнено името на титуляра"
  else if (fullerror.indexOf('lice:nomLk') > -1)
    message = "Не е попълненa лична карта на титуляра"    
  else if (fullerror.indexOf('lice:dataIzdavane') > -1)
    message = "Невалидна дата."    
  else if (fullerror.indexOf('lice:admRaion') > -1)
    message = "Не е попълнен района"
  else if (fullerror.indexOf('lice:nasMqsto') > -1)
    message = "Не е попълнено населеното място"
  else if (fullerror.indexOf('telefon') > -1)
    message = "Не е попълнен телефона"      
  else if (prefix+e == 'firma:ident')
    message = "Невалиден БУЛСТАТ на фирма"
  else if (prefix+e == 'firma:ime')
    message = "Не е попълнено името на фирмата"
  else if ((fullerror.indexOf('olduredi')> -1 && fullerror.indexOf(':id') > -1) ||
            (fullerror.indexOf('olduredi')> -1 && fullerror.indexOf(':broi') > -1))
    message = "Невъведени данни за уреди за демонтаж (Въпрос 18)"
  else if ((fullerror.indexOf('uredi')> -1 && fullerror.indexOf(':id') > -1) ||
           (fullerror.indexOf('uredi')> -1 && fullerror.indexOf(':broi') > -1))
    message = "Невъведени данни за уреди за монтаж (Въпрос 43)"
  else if (e == 'nv9')
    message = "Грешка въпрос 9"
  else if (e == 'v12')
    message = "Грешка въпрос 12"
  else if (e == 'v13')
    message = "Грешка въпрос 13"
  else if (e == 'v14')
    message = "Грешка въпрос 14"
  else if (e == 'v32')
    message = "Грешка въпрос 32"
  else if (e == 'v33')
    message = "Грешка въпрос 33"
  else if (e == 'unomer')
    message = "Грешен номер на формуляр"
  else  
    message = "Не е попълнено задължително поле"
  return message;  
}

export function getDogovorErrorMessage (e: string): string {
    let message = '';
    if (e == 'regnom')
      message = "Не е попълнен номер на договора."
    else if (e == 'regnomdata')
      message = "Не е попълнена дата на договора"
    else if (e == 'cenabezdds')
      message = "Не е попълнена цената без ДДС"
    else if (e == 'cenadds')
      message = "Не е попълнена цената с ДДС"
    else if (e == 'firma:eik')
      message = "Невалиден БУЛСТАТ на фирма"
    else if (e == 'firma:ime')
      message = "Не е попълнено името на фирмата"
    else if (e == 'firma:admRaion')
      message = "Не е попълнен района"
    else
      message = "Не е попълнено задължително поле"

    return message;  
}

export function getFakturaErrorMessage(e:string): string {
  let message = 'Не е попълнено задължително поле';
  return message;  
}