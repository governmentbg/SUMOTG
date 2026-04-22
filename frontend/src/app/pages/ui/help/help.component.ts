import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import packageInfo  from '../../../../../package.json';
import { UserData } from '../../../@core/interfaces/common/users';

@Component({
  selector: 'ngx-help',
  templateUrl: './help.component.html',
  styleUrls: ['./help.component.scss']
})
export class HelpComponent implements OnInit {

  version: string = packageInfo.version;
  versdate: string = packageInfo.versdate;

  constructor(
    private toasterService: NbToastrService,
    private userService: UserData
  ) { }
  
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  downloadTutorial (){
    this.downloadFile('EkoUredi_User_manual.docx');
  }

  downloadTutorialMaket10 (){
    this.downloadFile('INSTRUKCIA_MAKET_10.docx');
  }
  
  downloadLIFE (){
    this.downloadFile('Обхват-LIFE.docx');
  }

  downloadPrilDogFl () {
    this.downloadFile('Приложения към договор с ФЛ.docx');
  }

  downloadPrilDogFirma() {
    this.downloadFile('Приложения към договор с ЮЛ.docx');
  }

  downloadAdressElFiltri() {
    this.downloadFile('Регистър на монт. електростатични филтри - 542 броя.docx');
  }

  downloadBlankaPrekDog() {
    this.downloadFile('Бланка ДС за прекратяване.docx');
  }

  downloadFile (filename: string) {
    this.userService
      .downloadFile(filename)
      .subscribe((response: any) =>{
          let dataType = response.type;
          let binaryData = [];
          binaryData.push(response);
          let downloadLink = document.createElement('a');
          downloadLink.href = window.URL.createObjectURL(new Blob(binaryData, {type: dataType}));
          if (filename)
              downloadLink.setAttribute('download', filename);
          document.body.appendChild(downloadLink);
          downloadLink.click();
      },
      error => {
        this.handleWrongResponse();
      });
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при генерирането на дикумента!`);
  }
}
