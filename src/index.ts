import * as readline from 'readline';
import * as request from 'request';
import * as cheerio from 'cheerio';
import { AllRecipes, Profile, CookieAndKate, TheEndlessMeal } from './profile';
import { TheSpruceEats } from './profile/thespruceeats';

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
  terminal: false
});

rl.on('line', readInput)

function markdown(recipe) {

  const s = `# ${recipe.title}\n\n## Ingredients\n\n${ul(recipe.ingredients)}\n## Directions\n\n${ol(recipe.directions)}`;

  return s;

}

function ul(lst){
  return lstToString(lst.map(el => `- ${el}`));
}

function ol(lst){
  return lstToString(lst.map((el, index) => `${index+1}. ${el}`));
}

function lstToString(lst){
  return lst.map(el => `${el}\n`).join('');
}

const profiles: Profile[] = [
  new AllRecipes,
  new CookieAndKate,
  new TheEndlessMeal,
  new TheSpruceEats,
];

interface Recipe {
  title: string;
  ingredients: string[];
  directions: string[];
}

function readInput(url: string){
  request(url, (error, _response, data) => {
    error && console.log('error', error);
    const $ = cheerio.load(data);
    const chosenProfile = profiles.find((profile) => url.includes(profile.domain));
    !chosenProfile && console.error('url not supported', chosenProfile);

    const recipe: Recipe = {
      title: chosenProfile.title($),
      ingredients: chosenProfile.ingredients($),
      directions: chosenProfile.directions($),
    };

    process.stdout.write(markdown(recipe));  
  })
}
