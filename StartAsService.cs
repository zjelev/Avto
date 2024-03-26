namespace Avto;

internal class StartAsService : BackgroundService
{
    private readonly ILogger<StartAsService> _logger;

    public StartAsService(ILogger<StartAsService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
            Program.Main(null);
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("BackgroundService starting at: {time}", DateTimeOffset.Now);
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("BackgroundService stopping at: {time}", DateTimeOffset.Now);
        return base.StopAsync(cancellationToken);
    }
}
