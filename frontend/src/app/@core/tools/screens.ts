export abstract class Screens {
    public static setPageSize (height: number): number {
        let pageSize = 15;

        if (height < 800) {
          pageSize = 8;
        } else if (height >= 800 && height < 900) {
          pageSize = 14;
        } else if (height >= 900 && height < 1080) {
          pageSize = 15;
        } else if (height >= 1080 && height < 1500) {
            pageSize = 20;
          } else {
          pageSize = 25;
        }

        return pageSize;
    }
}
