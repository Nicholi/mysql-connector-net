mysql-connector-net
===================

Oracle's MySQL Connector/Net ADO.Net Drivers, with a twist.


Setup for signing dll's using Visual Studio's Strong name tool (sn.exe)

1. Create key pair
sn -k connector.snk

2. Add key to container used in code.
sn -i connector.snk ConnectorNet

3. Extract public key
sn -p connector.snk public.snk

4. Display public key
sn -tp public.snk

5. Copy public key and replace in these files.
Source/MySql.Data.Entity/Properties/AssemblyInfo.cs
Source/MySql.Data/Properties/AssemblyInfo.cs
Tests/MySql.Data.Tests/MediumTrust/MediumTrustDomain.cs
Tests/MySql.Data.Tests/Properties/AssemblyInfo.cs

6. Get public key token of built assembly.
sn -T MySql.Data.Entity.EF6.dll