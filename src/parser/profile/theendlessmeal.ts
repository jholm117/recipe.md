import { Profile, getList } from "./profile";

// TODO: support tree instructions
export class TheEndlessMeal implements Profile {
  domain = 'theendlessmeal.com';
  directions($: CheerioStatic): string[] {
    return getList('div.tasty-recipes-instructions ol, div.tasty-recipes-instructions p', $);
  }
  ingredients($: CheerioStatic): string[] {
    return getList('div.tasty-recipes-ingredients li', $);
  }
  title($: CheerioStatic): string {
    return $('h1.post-title').text();
  }
}
