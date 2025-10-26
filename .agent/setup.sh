#!/usr/bin/env bash
set -euo pipefail

DOTNET_VERSION="10.0"
DOTNET_ROOT="$HOME/.dotnet"

echo "================================================"
echo "OpenpilotToolkit Environment Setup"
echo "================================================"

# Install .NET 10
echo ""
echo "Installing .NET ${DOTNET_VERSION}..."

# Check if correct version is installed
NEEDS_INSTALL=false
if command -v dotnet >/dev/null 2>&1; then
    CURRENT_VERSION=$(dotnet --version)
    MAJOR_VERSION=$(echo "$CURRENT_VERSION" | cut -d. -f1)
    
    if [[ "$MAJOR_VERSION" == "10" ]]; then
        echo "✅ .NET 10 already installed: $CURRENT_VERSION"
    else
        echo "⚠️  Found .NET $CURRENT_VERSION, but need .NET 10"
        NEEDS_INSTALL=true
    fi
else
    NEEDS_INSTALL=true
fi

if [[ "$NEEDS_INSTALL" == "true" ]]; then
    echo "Installing .NET ${DOTNET_VERSION}..."
    wget -q https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
    chmod +x dotnet-install.sh
    ./dotnet-install.sh --channel "$DOTNET_VERSION" --install-dir "$DOTNET_ROOT" --no-path
    rm dotnet-install.sh
    
    export DOTNET_ROOT
    export PATH="$DOTNET_ROOT:$PATH"
    
    echo "✅ .NET $(dotnet --version) installed"
fi

# Install Cap'n Proto
echo ""
echo "Installing Cap'n Proto..."
if command -v capnp >/dev/null 2>&1; then
    echo "✅ Cap'n Proto already installed: $(capnp --version | head -n1)"
else
    sudo apt-get update -qq
    sudo apt-get install -y -qq capnproto libcapnp-dev
    echo "✅ Cap'n Proto $(capnp --version | head -n1) installed"
fi

# Install capnpc-csharp
echo ""
echo "Installing capnpc-csharp..."
export PATH="$HOME/.dotnet/tools:$PATH"

if command -v capnpc-csharp >/dev/null 2>&1; then
    echo "✅ capnpc-csharp already installed"
else
    dotnet tool install --global capnpc-csharp --verbosity quiet 2>/dev/null || \
        dotnet tool update --global capnpc-csharp --verbosity quiet 2>/dev/null || true
    echo "✅ capnpc-csharp installed"
fi

echo ""
echo "================================================"
echo "✅ Environment setup complete!"
echo "================================================"
echo ""
echo "Next steps:"
echo "  bash .agent/restore.sh       # Restore dependencies"
echo "  bash .agent/build.sh         # Build the project"
echo "  bash .agent/quick-build.sh   # Restore + build"
echo ""
