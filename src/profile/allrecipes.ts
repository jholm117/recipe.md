import { Profile } from "./profile";

export class AllRecipes implements Profile {
  domain = 'allrecipes.com';

  title($: CheerioStatic): string {
    return $('#recipe-main-content').text();
  }  
  
  ingredients($: CheerioStatic): string[] {
    return $('span[itemprop=recipeIngredient]').map((i, el) => $(el.firstChild).text()).get();
  }

  directions($: CheerioStatic): string[] {
    return $('ol[itemprop=recipeInstructions] li span').map((i, el) => $(el.firstChild).text().trim()).get();
  }
}
