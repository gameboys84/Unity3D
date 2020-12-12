using System;
using System.Drawing;
using System.Windows.Forms;

namespace Encode
{
    partial class Encode
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_path = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Mes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Open = new System.Windows.Forms.Button();
            this.button_Reload = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.richTextBox_FileType = new System.Windows.Forms.RichTextBox();
            this.comboBox_Select = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_path
            // 
            this.richTextBox_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_path.Location = new System.Drawing.Point(12, 25);
            this.richTextBox_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_path.Name = "richTextBox_path";
            this.richTextBox_path.ReadOnly = true;
            this.richTextBox_path.Size = new System.Drawing.Size(585, 97);
            this.richTextBox_path.TabIndex = 1;
            this.richTextBox_path.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "支持拖放目录";
            // 
            // listView_Mes
            // 
            this.listView_Mes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Mes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Mes.FullRowSelect = true;
            this.listView_Mes.GridLines = true;
            this.listView_Mes.HideSelection = false;
            this.listView_Mes.Location = new System.Drawing.Point(12, 126);
            this.listView_Mes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView_Mes.Name = "listView_Mes";
            this.listView_Mes.Size = new System.Drawing.Size(585, 277);
            this.listView_Mes.TabIndex = 3;
            this.listView_Mes.UseCompatibleStateImageBehavior = false;
            this.listView_Mes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容编码";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.Width = 75;
            // 
            // button_Open
            // 
            this.button_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Open.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Open.Location = new System.Drawing.Point(603, 25);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(129, 28);
            this.button_Open.TabIndex = 2;
            this.button_Open.Text = "打开文件夹";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_Reload
            // 
            this.button_Reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Reload.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Reload.Location = new System.Drawing.Point(603, 60);
            this.button_Reload.Name = "button_Reload";
            this.button_Reload.Size = new System.Drawing.Size(129, 28);
            this.button_Reload.TabIndex = 12;
            this.button_Reload.Text = "刷新";
            this.button_Reload.UseVisualStyleBackColor = true;
            this.button_Reload.Click += new System.EventHandler(this.button_Reload_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Clear.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Clear.Location = new System.Drawing.Point(603, 94);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(129, 28);
            this.button_Clear.TabIndex = 5;
            this.button_Clear.Text = "清空";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Change
            // 
            this.button_Change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Change.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Change.Location = new System.Drawing.Point(606, 298);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(129, 75);
            this.button_Change.TabIndex = 0;
            this.button_Change.Text = "转换";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // richTextBox_FileType
            // 
            this.richTextBox_FileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_FileType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_FileType.Location = new System.Drawing.Point(606, 143);
            this.richTextBox_FileType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_FileType.Name = "richTextBox_FileType";
            this.richTextBox_FileType.Size = new System.Drawing.Size(129, 70);
            this.richTextBox_FileType.TabIndex = 6;
            this.richTextBox_FileType.Text = ".txt";
            // 
            // comboBox_Select
            // 
            this.comboBox_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Select.FormattingEnabled = true;
            this.comboBox_Select.Items.AddRange(new object[] {
            "UTF8",
            "GB2312"});
            this.comboBox_Select.Location = new System.Drawing.Point(606, 378);
            this.comboBox_Select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Select.Name = "comboBox_Select";
            this.comboBox_Select.Size = new System.Drawing.Size(129, 25);
            this.comboBox_Select.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(603, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "格式( .txt|.ini )的文本文件";
            // 
            // Encode
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 410);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Select);
            this.Controls.Add(this.richTextBox_FileType);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Reload);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.listView_Mes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_path);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(758, 449);
            this.Name = "Encode";
            this.Text = "批量文本格式转换工具";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_Mes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.Button button_Reload;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Change;
        private System.Windows.Forms.RichTextBox richTextBox_FileType;
        private System.Windows.Forms.ComboBox comboBox_Select;
        private System.Windows.Forms.Label label2;
    }
}

