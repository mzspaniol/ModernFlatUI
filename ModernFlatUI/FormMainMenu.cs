using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ModernFlatUI
{
    public partial class FormMainMenu : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

            
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            // Limita o tamanho do form para ser o máximo igual a área de trabalho
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
           
        }

        private struct RGBColors
        {
            public static Color Color1 = Color.FromArgb(172, 126, 241);
            public static Color Color2 = Color.FromArgb(249, 118, 176);
            public static Color Color3 = Color.FromArgb(253, 138, 114);
            public static Color Color4 = Color.FromArgb(95, 77, 221);
            public static Color Color5 = Color.FromArgb(49, 88, 155);
            public static Color Color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lblTitleChildForm.Text = currentBtn.Text;

                if (currentChildForm != null)
                    currentChildForm.Close();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 36, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color1);
            OpenChildForm(new FormDashboard());
        }

        private void btnOrders_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color2);
            OpenChildForm(new FormOrders());
        }

        private void btnProducts_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color3);
            OpenChildForm(new FormProducts());
        }

        private void btnCustomers_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color4);
            OpenChildForm(new FormCustomers());
        }

        private void btnMarketing_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color5);
            OpenChildForm(new FormMarketing());
        }

        private void btnSetting_Click(object sender, System.EventArgs e)
        {
            ActivateButton(sender, RGBColors.Color6);
            OpenChildForm(new FormSettings());
        }

        private void btnHome_Click(object sender, System.EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Drag form

        [DllImport("user32.DLL", EntryPoint =  "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = this.panelDesktop.BackColor;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized ;
            else
                WindowState = FormWindowState.Normal;
            
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
