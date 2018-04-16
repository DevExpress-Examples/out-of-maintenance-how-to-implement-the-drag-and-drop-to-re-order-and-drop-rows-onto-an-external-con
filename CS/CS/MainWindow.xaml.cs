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

using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DevExpress.Data;
using System.Collections.Generic;
using DevExpress.Xpf.Grid;

namespace DragAndDrop_ReorderAndExternal {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = TestData.GetData();
            draggedRowsList.ItemsSource = new BindingList<TestData>();
        }
    }

    #region TestData class
    public class TestData {
        public static BindingList<TestData> GetData(int count = 100) {
            BindingList<TestData> list = new BindingList<TestData>();
            for(int i = 0; i < count; i++)
                list.Add(new TestData(i, "row " + i));
            return list;
        }
        public string Text { get; set; }
        public int Number { get; set; }
        public TestData() { }
        public TestData(int number, string text) {
            Number = number;
            Text = text;
        }
        public override string ToString() {
            return Text;
        }
    }
    #endregion
}