# Bonsai Hollistic Health (for humans)

Holistic Health data, research, documentation, and multimedia (sound, visual, ASMR, personal, interpersonal, and interior care)

------

... what follows is health checks for a server... this will be updated once the robot-cloud is ready for next steps ... (as well as the trustlane project)

This sample illustrates the use of Health Check Middleware and services. This sample demonstrates the scenario described in the [Health checks in ASP.NET Core](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks) topic.

To run the sample app for a scenario described in the topic, use the [dotnet run](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) command from the project's folder in a command shell. Pass a switch for the scenario that you're exploring. The app defaults to the `basic` configuration when a switch isn't provided to `dotnet run`.

| Scenario                                               | Sample app command               | Description |
| ------------------------------------------------------ | -------------------------------- | ----------- |
| Basic health probe (default)                           | `dotnet run --scenario basic`    | Confirms that the app can process HTTP requests. |
| Database probe                                         | `dotnet run --scenario db`       | Checks a SQL Server database connection. See the [Database probe](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks#database-probe) section of the topic for instructions. |
| Readiness/liveness probes                              | `dotnet run --scenario liveness` | Performs checks for a live app status (*liveness*) versus the app preparing to become live (*readiness*). |
| Metric-based probe (memory)/<br>custom response writer | `dotnet run --scenario writer`   | Checks against memory use and writes out custom JSON when the health endpoint is checked. |
| Filter by port                                         | `dotnet run --scenario port`     | Filters health checks to a given port. See the [Filter by port](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks#filter-by-port) section of the topic for instructions. |

The database probe and port filter scenarios require additional configuration. See the [Health checks](https://docs.microsoft.com/aspnet/core/host-and-deploy/health-checks) topic for details.
