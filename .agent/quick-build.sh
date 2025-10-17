#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
CONFIGURATION="${1:-Release}"

echo "================================================"
echo "Quick Build: Restore + Build ($CONFIGURATION)"
echo "================================================"

bash "$SCRIPT_DIR/restore.sh" || exit 1

echo ""

bash "$SCRIPT_DIR/build.sh" "$CONFIGURATION" || exit 1

echo ""
echo "✅ Quick build complete!"
echo ""