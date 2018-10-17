NativeShare
===========
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/ktos/DjToKey/devel/LICENSE)
[![GitHub release](https://img.shields.io/github/release/ktos/native-share.svg)]()

![Project logo](https://raw.githubusercontent.com/ktos/native-share/master/extension/icons/96.png) 

NativeShare (or native-share) is a small Windows 10 UWP utility enabling you to use the URI scheme
`nativeshare:` to launch the application and it will show native Windows 10
share dialog, allowing you to share data (text or URI currently supported)
from almost any application.

So you can go to a link, for example:

```
nativeshare://uri?value=http%3A%2F%2Fexample.com
```

([try here](nativeshare://uri?value=http%3A%2F%2Fexample.com) if installed)

or:

```
nativeshare://text?value=Some%20example%20text
```

([try here](nativeshare://text?value=Some%20example%20text) if installed)

And NativeShare will launch and launch automatically the Share dialog to pass
data further.

It all started when I wanted to launch native share dialog with URL for a 
website from Firefox, my browser of choice, so I can use "nearby sharing" to 
wirelessly publish it to my second computer, which is not connected to my 
Microsoft account or anything similar. "Share" button in Edge does exactly this,
but I am not Edge user (mostly).

So I prepared this small thing and Firefox extension (currently testing) and
it seems it works pretty well.

## Releases and changelog

The current release is [version 0.9.1](https://github.com/ktos/native-share/releases/tag/v0.9.1).
Will be available in the Microsoft Store as soon as it passes certification.
Or you can build it by yourself and deploy to any device. The application is
intented for Windows 10 Desktop.

For the more information (changelog, source code downloads), head over to 
[releases](https://github.com/ktos/native-share/releases) section.

## Contributing
You are welcome to contribute to NativeShare! Create issues, Pull Requests, add 
new core features. More informaction is available in the 
[Contributing](CONTRIBUTING.md) document.

## Additional information

Licensed under [MIT license](/LICENSE).

Have a lot of fun.

--ktos
