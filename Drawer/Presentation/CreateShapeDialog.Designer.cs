
namespace Drawer.Presentation
{
    partial class CreateShapeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._upperLeftXTextBox = new System.Windows.Forms.TextBox();
            this._upperLeftYTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._lowerRightXTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._lowerRightYTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.Location = new System.Drawing.Point(45, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "左上角座標 X";
            // 
            // _upperLeftXTextBox
            // 
            this._upperLeftXTextBox.Location = new System.Drawing.Point(40, 60);
            this._upperLeftXTextBox.Name = "_upperLeftXTextBox";
            this._upperLeftXTextBox.Size = new System.Drawing.Size(100, 22);
            this._upperLeftXTextBox.TabIndex = 1;
            // 
            // _upperLeftYTextBox
            // 
            this._upperLeftYTextBox.Location = new System.Drawing.Point(180, 60);
            this._upperLeftYTextBox.Name = "_upperLeftYTextBox";
            this._upperLeftYTextBox.Size = new System.Drawing.Size(100, 22);
            this._upperLeftYTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(185, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "左上角座標 Y";
            // 
            // _lowerRightXTextBox
            // 
            this._lowerRightXTextBox.Location = new System.Drawing.Point(40, 137);
            this._lowerRightXTextBox.Name = "_lowerRightXTextBox";
            this._lowerRightXTextBox.Size = new System.Drawing.Size(100, 22);
            this._lowerRightXTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(45, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "右上角座標 X";
            // 
            // _lowerRightYTextBox
            // 
            this._lowerRightYTextBox.Location = new System.Drawing.Point(180, 137);
            this._lowerRightYTextBox.Name = "_lowerRightYTextBox";
            this._lowerRightYTextBox.Size = new System.Drawing.Size(100, 22);
            this._lowerRightYTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label4.Location = new System.Drawing.Point(185, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "右上角座標 Y";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(48, 198);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(90, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.HandleOkButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(180, 198);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(90, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.HandleCancelButtonClick);
            // 
            // CreateShapeDialog
            // 
            this.AccessibleName = "CreateShapeDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._lowerRightYTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._lowerRightXTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._upperLeftYTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._upperLeftXTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateShapeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateShapeDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _upperLeftXTextBox;
        private System.Windows.Forms.TextBox _upperLeftYTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _lowerRightXTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _lowerRightYTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}