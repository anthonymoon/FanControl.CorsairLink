﻿namespace CorsairLink;

public abstract class DeviceBase : IDevice
{
    private readonly ILogger _logger;

    public abstract string UniqueId { get; }
    public abstract string Name { get; }
    public abstract IReadOnlyCollection<SpeedSensor> SpeedSensors { get; }
    public abstract IReadOnlyCollection<TemperatureSensor> TemperatureSensors { get; }

    protected DeviceBase(ILogger logger)
    {
        _logger = logger;
    }

    protected void LogInfo(string message) => _logger.Info(Name, message);

    protected void LogError(string message) => _logger.Error(Name, message);

    protected void LogError(Exception exception) => _logger.Error(Name, exception.FormatForLogging());

    protected void LogWarning(string message) => _logger.Warning(Name, message);

    protected void LogWarning(Exception exception) => _logger.Warning(Name, exception.FormatForLogging());

    protected void LogDebug(string message) => _logger.Debug(Name, message);

    protected void LogDebug(Exception exception) => _logger.Error(Name, exception.FormatForLogging());

    protected bool CanLogDebug => _logger.DebugEnabled;

    public virtual bool Connect(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual void Disconnect()
    {
        throw new NotImplementedException();
    }

    public virtual string GetFirmwareVersion()
    {
        throw new NotImplementedException();
    }

    public virtual void Refresh(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public virtual void SetChannelPower(int channel, int percent)
    {
        throw new NotImplementedException();
    }

    public virtual void ResetChannel(int channel)
    {
        SetChannelPower(channel, 50);
    }
}
