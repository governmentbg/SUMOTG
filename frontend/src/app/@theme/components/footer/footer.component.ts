import { Component } from '@angular/core';
import packageInfo  from '../../../../../package.json';

@Component({
  selector: 'ngx-footer',
  styleUrls: ['./footer.component.scss'],
  template: `
    <span class="created-by">Created by <b>
      <a href="" target="_blank">TbSoft</a></b> {{ currentYear }}, версия {{version}}
    </span>
  `,
})
export class FooterComponent {
  version: string = packageInfo.version;

  get currentYear(): number {
    return new Date().getFullYear();
  }
}
