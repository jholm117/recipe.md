"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TheEndlessMeal = /** @class */ (function () {
    function TheEndlessMeal() {
        this.domain = 'theendlessmeal.com';
    }
    TheEndlessMeal.prototype.directions = function ($) {
        return $('div.tasty-recipes-instructions ol, div.tasty-recipes-instructions p').map(function (_i, el) { return $(el).text(); }).get();
    };
    TheEndlessMeal.prototype.ingredients = function ($) {
        return $('div.tasty-recipes-ingredients li').map(function (_i, el) { return $(el).text(); }).get();
    };
    TheEndlessMeal.prototype.title = function ($) {
        return $('h1.post-title').text();
    };
    return TheEndlessMeal;
}());
exports.TheEndlessMeal = TheEndlessMeal;
