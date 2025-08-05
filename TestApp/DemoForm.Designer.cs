using AdamsLair.WinForms.ItemViews.EventArgs;
using AdamsLair.WinForms.TimelineControls.Models;

namespace AdamsLair.WinForms.TestApp
{
	partial class DemoForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            ItemModels.ListModel<object> listModel_11 = new ItemModels.ListModel<object>();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            TimelineModel timelineModel1 = new TimelineModel();
            radioEnabled = new System.Windows.Forms.RadioButton();
            radioDisabled = new System.Windows.Forms.RadioButton();
            radioReadOnly = new System.Windows.Forms.RadioButton();
            buttonRefresh = new System.Windows.Forms.Button();
            checkBoxNonPublic = new System.Windows.Forms.CheckBox();
            buttonObjA = new System.Windows.Forms.Button();
            buttonObjB = new System.Windows.Forms.Button();
            buttonObjMulti = new System.Windows.Forms.Button();
            buttonColorPicker = new System.Windows.Forms.Button();
            tabControl = new System.Windows.Forms.TabControl();
            tabPagePropertyGrid = new System.Windows.Forms.TabPage();
            checkBoxSortByName = new System.Windows.Forms.CheckBox();
            propertyGrid1 = new AdamsLair.WinForms.PropertyEditing.PropertyGrid();
            tabPageTiledView = new System.Windows.Forms.TabPage();
            checkBoxTiledViewStyle = new System.Windows.Forms.CheckBox();
            trackBarTileViewHeight = new System.Windows.Forms.TrackBar();
            trackBarTileViewWidth = new System.Windows.Forms.TrackBar();
            checkBoxTileViewHighlightHover = new System.Windows.Forms.CheckBox();
            checkBoxTileViewUserSelect = new System.Windows.Forms.CheckBox();
            radioTiledDisabled = new System.Windows.Forms.RadioButton();
            radioTiledEnabled = new System.Windows.Forms.RadioButton();
            buttonAddThousandTileItems = new System.Windows.Forms.Button();
            buttonClearTileItems = new System.Windows.Forms.Button();
            buttonRemoveTileItem = new System.Windows.Forms.Button();
            buttonAddTenTileItems = new System.Windows.Forms.Button();
            tiledView = new AdamsLair.WinForms.ItemViews.TiledView();
            tabPageColorControls = new System.Windows.Forms.TabPage();
            colorSlider4 = new AdamsLair.WinForms.ColorControls.ColorSlider();
            colorPanel3 = new AdamsLair.WinForms.ColorControls.ColorPanel();
            colorSlider3 = new AdamsLair.WinForms.ColorControls.ColorSlider();
            colorPanel2 = new AdamsLair.WinForms.ColorControls.ColorPanel();
            colorSlider2 = new AdamsLair.WinForms.ColorControls.ColorSlider();
            colorSlider1 = new AdamsLair.WinForms.ColorControls.ColorSlider();
            colorPanel1 = new AdamsLair.WinForms.ColorControls.ColorPanel();
            tabPageTimeline = new System.Windows.Forms.TabPage();
            trackBarTimelineUnitZoom = new System.Windows.Forms.TrackBar();
            timelineView1 = new AdamsLair.WinForms.TimelineControls.TimelineView();
            tabPageOriginSelector = new System.Windows.Forms.TabPage();
            originSelector10 = new OriginSelector();
            originSelector11 = new OriginSelector();
            originSelector12 = new OriginSelector();
            originSelector7 = new OriginSelector();
            originSelector8 = new OriginSelector();
            originSelector9 = new OriginSelector();
            originSelector4 = new OriginSelector();
            originSelector5 = new OriginSelector();
            originSelector6 = new OriginSelector();
            originSelector3 = new OriginSelector();
            originSelector2 = new OriginSelector();
            originSelector1 = new OriginSelector();
            menuStrip = new System.Windows.Forms.MenuStrip();
            tabControl.SuspendLayout();
            tabPagePropertyGrid.SuspendLayout();
            tabPageTiledView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTileViewHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTileViewWidth).BeginInit();
            tabPageColorControls.SuspendLayout();
            tabPageTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTimelineUnitZoom).BeginInit();
            tabPageOriginSelector.SuspendLayout();
            SuspendLayout();
            // 
            // radioEnabled
            // 
            radioEnabled.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            radioEnabled.AutoSize = true;
            radioEnabled.Checked = true;
            radioEnabled.Location = new System.Drawing.Point(13, 617);
            radioEnabled.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            radioEnabled.Name = "radioEnabled";
            radioEnabled.Size = new System.Drawing.Size(126, 25);
            radioEnabled.TabIndex = 3;
            radioEnabled.TabStop = true;
            radioEnabled.Text = "Enabled";
            radioEnabled.UseVisualStyleBackColor = true;
            radioEnabled.CheckedChanged += radioEnabled_CheckedChanged;
            // 
            // radioDisabled
            // 
            radioDisabled.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            radioDisabled.AutoSize = true;
            radioDisabled.Location = new System.Drawing.Point(334, 617);
            radioDisabled.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            radioDisabled.Name = "radioDisabled";
            radioDisabled.Size = new System.Drawing.Size(139, 25);
            radioDisabled.TabIndex = 4;
            radioDisabled.Text = "Disabled";
            radioDisabled.UseVisualStyleBackColor = true;
            radioDisabled.CheckedChanged += radioDisabled_CheckedChanged;
            // 
            // radioReadOnly
            // 
            radioReadOnly.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            radioReadOnly.AutoSize = true;
            radioReadOnly.Location = new System.Drawing.Point(165, 617);
            radioReadOnly.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            radioReadOnly.Name = "radioReadOnly";
            radioReadOnly.Size = new System.Drawing.Size(139, 25);
            radioReadOnly.TabIndex = 5;
            radioReadOnly.Text = "ReadOnly";
            radioReadOnly.UseVisualStyleBackColor = true;
            radioReadOnly.CheckedChanged += radioReadOnly_CheckedChanged;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonRefresh.Location = new System.Drawing.Point(676, 10);
            buttonRefresh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new System.Drawing.Size(234, 37);
            buttonRefresh.TabIndex = 6;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // checkBoxNonPublic
            // 
            checkBoxNonPublic.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBoxNonPublic.AutoSize = true;
            checkBoxNonPublic.Location = new System.Drawing.Point(490, 617);
            checkBoxNonPublic.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            checkBoxNonPublic.Name = "checkBoxNonPublic";
            checkBoxNonPublic.Size = new System.Drawing.Size(166, 25);
            checkBoxNonPublic.TabIndex = 8;
            checkBoxNonPublic.Text = "Non-Public";
            checkBoxNonPublic.UseVisualStyleBackColor = true;
            checkBoxNonPublic.CheckedChanged += checkBoxNonPublic_CheckedChanged;
            // 
            // buttonObjA
            // 
            buttonObjA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonObjA.Location = new System.Drawing.Point(676, 57);
            buttonObjA.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonObjA.Name = "buttonObjA";
            buttonObjA.Size = new System.Drawing.Size(234, 37);
            buttonObjA.TabIndex = 9;
            buttonObjA.Text = "Select Object A";
            buttonObjA.UseVisualStyleBackColor = true;
            buttonObjA.Click += buttonObjA_Click;
            // 
            // buttonObjB
            // 
            buttonObjB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonObjB.Location = new System.Drawing.Point(676, 104);
            buttonObjB.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonObjB.Name = "buttonObjB";
            buttonObjB.Size = new System.Drawing.Size(234, 37);
            buttonObjB.TabIndex = 10;
            buttonObjB.Text = "Select Object B";
            buttonObjB.UseVisualStyleBackColor = true;
            buttonObjB.Click += buttonObjB_Click;
            // 
            // buttonObjMulti
            // 
            buttonObjMulti.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonObjMulti.Location = new System.Drawing.Point(676, 150);
            buttonObjMulti.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonObjMulti.Name = "buttonObjMulti";
            buttonObjMulti.Size = new System.Drawing.Size(234, 37);
            buttonObjMulti.TabIndex = 11;
            buttonObjMulti.Text = "Select A and B";
            buttonObjMulti.UseVisualStyleBackColor = true;
            buttonObjMulti.Click += buttonObjMulti_Click;
            // 
            // buttonColorPicker
            // 
            buttonColorPicker.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonColorPicker.Location = new System.Drawing.Point(635, 592);
            buttonColorPicker.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonColorPicker.Name = "buttonColorPicker";
            buttonColorPicker.Size = new System.Drawing.Size(266, 37);
            buttonColorPicker.TabIndex = 12;
            buttonColorPicker.Text = "Open ColorPicker";
            buttonColorPicker.UseVisualStyleBackColor = true;
            buttonColorPicker.Click += buttonColorPicker_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tabPagePropertyGrid);
            tabControl.Controls.Add(tabPageTiledView);
            tabControl.Controls.Add(tabPageColorControls);
            tabControl.Controls.Add(tabPageTimeline);
            tabControl.Controls.Add(tabPageOriginSelector);
            tabControl.Location = new System.Drawing.Point(26, 43);
            tabControl.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(943, 683);
            tabControl.TabIndex = 13;
            // 
            // tabPagePropertyGrid
            // 
            tabPagePropertyGrid.Controls.Add(checkBoxSortByName);
            tabPagePropertyGrid.Controls.Add(propertyGrid1);
            tabPagePropertyGrid.Controls.Add(buttonRefresh);
            tabPagePropertyGrid.Controls.Add(checkBoxNonPublic);
            tabPagePropertyGrid.Controls.Add(buttonObjMulti);
            tabPagePropertyGrid.Controls.Add(radioDisabled);
            tabPagePropertyGrid.Controls.Add(radioReadOnly);
            tabPagePropertyGrid.Controls.Add(buttonObjA);
            tabPagePropertyGrid.Controls.Add(buttonObjB);
            tabPagePropertyGrid.Controls.Add(radioEnabled);
            tabPagePropertyGrid.Location = new System.Drawing.Point(4, 31);
            tabPagePropertyGrid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPagePropertyGrid.Name = "tabPagePropertyGrid";
            tabPagePropertyGrid.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPagePropertyGrid.Size = new System.Drawing.Size(935, 648);
            tabPagePropertyGrid.TabIndex = 0;
            tabPagePropertyGrid.Text = "PropertyGrid";
            tabPagePropertyGrid.UseVisualStyleBackColor = true;
            // 
            // checkBoxSortByName
            // 
            checkBoxSortByName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBoxSortByName.AutoSize = true;
            checkBoxSortByName.Checked = true;
            checkBoxSortByName.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxSortByName.Location = new System.Drawing.Point(676, 617);
            checkBoxSortByName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            checkBoxSortByName.Name = "checkBoxSortByName";
            checkBoxSortByName.Size = new System.Drawing.Size(192, 25);
            checkBoxSortByName.TabIndex = 12;
            checkBoxSortByName.Text = "Sort by Name";
            checkBoxSortByName.UseVisualStyleBackColor = true;
            checkBoxSortByName.CheckedChanged += checkBoxSortByName_CheckedChanged;
            // 
            // propertyGrid1
            // 
            propertyGrid1.AllowDrop = true;
            propertyGrid1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            propertyGrid1.AutoScroll = true;
            propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
            propertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            propertyGrid1.Location = new System.Drawing.Point(13, 10);
            propertyGrid1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.ReadOnly = false;
            propertyGrid1.ShowNonPublic = false;
            propertyGrid1.Size = new System.Drawing.Size(648, 594);
            propertyGrid1.SortEditorsByName = true;
            propertyGrid1.SplitterPosition = 259;
            propertyGrid1.SplitterRatio = 0.4F;
            propertyGrid1.TabIndex = 0;
            // 
            // tabPageTiledView
            // 
            tabPageTiledView.Controls.Add(checkBoxTiledViewStyle);
            tabPageTiledView.Controls.Add(trackBarTileViewHeight);
            tabPageTiledView.Controls.Add(trackBarTileViewWidth);
            tabPageTiledView.Controls.Add(checkBoxTileViewHighlightHover);
            tabPageTiledView.Controls.Add(checkBoxTileViewUserSelect);
            tabPageTiledView.Controls.Add(radioTiledDisabled);
            tabPageTiledView.Controls.Add(radioTiledEnabled);
            tabPageTiledView.Controls.Add(buttonAddThousandTileItems);
            tabPageTiledView.Controls.Add(buttonClearTileItems);
            tabPageTiledView.Controls.Add(buttonRemoveTileItem);
            tabPageTiledView.Controls.Add(buttonAddTenTileItems);
            tabPageTiledView.Controls.Add(tiledView);
            tabPageTiledView.Location = new System.Drawing.Point(4, 39);
            tabPageTiledView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageTiledView.Name = "tabPageTiledView";
            tabPageTiledView.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageTiledView.Size = new System.Drawing.Size(935, 640);
            tabPageTiledView.TabIndex = 1;
            tabPageTiledView.Text = "TiledView";
            tabPageTiledView.UseVisualStyleBackColor = true;
            // 
            // checkBoxTiledViewStyle
            // 
            checkBoxTiledViewStyle.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBoxTiledViewStyle.AutoSize = true;
            checkBoxTiledViewStyle.Location = new System.Drawing.Point(687, 607);
            checkBoxTiledViewStyle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            checkBoxTiledViewStyle.Name = "checkBoxTiledViewStyle";
            checkBoxTiledViewStyle.Size = new System.Drawing.Size(101, 25);
            checkBoxTiledViewStyle.TabIndex = 11;
            checkBoxTiledViewStyle.Text = "Style";
            checkBoxTiledViewStyle.UseVisualStyleBackColor = true;
            checkBoxTiledViewStyle.CheckedChanged += checkBoxTiledViewStyle_CheckedChanged;
            // 
            // trackBarTileViewHeight
            // 
            trackBarTileViewHeight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            trackBarTileViewHeight.BackColor = System.Drawing.SystemColors.Window;
            trackBarTileViewHeight.LargeChange = 50;
            trackBarTileViewHeight.Location = new System.Drawing.Point(836, 197);
            trackBarTileViewHeight.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            trackBarTileViewHeight.Maximum = 250;
            trackBarTileViewHeight.Minimum = 16;
            trackBarTileViewHeight.Name = "trackBarTileViewHeight";
            trackBarTileViewHeight.Orientation = System.Windows.Forms.Orientation.Vertical;
            trackBarTileViewHeight.Size = new System.Drawing.Size(80, 398);
            trackBarTileViewHeight.SmallChange = 5;
            trackBarTileViewHeight.TabIndex = 10;
            trackBarTileViewHeight.TickFrequency = 25;
            trackBarTileViewHeight.Value = 50;
            trackBarTileViewHeight.ValueChanged += trackBarTileViewHeight_ValueChanged;
            // 
            // trackBarTileViewWidth
            // 
            trackBarTileViewWidth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            trackBarTileViewWidth.BackColor = System.Drawing.SystemColors.Window;
            trackBarTileViewWidth.LargeChange = 50;
            trackBarTileViewWidth.Location = new System.Drawing.Point(750, 197);
            trackBarTileViewWidth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            trackBarTileViewWidth.Maximum = 250;
            trackBarTileViewWidth.Minimum = 16;
            trackBarTileViewWidth.Name = "trackBarTileViewWidth";
            trackBarTileViewWidth.Orientation = System.Windows.Forms.Orientation.Vertical;
            trackBarTileViewWidth.Size = new System.Drawing.Size(80, 398);
            trackBarTileViewWidth.SmallChange = 5;
            trackBarTileViewWidth.TabIndex = 9;
            trackBarTileViewWidth.TickFrequency = 25;
            trackBarTileViewWidth.Value = 50;
            trackBarTileViewWidth.ValueChanged += trackBarTileViewWidth_ValueChanged;
            // 
            // checkBoxTileViewHighlightHover
            // 
            checkBoxTileViewHighlightHover.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBoxTileViewHighlightHover.AutoSize = true;
            checkBoxTileViewHighlightHover.Checked = true;
            checkBoxTileViewHighlightHover.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxTileViewHighlightHover.Location = new System.Drawing.Point(503, 608);
            checkBoxTileViewHighlightHover.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            checkBoxTileViewHighlightHover.Name = "checkBoxTileViewHighlightHover";
            checkBoxTileViewHighlightHover.Size = new System.Drawing.Size(153, 25);
            checkBoxTileViewHighlightHover.TabIndex = 8;
            checkBoxTileViewHighlightHover.Text = "Mouseover";
            checkBoxTileViewHighlightHover.UseVisualStyleBackColor = true;
            checkBoxTileViewHighlightHover.CheckedChanged += checkBoxTileViewHighlightHover_CheckedChanged;
            // 
            // checkBoxTileViewUserSelect
            // 
            checkBoxTileViewUserSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBoxTileViewUserSelect.AutoSize = true;
            checkBoxTileViewUserSelect.Checked = true;
            checkBoxTileViewUserSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxTileViewUserSelect.Location = new System.Drawing.Point(321, 608);
            checkBoxTileViewUserSelect.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            checkBoxTileViewUserSelect.Name = "checkBoxTileViewUserSelect";
            checkBoxTileViewUserSelect.Size = new System.Drawing.Size(166, 25);
            checkBoxTileViewUserSelect.TabIndex = 7;
            checkBoxTileViewUserSelect.Text = "UserSelect";
            checkBoxTileViewUserSelect.UseVisualStyleBackColor = true;
            checkBoxTileViewUserSelect.CheckedChanged += checkBoxTileViewUserSelect_CheckedChanged;
            // 
            // radioTiledDisabled
            // 
            radioTiledDisabled.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            radioTiledDisabled.AutoSize = true;
            radioTiledDisabled.Location = new System.Drawing.Point(165, 607);
            radioTiledDisabled.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            radioTiledDisabled.Name = "radioTiledDisabled";
            radioTiledDisabled.Size = new System.Drawing.Size(139, 25);
            radioTiledDisabled.TabIndex = 6;
            radioTiledDisabled.Text = "Disabled";
            radioTiledDisabled.UseVisualStyleBackColor = true;
            radioTiledDisabled.CheckedChanged += radioTiledDisabled_CheckedChanged;
            // 
            // radioTiledEnabled
            // 
            radioTiledEnabled.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            radioTiledEnabled.AutoSize = true;
            radioTiledEnabled.Checked = true;
            radioTiledEnabled.Location = new System.Drawing.Point(13, 607);
            radioTiledEnabled.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            radioTiledEnabled.Name = "radioTiledEnabled";
            radioTiledEnabled.Size = new System.Drawing.Size(126, 25);
            radioTiledEnabled.TabIndex = 5;
            radioTiledEnabled.TabStop = true;
            radioTiledEnabled.Text = "Enabled";
            radioTiledEnabled.UseVisualStyleBackColor = true;
            radioTiledEnabled.CheckedChanged += radioTiledEnabled_CheckedChanged;
            // 
            // buttonAddThousandTileItems
            // 
            buttonAddThousandTileItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonAddThousandTileItems.Location = new System.Drawing.Point(750, 57);
            buttonAddThousandTileItems.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonAddThousandTileItems.Name = "buttonAddThousandTileItems";
            buttonAddThousandTileItems.Size = new System.Drawing.Size(162, 37);
            buttonAddThousandTileItems.TabIndex = 4;
            buttonAddThousandTileItems.Text = "Add 100000";
            buttonAddThousandTileItems.UseVisualStyleBackColor = true;
            buttonAddThousandTileItems.Click += buttonAddThousandTileItems_Click;
            // 
            // buttonClearTileItems
            // 
            buttonClearTileItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonClearTileItems.Location = new System.Drawing.Point(750, 150);
            buttonClearTileItems.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonClearTileItems.Name = "buttonClearTileItems";
            buttonClearTileItems.Size = new System.Drawing.Size(162, 37);
            buttonClearTileItems.TabIndex = 3;
            buttonClearTileItems.Text = "Clear";
            buttonClearTileItems.UseVisualStyleBackColor = true;
            buttonClearTileItems.Click += buttonClearTileItems_Click;
            // 
            // buttonRemoveTileItem
            // 
            buttonRemoveTileItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonRemoveTileItem.Location = new System.Drawing.Point(750, 104);
            buttonRemoveTileItem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonRemoveTileItem.Name = "buttonRemoveTileItem";
            buttonRemoveTileItem.Size = new System.Drawing.Size(162, 37);
            buttonRemoveTileItem.TabIndex = 2;
            buttonRemoveTileItem.Text = "Remove";
            buttonRemoveTileItem.UseVisualStyleBackColor = true;
            buttonRemoveTileItem.Click += buttonRemoveTileItem_Click;
            // 
            // buttonAddTenTileItems
            // 
            buttonAddTenTileItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonAddTenTileItems.Location = new System.Drawing.Point(750, 10);
            buttonAddTenTileItems.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            buttonAddTenTileItems.Name = "buttonAddTenTileItems";
            buttonAddTenTileItems.Size = new System.Drawing.Size(162, 37);
            buttonAddTenTileItems.TabIndex = 1;
            buttonAddTenTileItems.Text = "Add 100";
            buttonAddTenTileItems.UseVisualStyleBackColor = true;
            buttonAddTenTileItems.Click += buttonAddTenTileItems_Click;
            // 
            // tiledView
            // 
            tiledView.AllowUserItemEditing = true;
            tiledView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tiledView.AutoScroll = true;
            tiledView.AutoScrollMinSize = new System.Drawing.Size(0, -2);
            tiledView.BackColor = System.Drawing.SystemColors.Control;
            tiledView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tiledView.HighlightModelItem = null;
            tiledView.Location = new System.Drawing.Point(13, 10);
            tiledView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tiledView.Model = listModel_11;
            tiledView.ModelItemEditProperty = "Name";
            tiledView.Name = "tiledView";
            tiledView.RowAlignment = ItemViews.TiledView.HorizontalAlignment.Center;
            tiledView.Size = new System.Drawing.Size(721, 585);
            tiledView.TabIndex = 0;
            tiledView.TabStop = true;
            tiledView.ItemClicked += tiledView_ItemClicked;
            tiledView.ItemDoubleClicked += tiledView_ItemDoubleClicked;
            tiledView.ItemDrag += tiledView_ItemDrag;
            // 
            // tabPageColorControls
            // 
            tabPageColorControls.Controls.Add(colorSlider4);
            tabPageColorControls.Controls.Add(colorPanel3);
            tabPageColorControls.Controls.Add(colorSlider3);
            tabPageColorControls.Controls.Add(colorPanel2);
            tabPageColorControls.Controls.Add(colorSlider2);
            tabPageColorControls.Controls.Add(colorSlider1);
            tabPageColorControls.Controls.Add(colorPanel1);
            tabPageColorControls.Controls.Add(buttonColorPicker);
            tabPageColorControls.Location = new System.Drawing.Point(4, 39);
            tabPageColorControls.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageColorControls.Name = "tabPageColorControls";
            tabPageColorControls.Size = new System.Drawing.Size(935, 640);
            tabPageColorControls.TabIndex = 2;
            tabPageColorControls.Text = "Color";
            tabPageColorControls.UseVisualStyleBackColor = true;
            // 
            // colorSlider4
            // 
            colorSlider4.Enabled = false;
            colorSlider4.Location = new System.Drawing.Point(687, 5);
            colorSlider4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorSlider4.Name = "colorSlider4";
            colorSlider4.Size = new System.Drawing.Size(65, 323);
            colorSlider4.TabIndex = 19;
            // 
            // colorPanel3
            // 
            colorPanel3.BottomLeftColor = System.Drawing.Color.Blue;
            colorPanel3.BottomRightColor = System.Drawing.Color.Black;
            colorPanel3.Enabled = false;
            colorPanel3.Location = new System.Drawing.Point(453, 337);
            colorPanel3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorPanel3.Name = "colorPanel3";
            colorPanel3.Size = new System.Drawing.Size(449, 244);
            colorPanel3.TabIndex = 18;
            colorPanel3.TopLeftColor = System.Drawing.Color.Red;
            colorPanel3.TopRightColor = System.Drawing.Color.Lime;
            colorPanel3.ValuePercentual = (System.Drawing.PointF)resources.GetObject("colorPanel3.ValuePercentual");
            // 
            // colorSlider3
            // 
            colorSlider3.Location = new System.Drawing.Point(609, 5);
            colorSlider3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorSlider3.Maximum = System.Drawing.Color.Lime;
            colorSlider3.Minimum = System.Drawing.Color.Transparent;
            colorSlider3.Name = "colorSlider3";
            colorSlider3.Size = new System.Drawing.Size(65, 323);
            colorSlider3.TabIndex = 17;
            // 
            // colorPanel2
            // 
            colorPanel2.BottomLeftColor = System.Drawing.Color.Blue;
            colorPanel2.BottomRightColor = System.Drawing.Color.Black;
            colorPanel2.Location = new System.Drawing.Point(6, 337);
            colorPanel2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorPanel2.Name = "colorPanel2";
            colorPanel2.Size = new System.Drawing.Size(433, 244);
            colorPanel2.TabIndex = 16;
            colorPanel2.TopLeftColor = System.Drawing.Color.Red;
            colorPanel2.TopRightColor = System.Drawing.Color.Lime;
            colorPanel2.ValuePercentual = (System.Drawing.PointF)resources.GetObject("colorPanel2.ValuePercentual");
            // 
            // colorSlider2
            // 
            colorSlider2.Location = new System.Drawing.Point(531, 5);
            colorSlider2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorSlider2.Maximum = System.Drawing.Color.Blue;
            colorSlider2.Minimum = System.Drawing.Color.Red;
            colorSlider2.Name = "colorSlider2";
            colorSlider2.Size = new System.Drawing.Size(65, 323);
            colorSlider2.TabIndex = 15;
            // 
            // colorSlider1
            // 
            colorSlider1.Location = new System.Drawing.Point(453, 5);
            colorSlider1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorSlider1.Name = "colorSlider1";
            colorSlider1.Size = new System.Drawing.Size(65, 323);
            colorSlider1.TabIndex = 14;
            // 
            // colorPanel1
            // 
            colorPanel1.Location = new System.Drawing.Point(6, 5);
            colorPanel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            colorPanel1.Name = "colorPanel1";
            colorPanel1.Size = new System.Drawing.Size(433, 323);
            colorPanel1.TabIndex = 13;
            colorPanel1.ValuePercentual = (System.Drawing.PointF)resources.GetObject("colorPanel1.ValuePercentual");
            // 
            // tabPageTimeline
            // 
            tabPageTimeline.Controls.Add(trackBarTimelineUnitZoom);
            tabPageTimeline.Controls.Add(timelineView1);
            tabPageTimeline.Location = new System.Drawing.Point(4, 39);
            tabPageTimeline.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageTimeline.Name = "tabPageTimeline";
            tabPageTimeline.Size = new System.Drawing.Size(935, 640);
            tabPageTimeline.TabIndex = 3;
            tabPageTimeline.Text = "Timeline";
            tabPageTimeline.UseVisualStyleBackColor = true;
            // 
            // trackBarTimelineUnitZoom
            // 
            trackBarTimelineUnitZoom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            trackBarTimelineUnitZoom.BackColor = System.Drawing.SystemColors.Window;
            trackBarTimelineUnitZoom.Location = new System.Drawing.Point(821, 5);
            trackBarTimelineUnitZoom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            trackBarTimelineUnitZoom.Maximum = 1000;
            trackBarTimelineUnitZoom.Minimum = -1000;
            trackBarTimelineUnitZoom.Name = "trackBarTimelineUnitZoom";
            trackBarTimelineUnitZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            trackBarTimelineUnitZoom.Size = new System.Drawing.Size(80, 631);
            trackBarTimelineUnitZoom.TabIndex = 1;
            trackBarTimelineUnitZoom.TickFrequency = 100;
            trackBarTimelineUnitZoom.Value = 1;
            trackBarTimelineUnitZoom.ValueChanged += trackBarTimelineUnitZoom_ValueChanged;
            // 
            // timelineView1
            // 
            timelineView1.AdaptiveDrawingQuality = true;
            timelineView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            timelineView1.AutoScroll = true;
            timelineView1.BackColor = System.Drawing.SystemColors.Control;
            timelineView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            timelineView1.LeftSidebarSize = 50;
            timelineView1.Location = new System.Drawing.Point(6, 5);
            timelineView1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            timelineModel1.UnitBaseScale = 1F;
            timelineModel1.UnitDescription = "Time";
            timelineModel1.UnitName = "Seconds";
            timelineView1.Model = timelineModel1;
            timelineView1.Name = "timelineView1";
            timelineView1.RightSidebarSize = 100;
            timelineView1.SelectionBeginTime = 0F;
            timelineView1.SelectionEndTime = 0F;
            timelineView1.Size = new System.Drawing.Size(799, 631);
            timelineView1.TabIndex = 0;
            timelineView1.TabStop = true;
            // 
            // tabPageOriginSelector
            // 
            tabPageOriginSelector.Controls.Add(originSelector10);
            tabPageOriginSelector.Controls.Add(originSelector11);
            tabPageOriginSelector.Controls.Add(originSelector12);
            tabPageOriginSelector.Controls.Add(originSelector7);
            tabPageOriginSelector.Controls.Add(originSelector8);
            tabPageOriginSelector.Controls.Add(originSelector9);
            tabPageOriginSelector.Controls.Add(originSelector4);
            tabPageOriginSelector.Controls.Add(originSelector5);
            tabPageOriginSelector.Controls.Add(originSelector6);
            tabPageOriginSelector.Controls.Add(originSelector3);
            tabPageOriginSelector.Controls.Add(originSelector2);
            tabPageOriginSelector.Controls.Add(originSelector1);
            tabPageOriginSelector.Location = new System.Drawing.Point(4, 39);
            tabPageOriginSelector.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageOriginSelector.Name = "tabPageOriginSelector";
            tabPageOriginSelector.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            tabPageOriginSelector.Size = new System.Drawing.Size(935, 640);
            tabPageOriginSelector.TabIndex = 4;
            tabPageOriginSelector.Text = "Origin Selector";
            tabPageOriginSelector.UseVisualStyleBackColor = true;
            // 
            // originSelector10
            // 
            originSelector10.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            originSelector10.ForeColor = System.Drawing.Color.CornflowerBlue;
            originSelector10.Location = new System.Drawing.Point(368, 480);
            originSelector10.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector10.Name = "originSelector10";
            originSelector10.SelectionColor = System.Drawing.Color.Orange;
            originSelector10.Size = new System.Drawing.Size(67, 50);
            originSelector10.TabIndex = 11;
            // 
            // originSelector11
            // 
            originSelector11.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            originSelector11.ForeColor = System.Drawing.Color.CornflowerBlue;
            originSelector11.Location = new System.Drawing.Point(223, 480);
            originSelector11.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector11.Name = "originSelector11";
            originSelector11.SelectionColor = System.Drawing.Color.Orange;
            originSelector11.Size = new System.Drawing.Size(132, 99);
            originSelector11.TabIndex = 10;
            // 
            // originSelector12
            // 
            originSelector12.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            originSelector12.ForeColor = System.Drawing.Color.CornflowerBlue;
            originSelector12.Location = new System.Drawing.Point(13, 480);
            originSelector12.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector12.Name = "originSelector12";
            originSelector12.SelectionColor = System.Drawing.Color.Orange;
            originSelector12.Size = new System.Drawing.Size(197, 147);
            originSelector12.TabIndex = 9;
            // 
            // originSelector7
            // 
            originSelector7.BackColor = System.Drawing.SystemColors.Control;
            originSelector7.InvertArrowsHorizontal = true;
            originSelector7.InvertArrowsVertical = true;
            originSelector7.Location = new System.Drawing.Point(368, 323);
            originSelector7.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector7.Name = "originSelector7";
            originSelector7.Size = new System.Drawing.Size(67, 50);
            originSelector7.TabIndex = 8;
            // 
            // originSelector8
            // 
            originSelector8.BackColor = System.Drawing.SystemColors.Control;
            originSelector8.InvertArrowsHorizontal = true;
            originSelector8.InvertArrowsVertical = true;
            originSelector8.Location = new System.Drawing.Point(223, 323);
            originSelector8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector8.Name = "originSelector8";
            originSelector8.Size = new System.Drawing.Size(132, 99);
            originSelector8.TabIndex = 7;
            // 
            // originSelector9
            // 
            originSelector9.BackColor = System.Drawing.SystemColors.Control;
            originSelector9.InvertArrowsHorizontal = true;
            originSelector9.InvertArrowsVertical = true;
            originSelector9.Location = new System.Drawing.Point(13, 323);
            originSelector9.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector9.Name = "originSelector9";
            originSelector9.Size = new System.Drawing.Size(197, 147);
            originSelector9.TabIndex = 6;
            // 
            // originSelector4
            // 
            originSelector4.BackColor = System.Drawing.SystemColors.Control;
            originSelector4.InvertArrowsHorizontal = true;
            originSelector4.Location = new System.Drawing.Point(368, 167);
            originSelector4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector4.Name = "originSelector4";
            originSelector4.Size = new System.Drawing.Size(67, 50);
            originSelector4.TabIndex = 5;
            // 
            // originSelector5
            // 
            originSelector5.BackColor = System.Drawing.SystemColors.Control;
            originSelector5.InvertArrowsHorizontal = true;
            originSelector5.Location = new System.Drawing.Point(223, 167);
            originSelector5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector5.Name = "originSelector5";
            originSelector5.Size = new System.Drawing.Size(132, 99);
            originSelector5.TabIndex = 4;
            // 
            // originSelector6
            // 
            originSelector6.BackColor = System.Drawing.SystemColors.Control;
            originSelector6.InvertArrowsHorizontal = true;
            originSelector6.Location = new System.Drawing.Point(13, 167);
            originSelector6.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector6.Name = "originSelector6";
            originSelector6.Size = new System.Drawing.Size(197, 147);
            originSelector6.TabIndex = 3;
            // 
            // originSelector3
            // 
            originSelector3.BackColor = System.Drawing.SystemColors.Control;
            originSelector3.Location = new System.Drawing.Point(368, 10);
            originSelector3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector3.Name = "originSelector3";
            originSelector3.Size = new System.Drawing.Size(67, 50);
            originSelector3.TabIndex = 2;
            // 
            // originSelector2
            // 
            originSelector2.BackColor = System.Drawing.SystemColors.Control;
            originSelector2.Location = new System.Drawing.Point(223, 10);
            originSelector2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector2.Name = "originSelector2";
            originSelector2.Size = new System.Drawing.Size(132, 99);
            originSelector2.TabIndex = 1;
            // 
            // originSelector1
            // 
            originSelector1.BackColor = System.Drawing.SystemColors.Control;
            originSelector1.Location = new System.Drawing.Point(13, 10);
            originSelector1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            originSelector1.Name = "originSelector1";
            originSelector1.Size = new System.Drawing.Size(197, 147);
            originSelector1.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(13, 4, 0, 4);
            menuStrip.Size = new System.Drawing.Size(995, 24);
            menuStrip.TabIndex = 14;
            menuStrip.Text = "Main Menu";
            // 
            // DemoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(995, 746);
            Controls.Add(tabControl);
            Controls.Add(menuStrip);
            Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            MinimumSize = new System.Drawing.Size(1001, 768);
            Name = "DemoForm";
            Text = "Form1";
            tabControl.ResumeLayout(false);
            tabPagePropertyGrid.ResumeLayout(false);
            tabPagePropertyGrid.PerformLayout();
            tabPageTiledView.ResumeLayout(false);
            tabPageTiledView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTileViewHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarTileViewWidth).EndInit();
            tabPageColorControls.ResumeLayout(false);
            tabPageTimeline.ResumeLayout(false);
            tabPageTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTimelineUnitZoom).EndInit();
            tabPageOriginSelector.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private AdamsLair.WinForms.PropertyEditing.PropertyGrid propertyGrid1;
		private System.Windows.Forms.RadioButton radioEnabled;
		private System.Windows.Forms.RadioButton radioDisabled;
		private System.Windows.Forms.RadioButton radioReadOnly;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.CheckBox checkBoxNonPublic;
		private System.Windows.Forms.Button buttonObjA;
		private System.Windows.Forms.Button buttonObjB;
		private System.Windows.Forms.Button buttonObjMulti;
		private System.Windows.Forms.Button buttonColorPicker;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPagePropertyGrid;
		private System.Windows.Forms.TabPage tabPageTiledView;
		private System.Windows.Forms.TabPage tabPageColorControls;
		private AdamsLair.WinForms.ColorControls.ColorSlider colorSlider3;
		private AdamsLair.WinForms.ColorControls.ColorPanel colorPanel2;
		private AdamsLair.WinForms.ColorControls.ColorSlider colorSlider2;
		private AdamsLair.WinForms.ColorControls.ColorSlider colorSlider1;
		private AdamsLair.WinForms.ColorControls.ColorPanel colorPanel1;
		private AdamsLair.WinForms.ItemViews.TiledView tiledView;
		private System.Windows.Forms.Button buttonClearTileItems;
		private System.Windows.Forms.Button buttonRemoveTileItem;
		private System.Windows.Forms.Button buttonAddTenTileItems;
		private System.Windows.Forms.Button buttonAddThousandTileItems;
		private System.Windows.Forms.RadioButton radioTiledDisabled;
		private System.Windows.Forms.RadioButton radioTiledEnabled;
		private System.Windows.Forms.CheckBox checkBoxTileViewHighlightHover;
		private System.Windows.Forms.CheckBox checkBoxTileViewUserSelect;
		private System.Windows.Forms.TrackBar trackBarTileViewWidth;
		private ColorControls.ColorSlider colorSlider4;
		private ColorControls.ColorPanel colorPanel3;
		private System.Windows.Forms.TrackBar trackBarTileViewHeight;
		private System.Windows.Forms.CheckBox checkBoxTiledViewStyle;
		private System.Windows.Forms.TabPage tabPageTimeline;
		private TimelineControls.TimelineView timelineView1;
		private System.Windows.Forms.TrackBar trackBarTimelineUnitZoom;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.TabPage tabPageOriginSelector;
		private OriginSelector originSelector1;
		private OriginSelector originSelector3;
		private OriginSelector originSelector2;
		private OriginSelector originSelector7;
		private OriginSelector originSelector8;
		private OriginSelector originSelector9;
		private OriginSelector originSelector4;
		private OriginSelector originSelector5;
		private OriginSelector originSelector6;
		private OriginSelector originSelector10;
		private OriginSelector originSelector11;
		private OriginSelector originSelector12;
		private System.Windows.Forms.CheckBox checkBoxSortByName;
	}
}

