import React, { useState } from "react";

export interface LinkFormProps {
  onSubmit(url: string): void;
}

export function LinkForm({onSubmit}: LinkFormProps) {
  const [url, setUrl] = useState("");
  
  const handleSubmit = (evt: React.FormEvent<HTMLFormElement>) => {
      evt.preventDefault();
      onSubmit(url);
  }
  return (
    <form onSubmit={handleSubmit}>
        <input
          type="url"
          value={url}
          size={30}
          pattern="https://.*"
          placeholder='https://allrecipes.com/your-recipe'
          onChange={e => setUrl(e.target.value)}
        />
      <input type="submit" value="Submit" />
    </form>
  );
}
