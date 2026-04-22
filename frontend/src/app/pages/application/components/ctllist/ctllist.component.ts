import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from "@angular/core";
import { ControlContainer, FormControl, FormGroup } from "@angular/forms";
import { NgSelectConfig } from "@ng-select/ng-select";
import { ViewNom } from "../../../../@core/interfaces/common/nomenclatures";
import { NbAdjustableConnectedPositionStrategy, NbPosition, NbSelectComponent } from "@nebular/theme";

@Component({
  selector: "ngx-ctllist",
  templateUrl: "./ctllist.component.html",
  styleUrls: ["./ctllist.component.scss"],
})
export class CtlListComponent implements OnInit {
  public form: FormGroup;
  public control: FormControl;
  public NbPosition = NbPosition.TOP;

  @Output() selectionChanged: EventEmitter<ViewNom> =new EventEmitter<ViewNom>();

  @Input() controlName: string;
  @Input() items: ViewNom[] = [];
  @Input() disable: boolean = false;
  @Input() placeholder: string = "Изберете...";
  @Input() showclear: boolean = true;
  @Input() showabove: boolean = false;

  @ViewChild("select") select: NbSelectComponent;

  constructor(
    private controlContainer: ControlContainer,
    private config: NgSelectConfig
  ) {}

  ngOnInit(): void {
    this.form = <FormGroup>this.controlContainer.control;
    this.control = <FormControl>this.form.get(this.controlName);
    if (this.control.disabled == false && this.disable)
        this.control.disable();

    this.config.notFoundText = "Няма намерени елементи";
    this.config.appendTo = "body";
  }

  ngAfterViewInit(): void {

    if (this.showabove) {
      this.select["dropdownPosition"] = NbPosition.TOP
    }
  } 

  onSelectionChange(value: ViewNom) {
    this.selectionChanged.emit(value);
  }

  onBlur($event: Event) {
 //   console.log($event);
  }
}
