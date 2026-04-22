import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { NomenclatureData, NomKmetstvo } from '../../../@core/interfaces/common/nomenclatures';
import { EditKmetstvaDialogComponent } from './edit-dialog/edit-dialog.component';

@Component({
  selector: 'ngx-kmetstva',
  templateUrl: './kmetstva.component.html',
  styleUrls: ['./kmetstva.component.scss'],
})
export class KmetstvaComponent implements OnInit {
  nomcode: string = '';
  name: string = '';
  disable: boolean = false;

  items: NomKmetstvo [] = [];
  page = 1;
  pageSize = 15;

  constructor(
    private dialogService: NbDialogService,
    private router: Router,
    private route: ActivatedRoute,
    private nomenclatureService: NomenclatureData,
    private toasterService: NbToastrService
  ) {
    this.route.paramMap.subscribe( params => {
      this.nomcode = String(params.get('nomcode'));
      this.name = String(params.get('name'));
      this.disable = String(params.get('disable')) === 'true';
      
      if (this.nomcode !== '') {
        this.loadNomen();
      }
    });
  }

  ngOnInit(): void {
    this.loadNomen();
  }

  loadNomen() {
    this.nomenclatureService
    .getAllNomenKmetstva()
    .subscribe(result => {
      this.items = result;
    });
  }

  addItem() {
    this.dialogService.open(EditKmetstvaDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: ''},
                      })
        .onClose.subscribe(x => {
          if (x) this.loadNomen()
        });                      
  }

  editItem($data: NomKmetstvo) {
      this.dialogService.open(EditKmetstvaDialogComponent
                      , { hasBackdrop: true,
                        closeOnBackdropClick: true,
                        hasScroll: false,
                        context: {id: $data.nkod},
                      })
          .onClose.subscribe(x => {
              if (x) this.loadNomen()
          });                      
  }

  removeItem($data: NomKmetstvo) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Искате да изтриете избраният запис!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтриване!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        this.nomenclatureService.delRowNomenKmetstva( $data.nkod).subscribe(r=> {
            if (r) {
              this.handleSuccessResponse();
              this.loadNomen();
            } else {
              this.handleWrongResponse();
            }
          }) 
      }   
    });
  }

  handleSuccessResponse() {
    this.toasterService.success('', `Успешно беше изтрит записа.`);
  }

  handleWrongResponse() {
    this.toasterService.danger('', `Грешка при изтриване!`);
  }

  back() {
    this.router.navigate(['pages/nomenclatures']);
  }
}
