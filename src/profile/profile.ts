
export interface Profile {
  domain: string;
  
  directions($: CheerioStatic): string[];
  ingredients($: CheerioStatic): string[];
  title($: CheerioStatic): string;
}
