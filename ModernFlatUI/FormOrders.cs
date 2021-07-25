using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernFlatUI
{
    public partial class FormOrders : Form
    {
        private RadioButton radioButton1;
        private MonthCalendar monthCalendar1;

        public FormOrders()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 43);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // FormOrders
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.radioButton1);
            this.Name = "FormOrders";
            this.Text = "Orders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
