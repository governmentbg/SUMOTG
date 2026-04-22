import { Component, OnInit } from '@angular/core';
import packageInfo  from '../../../../../package.json';

@Component({
  selector: 'ngx-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {

  version: string = packageInfo.version;
  versdate: string = packageInfo.versdate;

  constructor() { }

  ngOnInit(): void {
  }

}
