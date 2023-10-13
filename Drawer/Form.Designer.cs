
namespace Drawer
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
            this._informationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._infoGroupBox = new System.Windows.Forms.GroupBox();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._createShapeButton = new System.Windows.Forms.Button();
            this._shapeDataGrid = new DoubleBufferedDataGridView();
            this._shapeListDeleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeListShapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeListInfoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._pageList = new System.Windows.Forms.ListView();
            this._page2 = new System.Windows.Forms.Button();
            this._page1 = new System.Windows.Forms.Button();
            this._drawArea = new DoubleBufferdPanel();
            this._toolBar = new System.Windows.Forms.ToolStrip();
            this._toolBarLineButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarRectangleButton = new System.Windows.Forms.ToolStripButton();
            this._toolBarCircleButton = new System.Windows.Forms.ToolStripButton();
            this._infoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGrid)).BeginInit();
            this._toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menu
            // 
            this._menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menu.Size = new System.Drawing.Size(883, 24);
            this._menu.TabIndex = 0;
            this._menu.Text = "menuStrip1";
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
            this._aboutMenuItem.Size = new System.Drawing.Size(122, 26);
            this._aboutMenuItem.Text = "關於";
            // 
            // _infoGroupBox
            // 
            this._infoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._infoGroupBox.Controls.Add(this._shapeComboBox);
            this._infoGroupBox.Controls.Add(this._createShapeButton);
            this._infoGroupBox.Controls.Add(this._shapeDataGrid);
            this._infoGroupBox.Location = new System.Drawing.Point(579, 64);
            this._infoGroupBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this._infoGroupBox.Name = "_infoGroupBox";
            this._infoGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._infoGroupBox.Size = new System.Drawing.Size(300, 436);
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
            this._shapeComboBox.Location = new System.Drawing.Point(85, 25);
            this._shapeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(121, 23);
            this._shapeComboBox.TabIndex = 2;
            this._shapeComboBox.TabStop = false;
            // 
            // _createShapeButton
            // 
            this._createShapeButton.Location = new System.Drawing.Point(3, 21);
            this._createShapeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._createShapeButton.Name = "_createShapeButton";
            this._createShapeButton.Size = new System.Drawing.Size(75, 30);
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
            this._shapeListDeleteColumn,
            this._shapeListShapeColumn,
            this._shapeListInfoColumn});
            this._shapeDataGrid.Location = new System.Drawing.Point(5, 58);
            this._shapeDataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._shapeDataGrid.Name = "_shapeDataGrid";
            this._shapeDataGrid.ReadOnly = true;
            this._shapeDataGrid.RowHeadersVisible = false;
            this._shapeDataGrid.RowHeadersWidth = 51;
            this._shapeDataGrid.RowTemplate.Height = 27;
            this._shapeDataGrid.Size = new System.Drawing.Size(288, 370);
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
            // _shapeListShapeColumn
            // 
            this._shapeListShapeColumn.HeaderText = "形狀";
            this._shapeListShapeColumn.MinimumWidth = 6;
            this._shapeListShapeColumn.Name = "_shapeListShapeColumn";
            this._shapeListShapeColumn.ReadOnly = true;
            // 
            // _shapeListInfoColumn
            // 
            this._shapeListInfoColumn.HeaderText = "資訊";
            this._shapeListInfoColumn.MinimumWidth = 6;
            this._shapeListInfoColumn.Name = "_shapeListInfoColumn";
            this._shapeListInfoColumn.ReadOnly = true;
            // 
            // _pageList
            // 
            this._pageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._pageList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this._pageList.HideSelection = false;
            this._pageList.Location = new System.Drawing.Point(0, 64);
            this._pageList.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this._pageList.Name = "_pageList";
            this._pageList.Size = new System.Drawing.Size(151, 438);
            this._pageList.TabIndex = 2;
            this._pageList.UseCompatibleStateImageBehavior = false;
            // 
            // _page2
            // 
            this._page2.Location = new System.Drawing.Point(5, 146);
            this._page2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._page2.Name = "_page2";
            this._page2.Size = new System.Drawing.Size(139, 72);
            this._page2.TabIndex = 4;
            this._page2.UseVisualStyleBackColor = true;
            // 
            // _page1
            // 
            this._page1.Location = new System.Drawing.Point(5, 69);
            this._page1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._page1.Name = "_page1";
            this._page1.Size = new System.Drawing.Size(139, 72);
            this._page1.TabIndex = 3;
            this._page1.UseVisualStyleBackColor = true;
            // 
            // _drawArea
            // 
            this._drawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._drawArea.BackColor = System.Drawing.SystemColors.Control;
            this._drawArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._drawArea.Location = new System.Drawing.Point(149, 64);
            this._drawArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._drawArea.Name = "_drawArea";
            this._drawArea.Size = new System.Drawing.Size(429, 436);
            this._drawArea.TabIndex = 5;
            // 
            // _toolBar
            // 
            this._toolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolBarLineButton,
            this._toolBarRectangleButton,
            this._toolBarCircleButton});
            this._toolBar.Location = new System.Drawing.Point(0, 24);
            this._toolBar.Name = "_toolBar";
            this._toolBar.Size = new System.Drawing.Size(883, 27);
            this._toolBar.TabIndex = 6;
            this._toolBar.Text = "toolStrip1";
            // 
            // _toolBarLineButton
            // 
            this._toolBarLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarLineButton.Image = global::Drawer.Properties.Resources.line;
            this._toolBarLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarLineButton.Name = "_toolBarLineButton";
            this._toolBarLineButton.Size = new System.Drawing.Size(29, 24);
            this._toolBarLineButton.Text = "toolStripButton1";
            this._toolBarLineButton.Click += new System.EventHandler(this.ClickToolBarLineButton);
            // 
            // _toolBarRectangleButton
            // 
            this._toolBarRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarRectangleButton.Image = global::Drawer.Properties.Resources.rectangle;
            this._toolBarRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarRectangleButton.Name = "_toolBarRectangleButton";
            this._toolBarRectangleButton.Size = new System.Drawing.Size(29, 24);
            this._toolBarRectangleButton.Text = "toolStripButton2";
            this._toolBarRectangleButton.Click += new System.EventHandler(this.ClickToolBarRectangleButton);
            // 
            // _toolBarCircleButton
            // 
            this._toolBarCircleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolBarCircleButton.Image = global::Drawer.Properties.Resources.circle;
            this._toolBarCircleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolBarCircleButton.Name = "_toolBarCircleButton";
            this._toolBarCircleButton.Size = new System.Drawing.Size(29, 24);
            this._toolBarCircleButton.Text = "toolStripButton3";
            this._toolBarCircleButton.Click += new System.EventHandler(this.ClickToolBarCircleButton);
            // 
            // From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 502);
            this.Controls.Add(this._toolBar);
            this.Controls.Add(this._drawArea);
            this.Controls.Add(this._page2);
            this.Controls.Add(this._page1);
            this.Controls.Add(this._pageList);
            this.Controls.Add(this._infoGroupBox);
            this.Controls.Add(this._menu);
            this.MainMenuStrip = this._menu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "From";
            this.Text = "Form1";
            this._infoGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeDataGrid)).EndInit();
            this._toolBar.ResumeLayout(false);
            this._toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _informationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.GroupBox _infoGroupBox;
        private System.Windows.Forms.DataGridView _shapeDataGrid;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _createShapeButton;
        private System.Windows.Forms.ListView _pageList;
        private System.Windows.Forms.Button _page2;
        private System.Windows.Forms.Button _page1;
        private System.Windows.Forms.DataGridViewButtonColumn _shapeListDeleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeListShapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeListInfoColumn;
        private System.Windows.Forms.Panel _drawArea;
        private System.Windows.Forms.ToolStrip _toolBar;
        private System.Windows.Forms.ToolStripButton _toolBarLineButton;
        private System.Windows.Forms.ToolStripButton _toolBarRectangleButton;
        private System.Windows.Forms.ToolStripButton _toolBarCircleButton;
    }
}

