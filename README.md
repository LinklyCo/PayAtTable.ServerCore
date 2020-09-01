# Linkly.PayAtTable

The Pay at Table API provides a common interface for the PIN pad to utilise the EFT-Client to retrieve available tables and orders so payment functions (e.g. tender, customer receipt etc.) can be performed by an operator on the PIN pad without using the main POS UI. 

The Pay at Table client requires the POS to act a data source so that it can retrieve information about available tables, orders, payment options etc. 

The Pay at Table client supports two data source options for the POS; a REST server or directly through the existing Linkly interface. 

## Start Developing

To start developing the Linkly Pay at Table solution, following the instructions on the [Linkly API](http://linkly.com.au/apidoc/TCPIP/#pay-at-table).

## REST Server 
When in REST server mode the Pay at Table extension will connect directly to the POS REST Server. 

An example REST server can be found in the [PayAtTable.ServerCore](PayAtTable.ServerCore) folder.

![REST INTERFACE DIAGRAM](rest-interface.png)

## Dependencies 

* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
* [Serilog](https://github.com/serilog/serilog-aspnetcore)
* [Swashbuckle](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)
* Visual Studio 2019

## Build and Test

1. Launch Visual Studio and open the PayAtTable.ServerCore solution
1. Run the application. The default listen port is 5000. This can be configured in `appsettings.json`
1. Logs are written to `%PROGRAMDATA%\Linkly\PayAtTable\Logs`. This can be configured in `appsettings.json`
1. Define `SERVICE` to compile as a [Windows service](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-3.1&tabs=visual-studio). Undefine `SERVICE` if the application will be hosted behind 
1. You can browse to http://localhost:5000 to see the UI and http://localhost:5000/swagger/ to see the API definition 

### SSL
If SSL is required, Linkly suggests hosting the application in reverse proxy-mode and offloading SSL handling to a front-end web server such as Nginx, Apache, or IIS.

## Release Notes
v1.0.0.0
- Initial release.
