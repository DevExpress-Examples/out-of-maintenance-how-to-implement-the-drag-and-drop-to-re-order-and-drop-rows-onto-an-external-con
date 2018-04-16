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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DragAndDrop_ReorderAndExternal {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
    }
}
