import { Profile } from "./profile";

export class CookieAndKate implements Profile {
  domain = 'cookieandkate.com';  
  
  directions($: CheerioStatic): string[] {
    return $('div.tasty-recipe-instructions li').map((_i, el) => $(el).text()).get();
  }
  ingredients($: CheerioStatic): string[] {
    return $('div.tasty-recipe-ingredients li').map((_i, el) => $(el).text()).get();
  }
  title($: CheerioStatic): string {
    return $('h1.entry-title').text();
  }
}
