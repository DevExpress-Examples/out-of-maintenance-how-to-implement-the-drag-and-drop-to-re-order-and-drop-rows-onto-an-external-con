<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128651510/12.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1194)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to implement the drag-and-drop to re-order and drop rows onto an external control


<p>We have implemented GridDragDropManager behavior in the grid extentions library. This attached behavior allows you to include the drag and drop support in your application more easily than the old approach.</p><br />
<p>This description is actual only for versions earlier than 12.1.:</p><p>The following example demonstrates how to implement the drag-and-drop capability to allow end-users to do the following:</p><p>1. re-order grid rows;</p><p>2. drag any grid row from a grid and drop it onto an external control.</p><br />
<p>To accomplish this task, it is necessary to set the GridView.AllowDrop property to True and handle its PreviewMouseDown, PreviewMouseMove, DragOver, and Drop events as shown in this example.</p>

<br/>


