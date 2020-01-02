import { Profile, getList } from "./profile";

export class TheSpruceEats implements Profile {
  domain = 'thespruceeats.com';
  directions($: CheerioStatic): string[] {
    return getList('section.section--instructions ol .mntl-sc-block-html p', $);
  }
  ingredients($: CheerioStatic): string[] {
    return getList('section.section--ingredients .simple-list__item', $);
  }
  title($: CheerioStatic): string {
    return $('h1.heading__title').text();
  }
}
