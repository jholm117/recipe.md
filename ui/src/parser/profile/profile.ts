
export interface Profile {
  domain: string;
  
  directions($: CheerioStatic): string[];
  ingredients($: CheerioStatic): string[];
  title($: CheerioStatic): string;
}

export function getList(selector: string, $: CheerioStatic): string[] {
  return $(selector).map((i, el) => $(el).text().trim()).get();
}

export function getListChild(selector: string, $: CheerioStatic): string[] {
  return $(selector).map((i, el) => $(el.lastChild).text().trim()).get();
}
