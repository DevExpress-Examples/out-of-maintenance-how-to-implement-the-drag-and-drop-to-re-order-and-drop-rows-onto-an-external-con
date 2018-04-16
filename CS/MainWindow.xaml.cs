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