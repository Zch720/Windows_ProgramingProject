using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer.Presentation
{
    public partial class CreateShapeDialog : Form
    {
        public delegate void CreateShapeClickedEventHandler(int upperLeftX, int upperLeftY, int lowerRightX, int loerRightY);

        public event CreateShapeClickedEventHandler _createShapeClicked;

        private int UpperLeftX
        {
            get
            {
                return int.Parse(_upperLeftXTextBox.Text);
            }
        }
        private int UpperLeftY
        {
            get
            {
                return int.Parse(_upperLeftYTextBox.Text);
            }
        }
        private int LowerRightX
        {
            get
            {
                return int.Parse(_lowerRightXTextBox.Text);
            }
        }
        private int LowerRightY
        {
            get
            {
                return int.Parse(_lowerRightYTextBox.Text);
            }
        }

        public CreateShapeDialog()
        {
            InitializeComponent();
        }

        private void HandleOkButtonClick(Object sender, EventArgs e)
        {
            if (_createShapeClicked != null)
                _createShapeClicked(UpperLeftX, UpperLeftY, LowerRightX, LowerRightY);
            ClearTexts();
            this.Close();
        }

        private void HandleCancelButtonClick(Object sender, EventArgs e)
        {
            ClearTexts();
            this.Close();
        }

        private void ClearTexts()
        {
            _upperLeftXTextBox.Text = "";
            _upperLeftYTextBox.Text = "";
            _lowerRightXTextBox.Text = "";
            _lowerRightYTextBox.Text = "";
        } 
    }
}
