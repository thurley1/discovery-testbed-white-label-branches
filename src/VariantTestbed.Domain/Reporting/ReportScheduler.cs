namespace VariantTestbed.Domain.Reporting;

public class ReportScheduler
{
    private readonly ReportService _reportService;
    private readonly List<ScheduledReport> _schedules = new();

    public ReportScheduler(ReportService reportService) => _reportService = reportService;

    public void Schedule(string reportName, ReportType type, string cron)
    {
        _schedules.Add(new ScheduledReport(reportName, type, cron));
    }

    public IReadOnlyList<ScheduledReport> GetSchedules() => _schedules.AsReadOnly();
}

public record ScheduledReport(string Name, ReportType Type, string CronExpression);
