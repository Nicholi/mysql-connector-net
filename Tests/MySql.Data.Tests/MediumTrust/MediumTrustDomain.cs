using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Permissions;
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;


namespace MySql.Data.MySqlClient.Tests
{
  public class MediumTrustDomain :IDisposable
  {

    private AppDomain _domain;
    private string fullPathAssembly { get; set; }

    public MediumTrustDomain()
    {
      Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
      foreach (var item in a.GetReferencedAssemblies())
      {
        if (item.Name.Contains("MySql.Data"))
        {
          if (item.Version == new Version(6, 7))
#if CLR4
            fullPathAssembly = @Path.GetFullPath(@".\..\..\..\..\Source\MySql.Data\bin\v4.0\Release\MySql.Data.dll");
#else
            fullPathAssembly = @Path.GetFullPath(@".\..\..\..\..\Source\MySql.Data\bin\v4.5\Release\MySql.Data.dll");                   
#endif
          else
            fullPathAssembly = @Path.GetFullPath(@".\..\..\..\..\Source\MySql.Data\bin\Release\MySql.Data.dll");
          break;
        }
      }   
      if (!string.IsNullOrEmpty(fullPathAssembly))
        registerAssembly();    
    }

    public AppDomain CreatePartialTrustAppDomain()
    {      
      PermissionSet permissions = new PermissionSet(PermissionState.None);
      permissions.AddPermission(new AspNetHostingPermission(AspNetHostingPermissionLevel.Medium));
      permissions.AddPermission(new DnsPermission(PermissionState.Unrestricted));
      permissions.AddPermission(new EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP;TMP;USERNAME;OS;COMPUTERNAME"));
      permissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, AppDomain.CurrentDomain.BaseDirectory));
      permissions.AddPermission(new IsolatedStorageFilePermission(PermissionState.None) { UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser, UserQuota = Int64.MaxValue });
      permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
      permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlThread));
      permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.ControlPrincipal));
      permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration));
      permissions.AddPermission(new SmtpPermission(SmtpAccess.Connect));
      permissions.AddPermission(new SqlClientPermission(PermissionState.Unrestricted));
#if NET_40_OR_GREATER
      permissions.AddPermission(new TypeDescriptorPermission(PermissionState.Unrestricted));
#endif
      permissions.AddPermission(new WebPermission(PermissionState.Unrestricted));
      permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
      permissions.AddPermission(new MySqlClientPermission(PermissionState.Unrestricted));
      permissions.AddPermission(new SocketPermission(PermissionState.Unrestricted));

      AppDomainSetup setup = new AppDomainSetup() { ApplicationBase = AppDomain.CurrentDomain.BaseDirectory };

#if NET_40_OR_GREATER
      setup.PartialTrustVisibleAssemblies = new string[]
            {
                "System.Web, PublicKey=002400000480000094000000060200000024000052534131000400000100010007d1fa57c4aed9f0a32e84aa0faefd0de9e8fd6aec8f87fb03766c834c99921eb23be79ad9d5dcc1dd9ad236132102900b723cf980957fc4e177108fc607774f29e8320e92ea05ece4e821c0a5efe8f1645c4c0c93c1ab99285d622caa652c1dfad63d745d6f2de5f17e5eaf0fc4963d261c8a12436518206dc093344d5ad293",
                "MySql.Data, PublicKey=00240000048000009400000006020000002400005253413100040000010001000995820dbf7835a6025fca1b875ce474fb428daf704ec253820701e1b9034d483fb28be7dfa954cd97bc97a5dd95ca7b9ce036ee1665321af14a8ede5fc164df09c077b624c5f88625ae89b2918fef64cc028e4be561e7cf5fdbe1f9404074979e19b36998ff97ad292b3005412a5f347f9512886f1240fccb7a379849b431ad"             
            };
#endif

      _domain = AppDomain.CreateDomain("MediumTrustSandbox", null, setup, permissions);
      return _domain;
    }

    public void Dispose()
    {
      if (_domain != null)
      {
        AppDomain.Unload(_domain);
        _domain = null;
        unregisterAssembly();
      }    
    }

    private void registerAssembly()
    {
      StringBuilder command = new StringBuilder();

      StringBuilder commandLineParams = new StringBuilder();
      commandLineParams.AppendFormat("/i \"{0}\"", fullPathAssembly);

      ProcessStartInfo processStartInfo = new ProcessStartInfo();
#if NET_40_OR_GREATER
      command.AppendFormat("\"{0}\"", @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).ToString() + @"\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\" + "gacutil.exe");
#else
      command.AppendFormat("\"{0}\"", @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).ToString() + @"\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\" + "gacutil.exe");
#endif
      processStartInfo.FileName = command.ToString();
      processStartInfo.Arguments = commandLineParams.ToString();
      processStartInfo.UseShellExecute = false;
      processStartInfo.Verb = "runas";
      var process = Process.Start(processStartInfo);
      process.WaitForExit(10000);
    }


    private void unregisterAssembly()
    {
      StringBuilder command = new StringBuilder();

      StringBuilder commandLineParams = new StringBuilder();
      commandLineParams.AppendFormat("/u \"{0}\"", "mysql.data");

      ProcessStartInfo processStartInfo = new ProcessStartInfo();
#if NET_40_OR_GREATER
      command.AppendFormat("\"{0}\"", @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).ToString() + @"\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\" + "gacutil.exe");
#else
      command.AppendFormat("\"{0}\"", @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).ToString() + @"\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\" + "gacutil.exe");
#endif
      processStartInfo.FileName = command.ToString();
      processStartInfo.Arguments = commandLineParams.ToString();
      processStartInfo.UseShellExecute = false;
      processStartInfo.Verb = "runas";
      var process = Process.Start(processStartInfo);
      process.WaitForExit();
    }

  }   
}

