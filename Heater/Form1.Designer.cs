namespace Heater
{
  partial class Form1
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
      this.DisplayLabel = new System.Windows.Forms.Label();
      this.UpButton = new System.Windows.Forms.Button();
      this.DownButton = new System.Windows.Forms.Button();
      this.OnOffButton = new System.Windows.Forms.Button();
      this.MaxButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // DisplayLabel
      // 
      this.DisplayLabel.BackColor = System.Drawing.Color.White;
      this.DisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.DisplayLabel.Font = new System.Drawing.Font("Yu Gothic UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.DisplayLabel.ForeColor = System.Drawing.Color.Purple;
      this.DisplayLabel.Location = new System.Drawing.Point(94, 71);
      this.DisplayLabel.Name = "DisplayLabel";
      this.DisplayLabel.Size = new System.Drawing.Size(278, 72);
      this.DisplayLabel.TabIndex = 0;
      this.DisplayLabel.Text = "label1";
      this.DisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // UpButton
      // 
      this.UpButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.UpButton.Location = new System.Drawing.Point(173, 157);
      this.UpButton.Name = "UpButton";
      this.UpButton.Size = new System.Drawing.Size(125, 45);
      this.UpButton.TabIndex = 1;
      this.UpButton.Text = "Up";
      this.UpButton.UseVisualStyleBackColor = true;
      this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
      // 
      // DownButton
      // 
      this.DownButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.DownButton.Location = new System.Drawing.Point(173, 208);
      this.DownButton.Name = "DownButton";
      this.DownButton.Size = new System.Drawing.Size(125, 45);
      this.DownButton.TabIndex = 2;
      this.DownButton.Text = "Down";
      this.DownButton.UseVisualStyleBackColor = true;
      this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
      // 
      // OnOffButton
      // 
      this.OnOffButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.OnOffButton.Location = new System.Drawing.Point(37, 12);
      this.OnOffButton.Name = "OnOffButton";
      this.OnOffButton.Size = new System.Drawing.Size(125, 45);
      this.OnOffButton.TabIndex = 3;
      this.OnOffButton.Text = "ON/OFF";
      this.OnOffButton.UseVisualStyleBackColor = true;
      this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
      // 
      // MaxButton
      // 
      this.MaxButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.MaxButton.Location = new System.Drawing.Point(317, 157);
      this.MaxButton.Name = "MaxButton";
      this.MaxButton.Size = new System.Drawing.Size(125, 45);
      this.MaxButton.TabIndex = 4;
      this.MaxButton.Text = "Max";
      this.MaxButton.UseVisualStyleBackColor = true;
      this.MaxButton.Click += new System.EventHandler(this.MaxButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(476, 289);
      this.Controls.Add(this.MaxButton);
      this.Controls.Add(this.OnOffButton);
      this.Controls.Add(this.DownButton);
      this.Controls.Add(this.UpButton);
      this.Controls.Add(this.DisplayLabel);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private Label DisplayLabel;
    private Button UpButton;
    private Button DownButton;
    private Button OnOffButton;
    private Button MaxButton;
  }
}