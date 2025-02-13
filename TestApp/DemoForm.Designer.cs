﻿using AdamsLair.WinForms.ItemViews.EventArgs;
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
			AdamsLair.WinForms.ItemModels.ListModel<object> listModel_11 = new AdamsLair.WinForms.ItemModels.ListModel<object>();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
			TimelineModel timelineModel1 = new TimelineModel();
			this.radioEnabled = new System.Windows.Forms.RadioButton();
			this.radioDisabled = new System.Windows.Forms.RadioButton();
			this.radioReadOnly = new System.Windows.Forms.RadioButton();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.checkBoxNonPublic = new System.Windows.Forms.CheckBox();
			this.buttonObjA = new System.Windows.Forms.Button();
			this.buttonObjB = new System.Windows.Forms.Button();
			this.buttonObjMulti = new System.Windows.Forms.Button();
			this.buttonColorPicker = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPagePropertyGrid = new System.Windows.Forms.TabPage();
			this.checkBoxSortByName = new System.Windows.Forms.CheckBox();
			this.propertyGrid1 = new AdamsLair.WinForms.PropertyEditing.PropertyGrid();
			this.tabPageTiledView = new System.Windows.Forms.TabPage();
			this.checkBoxTiledViewStyle = new System.Windows.Forms.CheckBox();
			this.trackBarTileViewHeight = new System.Windows.Forms.TrackBar();
			this.trackBarTileViewWidth = new System.Windows.Forms.TrackBar();
			this.checkBoxTileViewHighlightHover = new System.Windows.Forms.CheckBox();
			this.checkBoxTileViewUserSelect = new System.Windows.Forms.CheckBox();
			this.radioTiledDisabled = new System.Windows.Forms.RadioButton();
			this.radioTiledEnabled = new System.Windows.Forms.RadioButton();
			this.buttonAddThousandTileItems = new System.Windows.Forms.Button();
			this.buttonClearTileItems = new System.Windows.Forms.Button();
			this.buttonRemoveTileItem = new System.Windows.Forms.Button();
			this.buttonAddTenTileItems = new System.Windows.Forms.Button();
			this.tiledView = new AdamsLair.WinForms.ItemViews.TiledView();
			this.tabPageColorControls = new System.Windows.Forms.TabPage();
			this.colorSlider4 = new AdamsLair.WinForms.ColorControls.ColorSlider();
			this.colorPanel3 = new AdamsLair.WinForms.ColorControls.ColorPanel();
			this.colorSlider3 = new AdamsLair.WinForms.ColorControls.ColorSlider();
			this.colorPanel2 = new AdamsLair.WinForms.ColorControls.ColorPanel();
			this.colorSlider2 = new AdamsLair.WinForms.ColorControls.ColorSlider();
			this.colorSlider1 = new AdamsLair.WinForms.ColorControls.ColorSlider();
			this.colorPanel1 = new AdamsLair.WinForms.ColorControls.ColorPanel();
			this.tabPageTimeline = new System.Windows.Forms.TabPage();
			this.trackBarTimelineUnitZoom = new System.Windows.Forms.TrackBar();
			this.timelineView1 = new AdamsLair.WinForms.TimelineControls.TimelineView();
			this.tabPageOriginSelector = new System.Windows.Forms.TabPage();
			this.originSelector10 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector11 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector12 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector7 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector8 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector9 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector4 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector5 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector6 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector3 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector2 = new AdamsLair.WinForms.OriginSelector();
			this.originSelector1 = new AdamsLair.WinForms.OriginSelector();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.tabControl.SuspendLayout();
			this.tabPagePropertyGrid.SuspendLayout();
			this.tabPageTiledView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTileViewHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTileViewWidth)).BeginInit();
			this.tabPageColorControls.SuspendLayout();
			this.tabPageTimeline.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTimelineUnitZoom)).BeginInit();
			this.tabPageOriginSelector.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioEnabled
			// 
			this.radioEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioEnabled.AutoSize = true;
			this.radioEnabled.Checked = true;
			this.radioEnabled.Location = new System.Drawing.Point(6, 376);
			this.radioEnabled.Name = "radioEnabled";
			this.radioEnabled.Size = new System.Drawing.Size(64, 17);
			this.radioEnabled.TabIndex = 3;
			this.radioEnabled.TabStop = true;
			this.radioEnabled.Text = "Enabled";
			this.radioEnabled.UseVisualStyleBackColor = true;
			this.radioEnabled.CheckedChanged += new System.EventHandler(this.radioEnabled_CheckedChanged);
			// 
			// radioDisabled
			// 
			this.radioDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioDisabled.AutoSize = true;
			this.radioDisabled.Location = new System.Drawing.Point(154, 376);
			this.radioDisabled.Name = "radioDisabled";
			this.radioDisabled.Size = new System.Drawing.Size(66, 17);
			this.radioDisabled.TabIndex = 4;
			this.radioDisabled.Text = "Disabled";
			this.radioDisabled.UseVisualStyleBackColor = true;
			this.radioDisabled.CheckedChanged += new System.EventHandler(this.radioDisabled_CheckedChanged);
			// 
			// radioReadOnly
			// 
			this.radioReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioReadOnly.AutoSize = true;
			this.radioReadOnly.Location = new System.Drawing.Point(76, 376);
			this.radioReadOnly.Name = "radioReadOnly";
			this.radioReadOnly.Size = new System.Drawing.Size(72, 17);
			this.radioReadOnly.TabIndex = 5;
			this.radioReadOnly.Text = "ReadOnly";
			this.radioReadOnly.UseVisualStyleBackColor = true;
			this.radioReadOnly.CheckedChanged += new System.EventHandler(this.radioReadOnly_CheckedChanged);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.Location = new System.Drawing.Point(312, 6);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(108, 23);
			this.buttonRefresh.TabIndex = 6;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// checkBoxNonPublic
			// 
			this.checkBoxNonPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNonPublic.AutoSize = true;
			this.checkBoxNonPublic.Location = new System.Drawing.Point(226, 376);
			this.checkBoxNonPublic.Name = "checkBoxNonPublic";
			this.checkBoxNonPublic.Size = new System.Drawing.Size(78, 17);
			this.checkBoxNonPublic.TabIndex = 8;
			this.checkBoxNonPublic.Text = "Non-Public";
			this.checkBoxNonPublic.UseVisualStyleBackColor = true;
			this.checkBoxNonPublic.CheckedChanged += new System.EventHandler(this.checkBoxNonPublic_CheckedChanged);
			// 
			// buttonObjA
			// 
			this.buttonObjA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonObjA.Location = new System.Drawing.Point(312, 35);
			this.buttonObjA.Name = "buttonObjA";
			this.buttonObjA.Size = new System.Drawing.Size(108, 23);
			this.buttonObjA.TabIndex = 9;
			this.buttonObjA.Text = "Select Object A";
			this.buttonObjA.UseVisualStyleBackColor = true;
			this.buttonObjA.Click += new System.EventHandler(this.buttonObjA_Click);
			// 
			// buttonObjB
			// 
			this.buttonObjB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonObjB.Location = new System.Drawing.Point(312, 64);
			this.buttonObjB.Name = "buttonObjB";
			this.buttonObjB.Size = new System.Drawing.Size(108, 23);
			this.buttonObjB.TabIndex = 10;
			this.buttonObjB.Text = "Select Object B";
			this.buttonObjB.UseVisualStyleBackColor = true;
			this.buttonObjB.Click += new System.EventHandler(this.buttonObjB_Click);
			// 
			// buttonObjMulti
			// 
			this.buttonObjMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonObjMulti.Location = new System.Drawing.Point(312, 93);
			this.buttonObjMulti.Name = "buttonObjMulti";
			this.buttonObjMulti.Size = new System.Drawing.Size(108, 23);
			this.buttonObjMulti.TabIndex = 11;
			this.buttonObjMulti.Text = "Select A and B";
			this.buttonObjMulti.UseVisualStyleBackColor = true;
			this.buttonObjMulti.Click += new System.EventHandler(this.buttonObjMulti_Click);
			// 
			// buttonColorPicker
			// 
			this.buttonColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonColorPicker.Location = new System.Drawing.Point(293, 366);
			this.buttonColorPicker.Name = "buttonColorPicker";
			this.buttonColorPicker.Size = new System.Drawing.Size(123, 23);
			this.buttonColorPicker.TabIndex = 12;
			this.buttonColorPicker.Text = "Open ColorPicker";
			this.buttonColorPicker.UseVisualStyleBackColor = true;
			this.buttonColorPicker.Click += new System.EventHandler(this.buttonColorPicker_Click);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPagePropertyGrid);
			this.tabControl.Controls.Add(this.tabPageTiledView);
			this.tabControl.Controls.Add(this.tabPageColorControls);
			this.tabControl.Controls.Add(this.tabPageTimeline);
			this.tabControl.Controls.Add(this.tabPageOriginSelector);
			this.tabControl.Location = new System.Drawing.Point(12, 27);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(435, 423);
			this.tabControl.TabIndex = 13;
			// 
			// tabPagePropertyGrid
			// 
			this.tabPagePropertyGrid.Controls.Add(this.checkBoxSortByName);
			this.tabPagePropertyGrid.Controls.Add(this.propertyGrid1);
			this.tabPagePropertyGrid.Controls.Add(this.buttonRefresh);
			this.tabPagePropertyGrid.Controls.Add(this.checkBoxNonPublic);
			this.tabPagePropertyGrid.Controls.Add(this.buttonObjMulti);
			this.tabPagePropertyGrid.Controls.Add(this.radioDisabled);
			this.tabPagePropertyGrid.Controls.Add(this.radioReadOnly);
			this.tabPagePropertyGrid.Controls.Add(this.buttonObjA);
			this.tabPagePropertyGrid.Controls.Add(this.buttonObjB);
			this.tabPagePropertyGrid.Controls.Add(this.radioEnabled);
			this.tabPagePropertyGrid.Location = new System.Drawing.Point(4, 22);
			this.tabPagePropertyGrid.Name = "tabPagePropertyGrid";
			this.tabPagePropertyGrid.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePropertyGrid.Size = new System.Drawing.Size(427, 397);
			this.tabPagePropertyGrid.TabIndex = 0;
			this.tabPagePropertyGrid.Text = "PropertyGrid";
			this.tabPagePropertyGrid.UseVisualStyleBackColor = true;
			// 
			// checkBoxSortByName
			// 
			this.checkBoxSortByName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxSortByName.AutoSize = true;
			this.checkBoxSortByName.Checked = true;
			this.checkBoxSortByName.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSortByName.Location = new System.Drawing.Point(312, 376);
			this.checkBoxSortByName.Name = "checkBoxSortByName";
			this.checkBoxSortByName.Size = new System.Drawing.Size(90, 17);
			this.checkBoxSortByName.TabIndex = 12;
			this.checkBoxSortByName.Text = "Sort by Name";
			this.checkBoxSortByName.UseVisualStyleBackColor = true;
			this.checkBoxSortByName.CheckedChanged += new System.EventHandler(this.checkBoxSortByName_CheckedChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.AllowDrop = true;
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.AutoScroll = true;
			this.propertyGrid1.BackColor = System.Drawing.SystemColors.Control;
			this.propertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.propertyGrid1.Location = new System.Drawing.Point(6, 6);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.ReadOnly = false;
			this.propertyGrid1.ShowNonPublic = false;
			this.propertyGrid1.Size = new System.Drawing.Size(300, 364);
			this.propertyGrid1.SortEditorsByName = true;
			this.propertyGrid1.SplitterPosition = 120;
			this.propertyGrid1.SplitterRatio = 0.4F;
			this.propertyGrid1.TabIndex = 0;
			// 
			// tabPageTiledView
			// 
			this.tabPageTiledView.Controls.Add(this.checkBoxTiledViewStyle);
			this.tabPageTiledView.Controls.Add(this.trackBarTileViewHeight);
			this.tabPageTiledView.Controls.Add(this.trackBarTileViewWidth);
			this.tabPageTiledView.Controls.Add(this.checkBoxTileViewHighlightHover);
			this.tabPageTiledView.Controls.Add(this.checkBoxTileViewUserSelect);
			this.tabPageTiledView.Controls.Add(this.radioTiledDisabled);
			this.tabPageTiledView.Controls.Add(this.radioTiledEnabled);
			this.tabPageTiledView.Controls.Add(this.buttonAddThousandTileItems);
			this.tabPageTiledView.Controls.Add(this.buttonClearTileItems);
			this.tabPageTiledView.Controls.Add(this.buttonRemoveTileItem);
			this.tabPageTiledView.Controls.Add(this.buttonAddTenTileItems);
			this.tabPageTiledView.Controls.Add(this.tiledView);
			this.tabPageTiledView.Location = new System.Drawing.Point(4, 22);
			this.tabPageTiledView.Name = "tabPageTiledView";
			this.tabPageTiledView.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTiledView.Size = new System.Drawing.Size(427, 397);
			this.tabPageTiledView.TabIndex = 1;
			this.tabPageTiledView.Text = "TiledView";
			this.tabPageTiledView.UseVisualStyleBackColor = true;
			// 
			// checkBoxTiledViewStyle
			// 
			this.checkBoxTiledViewStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxTiledViewStyle.AutoSize = true;
			this.checkBoxTiledViewStyle.Location = new System.Drawing.Point(317, 374);
			this.checkBoxTiledViewStyle.Name = "checkBoxTiledViewStyle";
			this.checkBoxTiledViewStyle.Size = new System.Drawing.Size(49, 17);
			this.checkBoxTiledViewStyle.TabIndex = 11;
			this.checkBoxTiledViewStyle.Text = "Style";
			this.checkBoxTiledViewStyle.UseVisualStyleBackColor = true;
			this.checkBoxTiledViewStyle.CheckedChanged += new System.EventHandler(this.checkBoxTiledViewStyle_CheckedChanged);
			// 
			// trackBarTileViewHeight
			// 
			this.trackBarTileViewHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarTileViewHeight.BackColor = System.Drawing.SystemColors.Window;
			this.trackBarTileViewHeight.LargeChange = 50;
			this.trackBarTileViewHeight.Location = new System.Drawing.Point(386, 122);
			this.trackBarTileViewHeight.Maximum = 250;
			this.trackBarTileViewHeight.Minimum = 16;
			this.trackBarTileViewHeight.Name = "trackBarTileViewHeight";
			this.trackBarTileViewHeight.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarTileViewHeight.Size = new System.Drawing.Size(45, 246);
			this.trackBarTileViewHeight.SmallChange = 5;
			this.trackBarTileViewHeight.TabIndex = 10;
			this.trackBarTileViewHeight.TickFrequency = 25;
			this.trackBarTileViewHeight.Value = 50;
			this.trackBarTileViewHeight.ValueChanged += new System.EventHandler(this.trackBarTileViewHeight_ValueChanged);
			// 
			// trackBarTileViewWidth
			// 
			this.trackBarTileViewWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarTileViewWidth.BackColor = System.Drawing.SystemColors.Window;
			this.trackBarTileViewWidth.LargeChange = 50;
			this.trackBarTileViewWidth.Location = new System.Drawing.Point(346, 122);
			this.trackBarTileViewWidth.Maximum = 250;
			this.trackBarTileViewWidth.Minimum = 16;
			this.trackBarTileViewWidth.Name = "trackBarTileViewWidth";
			this.trackBarTileViewWidth.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarTileViewWidth.Size = new System.Drawing.Size(45, 246);
			this.trackBarTileViewWidth.SmallChange = 5;
			this.trackBarTileViewWidth.TabIndex = 9;
			this.trackBarTileViewWidth.TickFrequency = 25;
			this.trackBarTileViewWidth.Value = 50;
			this.trackBarTileViewWidth.ValueChanged += new System.EventHandler(this.trackBarTileViewWidth_ValueChanged);
			// 
			// checkBoxTileViewHighlightHover
			// 
			this.checkBoxTileViewHighlightHover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxTileViewHighlightHover.AutoSize = true;
			this.checkBoxTileViewHighlightHover.Checked = true;
			this.checkBoxTileViewHighlightHover.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxTileViewHighlightHover.Location = new System.Drawing.Point(232, 375);
			this.checkBoxTileViewHighlightHover.Name = "checkBoxTileViewHighlightHover";
			this.checkBoxTileViewHighlightHover.Size = new System.Drawing.Size(79, 17);
			this.checkBoxTileViewHighlightHover.TabIndex = 8;
			this.checkBoxTileViewHighlightHover.Text = "Mouseover";
			this.checkBoxTileViewHighlightHover.UseVisualStyleBackColor = true;
			this.checkBoxTileViewHighlightHover.CheckedChanged += new System.EventHandler(this.checkBoxTileViewHighlightHover_CheckedChanged);
			// 
			// checkBoxTileViewUserSelect
			// 
			this.checkBoxTileViewUserSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxTileViewUserSelect.AutoSize = true;
			this.checkBoxTileViewUserSelect.Checked = true;
			this.checkBoxTileViewUserSelect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxTileViewUserSelect.Location = new System.Drawing.Point(148, 375);
			this.checkBoxTileViewUserSelect.Name = "checkBoxTileViewUserSelect";
			this.checkBoxTileViewUserSelect.Size = new System.Drawing.Size(78, 17);
			this.checkBoxTileViewUserSelect.TabIndex = 7;
			this.checkBoxTileViewUserSelect.Text = "UserSelect";
			this.checkBoxTileViewUserSelect.UseVisualStyleBackColor = true;
			this.checkBoxTileViewUserSelect.CheckedChanged += new System.EventHandler(this.checkBoxTileViewUserSelect_CheckedChanged);
			// 
			// radioTiledDisabled
			// 
			this.radioTiledDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioTiledDisabled.AutoSize = true;
			this.radioTiledDisabled.Location = new System.Drawing.Point(76, 374);
			this.radioTiledDisabled.Name = "radioTiledDisabled";
			this.radioTiledDisabled.Size = new System.Drawing.Size(66, 17);
			this.radioTiledDisabled.TabIndex = 6;
			this.radioTiledDisabled.Text = "Disabled";
			this.radioTiledDisabled.UseVisualStyleBackColor = true;
			this.radioTiledDisabled.CheckedChanged += new System.EventHandler(this.radioTiledDisabled_CheckedChanged);
			// 
			// radioTiledEnabled
			// 
			this.radioTiledEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.radioTiledEnabled.AutoSize = true;
			this.radioTiledEnabled.Checked = true;
			this.radioTiledEnabled.Location = new System.Drawing.Point(6, 374);
			this.radioTiledEnabled.Name = "radioTiledEnabled";
			this.radioTiledEnabled.Size = new System.Drawing.Size(64, 17);
			this.radioTiledEnabled.TabIndex = 5;
			this.radioTiledEnabled.TabStop = true;
			this.radioTiledEnabled.Text = "Enabled";
			this.radioTiledEnabled.UseVisualStyleBackColor = true;
			this.radioTiledEnabled.CheckedChanged += new System.EventHandler(this.radioTiledEnabled_CheckedChanged);
			// 
			// buttonAddThousandTileItems
			// 
			this.buttonAddThousandTileItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddThousandTileItems.Location = new System.Drawing.Point(346, 35);
			this.buttonAddThousandTileItems.Name = "buttonAddThousandTileItems";
			this.buttonAddThousandTileItems.Size = new System.Drawing.Size(75, 23);
			this.buttonAddThousandTileItems.TabIndex = 4;
			this.buttonAddThousandTileItems.Text = "Add 100000";
			this.buttonAddThousandTileItems.UseVisualStyleBackColor = true;
			this.buttonAddThousandTileItems.Click += new System.EventHandler(this.buttonAddThousandTileItems_Click);
			// 
			// buttonClearTileItems
			// 
			this.buttonClearTileItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClearTileItems.Location = new System.Drawing.Point(346, 93);
			this.buttonClearTileItems.Name = "buttonClearTileItems";
			this.buttonClearTileItems.Size = new System.Drawing.Size(75, 23);
			this.buttonClearTileItems.TabIndex = 3;
			this.buttonClearTileItems.Text = "Clear";
			this.buttonClearTileItems.UseVisualStyleBackColor = true;
			this.buttonClearTileItems.Click += new System.EventHandler(this.buttonClearTileItems_Click);
			// 
			// buttonRemoveTileItem
			// 
			this.buttonRemoveTileItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemoveTileItem.Location = new System.Drawing.Point(346, 64);
			this.buttonRemoveTileItem.Name = "buttonRemoveTileItem";
			this.buttonRemoveTileItem.Size = new System.Drawing.Size(75, 23);
			this.buttonRemoveTileItem.TabIndex = 2;
			this.buttonRemoveTileItem.Text = "Remove";
			this.buttonRemoveTileItem.UseVisualStyleBackColor = true;
			this.buttonRemoveTileItem.Click += new System.EventHandler(this.buttonRemoveTileItem_Click);
			// 
			// buttonAddTenTileItems
			// 
			this.buttonAddTenTileItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddTenTileItems.Location = new System.Drawing.Point(346, 6);
			this.buttonAddTenTileItems.Name = "buttonAddTenTileItems";
			this.buttonAddTenTileItems.Size = new System.Drawing.Size(75, 23);
			this.buttonAddTenTileItems.TabIndex = 1;
			this.buttonAddTenTileItems.Text = "Add 100";
			this.buttonAddTenTileItems.UseVisualStyleBackColor = true;
			this.buttonAddTenTileItems.Click += new System.EventHandler(this.buttonAddTenTileItems_Click);
			// 
			// tiledView
			// 
			this.tiledView.AllowUserItemEditing = true;
			this.tiledView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tiledView.AutoScroll = true;
			this.tiledView.AutoScrollMinSize = new System.Drawing.Size(0, -2);
			this.tiledView.BackColor = System.Drawing.SystemColors.Control;
			this.tiledView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tiledView.HighlightModelItem = null;
			this.tiledView.Location = new System.Drawing.Point(6, 6);
			this.tiledView.Model = listModel_11;
			this.tiledView.ModelItemEditProperty = "Name";
			this.tiledView.Name = "tiledView";
			this.tiledView.RowAlignment = AdamsLair.WinForms.ItemViews.TiledView.HorizontalAlignment.Center;
			this.tiledView.Size = new System.Drawing.Size(334, 363);
			this.tiledView.TabIndex = 0;
			this.tiledView.TabStop = true;
			this.tiledView.ItemClicked += new System.EventHandler<TiledViewItemMouseEventArgs>(this.tiledView_ItemClicked);
			this.tiledView.ItemDoubleClicked += new System.EventHandler<TiledViewItemMouseEventArgs>(this.tiledView_ItemDoubleClicked);
			this.tiledView.ItemDrag += new System.EventHandler<TiledViewItemMouseEventArgs>(this.tiledView_ItemDrag);
			// 
			// tabPageColorControls
			// 
			this.tabPageColorControls.Controls.Add(this.colorSlider4);
			this.tabPageColorControls.Controls.Add(this.colorPanel3);
			this.tabPageColorControls.Controls.Add(this.colorSlider3);
			this.tabPageColorControls.Controls.Add(this.colorPanel2);
			this.tabPageColorControls.Controls.Add(this.colorSlider2);
			this.tabPageColorControls.Controls.Add(this.colorSlider1);
			this.tabPageColorControls.Controls.Add(this.colorPanel1);
			this.tabPageColorControls.Controls.Add(this.buttonColorPicker);
			this.tabPageColorControls.Location = new System.Drawing.Point(4, 22);
			this.tabPageColorControls.Name = "tabPageColorControls";
			this.tabPageColorControls.Size = new System.Drawing.Size(427, 397);
			this.tabPageColorControls.TabIndex = 2;
			this.tabPageColorControls.Text = "Color";
			this.tabPageColorControls.UseVisualStyleBackColor = true;
			// 
			// colorSlider4
			// 
			this.colorSlider4.Enabled = false;
			this.colorSlider4.Location = new System.Drawing.Point(317, 3);
			this.colorSlider4.Name = "colorSlider4";
			this.colorSlider4.Size = new System.Drawing.Size(30, 200);
			this.colorSlider4.TabIndex = 19;
			// 
			// colorPanel3
			// 
			this.colorPanel3.BottomLeftColor = System.Drawing.Color.Blue;
			this.colorPanel3.BottomRightColor = System.Drawing.Color.Black;
			this.colorPanel3.Enabled = false;
			this.colorPanel3.Location = new System.Drawing.Point(209, 209);
			this.colorPanel3.Name = "colorPanel3";
			this.colorPanel3.Size = new System.Drawing.Size(207, 151);
			this.colorPanel3.TabIndex = 18;
			this.colorPanel3.TopLeftColor = System.Drawing.Color.Red;
			this.colorPanel3.TopRightColor = System.Drawing.Color.Lime;
			this.colorPanel3.ValuePercentual = ((System.Drawing.PointF)(resources.GetObject("colorPanel3.ValuePercentual")));
			// 
			// colorSlider3
			// 
			this.colorSlider3.Location = new System.Drawing.Point(281, 3);
			this.colorSlider3.Maximum = System.Drawing.Color.Lime;
			this.colorSlider3.Minimum = System.Drawing.Color.Transparent;
			this.colorSlider3.Name = "colorSlider3";
			this.colorSlider3.Size = new System.Drawing.Size(30, 200);
			this.colorSlider3.TabIndex = 17;
			// 
			// colorPanel2
			// 
			this.colorPanel2.BottomLeftColor = System.Drawing.Color.Blue;
			this.colorPanel2.BottomRightColor = System.Drawing.Color.Black;
			this.colorPanel2.Location = new System.Drawing.Point(3, 209);
			this.colorPanel2.Name = "colorPanel2";
			this.colorPanel2.Size = new System.Drawing.Size(200, 151);
			this.colorPanel2.TabIndex = 16;
			this.colorPanel2.TopLeftColor = System.Drawing.Color.Red;
			this.colorPanel2.TopRightColor = System.Drawing.Color.Lime;
			this.colorPanel2.ValuePercentual = ((System.Drawing.PointF)(resources.GetObject("colorPanel2.ValuePercentual")));
			// 
			// colorSlider2
			// 
			this.colorSlider2.Location = new System.Drawing.Point(245, 3);
			this.colorSlider2.Maximum = System.Drawing.Color.Blue;
			this.colorSlider2.Minimum = System.Drawing.Color.Red;
			this.colorSlider2.Name = "colorSlider2";
			this.colorSlider2.Size = new System.Drawing.Size(30, 200);
			this.colorSlider2.TabIndex = 15;
			// 
			// colorSlider1
			// 
			this.colorSlider1.Location = new System.Drawing.Point(209, 3);
			this.colorSlider1.Name = "colorSlider1";
			this.colorSlider1.Size = new System.Drawing.Size(30, 200);
			this.colorSlider1.TabIndex = 14;
			// 
			// colorPanel1
			// 
			this.colorPanel1.Location = new System.Drawing.Point(3, 3);
			this.colorPanel1.Name = "colorPanel1";
			this.colorPanel1.Size = new System.Drawing.Size(200, 200);
			this.colorPanel1.TabIndex = 13;
			this.colorPanel1.ValuePercentual = ((System.Drawing.PointF)(resources.GetObject("colorPanel1.ValuePercentual")));
			// 
			// tabPageTimeline
			// 
			this.tabPageTimeline.Controls.Add(this.trackBarTimelineUnitZoom);
			this.tabPageTimeline.Controls.Add(this.timelineView1);
			this.tabPageTimeline.Location = new System.Drawing.Point(4, 22);
			this.tabPageTimeline.Name = "tabPageTimeline";
			this.tabPageTimeline.Size = new System.Drawing.Size(427, 397);
			this.tabPageTimeline.TabIndex = 3;
			this.tabPageTimeline.Text = "Timeline";
			this.tabPageTimeline.UseVisualStyleBackColor = true;
			// 
			// trackBarTimelineUnitZoom
			// 
			this.trackBarTimelineUnitZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarTimelineUnitZoom.BackColor = System.Drawing.SystemColors.Window;
			this.trackBarTimelineUnitZoom.Location = new System.Drawing.Point(379, 3);
			this.trackBarTimelineUnitZoom.Maximum = 1000;
			this.trackBarTimelineUnitZoom.Minimum = -1000;
			this.trackBarTimelineUnitZoom.Name = "trackBarTimelineUnitZoom";
			this.trackBarTimelineUnitZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarTimelineUnitZoom.Size = new System.Drawing.Size(45, 391);
			this.trackBarTimelineUnitZoom.TabIndex = 1;
			this.trackBarTimelineUnitZoom.TickFrequency = 100;
			this.trackBarTimelineUnitZoom.Value = 1;
			this.trackBarTimelineUnitZoom.ValueChanged += new System.EventHandler(this.trackBarTimelineUnitZoom_ValueChanged);
			// 
			// timelineView1
			// 
			this.timelineView1.AdaptiveDrawingQuality = true;
			this.timelineView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.timelineView1.AutoScroll = true;
			this.timelineView1.BackColor = System.Drawing.SystemColors.Control;
			this.timelineView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.timelineView1.LeftSidebarSize = 50;
			this.timelineView1.Location = new System.Drawing.Point(3, 3);
			timelineModel1.UnitBaseScale = 1F;
			timelineModel1.UnitDescription = "Time";
			timelineModel1.UnitName = "Seconds";
			this.timelineView1.Model = timelineModel1;
			this.timelineView1.Name = "timelineView1";
			this.timelineView1.RightSidebarSize = 100;
			this.timelineView1.SelectionBeginTime = 0F;
			this.timelineView1.SelectionEndTime = 0F;
			this.timelineView1.Size = new System.Drawing.Size(370, 391);
			this.timelineView1.TabIndex = 0;
			this.timelineView1.TabStop = true;
			// 
			// tabPageOriginSelector
			// 
			this.tabPageOriginSelector.Controls.Add(this.originSelector10);
			this.tabPageOriginSelector.Controls.Add(this.originSelector11);
			this.tabPageOriginSelector.Controls.Add(this.originSelector12);
			this.tabPageOriginSelector.Controls.Add(this.originSelector7);
			this.tabPageOriginSelector.Controls.Add(this.originSelector8);
			this.tabPageOriginSelector.Controls.Add(this.originSelector9);
			this.tabPageOriginSelector.Controls.Add(this.originSelector4);
			this.tabPageOriginSelector.Controls.Add(this.originSelector5);
			this.tabPageOriginSelector.Controls.Add(this.originSelector6);
			this.tabPageOriginSelector.Controls.Add(this.originSelector3);
			this.tabPageOriginSelector.Controls.Add(this.originSelector2);
			this.tabPageOriginSelector.Controls.Add(this.originSelector1);
			this.tabPageOriginSelector.Location = new System.Drawing.Point(4, 22);
			this.tabPageOriginSelector.Name = "tabPageOriginSelector";
			this.tabPageOriginSelector.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageOriginSelector.Size = new System.Drawing.Size(427, 397);
			this.tabPageOriginSelector.TabIndex = 4;
			this.tabPageOriginSelector.Text = "Origin Selector";
			this.tabPageOriginSelector.UseVisualStyleBackColor = true;
			// 
			// originSelector10
			// 
			this.originSelector10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.originSelector10.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.originSelector10.Location = new System.Drawing.Point(170, 297);
			this.originSelector10.Name = "originSelector10";
			this.originSelector10.SelectionColor = System.Drawing.Color.Orange;
			this.originSelector10.Size = new System.Drawing.Size(31, 31);
			this.originSelector10.TabIndex = 11;
			// 
			// originSelector11
			// 
			this.originSelector11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.originSelector11.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.originSelector11.Location = new System.Drawing.Point(103, 297);
			this.originSelector11.Name = "originSelector11";
			this.originSelector11.SelectionColor = System.Drawing.Color.Orange;
			this.originSelector11.Size = new System.Drawing.Size(61, 61);
			this.originSelector11.TabIndex = 10;
			// 
			// originSelector12
			// 
			this.originSelector12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.originSelector12.ForeColor = System.Drawing.Color.CornflowerBlue;
			this.originSelector12.Location = new System.Drawing.Point(6, 297);
			this.originSelector12.Name = "originSelector12";
			this.originSelector12.SelectionColor = System.Drawing.Color.Orange;
			this.originSelector12.Size = new System.Drawing.Size(91, 91);
			this.originSelector12.TabIndex = 9;
			// 
			// originSelector7
			// 
			this.originSelector7.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector7.InvertArrowsHorizontal = true;
			this.originSelector7.InvertArrowsVertical = true;
			this.originSelector7.Location = new System.Drawing.Point(170, 200);
			this.originSelector7.Name = "originSelector7";
			this.originSelector7.Size = new System.Drawing.Size(31, 31);
			this.originSelector7.TabIndex = 8;
			// 
			// originSelector8
			// 
			this.originSelector8.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector8.InvertArrowsHorizontal = true;
			this.originSelector8.InvertArrowsVertical = true;
			this.originSelector8.Location = new System.Drawing.Point(103, 200);
			this.originSelector8.Name = "originSelector8";
			this.originSelector8.Size = new System.Drawing.Size(61, 61);
			this.originSelector8.TabIndex = 7;
			// 
			// originSelector9
			// 
			this.originSelector9.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector9.InvertArrowsHorizontal = true;
			this.originSelector9.InvertArrowsVertical = true;
			this.originSelector9.Location = new System.Drawing.Point(6, 200);
			this.originSelector9.Name = "originSelector9";
			this.originSelector9.Size = new System.Drawing.Size(91, 91);
			this.originSelector9.TabIndex = 6;
			// 
			// originSelector4
			// 
			this.originSelector4.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector4.InvertArrowsHorizontal = true;
			this.originSelector4.Location = new System.Drawing.Point(170, 103);
			this.originSelector4.Name = "originSelector4";
			this.originSelector4.Size = new System.Drawing.Size(31, 31);
			this.originSelector4.TabIndex = 5;
			// 
			// originSelector5
			// 
			this.originSelector5.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector5.InvertArrowsHorizontal = true;
			this.originSelector5.Location = new System.Drawing.Point(103, 103);
			this.originSelector5.Name = "originSelector5";
			this.originSelector5.Size = new System.Drawing.Size(61, 61);
			this.originSelector5.TabIndex = 4;
			// 
			// originSelector6
			// 
			this.originSelector6.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector6.InvertArrowsHorizontal = true;
			this.originSelector6.Location = new System.Drawing.Point(6, 103);
			this.originSelector6.Name = "originSelector6";
			this.originSelector6.Size = new System.Drawing.Size(91, 91);
			this.originSelector6.TabIndex = 3;
			// 
			// originSelector3
			// 
			this.originSelector3.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector3.Location = new System.Drawing.Point(170, 6);
			this.originSelector3.Name = "originSelector3";
			this.originSelector3.Size = new System.Drawing.Size(31, 31);
			this.originSelector3.TabIndex = 2;
			// 
			// originSelector2
			// 
			this.originSelector2.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector2.Location = new System.Drawing.Point(103, 6);
			this.originSelector2.Name = "originSelector2";
			this.originSelector2.Size = new System.Drawing.Size(61, 61);
			this.originSelector2.TabIndex = 1;
			// 
			// originSelector1
			// 
			this.originSelector1.BackColor = System.Drawing.SystemColors.Control;
			this.originSelector1.Location = new System.Drawing.Point(6, 6);
			this.originSelector1.Name = "originSelector1";
			this.originSelector1.Size = new System.Drawing.Size(91, 91);
			this.originSelector1.TabIndex = 0;
			// 
			// menuStrip
			// 
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(459, 24);
			this.menuStrip.TabIndex = 14;
			this.menuStrip.Text = "Main Menu";
			// 
			// DemoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 462);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(475, 500);
			this.Name = "DemoForm";
			this.Text = "Form1";
			this.tabControl.ResumeLayout(false);
			this.tabPagePropertyGrid.ResumeLayout(false);
			this.tabPagePropertyGrid.PerformLayout();
			this.tabPageTiledView.ResumeLayout(false);
			this.tabPageTiledView.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTileViewHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTileViewWidth)).EndInit();
			this.tabPageColorControls.ResumeLayout(false);
			this.tabPageTimeline.ResumeLayout(false);
			this.tabPageTimeline.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTimelineUnitZoom)).EndInit();
			this.tabPageOriginSelector.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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

