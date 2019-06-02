using System;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Settings
{
    public interface ISettingsRepository
    {
        decimal GetValueOrDefault(string key, decimal defaultValue, string fileName = null);

        bool GetValueOrDefault(string key, bool defaultValue, string fileName = null);

        long GetValueOrDefault(string key, long defaultValue, string fileName = null);

        string GetValueOrDefault(string key, string defaultValue, string fileName = null);

        int GetValueOrDefault(string key, int defaultValue, string fileName = null);

        float GetValueOrDefault(string key, float defaultValue, string fileName = null);

        DateTime GetValueOrDefault(string key, DateTime defaultValue, string fileName = null);

        Guid GetValueOrDefault(string key, Guid defaultValue, string fileName = null);

        double GetValueOrDefault(string key, double defaultValue, string fileName = null);

        bool AddOrUpdateValue(string key, decimal value, string fileName = null);

        bool AddOrUpdateValue(string key, bool value, string fileName = null);

        bool AddOrUpdateValue(string key, long value, string fileName = null);

        bool AddOrUpdateValue(string key, string value, string fileName = null);

        bool AddOrUpdateValue(string key, int value, string fileName = null);

        bool AddOrUpdateValue(string key, float value, string fileName = null);

        bool AddOrUpdateValue(string key, DateTime value, string fileName = null);

        bool AddOrUpdateValue(string key, Guid value, string fileName = null);

        bool AddOrUpdateValue(string key, double value, string fileName = null);

        void Remove(string key, string fileName = null);

        void Clear(string fileName = null);

        bool Contains(string key, string fileName = null);

        bool OpenAppSettings();
    }
}