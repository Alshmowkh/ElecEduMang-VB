<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class table
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.prnt = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.nostud = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.avg = New System.Windows.Forms.Label
        Me.allhor = New System.Windows.Forms.Label
        Me.hortrm = New System.Windows.Forms.Label
        Me.dept = New System.Windows.Forms.Label
        Me.lblnam = New System.Windows.Forms.Label
        Me.ext = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btngo = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'prnt
        '
        Me.prnt.Location = New System.Drawing.Point(625, 451)
        Me.prnt.Name = "prnt"
        Me.prnt.Size = New System.Drawing.Size(70, 31)
        Me.prnt.TabIndex = 0
        Me.prnt.Text = "ÿ»«⁄…"
        Me.prnt.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.Brown
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(4, 125)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(702, 320)
        Me.dgv.TabIndex = 1
        '
        'nostud
        '
        Me.nostud.Location = New System.Drawing.Point(58, 15)
        Me.nostud.Name = "nostud"
        Me.nostud.Size = New System.Drawing.Size(100, 26)
        Me.nostud.TabIndex = 3
        Me.nostud.Text = "—ﬁ„ «·ÿ«·»"
        Me.nostud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.avg)
        Me.GroupBox1.Controls.Add(Me.allhor)
        Me.GroupBox1.Controls.Add(Me.hortrm)
        Me.GroupBox1.Controls.Add(Me.dept)
        Me.GroupBox1.Controls.Add(Me.lblnam)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "„⁄·Ê„«  «·ÿ«·»:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(67, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "«·„⁄œ·:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "«·”«⁄«  «·„”Ã·…"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "«·”«⁄«  «·„ﬂ ”»…"
        '
        'avg
        '
        Me.avg.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.avg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.avg.Font = New System.Drawing.Font("Arabic Transparent", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.avg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.avg.Location = New System.Drawing.Point(6, 65)
        Me.avg.Name = "avg"
        Me.avg.Size = New System.Drawing.Size(55, 25)
        Me.avg.TabIndex = 9
        Me.avg.Text = "0"
        Me.avg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'allhor
        '
        Me.allhor.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.allhor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.allhor.Font = New System.Drawing.Font("Arabic Transparent", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.allhor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.allhor.Location = New System.Drawing.Point(295, 65)
        Me.allhor.Name = "allhor"
        Me.allhor.Size = New System.Drawing.Size(66, 25)
        Me.allhor.TabIndex = 8
        Me.allhor.Text = "0"
        Me.allhor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hortrm
        '
        Me.hortrm.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.hortrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hortrm.Font = New System.Drawing.Font("Arabic Transparent", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.hortrm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.hortrm.Location = New System.Drawing.Point(119, 64)
        Me.hortrm.Name = "hortrm"
        Me.hortrm.Size = New System.Drawing.Size(65, 25)
        Me.hortrm.TabIndex = 7
        Me.hortrm.Text = "0"
        Me.hortrm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dept
        '
        Me.dept.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.dept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dept.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dept.Location = New System.Drawing.Point(80, 22)
        Me.dept.Name = "dept"
        Me.dept.Size = New System.Drawing.Size(120, 25)
        Me.dept.TabIndex = 6
        Me.dept.Text = "«· Œ’’:"
        Me.dept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblnam
        '
        Me.lblnam.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblnam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblnam.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblnam.Location = New System.Drawing.Point(206, 22)
        Me.lblnam.Name = "lblnam"
        Me.lblnam.Size = New System.Drawing.Size(248, 25)
        Me.lblnam.TabIndex = 5
        Me.lblnam.Text = "«”„ «·ÿ«·»:"
        Me.lblnam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ext
        '
        Me.ext.Location = New System.Drawing.Point(3, 450)
        Me.ext.Name = "ext"
        Me.ext.Size = New System.Drawing.Size(70, 31)
        Me.ext.TabIndex = 5
        Me.ext.Text = "Œ—ÊÃ"
        Me.ext.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btngo)
        Me.Panel1.Controls.Add(Me.nostud)
        Me.Panel1.Location = New System.Drawing.Point(506, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 91)
        Me.Panel1.TabIndex = 6
        '
        'btngo
        '
        Me.btngo.Location = New System.Drawing.Point(75, 47)
        Me.btngo.Name = "btngo"
        Me.btngo.Size = New System.Drawing.Size(70, 27)
        Me.btngo.TabIndex = 7
        Me.btngo.Text = " ‰›Ì–"
        Me.btngo.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Elec_Eduo_Mang.My.Resources.Resources.elec_educ_mang1
        Me.PictureBox2.Location = New System.Drawing.Point(-4, 445)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(710, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'table
        '
        Me.AcceptButton = Me.btngo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Brown
        Me.ClientSize = New System.Drawing.Size(708, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.ext)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.prnt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Font = New System.Drawing.Font("Arabic Transparent", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "table"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "table"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prnt As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents nostud As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblnam As System.Windows.Forms.Label
    Friend WithEvents avg As System.Windows.Forms.Label
    Friend WithEvents allhor As System.Windows.Forms.Label
    Friend WithEvents hortrm As System.Windows.Forms.Label
    Friend WithEvents dept As System.Windows.Forms.Label
    Friend WithEvents ext As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btngo As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
