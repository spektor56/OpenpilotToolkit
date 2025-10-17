# Agent Instructions for OpenpilotToolkit

## Environment Setup

This script sets up the build environment. Run this once before building.
```bash
#!/usr/bin/env bash
set -euo pipefail

readonly DOTNET_VERSION="10.0"
readonly DOTNET_ROOT="$HOME/.dotnet"

# Install .NET 10
echo "Installing .NET ${DOTNET_VERSION}..."
wget -q https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --channel "$DOTNET_VERSION" --install-dir "$DOTNET_ROOT" --no-path
rm dotnet-install.sh

export DOTNET_ROOT
export PATH="$DOTNET_ROOT:$PATH"

echo "✅ .NET $(dotnet --version) installed"

# Install Cap'n Proto
echo "Installing Cap'n Proto..."
sudo apt-get update -qq
sudo apt-get install -y -qq capnproto libcapnp-dev

echo "✅ Cap'n Proto $(capnp --version | head -n1) installed"

# Install capnpc-csharp
echo "Installing capnpc-csharp..."
dotnet tool install --global capnpc-csharp --verbosity quiet
export PATH="$HOME/.dotnet/tools:$PATH"

echo "✅ capnpc-csharp installed"

# Fix PWD for Cap'n Proto
unset PWD
cd /app

echo "✅ Environment setup complete!"
```

## Build Instructions

After environment setup, restore and build the project:

### Restore Dependencies
```bash
# Restore in dependency order
dotnet restore SSH.NET/src/Renci.SshNet/Renci.SshNet.csproj \
  --runtime win-x64 \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet

dotnet restore SshNet.Keygen/SshNet.Keygen/SshNet.Keygen.csproj \
  --runtime win-x64 \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet

dotnet restore OpenpilotSdk/OpenpilotSdk.csproj \
  --runtime win-x64 \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet

dotnet restore OpenpilotToolkit/OpenpilotToolkit.csproj \
  --runtime win-x64 \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet
```

### Build OpenpilotToolkit
```bash
dotnet build OpenpilotToolkit/OpenpilotToolkit.csproj \
  --configuration Release \
  --runtime win-x64 \
  --no-restore \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet \
  --nologo
```

### Quick Build Command
```bash
# One-liner to build after environment is set up
dotnet build OpenpilotToolkit/OpenpilotToolkit.csproj \
  --configuration Release \
  --runtime win-x64 \
  /p:EnableWindowsTargeting=true
```
