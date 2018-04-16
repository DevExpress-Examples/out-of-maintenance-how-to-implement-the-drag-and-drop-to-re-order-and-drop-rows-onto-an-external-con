// Developer Express Code Central Example:
// How to implement the drag-and-drop capability to re-order rows and drop them onto an external control
// 
// We have implemented GridDragDropManager behavior in the grid extentions library.
// This attached behavior allows you to include the drag and drop support in your
// application more easily than the old approach.
// 
// This description is actual
// only for versions earlier than 12.1.:
// The following example demonstrates how to
// implement the drag-and-drop capability to allow end-users to do the
// following:
// 1. re-order grid rows;
// 2. drag any grid row from a grid and drop it
// onto an external control.
// 
// To accomplish this task, it is necessary to set the
// GridView.AllowDrop property to True and handle its PreviewMouseDown,
// PreviewMouseMove, DragOver, and Drop events as shown in this example.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1194

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DragAndDrop_ReorderAndExternal")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DragAndDrop_ReorderAndExternal")]
[assembly: AssemblyCopyright("Copyright ©  2008")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
