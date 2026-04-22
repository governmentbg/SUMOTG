import { NbMenuItem } from '@nebular/theme';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';
import { ROLES } from '../@auth/roles';
import { PagesComponent } from './pages.component';

@Injectable()
export class PagesMenu {
      
  getMenu(role: string): Observable<NbMenuItem[]> {
    const menu: NbMenuItem[] = [
      {
          title: 'Кандидати',
          hidden: (role=== ROLES.GUEST),
          icon: 'book-open-outline',
          children: [
            {
                title: 'Формуляри',
                children: [
                    {
                        title: 'Индивидуални',
                        link: 'register/regfilter/1',
                        icon: {pack:"far", icon:"file"}
                    },
                    {
                        title: 'Колективи',
                        link: 'register/regfilter/2',
                        icon: {pack:"far", icon:"copy"}
                    },
                    {
                        title: 'Юридически лица',
                        link: 'register/regfilter/3',
                        icon: {pack:"far", icon:"file-alt"}
                    },
                ],
            },
            {
                title: 'Списък лица',
                link: 'register/regfilter/5',
                icon: 'list-outline'
            },
            {
                title: 'Списък юр.лица',
                link: 'register/regfilter/6',
                icon: 'list-outline'
            },
            {
                title: 'Договори лица',
                icon: {pack:"fas", icon:"file-contract"},
                link: 'register/regfilter/4',
                // children: [
                //     {
                //         title: 'Договори',
                //         link: 'register/regfilter/4',
                //     },
                //     {
                //         title: 'Прекратяване на договор',
                //         link: '/pages/register/sprfiltera/7/Прекратяване на договори',
                //     },
                //     {
                //         title: 'Прекратяване на собственост',
                //         link: '/pages/register/sprfiltera/8/Прекратяване на собственост',
                //     },
                //   ],
            },
            {
                title: 'Импорт на файл от Акстър',
                icon: 'download-outline',
                link: 'register/akster',
            },
            {
                title: 'Прекодиране на радиатори',
                icon: 'flip-outline',
                link: 'register/regfilter/7',
            },
        ],
      },
      {
          title: 'Изпълнители',
          hidden: !(role== ROLES.ADMIN || (role==ROLES.USER && PagesComponent.raion.length==0)),
          icon: 'people-outline',
          children: [
            {
                title: 'Договори',
                icon: 'file-text-outline',
                children: [
                    {
                        title: 'Монтаж',
                        link: 'firmcontracts/montazj',
                    },
                    {
                        title: 'Демонтаж',
                        link: 'firmcontracts/demontazj',
                    },
                  ],
            },
            {
                title: 'Поръчки',
                icon: 'repeat-outline',
                children: [
                    {
                        title: 'Mонтаж',
                        link: 'obrabotki/monorder',
                    },
                    {
                        title: 'Демонтаж',
                        link: 'obrabotki/demorder',
                    },                
                    {
                        title: 'Демонтаж отчети от "СОФЕКОСТРОЙ"',
                        link: 'obrabotki/demsofekostroi',
                    },                
                ],
            },
            {
                title: 'Фактури',
                icon: {pack:"fas", icon:"file-invoice"},                
                children: [
                    {
                        title: 'Mонтаж',
                        link: 'obrabotki/monfakturi',
                    },
                    {
                        title: 'Демонтаж',
                        link: 'obrabotki/demfakturi',
                    },                
                ],
            },
          ],
      },      
      {
        title: 'Профилактика',
        hidden: !(role== ROLES.ADMIN || (role==ROLES.USER && PagesComponent.raion.length==0)),
        icon: 'trending-up-outline',
        children: [
            {
                title: 'Списъци',
                icon: {pack:"fas", icon:"file-invoice"},
                link: '/pages/register/sprfiltera/12/Профилактика',
            },
            {
                title: 'Импорт на отчет',
                icon: 'download-outline',
                link: 'obrabotki/importprof',
            },
      ]},         
      {
          title: 'Справки',
          icon: {pack:"fas", icon:"chart-line"},
          link: 'spravki',
      },
      {
          title: 'Управление',
          icon: 'settings-outline',
          children: [
            {
                title: 'Номенклатури',
                icon: 'list-outline',
                link: 'nomenclatures',
            },
            // {
            //     title: 'Настройки',
            //     icon: 'settings-outline',
            //     hidden: (role!== ROLES.ADMIN),
            //     link: 'settings',
            // },
            {
                title: 'Потребители',
                icon: 'people-outline',
                hidden: (role!== ROLES.ADMIN),
                link: 'usersreg',
            },
            {
                title: 'Адреси от друг екологичен проект',
                icon: 'home-outline',
                hidden: (role!== ROLES.ADMIN),
                link: 'nomenclatures/extadreses',
            },
        ],
      },
      {
        title: 'Ръководства, инструкции, приложения',
        icon: 'question-mark-outline',
        link: 'help',
        children: undefined,
      },
      {
        title: 'За програмата',
        icon: 'award-outline',
        link: 'about',
        children: undefined,
      },
      {
          title: 'Изход',
          icon: 'unlock-outline',
          link: '/auth/logout',
          children: undefined,
      },
    ];

    return of([...menu]);
  }

}
