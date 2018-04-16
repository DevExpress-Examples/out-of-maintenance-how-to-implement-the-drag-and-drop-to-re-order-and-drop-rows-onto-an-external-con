# How to implement the drag-and-drop to re-order and drop rows onto an external control


<p>We have implemented GridDragDropManager behavior in the grid extentions library. This attached behavior allows you to include the drag and drop support in your application more easily than the old approach.</p><br />
<p>This description is actual only for versions earlier than 12.1.:</p><p>The following example demonstrates how to implement the drag-and-drop capability to allow end-users to do the following:</p><p>1. re-order grid rows;</p><p>2. drag any grid row from a grid and drop it onto an external control.</p><br />
<p>To accomplish this task, it is necessary to set the GridView.AllowDrop property to True and handle its PreviewMouseDown, PreviewMouseMove, DragOver, and Drop events as shown in this example.</p>

<br/>


