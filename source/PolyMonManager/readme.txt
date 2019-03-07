===== PolyMon ======
====================

Main Features
-------------
PolyMon is a system monitoring application that currently supports: Ping, SNMP, URL, File and Performance Counters 
	(same as the ones accessible in PerfMon). Additional monitor types can be added to the system as plug-ins and can
	be registered with PolyMon using the Monitor Type form in PolyMon Manager.
	
Each monitor can be configured as follows:
	1. Settings such as what to monitor and failure/warning thresholds (where appropriate)
	2. Operators that should be notified when alerts are generated
	3. Rules that define when and how often to alert based on monitor Fail/Warn status
	4. An email template to define the notification message format
	
All monitoring activity is stored to a database. In addition to being able to view historical monitor statuses, PolyMon
	also logs all status and counter information to the database. It is therefore possible to view historical data for as far back
	as you keep that data in the database. For example, if you run a CPU performance counter monitor, you can view a graph of the historical
	CPU utilization over your specified time period. In addition, PolyMon manager will also calculate frequency distribution of monitor statuses.

Polymon also provides for a customizable dashboard composed of Groups of Monitors. Monitors can appear in more than one group and this is very often
	useful when creating logical groupings of monitors rather than just physical groupings. For example, a SQL server may be critical to several 
	applications. Each application in turn could be dependent on a number of other resources. By creating a group for each application, if a common
	resource fails, each group will indicate that it has encountered a problem.


All data and non-user settings are stored in a SQL database. The database schema and stored procedures are compatible with both SQL 2005 and SQL 2000.

Email notifications are handled by a SQL stored procedure that utilizes CDO. If you are using SQL 2005 and would prefer another method
	to send emails, you can change that by writing your own implementation of the stored procedure polymon_sca_ProcessAlertEmails. All pending notifications  
	are stored in a table called OperatorAlert.

Note: PolyMon Manager will minimize to the system tray. In addition, using the Close button on the main PolyMon form will 
	not close the application but only minimize it to the system tray. To close PolyMon manager, choose the File|Exit menu option
	or right click the system tray PolyMon icon and choose Exit.
	
	
	
Installation (New Install)
--------------------------

NOTE: If you are upgrading PolyMon from Beta2 to Beta 3, please see instructions for upgrade installation in the next section.

PolyMon consists of a database, a windows service (PolyMon Executive) and a management tool (PolyMon Manager).
To install proceed as follows:

1. Create a database and run the SQL scripts to create tables, stored procedures, udf's and initial data. 
	Developed and tested on SQL 2005 Developer, but should work with SQL 2000 and Express versions of 2000/2005.
	The database name PolyMon is preferred but can in fact be named whatever you want.
	Run the scripts in the following order:
		- Schema.sql
		- Functions.sql
		- Stored Procedures.sql
		- Base Data.sql

2. Install and configure the PolyMon Service (PolyMon Executive). This is the service that runs all the monitoring 
	on a periodic basis and logs results/counters to the database. 
		- Install PolyMon Executive from the installation package.
		- Configure PolyMon Executive via the config file located in the install directory to reflect the correct
			connection string to your PolyMon database server. Look for the SQLConn setting under the appConfig section.
			If the database is located on your local machine and is named PolyMon you do not need to change this setting.
		- IMPORTANT: Since this service will be running various ping, snmp, performance counter, etc queries against
			your network please make sure that the service is running under an account with appropriate rights. By
			default, the service is set to use the Local System	account.
			
3. Install PolyMon Manager. This is the primary interface to PolyMon. After this step is completed you will need
	to alert the config file
		- Install PolyMon Manager from the installation package.
		- Configure PolyMon Manager via the config file located in the install directory to reflect the correct
			connection string to your PolyMon database server. Look for the SQLConn setting under the appConfig section.
			If the database is located on your local machine and is named PolyMon you do not need to change this setting.
			
4. Once the above steps are completed, run PolyMon Manager.
	a. First go to the General settings form and specify various information
		- Name of Server running the PolyMon Executive Windows service
		- The Main Timer interval determines how often the service will run the monitors (each monitor instance itself is based on 
			multiples of this timer interval. For example, if you set the Main Timer Interval to 60 seconds and a monitor to 5 cycles, 
			the monitor will run every 5 minutes.
		- Your SMTP server settings. This is used by a SQL stored procedure to send out email alerts. (See next sub section.)
		- The Status Refresh Interval of PolyMon Manager: this determines how often PolyMon manager (when running) will check 
			current monitor statuses and will provide visual feedback on monitor statuses of Warn/Fail (including a tray icon). 
			If Audio Alert is enabled then an audible alert will also be played whenever the status of a monitor is set to Warn/Fail.
	b. Define Operators via the Operators form.
	c. Define Monitors via the Monitor Definitions screen.
	d. Customize the dashboard by creating panel Groups that in turn contain Monitor panels.
5. In order to receive email alerts, you must create a SQL job that should run periodically. 
	Typically this should be set to run as often as the main timer interval. To do this, go to SQL 
	Server Agent and create a new job. This job only needs a single step that should execute the stored 
	procedure * polymon_sca_ProcessAlertEmails *.


Installation (Beta 2 to Beta 3)
-------------------------------

If you already have PolyMon Beta 2 installed you can upgrade to Beta 3 as follows:

1. Follow steps 2 and 3 of the installation instructions in previous section.
2. PolyMon has added one new monitor and monitor editors (replacing the generic XML editor) and you will need to configure your monitors as follows:
	a. Open PolyMon Manager Beta 3.
	b. Open the Monitor Types form
	c. For each of the following monitor types, replace the Editor assembly entry as follows:
		i.   File Monitor: FileMonitorEditor.dll
		ii.  Performance Monitor: PerfMonitorEditor.dll
		iii. Ping Monitor: PingMonitorEditor.dll
		iv.  Service Monitor: ServiceMonitorEditor.dll
		v.   SNMP Monitor: SNMPMonitorEditor.dll
		v.   URL Monitor: URLMonitorEditor.dll
	d. Register the new TcpPortMonitor as follows:
		i. Click on the New icon in the same Monitor Types form you opened for the preceding step.
		ii. Enter the following information:
			Name: TcpPortMonitor
			Monitor Assembly: TcpPortMonitor.dll
			Editor Assembly: TcpPortMonitorEditor.dll
			XML Template: 
				 <TcpMonitor>
					<Host></Host>
					<Port></Port>
					<Timeout>2000</Timeout>
				</TcpMonitor>
		iii. Click on the Save icon.
		

Charting
--------
PolyMon includes software developed as part of the NPlot library project available from: http://www.nplot.com/
Many thanks to Matt Howlett, Paolo Pierini and Pawel Konieczny for their creation/contribution to this great Charting package. 
If you need a good windows charting component (I have not tried web charting with it yet, but it does support it) for Visual Studio, I highly recommend it. It is very easy to use, very flexible
and open source as well. Great package!
