"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var readline = require("readline");
var request = require("request");
var cheerio = require("cheerio");
var profile_1 = require("./profile");
var thespruceeats_1 = require("./profile/thespruceeats");
var rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
    terminal: false
});
rl.on('line', readInput);
function markdown(recipe) {
    var s = "# " + recipe.title + "\n\n## Ingredients\n\n" + ul(recipe.ingredients) + "\n## Directions\n\n" + ol(recipe.directions);
    return s;
}
function ul(lst) {
    return lstToString(lst.map(function (el) { return "- " + el; }));
}
function ol(lst) {
    return lstToString(lst.map(function (el, index) { return index + 1 + ". " + el; }));
}
function lstToString(lst) {
    return lst.map(function (el) { return el + "\n"; }).join('');
}
var profiles = [
    new profile_1.AllRecipes,
    new profile_1.CookieAndKate,
    new profile_1.TheEndlessMeal,
    new thespruceeats_1.TheSpruceEats,
];
function readInput(url) {
    request(url, function (error, _response, data) {
        error && console.log('error', error);
        var $ = cheerio.load(data);
        var chosenProfile = profiles.find(function (profile) { return url.includes(profile.domain); });
        !chosenProfile && console.error('url not supported', chosenProfile);
        var recipe = {
            title: chosenProfile.title($),
            ingredients: chosenProfile.ingredients($),
            directions: chosenProfile.directions($),
        };
        process.stdout.write(markdown(recipe));
    });
}
