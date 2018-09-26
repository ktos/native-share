let protocol = "nativeshare"

function onCreated(tab) {
  browser.tabs.remove(tab.id)
}

function onError(tab) {
}

function openCompanionAppByProtocol() {
  browser.tabs.query({ active: true }).then((tab) => {
    var creating = browser.tabs.create({
      "url": protocol + ":uri?value=" + encodeURIComponent(tab[0].url)
    });

    creating.then(onCreated, onError);
  })
}

browser.browserAction.onClicked.addListener(openCompanionAppByProtocol);