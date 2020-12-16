"use strict";

chrome.runtime.onStartup.addListener(async () => {
  const uri = "https://recipe-md.azurewebsites.net/metadata/supportedsites";
  const response = await fetch(uri);
  const supportedSites = response.json();
  const conditions = supportedSites.map(
    (site) =>
      new chrome.declarativeContent.PageStateMatcher({
        pageUrl: { hostEquals: site },
      })
  );

  chrome.declarativeContent.onPageChanged.removeRules(undefined, function () {
    chrome.declarativeContent.onPageChanged.addRules([
      {
        conditions,
        actions: [new chrome.declarativeContent.ShowPageAction()],
      },
    ]);
  });
});
