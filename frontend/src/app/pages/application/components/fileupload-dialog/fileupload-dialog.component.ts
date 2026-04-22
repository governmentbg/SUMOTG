import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NbDialogRef, NbToastrService } from '@nebular/theme';
import { DocumentsData, FileToUpload } from '../../../../@core/interfaces/common/documents';
import { NomenclatureData, ViewNom } from '../../../../@core/interfaces/common/nomenclatures';

@Component({
  selector: 'ngx-fileupload-dialog',
  templateUrl: './fileupload-dialog.component.html',
  styleUrls: ['./fileupload-dialog.component.scss'],
})
export class FileUploadDialogComponent implements OnInit {
  idDog: number = 0; 
  typeDoc: number = 0; 
  EditForm: FormGroup;
  vlistdocs:  ViewNom[];
  theFile: any = null;

  constructor(
    protected ref: NbDialogRef<FileUploadDialogComponent>,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService,
    private documentService: DocumentsData
  ) {
    this.EditForm = new FormGroup({
      'text': new FormControl(''),
      'filename': new FormControl('',[Validators.required]),
      'status':new FormControl(1)                
    });
  }

  ngOnInit(): void {
    this.loadDocuments();
  }

  loadDocuments() {
    this.nomenclatureService
      .getNomenObshti('09')
      .subscribe(result => {
          this.vlistdocs = result.map(item => new ViewNom().convertNomObshti(item));
      });
  }

  dismiss() {
    this.ref.close();
  }

  save() {
    this.readAndUploadFile();    
  }

  onFileSelected(event) {
    if(event.target.files.length > 0) {
       this.EditForm.get('filename').setValue(event.target.files[0].name);
       this.theFile = event.target.files[0];
    }
  }  

  private readAndUploadFile() {
    let file = new FileToUpload();    
    const obj = this.EditForm.value;

    // Set File Information
    file.idDog = this.idDog;
    file.docType = this.typeDoc;
    file.fileName = this.theFile.name;
    file.fileSize = this.theFile.size;
    file.fileType = this.theFile.type;
    file.description = this.EditForm.get('text').value;

    let reader = new FileReader();
  
    reader.onload = () => {
        file.fileAsBase64 = reader.result.toString();
        
        this.documentService.uploadFile(file).subscribe(resp => { 
           this.toasterService.success('', `Файлът е добавен успешно!`);
           this.ref.close(this.EditForm.value);
        });    
    }
    reader.readAsDataURL(this.theFile);
  }
} 
