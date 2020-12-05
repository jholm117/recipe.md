let changeColor = document.getElementById("changeColor");

// chrome.storage.sync.get("color", function (data) {
//   changeColor.style.backgroundColor = data.color;
//   changeColor.setAttribute("value", data.color);
// });

changeColor.onclick = function (element) {
  chrome.tabs.query({ active: true, currentWindow: true }, function (tabs) {
    // chrome.tabs.executeScript(tabs[0].id, {
    //   code: 'document.body.style.backgroundColor = "' + color + '";',
    // });
    const activeTab = tabs[0];
    const newUrl = `https://jholm117.github.io/recipe.md/#${activeTab.url}`;
    chrome.tabs.executeScript(activeTab.id, {
      code: `window.location.href="${newUrl}"`,
    });
    // chrome.extension.sendRequest({redirect: newurl}); // send message to redirect
  });
};
