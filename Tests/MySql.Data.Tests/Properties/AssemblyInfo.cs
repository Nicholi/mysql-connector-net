// Copyright � 2004, 2013, Oracle and/or its affiliates. All rights reserved.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle("MySqlClientTests")]
[assembly: AssemblyDescription("Test fixtures for MySQL Connector/Net")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Oracle")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Copyright � 2004, 2013, Oracle and/or its affiliates. All rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
#pragma warning disable 1699
[assembly: AssemblyKeyName("ConnectorNet")]
#pragma warning restore 1699
#if !CF && !RT
[assembly: AllowPartiallyTrustedCallers]
#endif
[assembly: InternalsVisibleTo("MySql.Data.Entity.Tests, PublicKey = 00240000048000009400000006020000002400005253413100040000010001000995820dbf7835a6025fca1b875ce474fb428daf704ec253820701e1b9034d483fb28be7dfa954cd97bc97a5dd95ca7b9ce036ee1665321af14a8ede5fc164df09c077b624c5f88625ae89b2918fef64cc028e4be561e7cf5fdbe1f9404074979e19b36998ff97ad292b3005412a5f347f9512886f1240fccb7a379849b431ad")]
[assembly: InternalsVisibleTo("MySql.Data.Entity.CodeFirst.Tests, PublicKey = 00240000048000009400000006020000002400005253413100040000010001000995820dbf7835a6025fca1b875ce474fb428daf704ec253820701e1b9034d483fb28be7dfa954cd97bc97a5dd95ca7b9ce036ee1665321af14a8ede5fc164df09c077b624c5f88625ae89b2918fef64cc028e4be561e7cf5fdbe1f9404074979e19b36998ff97ad292b3005412a5f347f9512886f1240fccb7a379849b431ad")]
[assembly: InternalsVisibleTo("MySql.Web.Tests, PublicKey = 00240000048000009400000006020000002400005253413100040000010001000995820dbf7835a6025fca1b875ce474fb428daf704ec253820701e1b9034d483fb28be7dfa954cd97bc97a5dd95ca7b9ce036ee1665321af14a8ede5fc164df09c077b624c5f88625ae89b2918fef64cc028e4be561e7cf5fdbe1f9404074979e19b36998ff97ad292b3005412a5f347f9512886f1240fccb7a379849b431ad")]
[assembly: InternalsVisibleTo("MySql.Data.Entity.Migrations.Tests, PublicKey = 00240000048000009400000006020000002400005253413100040000010001000995820dbf7835a6025fca1b875ce474fb428daf704ec253820701e1b9034d483fb28be7dfa954cd97bc97a5dd95ca7b9ce036ee1665321af14a8ede5fc164df09c077b624c5f88625ae89b2918fef64cc028e4be561e7cf5fdbe1f9404074979e19b36998ff97ad292b3005412a5f347f9512886f1240fccb7a379849b431ad")]
