import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ControlContainer, FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NbDialogService } from '@nebular/theme';
import Swal from 'sweetalert2';
import { DogovorUredi, ObrabotkaData } from '../../../../@core/interfaces/common/obrabotki';
import { DemordereditDialogComponent } from '../demorderedit-dialog/demorderedit-dialog.component';

@Component({
  selector: 'ngx-demorder-order',
  templateUrl: './demorder-order.component.html',
  styleUrls: ['./demorder-order.component.scss']
})
export class DemorderOrderComponent implements OnInit {
  public form: FormGroup;
  public porychkaitems: FormArray

  @Input() uredi: DogovorUredi[];
  @Input() iddogovorfirma: number;
  @Output() public statusChanged = new EventEmitter<boolean>();

  constructor(
    private controlContainer: ControlContainer,
    private dialogService: NbDialogService,
    private fb: FormBuilder,
    private obrabotkiService: ObrabotkaData,
  ) { }

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.porychkaitems = this.form.get("porychkaitems") as FormArray;    
  }

  addPersPersDogUred() {
    this.statusChanged.emit(true);

    const nkod = this.form.get('raion').value;
    const idporychka = this.form.get('idporychkamain').value;
    const idmonporychka = this.form.get('idmonporychka').value;

    let selected = [];
    let items =  (this.porychkaitems as FormArray) 

    items.controls.forEach((form: FormGroup) => { 
        let idlice =  form.get('idl') ? form.get('idl').value : 0;
        if (selected.findIndex(x => x == idlice) == -1)
            selected.push(idlice);
    })
    
    this.dialogService
        .open(DemordereditDialogComponent
                          , { hasBackdrop: true,
                              closeOnBackdropClick: true,
                              hasScroll: false,
                              context: {
                                idporychka: idporychka,
                                idmonporychka: idmonporychka,
                                iddogovorfirma: this.iddogovorfirma, 
                                raion: nkod, 
                                selectedItems: selected
                              },
                            })
        .onClose.subscribe(x => {
          if (x) {
            this.addPorychkaItems(x);
          }
          
          this.statusChanged.emit(false);
        });                         
  }

  addPorychkaItems(items: any) { 
    items.filter(async x => {
      if (x.ischeck) {
        let iddogovorfirma = this.form.get('iddogovorfirma').value;
        let canAdd = true;          

        this.porychkaitems.controls.forEach((form: FormGroup, index) => {  
          let idlice =  form.get('idl') ? form.get('idl').value : 0
          if (idlice === x.idL ) {
            canAdd = false;
          }
        })
    
        if (canAdd) {
          await this.obrabotkiService
              .getDemonPersonUredi(iddogovorfirma, x.idL)
              .subscribe(result => {
                  result.forEach((t) => {
                    var ured =  this.createFormItem();
                
                    var ured = this.fb.group({
                      idporychkabody:0,
                      iddogovorlice: t.iddogovorlice,
                      idl: t.idL,
                      idured: t.idured,
                      broi: t.broi,
                      ident: t.ident,
                      ime: t.ime,
                      vidimot: t.vidimot,
                      adres: t.adres,
                      email: t.email,
                      telefon: t.telefon,
                      uredname: t.uredname,
                      unom: t.unom,
                      dodata: null,
                      otchas:'',
                      dochas:'',
                      note:'',
                      mondata: null,
                      status_g: 0,
                      status_m: 0,
                      status: 1,
                      snimka: '',
                      vidured: t.vidured,
                      raion: t.raion,
                      note2:''
                    })

                  this.porychkaitems.push(ured);

                  let idx = this.uredi.findIndex(x => x.id == t.idured);
                  this.uredi[idx].broiporychani = this.uredi[idx].broiporychani + t.broi;
                  this.uredi[idx].currentbroi = this.uredi[idx].currentbroi + t.broi;
                  this.uredi[idx].maxbroi = this.uredi[idx].broi - this.uredi[idx].broiporychani;
              })        
          });        
        }  
      }        
    });
  }

  createFormItem(): FormGroup {
    return new FormGroup({
      iddogovorlice: new FormControl(0),
      idured: new FormControl(0),
      broi: new FormControl(0),
      idL: new FormControl(0),
      ident: new FormControl(''),
      ime: new FormControl(''),
      vidimot: new FormControl(''),
      adres: new FormControl(''),
      email: new FormControl(''),
      telefon: new FormControl(''),
      ischeck: new FormControl(0),
      unom: new FormControl(''),
      uredname: new FormControl(''),
    });
  }


  removeItem(item: FormGroup) {
    Swal.fire({
      title:'<h5 style="padding-left:0px;color:#F8BB86">Сигурни ли сте?</h5> ',
      text: 'Искате да изтриете избраната поръчка!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Да, изтриване!',
      cancelButtonText: 'Отказ',
    }).then((result) => {
      if (result.isConfirmed) {
        let idporychkamain = this.form.get('idporychkamain').value;
        let iddogovor = item.get('iddogovorlice').value;
    
        this.obrabotkiService
            .delDemonUrediDogovor(idporychkamain, iddogovor)
            .subscribe((result) => {
              this.removePorychka(iddogovor)
        });
      }
    });
  }

  removePorychka(iddogovor: number) {
    let items = this.fb.array([]);

    this.porychkaitems.controls.forEach((form: FormGroup, index) => {  
      let obj =  form.get('iddogovorlice') ? form.get('iddogovorlice').value : 0
      if (obj === iddogovor ) {
        let broi = form.get('broi').value; 
        let idured = form.get('idured').value; 

        let idx = this.uredi.findIndex(x => x.id == idured);
        this.uredi[idx].broiporychani = this.uredi[idx].broiporychani - broi;
        this.uredi[idx].currentbroi = this.uredi[idx].currentbroi - broi;
        this.uredi[idx].maxbroi = this.uredi[idx].broi - this.uredi[idx].broiporychani;
      } else {
        items.push(form)
      }
    })          

    this.porychkaitems.clear();
    items.controls.forEach((form: FormGroup, index) => {            
      this.porychkaitems.push(form);
    });  
  }

}
