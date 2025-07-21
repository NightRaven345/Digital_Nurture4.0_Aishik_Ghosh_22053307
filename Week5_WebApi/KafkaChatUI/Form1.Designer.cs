namespace KafkaChatUI
{
    partial class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null!;
        private System.Windows.Forms.TextBox txtChat = null!;
        private System.Windows.Forms.TextBox txtInput = null!;
        private System.Windows.Forms.Button btnSend = null!;
        private System.Windows.Forms.Panel panelBottom = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtChat = new TextBox();
            txtInput = new TextBox();
            btnSend = new Button();
            panelBottom = new Panel();
            var layoutBottom = new TableLayoutPanel();

            SuspendLayout();

            // txtChat (chat display box)
            txtChat.Multiline = true;
            txtChat.Dock = DockStyle.Fill;
            txtChat.ReadOnly = true;
            txtChat.ScrollBars = ScrollBars.Vertical;
            txtChat.Font = new Font("Segoe UI", 10);
            txtChat.BackColor = Color.White;
            txtChat.BorderStyle = BorderStyle.FixedSingle;
            txtChat.TabIndex = 0;

            // txtInput (user input)
            txtInput.Font = new Font("Segoe UI", 10);
            txtInput.Dock = DockStyle.Fill;
            txtInput.TabIndex = 1;

            // btnSend (send button)
            btnSend.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSend.Text = "Send";
            btnSend.Dock = DockStyle.Fill;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.TabIndex = 2;

            // layoutBottom (grid layout for input + button)
            layoutBottom.ColumnCount = 2;
            layoutBottom.RowCount = 1;
            layoutBottom.Dock = DockStyle.Fill;
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            layoutBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            layoutBottom.Controls.Add(txtInput, 0, 0);
            layoutBottom.Controls.Add(btnSend, 1, 0);

            // panelBottom (container at the bottom)
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 50;
            panelBottom.Padding = new Padding(5);
            panelBottom.Controls.Add(layoutBottom);

            // Form1
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(txtChat);
            Controls.Add(panelBottom);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kafka Chat UI";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
