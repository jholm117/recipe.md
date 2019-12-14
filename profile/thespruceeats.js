"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TheSpruceEats = /** @class */ (function () {
    function TheSpruceEats() {
        this.domain = 'thespruceeats.com';
    }
    TheSpruceEats.prototype.directions = function ($) {
        return getList('section.section--instructions ol .mntl-sc-block-html p', $);
    };
    TheSpruceEats.prototype.ingredients = function ($) {
        return getList('section.section--ingredients .simple-list__item', $);
    };
    TheSpruceEats.prototype.title = function ($) {
        return $('h1.heading__title').text();
    };
    return TheSpruceEats;
}());
exports.TheSpruceEats = TheSpruceEats;
function getList(selector, $) {
    return $(selector).map(function (i, el) { return $(el).text().trim(); }).get();
}
function getListChild(selector, $) {
    return $(selector).map(function (i, el) { return $(el.lastChild).text().trim(); }).get();
}
