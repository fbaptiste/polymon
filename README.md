# Polymon

[-- this project is inactive --]

I originally created Polymon as open source in CodePlex.
The original archive can still be found here: https://archive.codeplex.com/?p=polymon

### What is PolyMon?
PolyMon is an open source system monitoring solution that can be used to generate email alerts and analyze historical trends of monitor counters and monitor statuses. It is based on the .NET 2.0 framework and SQL Server 2005.

It is simple to use and run but flexible enough for many circumstances.

It is made up of three primary components:
* A SQL Server database to store monitor statuses, alerts and general settings.
* A windows service (PolyMon Executive) that runs monitors on a periodic basis, logs results to the database and sends out email notifications.
* A management/monitoring front-end (PolyMon Manager) that is used to manage general settings, monitor definitions, operators, alert rules, etc. and analyze historical trends (both monitor counters and statuses).

#### Current monitor plug-ins:
- CPU Monitor
- Disk Monitor
- File (Age and Counts)
- Windows Performance Counters Monitor (built-in Performance Counter browser)
- Ping
- PowerShell Scripting
- SQL Monitor (Can run any stored procedure that returns resultsets in a specific format)
- SNMP Monitor
- TCP Port Monitor
- URL (HTML) Monitor
- URL (XML) Monitor
- Windows Service Monitor
- WMI Monitor (built-in WMI browser and query builder)

Monitors are built using a plug-in architecture and can be added to PolyMon without requiring a recompile of the application. New plug-ins simply need to inherit from a base class. Once compiled and placed in the appropriate directories, new monitors are registered with PolyMon using a plug-in registration form in PolyMon Manager.

In addition, users can create completely custom monitors by using PowerShell scripts. PolyMon now integrates PowerShell scripting allowing Status and Counter information to be passed back from a PowerShell script to the PolyMon PowerShell Monitor. This essentially provides PolyMon a complete integrated scripting language for custom monitoring. Furthermore, because these monitors are created using PowerShell you have full control over what actions to take in the event of a Warning or Failure state.

Post-Event scripting via PowerShell or VBScript is also possible, allowing you to take actions based on the status or counter values of any monitor, not just PowerShell based monitors.

In addition, you can interface to the PolyMon system via PowerShell using Steve's PoshMon PowerShell snap-in. The snap-in is available through the downloads area, but I recommend you check out this site also: http://powershell-basics.com/category/poshmon/.
