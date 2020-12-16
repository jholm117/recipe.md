let changeColor = document.getElementById("changeColor");

changeColor.onclick = function (element) {
  chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
    const activeTab = tabs[0];
    const newUrl = `https://recipe-md.azurewebsites.net/recipe/${activeTab.url.replace(
      "https://",
      ""
    )}`;
    chrome.tabs.executeScript(activeTab.id, {
      code: `window.location.href="${newUrl}"`,
    });
  });
};
