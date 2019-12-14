import { Profile } from "./profile";

export class TheEndlessMeal implements Profile {
  domain = 'theendlessmeal.com';
  directions($: CheerioStatic): string[] {
    return $('div.tasty-recipes-instructions ol, div.tasty-recipes-instructions p').map((_i, el) => $(el).text()).get();
  }
  ingredients($: CheerioStatic): string[] {
    return $('div.tasty-recipes-ingredients li').map((_i, el) => $(el).text()).get();
  }
  title($: CheerioStatic): string {
    return $('h1.post-title').text();
  }


}
