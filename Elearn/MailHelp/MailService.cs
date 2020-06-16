using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elearn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elearn.MailHelp
{
    
    public class MailService : IHostedService, IDisposable
    {
    aspnetElearnContext context = new aspnetElearnContext();
    MailHelper mh = new MailHelper();
    private readonly ILogger<MailService> _logger;
    private Timer _timer;

    public MailService(ILogger<MailService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromHours(12));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        var pendingAssigns = context.Asign.Include("Result").Where(x=> (x.ExpireDate > DateTime.Today && x.Result.Count ==1 && x.Result.SingleOrDefault().Mark < 0)).ToList();
        foreach(var assign in pendingAssigns)
        {
            var username = context.AspNetUsers.Where(x=> x.Id == assign.ApplicantId).SingleOrDefault().UserName;
            string testName = context.Asign.Where(x=>assign.Id == x.Id).Include("Test").SingleOrDefault().Test.Name;
            mh.InformIncomingAssign(username,testName, (DateTime)assign.ExpireDate);
        }

    }


    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
}