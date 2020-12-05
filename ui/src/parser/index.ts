import * as cheerio from "cheerio";
import { AllRecipes, CookieAndKate } from "./profile";
import { TheSpruceEats } from "./profile/thespruceeats";
import { Profile } from "./profile/profile";

export function markdown(recipe: Recipe) {
  const s = `# ${recipe.title}\n\n## Ingredients\n\n${ul(
    recipe.ingredients
  )}\n## Directions\n\n${ol(recipe.directions)}`;

  return s;
}

function ul(lst: string[]) {
  return lstToString(lst.map((el) => `- ${el}`));
}

function ol(lst: string[]) {
  return lstToString(lst.map((el, index) => `${index + 1}. ${el}`));
}

function lstToString(lst: string[]) {
  return lst.map((el) => `${el}\n\n`).join("");
}

export const profiles: Profile[] = [
  new AllRecipes(),
  new CookieAndKate(),
  new TheSpruceEats(),
];

export interface Recipe {
  title: string;
  ingredients: string[];
  directions: string[];
}

export async function readInput(url: string): Promise<Recipe | null> {
  const response = await fetch(url, { mode: "no-cors" });
  const text = await response.text();
  const $ = cheerio.load(text);
  const chosenProfile = profiles.find((profile) =>
    url.includes(profile.domain)
  );
  if (!chosenProfile) {
    console.error("url not supported", chosenProfile);
    return null;
  }

  const recipe: Recipe = {
    title: chosenProfile.title($),
    ingredients: chosenProfile.ingredients($),
    directions: chosenProfile.directions($),
  };
  return recipe;
}
