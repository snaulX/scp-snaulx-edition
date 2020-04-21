// Asset data activators generated from parsed views and assets
#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public static partial class Assets
    {
        static Assets()
        {
            ViewActivators = new Dictionary<string, Func<View, View, Template, View>>();
            ViewActivators.Add("SceneObjectView", (x, y, z) => new SceneObjectView(x, y, null, z));
            ViewActivators.Add("Button", (x, y, z) => new Button(x, y, null, z));
            ViewActivators.Add("UIImageView", (x, y, z) => new UIImageView(x, y, null, z));
            ViewActivators.Add("Label", (x, y, z) => new Label(x, y, null, z));
            ViewActivators.Add("CanvasRendererView", (x, y, z) => new CanvasRendererView(x, y, null, z));
            ViewActivators.Add("UIView", (x, y, z) => new UIView(x, y, null, z));
            ViewActivators.Add("CheckBox", (x, y, z) => new CheckBox(x, y, null, z));
            ViewActivators.Add("Group", (x, y, z) => new Group(x, y, null, z));
            ViewActivators.Add("Image", (x, y, z) => new Image(x, y, null, z));
            ViewActivators.Add("Collection", (x, y, z) => new Collection(x, y, null, z));
            ViewActivators.Add("ComboBox", (x, y, z) => new ComboBox(x, y, null, z));
            ViewActivators.Add("ComboBoxListItem", (x, y, z) => new ComboBoxListItem(x, y, null, z));
            ViewActivators.Add("UICanvas", (x, y, z) => new UICanvas(x, y, null, z));
            ViewActivators.Add("List", (x, y, z) => new List(x, y, null, z));
            ViewActivators.Add("ListItem", (x, y, z) => new ListItem(x, y, null, z));
            ViewActivators.Add("Frame", (x, y, z) => new Frame(x, y, null, z));
            ViewActivators.Add("LayoutGrid", (x, y, z) => new LayoutGrid(x, y, null, z));
            ViewActivators.Add("GridSplitter", (x, y, z) => new GridSplitter(x, y, null, z));
            ViewActivators.Add("GridSplitterHandle", (x, y, z) => new GridSplitterHandle(x, y, null, z));
            ViewActivators.Add("InputField", (x, y, z) => new InputField(x, y, null, z));
            ViewActivators.Add("Region", (x, y, z) => new Region(x, y, null, z));
            ViewActivators.Add("RectMask2D", (x, y, z) => new RectMask2D(x, y, null, z));
            ViewActivators.Add("LayoutRoot", (x, y, z) => new LayoutRoot(x, y, null, z));
            ViewActivators.Add("ScrollableRegion", (x, y, z) => new ScrollableRegion(x, y, null, z));
            ViewActivators.Add("Mask", (x, y, z) => new Mask(x, y, null, z));
            ViewActivators.Add("RadioButton", (x, y, z) => new RadioButton(x, y, null, z));
            ViewActivators.Add("Scrollbar", (x, y, z) => new Scrollbar(x, y, null, z));
            ViewActivators.Add("SelectionIndicator", (x, y, z) => new SelectionIndicator(x, y, null, z));
            ViewActivators.Add("Slider", (x, y, z) => new Slider(x, y, null, z));
            ViewActivators.Add("Tab", (x, y, z) => new Tab(x, y, null, z));
            ViewActivators.Add("TabHeader", (x, y, z) => new TabHeader(x, y, null, z));
            ViewActivators.Add("TabPanel", (x, y, z) => new TabPanel(x, y, null, z));
            ViewActivators.Add("ViewSwitcher", (x, y, z) => new ViewSwitcher(x, y, null, z));
            ViewActivators.Add("ToggleGroup", (x, y, z) => new ToggleGroup(x, y, null, z));

            ViewTypes = new Dictionary<string, Type>();
            ViewTypes.Add("SceneObjectView", typeof(SceneObjectView));
            ViewTypes.Add("Button", typeof(Button));
            ViewTypes.Add("UIImageView", typeof(UIImageView));
            ViewTypes.Add("Label", typeof(Label));
            ViewTypes.Add("CanvasRendererView", typeof(CanvasRendererView));
            ViewTypes.Add("UIView", typeof(UIView));
            ViewTypes.Add("CheckBox", typeof(CheckBox));
            ViewTypes.Add("Group", typeof(Group));
            ViewTypes.Add("Image", typeof(Image));
            ViewTypes.Add("Collection", typeof(Collection));
            ViewTypes.Add("ComboBox", typeof(ComboBox));
            ViewTypes.Add("ComboBoxListItem", typeof(ComboBoxListItem));
            ViewTypes.Add("UICanvas", typeof(UICanvas));
            ViewTypes.Add("List", typeof(List));
            ViewTypes.Add("ListItem", typeof(ListItem));
            ViewTypes.Add("Frame", typeof(Frame));
            ViewTypes.Add("LayoutGrid", typeof(LayoutGrid));
            ViewTypes.Add("GridSplitter", typeof(GridSplitter));
            ViewTypes.Add("GridSplitterHandle", typeof(GridSplitterHandle));
            ViewTypes.Add("InputField", typeof(InputField));
            ViewTypes.Add("Region", typeof(Region));
            ViewTypes.Add("RectMask2D", typeof(RectMask2D));
            ViewTypes.Add("LayoutRoot", typeof(LayoutRoot));
            ViewTypes.Add("ScrollableRegion", typeof(ScrollableRegion));
            ViewTypes.Add("Mask", typeof(Mask));
            ViewTypes.Add("RadioButton", typeof(RadioButton));
            ViewTypes.Add("Scrollbar", typeof(Scrollbar));
            ViewTypes.Add("SelectionIndicator", typeof(SelectionIndicator));
            ViewTypes.Add("Slider", typeof(Slider));
            ViewTypes.Add("Tab", typeof(Tab));
            ViewTypes.Add("TabHeader", typeof(TabHeader));
            ViewTypes.Add("TabPanel", typeof(TabPanel));
            ViewTypes.Add("ViewSwitcher", typeof(ViewSwitcher));
            ViewTypes.Add("ToggleGroup", typeof(ToggleGroup));
        }
    }
}
