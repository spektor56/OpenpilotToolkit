using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace OpenpilotSdk.Caching
{
    public static class DeviceCache
    {
        private static readonly string CacheFile;
        private static readonly TimeSpan MaxAge = TimeSpan.FromDays(30);

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = false
        };

        static DeviceCache()
        {
            CacheFile = Path.Combine(
                OperatingSystem.IsWindows()
                    ? AppContext.BaseDirectory
                    : Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "discoverdDevices.json"
            );
        }

        public static async Task<IReadOnlyList<DeviceInfo>> LoadAsync()
        {
            var tmpFile = CacheFile + ".tmp";

            // Recovery: if tmp exists but main file is missing, recover
            if (!File.Exists(CacheFile) && File.Exists(tmpFile))
            {
                File.Move(tmpFile, CacheFile, overwrite: true);
            }

            if (!File.Exists(CacheFile))
            {
                return Array.Empty<DeviceInfo>();
            }

            try
            {
                var json = await File.ReadAllTextAsync(CacheFile).ConfigureAwait(false);
                var devices = JsonSerializer.Deserialize<List<DeviceInfo>>(json, JsonOptions);
                if (devices is null || devices.Count == 0)
                {
                    return Array.Empty<DeviceInfo>();
                }

                var cutoff = DateTime.UtcNow - MaxAge;
                return (IReadOnlyList<DeviceInfo>)devices
                    .Where(d => d.LastSeen >= cutoff)
                    .ToArray();
            }
            catch
            {
                return Array.Empty<DeviceInfo>();
            }
        }

        private static async Task SaveAsync(IEnumerable<DeviceInfo> devices)
        {
            var json = JsonSerializer.Serialize(devices, JsonOptions);

            var tempFile = CacheFile + ".tmp";
            await File.WriteAllTextAsync(tempFile, json).ConfigureAwait(false);

            File.Move(tempFile, CacheFile, overwrite: true);
        }

        public static async Task MergeDevicesAsync(IEnumerable<DeviceInfo> newDevices)
        {
            var cutoff = DateTime.UtcNow - MaxAge;
            var merged = new Dictionary<string, DeviceInfo>(StringComparer.OrdinalIgnoreCase);

            // Load existing
            var existing = await LoadAsync().ConfigureAwait(false);
            foreach (var d in existing)
            {
                if (d.LastSeen < cutoff) continue;
                var key = !string.IsNullOrWhiteSpace(d.Hostname)
                    ? $"H:{d.Hostname}"
                    : $"I:{d.IpAddress}";
                merged[key] = d;
            }

            // Merge new
            foreach (var d in newDevices)
            {
                if (d.LastSeen < cutoff) continue;
                var key = !string.IsNullOrWhiteSpace(d.Hostname)
                    ? $"H:{d.Hostname}"
                    : $"I:{d.IpAddress}";
                if (!merged.TryGetValue(key, out var existingDevice) ||
                    d.LastSeen > existingDevice.LastSeen)
                {
                    merged[key] = d;
                }
            }

            await SaveAsync(merged.Values).ConfigureAwait(false);
        }
    }
}
