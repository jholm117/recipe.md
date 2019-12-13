const readline = require('readline');
const request = require("request");
const cheerio = require('cheerio');

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

function readInput(url){
  request(url, (error, response, data) => {
    error && console.log('error', error);
    const $ = cheerio.load(data);
    const title = $('#recipe-main-content').text();
    const ingredients = $('span[itemprop=recipeIngredient]').map((i, el) => $(el.firstChild).text()).get();
    const directions = $('ol[itemprop=recipeInstructions] li span').map((i, el) => $(el.firstChild).text().trim()).get();

    const recipe = {
      title,
      ingredients,
      directions,
    };
    process.stdout.write(markdown(recipe));  
  })
}
