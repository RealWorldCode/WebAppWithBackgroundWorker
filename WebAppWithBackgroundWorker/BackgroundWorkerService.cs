namespace WebAppWithBackgroundWorker
{
	public class BackgroundWorkerService : BackgroundService
	{
		// This is the time span for recording the video
		private static readonly TimeSpan TimeBetweenRuns = TimeSpan.FromSeconds(15);

		// This is the time span for the Real World
		// private static TimeSpan TimeBetweenRuns = TimeSpan.FromDays(1);

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			// Log that the service was started
			Console.WriteLine($"Background service started at {DateTime.Now}");

			// Start the loop that keeps going until stopped
			while (!stoppingToken.IsCancellationRequested)
			{
				// Wait an amount of time between each run
				await Task.Delay(TimeBetweenRuns, stoppingToken);

				// Log that the scheduled work is starting
				Console.WriteLine($"Service is doing work at {DateTime.Now}");

				// Do some scheduled work
				await DoScheduledWork(stoppingToken);

				// Log that the scheduled work is finished
				Console.WriteLine($"Service is finished at {DateTime.Now}");
			}

			// Log that the service was has stopped
			Console.WriteLine($"Background service stopped at {DateTime.Now}");
		}

		private static async Task DoScheduledWork(CancellationToken stoppingToken)
		{
			// TODO: Replace this simulated work with real work.

			await Task.Delay(TimeSpan.FromSeconds(new Random().Next(5, 21)), stoppingToken);
		}
	}
}
