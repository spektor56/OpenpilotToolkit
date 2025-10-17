#!/usr/bin/env bash
set -euo pipefail

DOTNET_ROOT="$HOME/.dotnet"
export DOTNET_ROOT
export PATH="$DOTNET_ROOT:$HOME/.dotnet/tools:$PATH"

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"

# Fix PWD for Cap'n Proto
unset PWD
cd "$REPO_ROOT"

CONFIGURATION="${1:-Release}"
PROJECT="OpenpilotToolkit/OpenpilotToolkit.csproj"

echo "================================================"
echo "Building OpenpilotToolkit ($CONFIGURATION)"
echo "================================================"

if [[ ! -f "$PROJECT" ]]; then
    echo "❌ Error: Project not found: $PROJECT"
    exit 1
fi

echo ""
echo "Building $PROJECT..."
echo ""

dotnet build "$PROJECT" \
    --configuration "$CONFIGURATION" \
    --runtime win-x64 \
    --no-restore \
    /p:EnableWindowsTargeting=true \
    --nologo

OUTPUT_DIR="OpenpilotToolkit/bin/$CONFIGURATION/net10.0-windows7.0/win-x64"
EXE_PATH="$OUTPUT_DIR/OpenpilotToolkit.exe"

echo ""
echo "================================================"
echo "✅ Build completed successfully!"
echo "================================================"
echo ""
echo "Output: $EXE_PATH"
echo ""