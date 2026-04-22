export interface Filter {
    raionid: string,
    tipuredi: string,
    uredi: string,
    olduredi: string,
    statusL: number,
    statusF: number,
    statusDL: number,
    statusU: number, 
    faza: number,
    descript: string,
    txtfilter: string,
    disable: boolean,
    unomer: number,
    regnom: string,
    adres: string,
    vid: number,
    firma?: number,
    dogovor?: number,
    statusDU?: number, 
    demfirma?: number,
    demdogovor?: number,
    dpregnom?: string,
    viddpspor?: number,
    limit?: number,
    vidformulqr?: number
    vidportret?: number

}
 

export interface FilterSettings {
    title: string,
    vidfilter: number,
    storageKey: string,
    showAllFaza: boolean,
    filters: {
        faza: boolean,
        raion: boolean,
        unomer: boolean,
        tipuredi?: boolean,
        tipuredi1?: boolean,
        tipuredi2?: boolean,
        tipuredi3?: boolean,
        uredi: boolean,
        olduredi: boolean,
        statusL: boolean,
        statusF: boolean,
        statusDL: boolean,
        statusU: boolean,
        regnom: boolean,
        adres: boolean,    
        vid: boolean,        
        firma?: boolean,
        dogovor?: boolean,
        statusDU?: boolean, 
        demfirma?: boolean,
        demdogovor?: boolean,
        dpregnom?: boolean,
        viddpspor?: boolean,
        limit?: boolean,        
        vidformulqr?: boolean,
        vidportret?:boolean
    }
}

export const EmptyFilter = {
    title: '',
    vidfilter: 0,
    storageKey: '',
    showAllFaza: false,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const RegFilter1 = {
    title: 'индивидуални формуляри',
    vidfilter: 1,
    storageKey: 'register1',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};


export const RegFilter2 = {
    title: 'формуляри за колективно решение за отопление',
    vidfilter: 2,
    storageKey: 'register2',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};


export const RegFilter3 = {
    title: 'формуляри за юридически лица',
    vidfilter: 3,
    storageKey: 'register3',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const ListPersons = {
    title: 'списък лица',
    vidfilter: 2,
    storageKey: 'listpersons',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};


export const ListFirms = {
    title: 'списък юридически лица',
    vidfilter: 2,
    storageKey: 'listfirms',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const DogovorFilter = {
    title: 'договори с лица',
    vidfilter: 4,
    storageKey: 'dogfilter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: true,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: true,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const RadPrekodFilter = {
    title: 'Прекодиране на радиатори',
    vidfilter: 7,
    storageKey: 'radprekodfilter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: true,
        unomer: true,
        tipuredi2: true,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: true,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
}

export const Spravka2Filter = {
    title: '2. заявени уреди',
    vidfilter: 11,
    storageKey: 'spravka2filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: true,
        uredi: true,
        olduredi: true,
        statusL: false,
        statusF: true,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka3Filter = {
    title: '3. договорирани уреди',
    vidfilter: 12,
    storageKey: 'spravka3filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: true,
        uredi: true,
        olduredi: true,
        statusL: false,
        statusF: false,
        statusDL: true,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: true,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka4Filter = {
    title: '4. формуляри по статуси',
    vidfilter: 13,
    storageKey: 'spravka4filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: true,
        statusF: true,
        statusDL: true,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka5Filter = {
    title: '5. лица и уреди по статуси',
    vidfilter: 14,
    storageKey: 'spravka5filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        tipuredi1: true,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: true,
        statusU: true,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};
 

export const Spravka6Filter = {
    title: '6. за поръчани/монтирани уреди по договор',
    vidfilter: 15,
    storageKey: 'spravka6filter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: true,
        dogovor: true,
    }
};


export const Spravka7Filter = {
    title: '7. за поръчани/монтирани уреди',
    vidfilter: 16,
    storageKey: 'spravka7filter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};


export const Spravka8Filter = {
    title: '8. за планови разчети',
    vidfilter: 17,
    storageKey: 'spravka8filter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: true,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka9Filter = {
    title: '9. лица и уреди за демонтаж по статуси',
    vidfilter: 19,
    storageKey: 'spravka9filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: true,
        statusL: false,
        statusF: false,
        statusDL: true,
        regnom: false,
        adres: false,        
        vid: false,        
        statusU: false,
        statusDU: true,
    }
};
 

export const Spravka10Filter = {
    title: '10. за поръчани/демонтирани уреди по договор',
    vidfilter: 20,
    storageKey: 'spravka10filter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: true,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        statusDU: false,
        demfirma: true,
        demdogovor: true,
    }
};


export const Spravka20Filter = {
    title: '20. справка на замени',
    vidfilter: 18,
    storageKey: 'spravka20filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka21Filter = {
    title: '21. справка за монтирани уреди',
    vidfilter: 21,
    storageKey: 'spravka21filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka15Filter = {
    title: '15.  Справка допълнителни споразумения и заявления',
    vidfilter: 22,
    storageKey: 'spravka15filter',
    showAllFaza: true,
    filters: {
        faza: false,
        raion: true,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: true,
        adres: false,        
        vid: false,        
        statusDU: false,
        demfirma: false,
        demdogovor: false,
        dpregnom: true,
        viddpspor: true,
    }
};


export const Spravka22Filter = {
    title: '22. Портрет на ОПОС',
    vidfilter: 22,
    storageKey: 'spravka22filter',
    showAllFaza: false,
    filters: {
        faza: true,
        raion: false,
        unomer: true,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        statusDU: false,
        demfirma: false,
        demdogovor: false,
        dpregnom: false,
        viddpspor: false,
        vidformulqr: true,
        vidportret:true
    }
};


export const Spravka24Filter = {
    title: '5.1. лица и уреди по статуси',
    vidfilter: 24,
    storageKey: 'spravka24filter',
    showAllFaza: true,
    filters: {
        faza: true,
        raion: true,
        unomer: true,
        tipuredi3: true,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: true,
        statusU: true,
        regnom: false,
        adres: false,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka25Filter = {
    title: 'Кандидати за Фаза 3 - Предварителни данни',
    vidfilter: 25,
    storageKey: 'spravka25filter',
    showAllFaza: false,
    filters: {
        faza: false,
        raion: true,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: true,        
        vid: false,        
        firma: false,
        dogovor: false,
    }
};

export const Spravka50Filter = {
    title: '50. Достигнати лимити от бюджета',
    vidfilter: 50,
    storageKey: 'spravka50filter',
    showAllFaza: false,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: false,
        uredi: false,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        statusDU: false,
        firma: true,
        limit: true,
    }
};


export const Spravka51Filter = {
    title: '51. Фактически и предстоящ за изразходване бюджет',
    vidfilter: 51,
    storageKey: 'spravka51filter',
    showAllFaza: false,
    filters: {
        faza: false,
        raion: false,
        unomer: false,
        tipuredi: true,
        uredi: true,
        olduredi: false,
        statusL: false,
        statusF: false,
        statusDL: false,
        statusU: false,
        regnom: false,
        adres: false,        
        vid: false,        
        statusDU: false,
        firma: false,
        limit: false,
    }
};