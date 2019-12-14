"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AllRecipes = /** @class */ (function () {
    function AllRecipes() {
        this.domain = 'allrecipes.com';
    }
    AllRecipes.prototype.title = function ($) {
        return $('#recipe-main-content').text();
    };
    AllRecipes.prototype.ingredients = function ($) {
        return $('span[itemprop=recipeIngredient]').map(function (i, el) { return $(el.firstChild).text(); }).get();
    };
    AllRecipes.prototype.directions = function ($) {
        return $('ol[itemprop=recipeInstructions] li span').map(function (i, el) { return $(el.firstChild).text().trim(); }).get();
    };
    return AllRecipes;
}());
exports.AllRecipes = AllRecipes;
