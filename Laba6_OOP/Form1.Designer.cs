
namespace Laba6_OOP
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_rec = new System.Windows.Forms.Button();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_triangle = new System.Windows.Forms.Button();
            this.btn_black = new System.Windows.Forms.Button();
            this.btn_white = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(600, 340);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // btn_circle
            // 
            this.btn_circle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_circle.CausesValidation = false;
            this.btn_circle.Enabled = false;
            this.btn_circle.Location = new System.Drawing.Point(618, 12);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(62, 35);
            this.btn_circle.TabIndex = 1;
            this.btn_circle.TabStop = false;
            this.btn_circle.Text = "Круг";
            this.btn_circle.UseVisualStyleBackColor = true;

            // 
            // btn_rec
            // 
            this.btn_rec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_rec.Location = new System.Drawing.Point(618, 53);
            this.btn_rec.Name = "btn_rec";
            this.btn_rec.Size = new System.Drawing.Size(62, 35);
            this.btn_rec.TabIndex = 2;
            this.btn_rec.Text = "Прямоугольник";
            this.btn_rec.UseVisualStyleBackColor = true;
            // 
            // btn_square
            // 
            this.btn_square.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_square.Location = new System.Drawing.Point(618, 94);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(62, 35);
            this.btn_square.TabIndex = 3;
            this.btn_square.Text = "Квадрат";
            this.btn_square.UseVisualStyleBackColor = true;
            // 
            // btn_triangle
            // 
            this.btn_triangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_triangle.Location = new System.Drawing.Point(618, 135);
            this.btn_triangle.Name = "btn_triangle";
            this.btn_triangle.Size = new System.Drawing.Size(62, 35);
            this.btn_triangle.TabIndex = 4;
            this.btn_triangle.Text = "Треугольник";
            this.btn_triangle.UseVisualStyleBackColor = true;
            // 
            // btn_black
            // 
            this.btn_black.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_black.Location = new System.Drawing.Point(618, 217);
            this.btn_black.Name = "btn_black";
            this.btn_black.Size = new System.Drawing.Size(62, 35);
            this.btn_black.TabIndex = 6;
            this.btn_black.Text = "Черный";
            this.btn_black.UseVisualStyleBackColor = true;
            // 
            // btn_white
            // 
            this.btn_white.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_white.Location = new System.Drawing.Point(618, 258);
            this.btn_white.Name = "btn_white";
            this.btn_white.Size = new System.Drawing.Size(62, 35);
            this.btn_white.TabIndex = 7;
            this.btn_white.Text = "Белый";
            this.btn_white.UseVisualStyleBackColor = true;
            // 
            // btn_green
            // 
            this.btn_green.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_green.Location = new System.Drawing.Point(618, 299);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(62, 35);
            this.btn_green.TabIndex = 8;
            this.btn_green.Text = "Зеленый";
            this.btn_green.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.btn_green);
            this.Controls.Add(this.btn_white);
            this.Controls.Add(this.btn_black);
            this.Controls.Add(this.btn_triangle);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.btn_rec);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.canvas);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_rec;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_triangle;
        private System.Windows.Forms.Button btn_black;
        private System.Windows.Forms.Button btn_white;
        private System.Windows.Forms.Button btn_green;
    }
}

