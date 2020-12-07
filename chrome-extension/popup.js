let changeColor = document.getElementById("changeColor");

changeColor.onclick = function (element) {
  chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
    // chrome.tabs.executeScript(tabs[0].id, {
    //   code: 'document.body.style.backgroundColor = "' + color + '";',
    // });
    const activeTab = tabs[0];
    const newUrl = `https://recipe-md.azurewebsites.net/recipe/${activeTab.url.replace("https://", "")}`;
    chrome.tabs.executeScript(activeTab.id, {
      code: `window.location.href="${newUrl}"`,
    });
  });
};
