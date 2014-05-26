mysql-connector-net
===================

Oracle's MySQL Connector/Net ADO.Net Drivers, with a twist.

### Major Changes
 * MySql.Data.MySqlClient connection string has one additional parameter now, time_zone, to set the default session time_zone variable immediately upon connection. Default setting will use the time_zone set by mysql instances as expected in official client. Use strings like +00:00 (for UTC) or SYSTEM (usual default for system time_zone). Will work with pooled connections as well (implemented when the underlying Driver connection is open or reset).
 * In implementations for MembershipProvider, ProfileProvider, and SessionStateStoreProvider added an additional non-standard boolean parameter, dateTimeUseUtc, which will tell our underlying implementations to attempt to always use UTC DateTimes. Set to true to use new features. When creating current time uses UtcNow rather than Now, and also when reading `timestamp`/`datetime` fields from DB will attempt to always set the DateTimeKind property (the default implementation only sets the Kind for `timestamp` fields by default). Default is false, so code routines will run exactly same as official implementation. Meant to be used with time_zone=+00:00 in connection string to always keep DateTime objects in UTC. Also a minimal implementation of MembershipUser which stores DateTime objects in UTC and returns DateTimes in UTC (default implementation stores in UTC but ALWAYS returns Local DateTimeKind).
 * Targeting VS2013 specifically (removed older solution files)
 * Should still work with other TargetFrameworks, only testing with v4.5. Also really only tested MySql.Data and MySql.Web (but not MySql.Entity)
 * Removed all non-EF6 related stuff (probably won't easily build with EF5 anymore)

 
### Setup for signing dll's using Visual Studio's Strong name tool (sn.exe)

 * Create key pair
sn -k connector.snk

 * Add key to container used in code.
sn -i connector.snk ConnectorNet

 * Extract public key
sn -p connector.snk public.snk

 * Display public key
sn -tp public.snk

 * Copy public key and replace in these files.
Source/MySql.Data.Entity/Properties/AssemblyInfo.cs
Source/MySql.Data/Properties/AssemblyInfo.cs
Tests/MySql.Data.Tests/MediumTrust/MediumTrustDomain.cs
Tests/MySql.Data.Tests/Properties/AssemblyInfo.cs

 * Get public key token of built assembly.
sn -T MySql.Data.Entity.EF6.dll