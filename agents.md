# OpenpilotToolkit - AI Agent Instructions

## Project Information

- **Type**: .NET 10 WinForms Desktop Application
- **Language**: C# 
- **Target**: Windows x64
- **Main Project**: `OpenpilotToolkit/OpenpilotToolkit.csproj`
- **Build Output**: `OpenpilotToolkit/bin/{Configuration}/net10.0-windows7.0/win-x64/OpenpilotToolkit.exe`

## Dependencies

- .NET 10 SDK
- Cap'n Proto compiler (`capnproto`, `libcapnp-dev`)
- capnpc-csharp (dotnet tool)

## Build Commands

### Complete Setup and Build
```bash
bash .agent/setup.sh && bash .agent/quick-build.sh
```

### Individual Steps
```bash
# 1. Setup environment (one-time)
bash .agent/setup.sh

# 2. Restore NuGet packages
bash .agent/restore.sh

# 3. Build (Release or Debug)
bash .agent/build.sh
bash .agent/build.sh Debug

# 4. Quick build (restore + build)
bash .agent/quick-build.sh
bash .agent/quick-build.sh Debug
```

## Project Structure
```
OpenpilotToolkit/
├── .agent/                    # Build automation scripts
│   ├── setup.sh              # Install .NET, Cap'n Proto, capnpc-csharp
│   ├── restore.sh            # Restore NuGet packages
│   ├── build.sh              # Build project
│   └── quick-build.sh        # Restore + build
├── OpenpilotToolkit/         # Main application (WinForms)
├── OpenpilotSdk/             # SDK with Cap'n Proto schemas (*.capnp files)
├── MaterialSkin/             # Material Design UI components
├── SSH.NET/                  # SSH library (git submodule)
├── SshNet.Keygen/            # SSH key generation
├── OpenpilotToolkitAndroid/  # Android version (skip for desktop builds)
└── agents.md                 # This file
```

## Build Configuration

### Required Build Flags
```bash
--runtime win-x64                    # Target Windows x64
/p:EnableWindowsTargeting=true       # Enable Windows APIs on Linux
--verbosity quiet                    # Suppress verbose output
```

### Project Build Order (Dependency Chain)
```
SSH.NET → SshNet.Keygen → OpenpilotSdk → MaterialSkin → OpenpilotToolkit
```
(Scripts handle this automatically)

## Common Issues

### Issue: `capnp: command not found`
**Cause**: Cap'n Proto not installed  
**Fix**:
```bash
sudo apt-get install capnproto libcapnp-dev
```

### Issue: `PWD environment variable doesn't match`
**Cause**: Cap'n Proto PWD sensitivity  
**Fix**: Scripts handle automatically with `unset PWD`

### Issue: WFO1000 warnings
**Cause**: WinForms designer serialization warnings (.NET 10)  
**Impact**: None - safe to ignore

### Issue: NU1701 warnings
**Cause**: .NET Framework package compatibility warnings  
**Impact**: None - packages work fine with .NET 10

### Issue: SSH.NET not found
**Cause**: Git submodule not initialized  
**Fix**:
```bash
git submodule update --init --recursive
```

### Issue: `dotnet: command not found` after setup
**Cause**: PATH not updated  
**Fix**:
```bash
export DOTNET_ROOT=$HOME/.dotnet
export PATH="$DOTNET_ROOT:$HOME/.dotnet/tools:$PATH"
```

## Code Modification Workflow

When modifying code, determine rebuild requirements:

| Changed Files | Action Required |
|---------------|-----------------|
| `*.cs` (C# code) | `bash .agent/build.sh` |
| `*.capnp` (schemas) | `bash .agent/quick-build.sh` |
| `*.csproj` (project files) | `bash .agent/quick-build.sh` |
| Dependencies added/removed | `bash .agent/quick-build.sh` |

## Testing Changes

After build:
```bash
# Verify executable exists
ls -lh OpenpilotToolkit/bin/Release/net10.0-windows7.0/win-x64/OpenpilotToolkit.exe

# Check file size (should be ~several MB)
du -h OpenpilotToolkit/bin/Release/net10.0-windows7.0/win-x64/OpenpilotToolkit.exe
```

## CI/CD Integration
```yaml
# GitHub Actions example
steps:
  - uses: actions/checkout@v3
    with:
      submodules: recursive
  
  - name: Setup
    run: bash .agent/setup.sh
  
  - name: Build
    run: bash .agent/quick-build.sh
```

## Key Technical Details

### Cap'n Proto Schema Generation
- Schema files: `OpenpilotSdk/OpenPilot/Cereal/*.capnp`
- C# code generated during build via capnpc-csharp
- Requires both `capnp` compiler and `capnpc-csharp` plugin

### Build Environment
- Fresh Linux VM (Ubuntu/Debian)
- Cross-compiles for Windows x64
- Git submodules must be initialized before build

### Output Structure
```
bin/{Configuration}/net10.0-windows7.0/win-x64/
├── OpenpilotToolkit.exe       # Main executable
├── OpenpilotToolkit.dll       # Application DLL
├── OpenpilotSdk.dll           # SDK with generated Cap'n Proto types
├── Renci.SshNet.dll           # SSH library
├── MaterialSkin.dll           # UI components
└── *.dll                      # Other dependencies
```

## Quick Reference

| Task | Command |
|------|---------|
| First-time setup | `bash .agent/setup.sh && bash .agent/quick-build.sh` |
| Rebuild after changes | `bash .agent/build.sh` |
| Full rebuild | `bash .agent/quick-build.sh` |
| Debug build | `bash .agent/build.sh Debug` |
| Check environment | `dotnet --version && capnp --version` |

## Script Descriptions

### `.agent/setup.sh`
- Installs .NET 10 SDK to `~/.dotnet`
- Installs Cap'n Proto via apt (`capnproto`, `libcapnp-dev`)
- Installs capnpc-csharp as global dotnet tool
- Idempotent (safe to run multiple times)

### `.agent/restore.sh`
- Restores NuGet packages for OpenpilotToolkit.csproj
- Automatically restores all project dependencies
- Must run after setup.sh

### `.agent/build.sh`
- Builds OpenpilotToolkit in specified configuration (default: Release)
- Requires prior restore (use `--no-restore` flag)
- Cross-compiles for Windows x64

### `.agent/quick-build.sh`
- Combines restore.sh + build.sh
- Recommended for most builds
- Accepts configuration argument (Release/Debug)

## Notes for AI Agents

- **All paths are relative to repository root**
- **Scripts must be run from repository root or use absolute paths**
- **Git submodules required**: Run `git submodule update --init --recursive` before setup
- **Build is cross-platform**: Builds Windows app on Linux
- **Output is not runnable on Linux**: Requires Windows or Wine to execute
- **PWD issues handled automatically**: Scripts unset PWD before building
- **Warnings are expected**: WFO1000 and NU1701 warnings are normal and safe
