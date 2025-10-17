# Agent Instructions for OpenpilotToolkit

## Project Overview
This is a .NET 10 WinForms application for Openpilot management. The main project to build is OpenpilotToolkit.

## Environment Setup

### Prerequisites
- .NET 10 SDK
- Cap'n Proto compiler and development libraries
- capnpc-csharp dotnet tool

### Setup Script
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

# Fix PWD for Cap'n Proto and set working directory
unset PWD
cd /app

# Restore dependencies in dependency order
echo "Restoring dependencies..."
for project in \
  "SSH.NET/src/Renci.SshNet/Renci.SshNet.csproj" \
  "SshNet.Keygen/SshNet.Keygen/SshNet.Keygen.csproj" \
  "OpenpilotSdk/OpenpilotSdk.csproj" \
  "OpenpilotToolkit/OpenpilotToolkit.csproj"
do
  dotnet restore "$project" \
    --runtime win-x64 \
    /p:EnableWindowsTargeting=true \
    --verbosity quiet
done

echo "✅ Dependencies restored"

# Build OpenpilotToolkit
echo "Building OpenpilotToolkit..."
dotnet build OpenpilotToolkit/OpenpilotToolkit.csproj \
  --configuration Release \
  --runtime win-x64 \
  --no-restore \
  /p:EnableWindowsTargeting=true \
  --verbosity quiet \
  --nologo

echo "✅ OpenpilotToolkit build complete!"
```

## Build Instructions

### Main Project
- **Project to build**: `OpenpilotToolkit/OpenpilotToolkit.csproj`
- **Configuration**: Release
- **Platform**: x64 (win-x64)

### Project Dependencies (in order)
1. SSH.NET/src/Renci.SshNet/Renci.SshNet.csproj
2. SshNet.Keygen/SshNet.Keygen/SshNet.Keygen.csproj
3. OpenpilotSdk/OpenpilotSdk.csproj
4. OpenpilotToolkit/OpenpilotToolkit.csproj

### Notes
- Skip the OpenpilotToolkitAndroid project (Android-specific)
- Cap'n Proto schemas are used in OpenpilotSdk
- Build requires EnableWindowsTargeting=true on Linux

## Testing
After build, the executable will be at:
`OpenpilotToolkit/bin/Release/net10.0-windows7.0/win-x64/OpenpilotToolkit.exe`

## Common Issues
- **PWD mismatch**: Unset PWD before building
- **WFO1000 warnings**: These are designer serialization warnings, safe to ignore
