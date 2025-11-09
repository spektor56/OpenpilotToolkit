# Openpilot Toolkit (OPTK)

Openpilot Toolkit is a class library and desktop/mobile toolkit for interacting with openpilot and comma devices.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Development](#development)
- [Contributing](#contributing)
- [License](#license)
- [Support](#support)


## Overview

Openpilot Toolkit streamlines common tasks for openpilot device owners. The toolkit bundles desktop and Android utilities for managing SSH keys, transferring files, reviewing drive data, and installing forks while providing an approachable UI for everyday workflows.

## Features

### Windows App
- **Drive Video Player:** Playback and raw export of all camera footage.
- **SSH Wizard:** Easily generate and install SSH keys.
- **Remote Control:** Access common functions remotely.
- **Fork Installer:** Simple installation of different openpilot forks.
- **Fingerprint V2 Viewer:** View your vehicle's fingerprint.
- **SSH File Explorer:** Browse, edit, delete, and upload files.
- **SSH Terminal:** Full terminal emulation for direct device access.

### Android App
- **SSH Wizard:** Easily generate and install SSH keys.
- **Fork Installer:** Simple installation of different openpilot forks.

## Getting Started

### Prerequisites
- Windows 10/11 (x64) for the desktop application
- Android device (APK sideload) for the mobile application
- Access to an openpilot or comma device on the same network

### Installation

- **Windows:** [Download the latest release](https://github.com/spektor56/OpenpilotToolkit/releases/download/1.9.8/OpenpilotToolkit.zip), extract the archive, and launch `OpenpilotToolkit.exe`.
- **Android:** [Download the APK](https://github.com/spektor56/OpenpilotToolkit/releases/download/1.9.5/com.spektor56.openpilottoolkitandroid.apk) and sideload it on your device.

## Usage

1. Connect your comma device and ensure it is on the same network as the computer or phone running OPTK.
2. Launch the Windows or Android application.
3. Use the SSH wizard to configure access, then explore the drive exporter, file explorer, and other modules as needed.

Refer to the screenshots below for examples of the available tools.

## Screenshots

![openpilot Toolkit Exporter](https://i.imgur.com/GAG527Q.png)
![openpilot Toolkit Remote](https://i.imgur.com/eog5Bhp.png)
![openpilot Toolkit Explorer](https://i.imgur.com/DkBxWfU.png)
![openpilot Toolkit Fingerprint Wizard](https://i.imgur.com/Nq1dW2k.png)
![openpilot Toolkit SSH Wizard](https://i.imgur.com/9nQLkxy.png)
![openpilot Toolkit Fork Installer](https://i.imgur.com/Qp5pQlK.png)
![openpilot Toolkit Terminal](https://i.imgur.com/3MVi4b9.png)

## Development

Developers can clone the repository and use the scripts in the `.agent/` directory to set up dependencies and build the solution:

```bash
git clone https://github.com/spektor56/OpenpilotToolkit.git
cd OpenpilotToolkit
git submodule update --init --recursive
bash .agent/setup.sh
bash .agent/quick-build.sh
```

## Contributing

Contributions are welcome! Please feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Support / Donate

If you find this project helpful, consider supporting its development:

<a href='https://ko-fi.com/M4M55991G' target='_blank'><img alt="Ko-Fi donation link" height='36' style='border:0px;height:36px;' src='https://cdn.ko-fi.com/cdn/kofi1.png?v=2' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

<a href="https://www.buymeacoffee.com/spektor56"><img alt="buy me a coffee donation link" src="https://img.buymeacoffee.com/button-api/?text=Buy me a coffee&emoji=&slug=spektor56&button_colour=5F7FFF&font_colour=ffffff&font_family=Cookie&outline_colour=000000&coffee_colour=FFDD00"></a>
