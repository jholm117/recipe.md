import React from "react";
import { Recipe } from "../parser";

interface RecipeDisplayProps {
  recipe: Recipe;
}

export function RecipeDisplay({recipe}: RecipeDisplayProps) {
  const { title, ingredients, directions } = recipe;
  return (
    <div className="container">
      <h1>{title}</h1>
      <hr />
      <h2>Ingredients</h2>
      <ul>{ingredients.map((i, idx) => <li key={idx}>{i}</li>)}</ul>
      <h2>Directions</h2>
      <ol>{directions.map((d, idx) => <li key={idx}><p>{d}</p></li>)}</ol>
    </div>
  );
}
