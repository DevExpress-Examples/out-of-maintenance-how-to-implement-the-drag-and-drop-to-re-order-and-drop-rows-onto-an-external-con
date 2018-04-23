using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DevExpress.Data;

namespace DragAndDrop_ReorderAndExternal {

    public partial class Window1 : Window {
        BindingList<TestData> list;
        BindingList<TestData> draggedRows = new BindingList<TestData>();
        bool dragStarted;

        public Window1() {
            InitializeComponent();

            #region Data binding
            list = new BindingList<TestData>();
            for (int i = 0; i < 100; i++) {
                list.Add(new TestData() {
                    Text = "row " + i,
                    Number = i,
                });
            }
            grid.ItemsSource = list;
            #endregion

            view.AllowDrop = true;
            draggedRowsList.AllowDrop = true;

            view.PreviewMouseDown += new MouseButtonEventHandler(View_PreviewMouseDown);
            view.DragOver += new DragEventHandler(View_DragOver);
            view.Drop += new DragEventHandler(View_Drop);

            draggedRowsList.DragOver += new DragEventHandler(draggedRowsList_DragOver);
            draggedRowsList.Drop += new DragEventHandler(draggedRowsList_Drop);
            draggedRowsList.ItemsSource = draggedRows;
        }

        void draggedRowsList_Drop(object sender, DragEventArgs e) {
            int rowHandle = (int)e.Data.GetData(typeof(int));
            TestData obj = (TestData)grid.GetRow(rowHandle);
            if (!draggedRows.Contains(obj))
                draggedRows.Add(obj);
        }

        void draggedRowsList_DragOver(object sender, DragEventArgs e) {
            int rowHandle = (int)e.Data.GetData(typeof(int));
            TestData obj = (TestData)grid.GetRow(rowHandle);
            e.Effects = draggedRows.Contains(obj) ? DragDropEffects.None : DragDropEffects.Move;
            e.Handled = true;
        }

        void View_Drop(object sender, DragEventArgs e) {
            int rowHandle = (int)e.Data.GetData(typeof(int));
            TestData obj = (TestData)grid.GetRow(rowHandle);
            int insertRowHandle = view.GetRowHandleByTreeElement(e.OriginalSource as DependencyObject);
            int insertListIndex = grid.GetRowListIndex(insertRowHandle);
            if (IsCopyEffect(e)) {
                list.Insert(insertListIndex, new TestData() { Text = obj.Text + " (Copy)", Number = obj.Number });
            }
            else {
                list.Remove(obj);
                list.Insert(insertListIndex, obj);
            }
        }

        void View_DragOver(object sender, DragEventArgs e) {
            if (view.GetRowElementByTreeElement(e.OriginalSource as DependencyObject) != null)
                e.Effects = IsCopyEffect(e) ? DragDropEffects.Copy : DragDropEffects.Move;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        bool IsCopyEffect(DragEventArgs e) {
            return (e.KeyStates & DragDropKeyStates.ControlKey) == DragDropKeyStates.ControlKey;
        }

        private void view_MouseMove(object sender, MouseEventArgs e) {
            int rowHandle = view.GetRowHandleByMouseEventArgs(e);
            if (dragStarted) {
                DataObject data = CreateDataObject(rowHandle);
                DragDrop.DoDragDrop(view.GetRowElementByMouseEventArgs(e), data,
                    DragDropEffects.Move | DragDropEffects.Copy);
                dragStarted = false;
            }
        }

        void View_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            int rowHandle = view.GetRowHandleByMouseEventArgs(e);
            if (rowHandle != GridDataController.InvalidRow)
                dragStarted = true;
        }

        private DataObject CreateDataObject(int rowHandle) {
            DataObject data = new DataObject();
            data.SetData(typeof(int), rowHandle);
            return data;
        }
    }

    #region TestData class
    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }
    #endregion
}