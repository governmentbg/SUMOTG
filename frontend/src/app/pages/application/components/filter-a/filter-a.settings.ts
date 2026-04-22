export interface FilterA {
    raionid: string,
    statusG: number,
    statusM: number,
    unomer: number,
    porychkanom: number,
    demporychkanom?: number,
    firma?: number,
    dogovor?: number,
    demfirma?: number,
    demdogovor?: number,
    grafikdataot: Date,
    grafikdatado: Date,
    otchetdataot: Date,
    otchetdatado: Date,
    tipuredi: string,
    uredi: string,    
    descript: string,
    txtfilter: string,
    disable: boolean, 
    kymdata?: Date,
    sleddata?: Date,   
    otdata?: Date,
    dodata?: Date,   
    statusPF?: number,
    curdate?: Date,   
}
 

export interface FilterASettings {
    title: string,
    vidfilter: number,
    storageKey: string,
    filters: {
        vid: number,
        raion: boolean,
        unomer: boolean,
        statusG: boolean,
        statusM: boolean,
        porychkanom: boolean,
        demporychkanom?: boolean,
        firma?: boolean,
        dogovor?: boolean,
        demfirma?: boolean,
        demdogovor?: boolean,
        grafikdata: boolean,
        otchetdata: boolean,    
        tipuredi?: boolean,        
        uredi?: boolean,
        kymdata?: boolean,
        sleddata?: boolean,
        fromto?: boolean,
        statusPF?: boolean,
        showporychkanom?: boolean,
    }
}

export const EmptyFilterA = {
    title: '',
    vidfilter: 0,
    storageKey: '',
    filters: {
        vid: 1,
        raion: false,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,    
        tipuredi: false,
        uredi: false,
    }
};


export const Spravka11Filter = {
    title: '11. състояние на поръчка за монтаж',
    vidfilter: 1,
    storageKey: 'spravka11filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: true,
        statusM: true,
        porychkanom: true,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: true,
        otchetdata: true,    
    }
};


export const Spravka12Filter = {
    title: '12. състояние на поръчка за демонтаж',
    vidfilter: 2,
    storageKey: 'spravka12filter',
    filters: {
        vid: 2,
        raion: true,
        unomer: true,
        statusG: true,
        statusM: true,
        porychkanom: false,
        demporychkanom: true,
        firma: false,
        dogovor: false,
        demfirma: true,
        demdogovor: true,
        grafikdata: true,
        otchetdata: true,    
    }
};

export const Spravka13Filter = {
    title: '13. Обобщена справка',
    vidfilter: 4,
    storageKey: 'spravka13filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        tipuredi: true,
        uredi: false,
    }
};

export const Spravka14Filter = {
    title: '14.Състояние на поръчки за монтаж-демонтаж',
    vidfilter: 4,
    storageKey: 'spravka14filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: false,
        statusM: false,
        porychkanom: true,
        demporychkanom: true,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
    }
};


export const Spravka60Filter = {
    title: '60.Списък на профилактики по статуси',
    vidfilter: 4,
    storageKey: 'spravka60filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        fromto: true,
        statusPF: true,
        showporychkanom: true,
    }
};


export const Spravka61Filter = {
    title: '61.Списък на неотчетени профилактики',
    vidfilter: 4,
    storageKey: 'spravka61filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        fromto: true,
        statusPF: false,
        showporychkanom: true,
    }
};


export const Spravka62Filter = {
    title: '62.Списък на пропуснати профилактики',
    vidfilter: 4,
    storageKey: 'spravka62filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        fromto: true,
        statusPF: false,
        showporychkanom: true,
    }
};

export const Spravka70Filter = {
    title: '70. Справка за уреди, отчислени като актив на СО;',
    vidfilter: 4,
    storageKey: 'spravka70filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: true,
        kymdata: false,
        sleddata: true,
        fromto: false,
    }
};

export const Spravka71Filter = {
    title: '71. Справка за уреди, предстоящи за отчисление',
    vidfilter: 4,
    storageKey: 'spravka71filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: true,
        kymdata: true,
        sleddata: false,
        fromto: false,
    }
};

export const Spravka72Filter = {
    title: '72. Справка за изтекли договори с лица',
    vidfilter: 4,
    storageKey: 'spravka72filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        kymdata: false,
        sleddata: true,
        fromto: false,
    }
};

export const Spravka73Filter = {
    title: '73. Справка за договори с лица, предстоящи за изтичане',
    vidfilter: 4,
    storageKey: 'spravka73filter',
    filters: {
        vid: 1,
        raion: true,
        unomer: true,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        kymdata: true,
        sleddata: false,
        fromto: false,
    }
};


export const Spravka78Filter = {
    title: 'Прекратяване на договори',
    vidfilter: 4,
    storageKey: 'spravka78filter',
    filters: {
        vid: 1,
        raion: false,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        kymdata: true,
        sleddata: false,
        fromto: false,
    }
};


export const Spravka79Filter = {
    title: 'Прекратяване на собственост',
    vidfilter: 4,
    storageKey: 'spravka79filter',
    filters: {
        vid: 1,
        raion: false,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: false,
        dogovor: false,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        kymdata: true,
        sleddata: false,
        fromto: false,
    }
};

export const Spravka80Filter = {
    title: 'Профилактика',
    vidfilter: 4,
    storageKey: 'spravka80filter',
    filters: {
        vid: 1,
        raion: false,
        unomer: false,
        statusG: false,
        statusM: false,
        porychkanom: false,
        demporychkanom: false,
        firma: true,
        dogovor: true,
        demfirma: false,
        demdogovor: false,
        grafikdata: false,
        otchetdata: false,
        uredi: false,
        kymdata: false,
        sleddata: false,
        fromto: false,
        statusPF: true,
        showporychkanom: true,
    }
};