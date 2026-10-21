namespace MdiApp;

partial class FormMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip = new System.Windows.Forms.MenuStrip();
        menuSystem = new System.Windows.Forms.ToolStripMenuItem();
        menuLogout = new System.Windows.Forms.ToolStripMenuItem();
        menuExit = new System.Windows.Forms.ToolStripMenuItem();
        menuCatalog = new System.Windows.Forms.ToolStripMenuItem();
        menuStudent = new System.Windows.Forms.ToolStripMenuItem();
        menuProduct = new System.Windows.Forms.ToolStripMenuItem();
        menuWindow = new System.Windows.Forms.ToolStripMenuItem();
        menuCascade = new System.Windows.Forms.ToolStripMenuItem();
        menuTileH = new System.Windows.Forms.ToolStripMenuItem();
        menuTileV = new System.Windows.Forms.ToolStripMenuItem();
        menuSep = new System.Windows.Forms.ToolStripSeparator();
        menuCloseAll = new System.Windows.Forms.ToolStripMenuItem();
        toolStrip = new System.Windows.Forms.ToolStrip();
        tsbStudent = new System.Windows.Forms.ToolStripButton();
        tsbProduct = new System.Windows.Forms.ToolStripButton();
        tsSep1 = new System.Windows.Forms.ToolStripSeparator();
        tsbRefresh = new System.Windows.Forms.ToolStripButton();
        statusStrip = new System.Windows.Forms.StatusStrip();
        lblUser = new System.Windows.Forms.ToolStripStatusLabel();
        lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
        lblTime = new System.Windows.Forms.ToolStripStatusLabel();
        ctxMain = new System.Windows.Forms.ContextMenuStrip(components);
        ctxCascade = new System.Windows.Forms.ToolStripMenuItem();
        ctxTileH = new System.Windows.Forms.ToolStripMenuItem();
        ctxTileV = new System.Windows.Forms.ToolStripMenuItem();
        ctxCloseAll = new System.Windows.Forms.ToolStripMenuItem();
        timerClock = new System.Windows.Forms.Timer(components);
        menuStrip.SuspendLayout();
        toolStrip.SuspendLayout();
        statusStrip.SuspendLayout();
        ctxMain.SuspendLayout();
        SuspendLayout();
        //
        // menuStrip
        //
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuSystem, menuCatalog, menuWindow });
        menuStrip.Location = new System.Drawing.Point(0, 0);
        menuStrip.MdiWindowListItem = menuWindow;
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new System.Drawing.Size(1000, 24);
        menuStrip.TabIndex = 0;
        //
        // menuSystem
        //
        menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuLogout, menuExit });
        menuSystem.Name = "menuSystem";
        menuSystem.Text = "&Hệ thống";
        //
        // menuLogout
        //
        menuLogout.Name = "menuLogout";
        menuLogout.Text = "Đăng xuất";
        menuLogout.Click += menuLogout_Click;
        //
        // menuExit
        //
        menuExit.Name = "menuExit";
        menuExit.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
        menuExit.Text = "Thoát";
        menuExit.Click += menuExit_Click;
        //
        // menuCatalog
        //
        menuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuStudent, menuProduct });
        menuCatalog.Name = "menuCatalog";
        menuCatalog.Text = "&Danh mục";
        //
        // menuStudent
        //
        menuStudent.Name = "menuStudent";
        menuStudent.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1;
        menuStudent.Text = "Quản lý Sinh viên";
        menuStudent.Click += menuStudent_Click;
        //
        // menuProduct
        //
        menuProduct.Name = "menuProduct";
        menuProduct.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2;
        menuProduct.Text = "Quản lý Sản phẩm";
        menuProduct.Click += menuProduct_Click;
        //
        // menuWindow
        //
        menuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuCascade, menuTileH, menuTileV, menuSep, menuCloseAll });
        menuWindow.Name = "menuWindow";
        menuWindow.Text = "&Cửa sổ";
        //
        // menuCascade
        //
        menuCascade.Name = "menuCascade";
        menuCascade.Text = "Cascade";
        menuCascade.Click += menuCascade_Click;
        //
        // menuTileH
        //
        menuTileH.Name = "menuTileH";
        menuTileH.Text = "Tile Horizontal";
        menuTileH.Click += menuTileH_Click;
        //
        // menuTileV
        //
        menuTileV.Name = "menuTileV";
        menuTileV.Text = "Tile Vertical";
        menuTileV.Click += menuTileV_Click;
        //
        // menuSep
        //
        menuSep.Name = "menuSep";
        //
        // menuCloseAll
        //
        menuCloseAll.Name = "menuCloseAll";
        menuCloseAll.Text = "Đóng tất cả";
        menuCloseAll.Click += menuCloseAll_Click;
        //
        // toolStrip
        //
        toolStrip.ContextMenuStrip = ctxMain;
        toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
        toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbStudent, tsbProduct, tsSep1, tsbRefresh });
        toolStrip.Location = new System.Drawing.Point(0, 24);
        toolStrip.Name = "toolStrip";
        toolStrip.Size = new System.Drawing.Size(1000, 59);
        toolStrip.TabIndex = 1;
        //
        // tsbStudent
        //
        tsbStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
        tsbStudent.Name = "tsbStudent";
        tsbStudent.Text = "Sinh viên";
        tsbStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbStudent.Click += menuStudent_Click;
        //
        // tsbProduct
        //
        tsbProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
        tsbProduct.Name = "tsbProduct";
        tsbProduct.Text = "Sản phẩm";
        tsbProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbProduct.Click += menuProduct_Click;
        //
        // tsSep1
        //
        tsSep1.Name = "tsSep1";
        //
        // tsbRefresh
        //
        tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
        tsbRefresh.Name = "tsbRefresh";
        tsbRefresh.Text = "Làm mới";
        tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        tsbRefresh.Click += tsbRefresh_Click;
        //
        // statusStrip
        //
        statusStrip.ContextMenuStrip = ctxMain;
        statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblUser, lblMessage, lblTime });
        statusStrip.Location = new System.Drawing.Point(0, 628);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new System.Drawing.Size(1000, 22);
        statusStrip.TabIndex = 2;
        //
        // lblUser
        //
        lblUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
        lblUser.Name = "lblUser";
        lblUser.Text = "Người dùng: -";
        //
        // lblMessage
        //
        lblMessage.Name = "lblMessage";
        lblMessage.Spring = true;
        lblMessage.Text = "Sẵn sàng.";
        lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // lblTime
        //
        lblTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
        lblTime.Name = "lblTime";
        lblTime.Text = "--/--/---- --:--:--";
        //
        // ctxMain
        //
        ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ctxCascade, ctxTileH, ctxTileV, ctxCloseAll });
        ctxMain.Name = "ctxMain";
        //
        // ctxCascade
        //
        ctxCascade.Name = "ctxCascade";
        ctxCascade.Text = "Sắp xếp Cascade";
        ctxCascade.Click += menuCascade_Click;
        //
        // ctxTileH
        //
        ctxTileH.Name = "ctxTileH";
        ctxTileH.Text = "Sắp xếp Tile Horizontal";
        ctxTileH.Click += menuTileH_Click;
        //
        // ctxTileV
        //
        ctxTileV.Name = "ctxTileV";
        ctxTileV.Text = "Sắp xếp Tile Vertical";
        ctxTileV.Click += menuTileV_Click;
        //
        // ctxCloseAll
        //
        ctxCloseAll.Name = "ctxCloseAll";
        ctxCloseAll.Text = "Đóng tất cả cửa sổ con";
        ctxCloseAll.Click += menuCloseAll_Click;
        //
        // timerClock
        //
        timerClock.Enabled = true;
        timerClock.Interval = 1000;
        timerClock.Tick += timerClock_Tick;
        //
        // FormMain
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1000, 650);
        Controls.Add(statusStrip);
        Controls.Add(toolStrip);
        Controls.Add(menuStrip);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip;
        Name = "FormMain";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Ứng dụng quản lý (MDI) - Async";
        WindowState = System.Windows.Forms.FormWindowState.Maximized;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        toolStrip.ResumeLayout(false);
        toolStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ctxMain.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuSystem;
    private System.Windows.Forms.ToolStripMenuItem menuLogout;
    private System.Windows.Forms.ToolStripMenuItem menuExit;
    private System.Windows.Forms.ToolStripMenuItem menuCatalog;
    private System.Windows.Forms.ToolStripMenuItem menuStudent;
    private System.Windows.Forms.ToolStripMenuItem menuProduct;
    private System.Windows.Forms.ToolStripMenuItem menuWindow;
    private System.Windows.Forms.ToolStripMenuItem menuCascade;
    private System.Windows.Forms.ToolStripMenuItem menuTileH;
    private System.Windows.Forms.ToolStripMenuItem menuTileV;
    private System.Windows.Forms.ToolStripSeparator menuSep;
    private System.Windows.Forms.ToolStripMenuItem menuCloseAll;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton tsbStudent;
    private System.Windows.Forms.ToolStripButton tsbProduct;
    private System.Windows.Forms.ToolStripSeparator tsSep1;
    private System.Windows.Forms.ToolStripButton tsbRefresh;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblUser;
    private System.Windows.Forms.ToolStripStatusLabel lblMessage;
    private System.Windows.Forms.ToolStripStatusLabel lblTime;
    private System.Windows.Forms.ContextMenuStrip ctxMain;
    private System.Windows.Forms.ToolStripMenuItem ctxCascade;
    private System.Windows.Forms.ToolStripMenuItem ctxTileH;
    private System.Windows.Forms.ToolStripMenuItem ctxTileV;
    private System.Windows.Forms.ToolStripMenuItem ctxCloseAll;
    private System.Windows.Forms.Timer timerClock;
}
