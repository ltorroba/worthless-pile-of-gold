namespace Skype_Bot
{
    partial class Form1
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
            this.speakerList = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.speakerListClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.masterListClear = new System.Windows.Forms.Button();
            this.masterList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // speakerList
            // 
            this.speakerList.FormattingEnabled = true;
            this.speakerList.Location = new System.Drawing.Point(12, 29);
            this.speakerList.Name = "speakerList";
            this.speakerList.Size = new System.Drawing.Size(120, 95);
            this.speakerList.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(509, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 284);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(509, 95);
            this.listBox2.TabIndex = 2;
            // 
            // speakerListClear
            // 
            this.speakerListClear.Location = new System.Drawing.Point(12, 130);
            this.speakerListClear.Name = "speakerListClear";
            this.speakerListClear.Size = new System.Drawing.Size(120, 23);
            this.speakerListClear.TabIndex = 3;
            this.speakerListClear.Text = "button1";
            this.speakerListClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speaker list:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Master list:";
            // 
            // masterListClear
            // 
            this.masterListClear.Location = new System.Drawing.Point(154, 130);
            this.masterListClear.Name = "masterListClear";
            this.masterListClear.Size = new System.Drawing.Size(120, 23);
            this.masterListClear.TabIndex = 7;
            this.masterListClear.Text = "button2";
            this.masterListClear.UseVisualStyleBackColor = true;
            // 
            // masterList
            // 
            this.masterList.FormattingEnabled = true;
            this.masterList.Location = new System.Drawing.Point(154, 29);
            this.masterList.Name = "masterList";
            this.masterList.Size = new System.Drawing.Size(120, 95);
            this.masterList.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 401);
            this.Controls.Add(this.masterListClear);
            this.Controls.Add(this.masterList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speakerListClear);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.speakerList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox speakerList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button speakerListClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button masterListClear;
        private System.Windows.Forms.ListBox masterList;
    }
}

