import React, { useState } from 'react';
import './App.css';
import { readInput, Recipe } from './parser';
import { RecipeDisplay } from './components/recipe';
import { LandingPage } from './components/landing-page';

const App: React.FC = () => {
  const [recipe, setRecipe] = useState(null as Recipe | null);

  async function onSubmit(url: string) {
    const recipe = await readInput(url);
    setRecipe(recipe as Recipe);
  }

  return (
    <div className="App">
      <header className="App-header">
        <div className="container">
          {recipe ? 
          <RecipeDisplay recipe={recipe}/> : 
          <LandingPage onSubmit={onSubmit} />}
        </div>
      </header>
    </div>
  );
}

export default App;
