"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CookieAndKate = /** @class */ (function () {
    function CookieAndKate() {
        this.domain = 'cookieandkate.com';
    }
    CookieAndKate.prototype.directions = function ($) {
        return $('div.tasty-recipe-instructions li').map(function (_i, el) { return $(el).text(); }).get();
    };
    CookieAndKate.prototype.ingredients = function ($) {
        return $('div.tasty-recipe-ingredients li').map(function (_i, el) { return $(el).text(); }).get();
    };
    CookieAndKate.prototype.title = function ($) {
        return $('h1.entry-title').text();
    };
    return CookieAndKate;
}());
exports.CookieAndKate = CookieAndKate;
