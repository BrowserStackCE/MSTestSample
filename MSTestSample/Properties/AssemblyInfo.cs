using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

//[assembly: AssemblyTitle("MSTestSample")]
[assembly: AssemblyDescription("Tester1")]
//[assembly: AssemblyConfiguration("TesttingConfig")]
//[assembly: AssemblyCompany("THETESTER")]
//[assembly: AssemblyProduct("Automation")]
[assembly: AssemblyCopyright("NO way")]
[assembly: AssemblyTrademark("R")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

//[assembly: AssemblyVersion("1.0.1")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
    [assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]