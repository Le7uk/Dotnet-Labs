namespace FileBrowser
{
    partial class FileBrowserForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openButton = new Button();
            resultTextBox = new TextBox();
            nextButton = new Button();
            closeButton = new Button();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // openButton
            // 
            openButton.Location = new Point(12, 12);
            openButton.Name = "openButton";
            openButton.Size = new Size(112, 34);
            openButton.TabIndex = 0;
            openButton.Text = "Open";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(12, 60);
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(771, 378);
            resultTextBox.TabIndex = 1;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(144, 11);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(112, 34);
            nextButton.TabIndex = 2;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(278, 11);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(112, 34);
            closeButton.TabIndex = 3;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // FileBrowserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(closeButton);
            Controls.Add(nextButton);
            Controls.Add(resultTextBox);
            Controls.Add(openButton);
            Name = "FileBrowserForm";
            Text = "File Browser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openButton;
        private TextBox resultTextBox;
        private Button nextButton;
        private Button closeButton;
        private OpenFileDialog openFileDialog;
    }
}