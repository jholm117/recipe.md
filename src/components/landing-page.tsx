import React from "react";
import { LinkFormProps, LinkForm } from "./url-form";
import { profiles } from "../parser";

interface LandingPageProps extends LinkFormProps {}

export function LandingPage(props: LandingPageProps){
  return (
    <div className="d-flex justify-content-around">
      <div>
        <h1>recipe.md</h1>
        <LinkForm {...props} />
      </div>
      <div>
        <h2>Supported Sites</h2>
        <ul>{profiles.map((profile) => <li key={profile.domain}>{profile.domain}</li>)}</ul>
      </div>
    </div>
  );
}
