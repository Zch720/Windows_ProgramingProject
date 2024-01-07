using Drawer.GraphicsAdapter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer.Presentation
{
    public partial class From : Form
    {
        private const string TOOL_STRIP_BUTTON_CHECKED_PROP = "Checked";
        private const string LINE_CHECKED_PROP = "ToolBarLineButtonChecked";
        private const string RECTANGLE_CHECKED_PROP = "ToolBarRectangleButtonChecked";
        private const string CIRCLE_CHECKED_PROP = "ToolBarCircleButtonChecked";
        private const string CURSOR_CHECKED_PROP = "ToolBarCursorButtonChecked";
        private const float DRAW_AREA_PADDING = 30.0f;
        private const float DRAW_AREA_WIDTH_RATIO = 16.0f;
        private const float DRAW_AREA_HEIGHT_RATIO = 9.0f;
        private const float DRAW_AREA_MODEL_WIDTH = 1920.0f;
        private const float DRAW_AREA_MODEL_HEIGHT = 1080.0f;
        private const int TWO = 2;
        private const int THREE = 3;

        private PresentationModel _presentationModel;
        private CreateShapeDialog _createShapeDialog;

        public From(PresentationModel presentationModel)
        {
            InitializeComponent();
            this._pages = new List<Button>();
            AddFirstPage();

            KeyPreview = true;
            KeyDown += HandleFormKeyDown;
            Resize += HandleFormResize;

            _createShapeDialog = new CreateShapeDialog();
            _createShapeDialog._createShapeClicked += HandleCreateShape;

            _shapeComboBox.SelectedIndex = 0;

            _splitContainerPageListAndPage.SplitterMoved += HandlePageListResize;
            _splitContainerPageAndInfos.SplitterMoved += HandlePageInfoResize;

            _drawArea.MouseEnter += MouseEnterDrawArea;
            _drawArea.MouseLeave += MouseLeaveDrawArea;
            _drawArea.MouseDown += MouseDownInDrawArea;
            _drawArea.MouseMove += MouseMoveInDrawArea;
            _drawArea.MouseUp += MouseUpInDrawArea;
            _drawArea.Paint += DrawAreaPaint;
            _drawArea.Resize += HandleDrawAreaResize;

            _presentationModel = presentationModel;
            _presentationModel._modelShapesListUpdated += UpdateShapeList;
            _presentationModel._cursorStyleUpdated += UpdateCursorStyle;
            _presentationModel._tempShapeUpdated += UpdateTempShape;
            _presentationModel._selectedPageChanged += HandleModelSelectedPageChanged;
            _presentationModel._pageCreated += CreatePage;
            _presentationModel._pageDeleted += DeletePage;

            _shapeDataGrid.DataSource = _presentationModel.ShapeDatas;
            _toolBarLineButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, LINE_CHECKED_PROP);
            _toolBarRectangleButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, RECTANGLE_CHECKED_PROP);
            _toolBarCircleButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, CIRCLE_CHECKED_PROP);
            _toolBarCursorButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, CURSOR_CHECKED_PROP);

            ResizeDrawArea();
            ResizePageList();

            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle keyboard key down event.
        /// </summary>
        private void HandleFormKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleFormKeyDown(e.KeyCode.ToString());
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle from resize.
        /// </summary>
        private void HandleFormResize(object sender, EventArgs e)
        {
            ResizeDrawArea();
            ResizePageList();
        }

        /// <summary>
        /// Handle page list resize.
        /// </summary>
        private void HandlePageListResize(object sender, SplitterEventArgs e)
        {
            ResizeDrawArea();
            ResizePageList();
        }

        /// <summary>
        /// Handle page info resize.
        /// </summary>
        private void HandlePageInfoResize(object sender, SplitterEventArgs e)
        {
            ResizeDrawArea();
        }

        /// <summary>
        /// Handle draw area resize.
        /// </summary>
        private void HandleDrawAreaResize(object sender, EventArgs e)
        {
            UpdateScalePointSize();
        }

        /// <summary>
        /// Update scale point size.
        /// </summary>
        private void UpdateScalePointSize()
        {
            _presentationModel.ScalePointSize = (int)(THREE * DRAW_AREA_MODEL_HEIGHT / _drawArea.Height);
        }

        /// <summary>
        /// Resize draw area.
        /// </summary>
        private void ResizeDrawArea()
        {
            int containerWidth = _splitContainerPageAndInfos.Panel1.Width;
            int containerHeight = _splitContainerPageAndInfos.Panel1.Height;

            float widthRatio = (containerWidth - DRAW_AREA_PADDING) / DRAW_AREA_WIDTH_RATIO;
            float heightRatio = (containerHeight - DRAW_AREA_PADDING) / DRAW_AREA_HEIGHT_RATIO;
            float scaleRatio = widthRatio < heightRatio ? widthRatio : heightRatio;

            _drawArea.Width = (int)(DRAW_AREA_WIDTH_RATIO * scaleRatio);
            _drawArea.Height = (int)(DRAW_AREA_HEIGHT_RATIO * scaleRatio);

            _drawArea.Top = (containerHeight - _drawArea.Height) / TWO;
            _drawArea.Left = (containerWidth - _drawArea.Width) / TWO;
        }

        /// <summary>
        /// Resize page size by draw area size.
        /// </summary>
        private void ResizePageList()
        {
            if (_pages.Count == 0) return;
            int newHeight = (int)(_pages[0].Width / DRAW_AREA_WIDTH_RATIO * DRAW_AREA_HEIGHT_RATIO);
            _pages[0].Location = new System.Drawing.Point(2, 3);
            _pages[0].Height = newHeight;
            for (int i = 1; i < _pages.Count; i++)
            {
                _pages[i].Location = new System.Drawing.Point(2, _pages[i - 1].Location.Y + newHeight);
                _pages[i].Width = _pages[0].Width;
                _pages[i].Height = newHeight;
            }
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            _createShapeDialog.ShowDialog();
        }

        private void HandleCreateShape(int upperLeftX, int upperLeftY, int lowerRightX, int lowerRightY)
        {
            _presentationModel.CreateShape(_shapeComboBox.Text, upperLeftX, upperLeftY, lowerRightX, lowerRightY);
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle click event for cell of _shapeDataGridView.
        /// </summary>
        private void ClickShapeDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ClickShapeDataGridCell(e.ColumnIndex, e.RowIndex);
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle click event for _toolbarLinebutton.
        /// </summary>
        private void ClickToolBarLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarLineButton();
        }

        /// <summary>
        /// Handle click event for _toolbarRectanglebutton.
        /// </summary>
        private void ClickToolBarRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarRectangleButton();
        }

        /// <summary>
        /// Handle click event for _toolbarCirclebutton.
        /// </summary>
        private void ClickToolBarCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarCircleButton();
        }

        /// <summary>
        /// Handle click event for _toolbarCursorbutton.
        /// </summary>
        private void ClickToolBarCursorButton(object sender, EventArgs e)
        {
            _presentationModel.ClearToolBarButtonChecked();
        }

        private void ClickToolBarAddSlideButton(object sender, EventArgs e)
        {
            _presentationModel.AddNewPage();
        }

        /// <summary>
        /// Handle click event for _toolbarUndobutton.
        /// </summary>
        private void ClickToolBarUndoButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarUndoButton();
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Update the tool bar undo and redo button enable.
        /// </summary>
        private void UpdateUndoRedoButtonEnable()
        {
            _toolBarUndoButton.Enabled = _presentationModel.HasPreviousCommand;
            _toolBarRedoButton.Enabled = _presentationModel.HasNextCommand;
        }

        /// <summary>
        /// Handle click event for _toolbarRedobutton.
        /// </summary>
        private void ClickToolBarRedoButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarRedoButton();
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle click event for _toolbarRedobutton.
        /// </summary>
        private async void ClickToolBarSaveButton(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to upload to Google Drive?", "",
                MessageBoxButtons.OKCancel);
            if (result ==  DialogResult.OK)
            {
                _toolBarUploadButton.Enabled = false;
                try
                {
                    await Task.Run(() => _presentationModel.ClickToolBarSaveButton());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                _toolBarUploadButton.Enabled = true;
            }
        }

        /// <summary>
        /// Handle click event for _toolbarRedobutton.
        /// </summary>
        private void ClickToolBarLoadButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarLoadButton();
            UpdateUndoRedoButtonEnable();
        }

        private void ClickPage(object sender, EventArgs e)
        {
            Button page = sender as Button;
            if (page == null)
                throw new Exception();
            int index = GetPageIndex(page);
            _presentationModel.ClickPage(index);
        }

        /// <summary>
        /// Handle mouse enter event of _drawArea.
        /// </summary>
        private void MouseEnterDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseEnterDrawArea();
        }

        /// <summary>
        /// Handle mouse leave event of _drawArea.
        /// </summary>
        private void MouseLeaveDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseLeaveDrawArea();
        }

        /// <summary>
        /// Handle mouse down event of _drawArea.
        /// </summary>
        private void MouseDownInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDownInDrawArea(e.X, e.Y, _drawArea.Width, _drawArea.Height);
        }

        /// <summary>
        /// Handle mouse move event of _drawArea.
        /// </summary>
        private void MouseMoveInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseMoveInDrawArea(e.X, e.Y, _drawArea.Width, _drawArea.Height);
        }

        /// <summary>
        /// Handle mouse up event of _drawArea.
        /// </summary>
        private void MouseUpInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUpInDrawArea(e.X, e.Y, _drawArea.Width, _drawArea.Height);
            UpdateUndoRedoButtonEnable();
        }

        /// <summary>
        /// Handle paint event of _drawArea.
        /// </summary>
        private void DrawAreaPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _presentationModel.DrawWithTemp(_presentationModel.SelectedPage, new DrawAreaGraphicsAdapter(e.Graphics, _drawArea.Width / DRAW_AREA_MODEL_WIDTH));
        }

        /// <summary>
        /// Handle paint event of page.
        /// </summary>
        private void PagePaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int index = GetPageIndex(sender as Button);
            _presentationModel.DrawWithTemp(index, new PageGraphicsAdapter(e.Graphics, _pages[0].Width / DRAW_AREA_MODEL_WIDTH));
        }

        private void HandleModelSelectedPageChanged()
        {
            UpdateDrawArea();
            if (_presentationModel.SelectedPage != -1)
                _pages[_presentationModel.SelectedPage].Focus();
            UpdateScalePointSize();
        }

        private void UpdateDrawArea()
        {
            _drawArea.Invalidate(true);
        }

        /// <summary>
        /// Notify view the shapes in model is updated.
        /// </summary>
        public void UpdateShapeList()
        {
            _drawArea.Invalidate(true);
            foreach (Button page in _pages)
            {
                page.Invalidate(true);
            }
        }

        /// <summary>
        /// Handle drawing shape update.
        /// </summary>
        public void UpdateTempShape()
        {
            _drawArea.Invalidate(true);
            foreach (Button page in _pages)
            {
                page.Invalidate(true);
            }
        }

        /// <summary>
        /// Handle cursor style update.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void UpdateCursorStyle()
        {
            switch (_presentationModel.CursorStyle)
            {
                case PresentationModel.CursorStatus.Pointer:
                    SetCursor(Cursors.Arrow);
                    break;
                case PresentationModel.CursorStatus.Cross:
                    SetCursor(Cursors.Cross);
                    break;
                case PresentationModel.CursorStatus.SizeUpperRight:
                    SetCursor(Cursors.SizeNESW);
                    break;
                case PresentationModel.CursorStatus.SizeUpperLeft:
                    SetCursor(Cursors.SizeNWSE);
                    break;
            }
        }

        /// <summary>
        /// Set cursor style of form.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void SetCursor(Cursor cursor)
        {
            Cursor = cursor;
        }

        private void AddFirstPage()
        {
            _pages.Add(NewEmptyPage());
            this._splitContainerPageListAndPage.Panel1.Controls.Add(_pages[0]);
        }

        private void CreatePage(int index)
        {
            int pageWidth = _splitContainerPageListAndPage.Panel1.Width - 4;
            int pageHeight = (int)(pageWidth / DRAW_AREA_WIDTH_RATIO * DRAW_AREA_HEIGHT_RATIO);

            Button newPage = NewEmptyPage();
            if (index != 0)
            {
                newPage.Location = new System.Drawing.Point(2, _pages[index - 1].Location.Y + pageHeight);
                newPage.Size = _pages[0].Size;
            }
            else
            {
                newPage.Size = new System.Drawing.Size(pageWidth, pageHeight);
            }
                
            _pages.Insert(index, newPage);
            _splitContainerPageListAndPage.Panel1.Controls.Add(newPage);

            for (int i = index + 1; i < _pages.Count; i++)
            {
                _pages[i].Location = new System.Drawing.Point(2, _pages[i - 1].Location.Y + pageHeight);
            }

            UpdateScalePointSize();
        }

        private void DeletePage(int index)
        {
            _splitContainerPageListAndPage.Panel1.Controls.Remove(_pages[index]);
            _pages.RemoveAt(index);
            ResizePageList();
            _drawArea.Invalidate(true);
        }

        private Button NewEmptyPage()
        {
            Button newPage = new Button();
            newPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            newPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            newPage.Location = new System.Drawing.Point(2, 3);
            newPage.Margin = new System.Windows.Forms.Padding(2);
            newPage.Name = "_page1";
            newPage.Size = new System.Drawing.Size(164, 66);
            newPage.TabIndex = 3;
            newPage.UseVisualStyleBackColor = false;
            newPage.Click += new EventHandler(ClickPage);
            newPage.Paint += PagePaint;

            return newPage;
        }

        private int GetPageIndex(Button page)
        {
            for (int i = 0; i < _pages.Count; i++)
            {
                if (page.Location.Y == _pages[i].Location.Y)
                    return i;
            }
            return -1;
        }
    }
}
