using System.Collections.Generic;

namespace Drawer.Presentation
{
    partial class From
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._menu = new System.Windows.Forms.MenuStrip();
            this._toolBarMenuInfos = new System.Windows.Forms.ToolStripMenuItem();
            this._toolBarMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._informationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._infoGroupBox = new System.Windows.Forms.GroupBox();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._createShapeButton = new System.Windows.Forms.Button();
            this._shapeDataGrid = new System.Windows.Forms.DataGridView();
            this._shapeListDeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._toolBarLineButton = new Drawer.Presentation.ToolStripBindButton();
            this._toolBarRectangleButton = new Drawer.Presentation.ToolStripBindButton();
            this._toolBarCircleButton = new Drawer.Presentation.ToolStripBindButton();
            this._toolBarCursorButton = new Drawer.Presentation.ToolStripBindButton();
            this._toolBarAddSildeButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarUndoButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarRedoButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarUploadButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarDownloadButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainerPageListAndPage = new System.Windows.Forms.SplitContainer();
            this._splitContainerPageAndInfos = new System.Windows.Forms.SplitContainer();
            this._drawArea = new Drawer.Presentation.DoubleBufferdPanel();
            this._menu.SuspendLayout();
            this._infoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGrid)).BeginInit();
            this._toolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPageListAndPage)).BeginInit();
            this._splitContainerPageListAndPage.Panel2.SuspendLayout();
            this._splitContainerPageListAndPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPageAndInfos)).BeginInit();
            this._splitContainerPageAndInfos.Panel1.SuspendLayout();
            this._splitContainerPageAndInfos.Panel2.SuspendLayout();
            this._splitContainerPageAndInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolBarMenuInfos});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this._menu.Size = new System.Drawing.Size(984, 24);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
            // 
            // _toolBarMenuInfos
            // 
            this._toolBarMenuInfos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolBarMenuAbout});
            this._toolBarMenuInfos.Name = "_toolBarMenuInfos";
            this._toolBarMenuInfos.Size = new System.Drawing.Size(43, 20);
            this._toolBarMenuInfos.Text = "說明";
            // 
            // _toolBarMenuAbout
            // 
            this._toolBarMenuAbout.Name = "_toolBarMenuAbout";
            this._toolBarMenuAbout.Size = new System.Drawing.Size(98, 22);
            this._toolBarMenuAbout.Text = "關於";
            // 
            // _informationMenuItem
            // 
            this._informationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutMenuItem});
            this._informationMenuItem.Name = "_informationMenuItem";
            this._informationMenuItem.Size = new System.Drawing.Size(43, 20);
            this._informationMenuItem.Text = "說明";
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutMenuItem.Text = "關於";
            // 
            // _infoGroupBox
            // 
            this._infoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._infoGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this._infoGroupBox.Controls.Add(this._shapeComboBox);
            this._infoGroupBox.Controls.Add(this._createShapeButton);
            this._infoGroupBox.Controls.Add(this._shapeDataGrid);
            this._infoGroupBox.Location = new System.Drawing.Point(2, 3);
            this._infoGroupBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._infoGroupBox.Name = "_infoGroupBox";
            this._infoGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this._infoGroupBox.Size = new System.Drawing.Size(304, 504);
            this._infoGroupBox.TabIndex = 1;
            this._infoGroupBox.TabStop = false;
            this._infoGroupBox.Text = "資料顯示";
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "圓"});
            this._shapeComboBox.Location = new System.Drawing.Point(64, 20);
            this._shapeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(92, 20);
            this._shapeComboBox.TabIndex = 2;
            this._shapeComboBox.TabStop = false;
            // 
            // _createShapeButton
            // 
            this._createShapeButton.Location = new System.Drawing.Point(2, 17);
            this._createShapeButton.Margin = new System.Windows.Forms.Padding(2);
            this._createShapeButton.Name = "_createShapeButton";
            this._createShapeButton.Size = new System.Drawing.Size(56, 24);
            this._createShapeButton.TabIndex = 1;
            this._createShapeButton.Text = "新增";
            this._createShapeButton.UseVisualStyleBackColor = true;
            this._createShapeButton.Click += new System.EventHandler(this.ClickCreateShapeButton);
            // 
            // _shapeDataGrid
            // 
            this._shapeDataGrid.AllowUserToAddRows = false;
            this._shapeDataGrid.AllowUserToDeleteRows = false;
            this._shapeDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._shapeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._shapeListDeleteColumn});
            this._shapeDataGrid.Location = new System.Drawing.Point(0, 44);
            this._shapeDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this._shapeDataGrid.Name = "_shapeDataGrid";
            this._shapeDataGrid.ReadOnly = true;
            this._shapeDataGrid.RowHeadersVisible = false;
            this._shapeDataGrid.RowHeadersWidth = 51;
            this._shapeDataGrid.RowTemplate.Height = 27;
            this._shapeDataGrid.Size = new System.Drawing.Size(304, 455);
            this._shapeDataGrid.TabIndex = 0;
            this._shapeDataGrid.TabStop = false;
            this._shapeDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickShapeDataGridCell);
            // 
            // _shapeListDeleteColumn
            // 
            this._shapeListDeleteColumn.HeaderText = "刪除";
            this._shapeListDeleteColumn.MinimumWidth = 6;
            this._shapeListDeleteColumn.Name = "_shapeListDeleteColumn";
            this._shapeListDeleteColumn.ReadOnly = true;
            this._shapeListDeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._shapeListDeleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._shapeListDeleteColumn.Text = "刪除";
            this._shapeListDeleteColumn.UseColumnTextForButtonValue = true;
            // 
            // _toolBar
            // 
            this._toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolBarLineButton,
            this._toolBarRectangleButton,
            this._toolBarCircleButton,
            this._toolBarCursorButton,
            this._toolBarAddSildeButton,
            this._toolBarUndoButton,
            this._toolBarRedoButton,
            this._toolBarUploadButton,
            this._toolBarDownloadButton});
            this._toolBar.Location = new System.Drawing.Point(0, 24);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(984, 27);
            this._toolBar.TabIndex = 6;
            this._toolBar.Text = "toolStrip1";
            // 
            // _toolBarLineButton
            // 
            this._toolBarLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarLineButton.Image = global::Drawer.Properties.Resources.line;
            this._toolBarLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarLineButton.Name = "_toolBarLineButton";
            this._toolBarLineButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarLineButton.Text = "toolStripButton1";
            this._toolBarLineButton.Click += new System.EventHandler(this.ClickToolBarLineButton);
            // 
            // _toolBarRectangleButton
            // 
            this._toolBarRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarRectangleButton.Image = global::Drawer.Properties.Resources.rectangle;
            this._toolBarRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarRectangleButton.Name = "_toolBarRectangleButton";
            this._toolBarRectangleButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarRectangleButton.Text = "toolStripButton2";
            this._toolBarRectangleButton.Click += new System.EventHandler(this.ClickToolBarRectangleButton);
            // 
            // _toolBarCircleButton
            // 
            this._toolBarCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarCircleButton.Image = global::Drawer.Properties.Resources.circle;
            this._toolBarCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarCircleButton.Name = "_toolBarCircleButton";
            this._toolBarCircleButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarCircleButton.Text = "toolStripButton3";
            this._toolBarCircleButton.Click += new System.EventHandler(this.ClickToolBarCircleButton);
            // 
            // _toolBarCursorButton
            // 
            this._toolBarCursorButton.Checked = true;
            this._toolBarCursorButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._toolBarCursorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarCursorButton.Image = global::Drawer.Properties.Resources.cursor;
            this._toolBarCursorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarCursorButton.Name = "_toolBarCursorButton";
            this._toolBarCursorButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarCursorButton.Text = "toolStripButton1";
            this._toolBarCursorButton.Click += new System.EventHandler(this.ClickToolBarCursorButton);
            // 
            // _toolBarAddSildeButton
            // 
            this._toolBarAddSildeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarAddSildeButton.Image = global::Drawer.Properties.Resources.add_slide;
            this._toolBarAddSildeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarAddSildeButton.Name = "_toolBarAddSildeButton";
            this._toolBarAddSildeButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarAddSildeButton.Text = "toolStripButton1";
            this._toolBarAddSildeButton.Click += new System.EventHandler(this.ClickToolBarAddSlideButton);
            // 
            // _toolBarUndoButton
            // 
            this._toolBarUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarUndoButton.Image = global::Drawer.Properties.Resources.undo;
            this._toolBarUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarUndoButton.Name = "_toolBarUndoButton";
            this._toolBarUndoButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarUndoButton.Text = "toolStripButton1";
            this._toolBarUndoButton.Click += new System.EventHandler(this.ClickToolBarUndoButton);
            // 
            // _toolBarRedoButton
            // 
            this._toolBarRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarRedoButton.Image = global::Drawer.Properties.Resources.redo;
            this._toolBarRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarRedoButton.Name = "_toolBarRedoButton";
            this._toolBarRedoButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarRedoButton.Text = "toolStripButton1";
            this._toolBarRedoButton.Click += new System.EventHandler(this.ClickToolBarRedoButton);
            // 
            // _toolBarUploadButton
            // 
            this._toolBarUploadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarUploadButton.Image = global::Drawer.Properties.Resources.upload;
            this._toolBarUploadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarUploadButton.Name = "_toolBarUploadButton";
            this._toolBarUploadButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarUploadButton.Text = "toolStripButton1";
            // 
            // _toolBarDownloadButton
            // 
            this._toolBarDownloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarDownloadButton.Image = global::Drawer.Properties.Resources.download;
            this._toolBarDownloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarDownloadButton.Name = "_toolBarDownloadButton";
            this._toolBarDownloadButton.Size = new System.Drawing.Size(24, 24);
            this._toolBarDownloadButton.Text = "toolStripButton1";
            // 
            // _splitContainerPageListAndPage
            // 
            this._splitContainerPageListAndPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainerPageListAndPage.BackColor = System.Drawing.SystemColors.WindowText;
            this._splitContainerPageListAndPage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainerPageListAndPage.Location = new System.Drawing.Point(0, 54);
            this._splitContainerPageListAndPage.Name = "_splitContainerPageListAndPage";
            // 
            // _splitContainerPageListAndPage.Panel1
            // 
            this._splitContainerPageListAndPage.Panel1.AutoScroll = true;
            this._splitContainerPageListAndPage.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this._splitContainerPageListAndPage.Panel1MinSize = 50;
            // 
            // _splitContainerPageListAndPage.Panel2
            // 
            this._splitContainerPageListAndPage.Panel2.Controls.Add(this._splitContainerPageAndInfos);
            this._splitContainerPageListAndPage.Size = new System.Drawing.Size(984, 507);
            this._splitContainerPageListAndPage.SplitterDistance = 169;
            this._splitContainerPageListAndPage.SplitterWidth = 2;
            this._splitContainerPageListAndPage.TabIndex = 7;
            this._splitContainerPageListAndPage.TabStop = false;
            // 
            // _splitContainerPageAndInfos
            // 
            this._splitContainerPageAndInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainerPageAndInfos.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainerPageAndInfos.Location = new System.Drawing.Point(0, 0);
            this._splitContainerPageAndInfos.Name = "_splitContainerPageAndInfos";
            // 
            // _splitContainerPageAndInfos.Panel1
            // 
            this._splitContainerPageAndInfos.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this._splitContainerPageAndInfos.Panel1.Controls.Add(this._drawArea);
            this._splitContainerPageAndInfos.Panel1MinSize = 100;
            // 
            // _splitContainerPageAndInfos.Panel2
            // 
            this._splitContainerPageAndInfos.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this._splitContainerPageAndInfos.Panel2.Controls.Add(this._infoGroupBox);
            this._splitContainerPageAndInfos.Panel2MinSize = 150;
            this._splitContainerPageAndInfos.Size = new System.Drawing.Size(821, 507);
            this._splitContainerPageAndInfos.SplitterDistance = 507;
            this._splitContainerPageAndInfos.SplitterWidth = 2;
            this._splitContainerPageAndInfos.TabIndex = 0;
            this._splitContainerPageAndInfos.TabStop = false;
            // 
            // _drawArea
            // 
            this._drawArea.AutoSize = true;
            this._drawArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._drawArea.Location = new System.Drawing.Point(3, 3);
            this._drawArea.Name = "_drawArea";
            this._drawArea.Size = new System.Drawing.Size(30, 30);
            this._drawArea.TabIndex = 7;
            // 
            // From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._menu);
            this.Controls.Add(this._splitContainerPageListAndPage);
            this.MainMenuStrip = this._menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "From";
            this.Text = "Form1";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this._infoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGrid)).EndInit();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this._splitContainerPageListAndPage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPageListAndPage)).EndInit();
            this._splitContainerPageListAndPage.ResumeLayout(false);
            this._splitContainerPageAndInfos.Panel1.ResumeLayout(false);
            this._splitContainerPageAndInfos.Panel1.PerformLayout();
            this._splitContainerPageAndInfos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerPageAndInfos)).EndInit();
            this._splitContainerPageAndInfos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _informationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.GroupBox _infoGroupBox;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _createShapeButton;
        //private System.Windows.Forms.Button _page1;
        private List<System.Windows.Forms.Button> _pages;
        private System.Windows.Forms.DataGridViewButtonColumn _shapeListDeleteColumn;
        private System.Windows.Forms.ToolStrip _toolBar;
        private ToolStripBindButton _toolBarLineButton;
        private ToolStripBindButton _toolBarRectangleButton;
        private ToolStripBindButton _toolBarCircleButton;
        private ToolStripBindButton _toolBarCursorButton;
        private System.Windows.Forms.DataGridView _shapeDataGrid;
        private System.Windows.Forms.ToolStripMenuItem _toolBarMenuInfos;
        private System.Windows.Forms.ToolStripButton _toolBarUndoButton;
        private System.Windows.Forms.ToolStripButton _toolBarRedoButton;
        private System.Windows.Forms.ToolStripMenuItem _toolBarMenuAbout;
        private DoubleBufferdPanel _drawArea;
        private System.Windows.Forms.SplitContainer _splitContainerPageListAndPage;
        private System.Windows.Forms.SplitContainer _splitContainerPageAndInfos;
        private System.Windows.Forms.ToolStripButton _toolBarAddSildeButton;
        private System.Windows.Forms.ToolStripButton _toolBarUploadButton;
        private System.Windows.Forms.ToolStripButton _toolBarDownloadButton;
    }
}

