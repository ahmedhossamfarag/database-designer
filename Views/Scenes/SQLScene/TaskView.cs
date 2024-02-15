using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class TaskView : Panel
	{
		private Label TaskName;
		private Button SQLWrite;
		private Button SQLSelectX;
		private Button SQLSelect;
		private Button SQLInsert;
		private Button SQLUpdate;
		private Button SQLDelete;
		private FlowLayoutPanel SQLB;
		public readonly List<SQLOperation> SQL = new List<SQLOperation>();

		private Task Task_;

		public Task Task
		{
			get { return Task_; }
			set { 
				Task_ = value;
				TaskName.Text = Task != null ? Task.Name + (Task.In ? "     In" : "") + (Task.Out ? "     Out" : "") : "SQL Queries";
				SQLDelete.Enabled = SQLInsert.Enabled = SQLUpdate.Enabled = Task == null || Task.In;
				SQLSelectX.Enabled = SQLSelect.Enabled = Task == null || Task.Out;

			}
		}

		public Database Database { get; set; }


		public TaskView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.TaskName = new Label();
			this.SQLDelete = new Button();
			this.SQLSelectX = new Button();
			this.SQLSelect = new Button();
			this.SQLWrite = new Button();
			this.SQLInsert = new Button();
			this.SQLUpdate = new Button();
			this.SQLB = new FlowLayoutPanel();
			// 
			// TaskName
			// 
			this.TaskName.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Left)
			| AnchorStyles.Right)));
			this.TaskName.Location = new System.Drawing.Point(0, 0);
			this.TaskName.Name = "TaskName";
			this.TaskName.Padding = new Padding(10, 0, 0, 0);
			this.TaskName.Size = new System.Drawing.Size(235, 40);
			this.TaskName.TabIndex = 0;
			this.TaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SQLDelete
			// 
			this.SQLDelete.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLDelete.Location = new System.Drawing.Point(691, 2);
			this.SQLDelete.Name = "SQLDelete";
			this.SQLDelete.Size = new System.Drawing.Size(97, 36);
			this.SQLDelete.TabIndex = 1;
			this.SQLDelete.Text = "Delete";
			this.SQLDelete.UseVisualStyleBackColor = true;
			this.SQLDelete.Click += new System.EventHandler(this.SQLDelete_Click);
			// 
			// SQLSelectX
			// 
			this.SQLSelectX.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLSelectX.Location = new System.Drawing.Point(382, 2);
			this.SQLSelectX.Name = "SQLSelectX";
			this.SQLSelectX.Size = new System.Drawing.Size(97, 36);
			this.SQLSelectX.TabIndex = 2;
			this.SQLSelectX.Text = "SelectX";
			this.SQLSelectX.UseVisualStyleBackColor = true;
			this.SQLSelectX.Click += new System.EventHandler(this.SQLSelectX_Click);
			// 
			// SQLSelect
			// 
			this.SQLSelect.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLSelect.Location = new System.Drawing.Point(279, 2);
			this.SQLSelect.Name = "SQLSelect";
			this.SQLSelect.Size = new System.Drawing.Size(97, 36);
			this.SQLSelect.TabIndex = 3;
			this.SQLSelect.Text = "Select";
			this.SQLSelect.UseVisualStyleBackColor = true;
			this.SQLSelect.Click += new System.EventHandler(this.SQLSelect_Click);
			// 
			// SQLWrite
			// 
			this.SQLWrite.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLWrite.Location = new System.Drawing.Point(176, 2);
			this.SQLWrite.Name = "SQLWrite";
			this.SQLWrite.Size = new System.Drawing.Size(97, 36);
			this.SQLWrite.TabIndex = 3;
			this.SQLWrite.Text = "Write SQL";
			this.SQLWrite.UseVisualStyleBackColor = true;
			this.SQLWrite.Click += new System.EventHandler(this.SQLWrite_Click);
			// 
			// SQLInsert
			// 
			this.SQLInsert.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLInsert.Location = new System.Drawing.Point(485, 2);
			this.SQLInsert.Name = "SQLInsert";
			this.SQLInsert.Size = new System.Drawing.Size(97, 36);
			this.SQLInsert.TabIndex = 4;
			this.SQLInsert.Text = "Insert";
			this.SQLInsert.UseVisualStyleBackColor = true;
			this.SQLInsert.Click += new System.EventHandler(this.SQLInsert_Click);
			// 
			// SQLUpdate
			// 
			this.SQLUpdate.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			this.SQLUpdate.Location = new System.Drawing.Point(588, 2);
			this.SQLUpdate.Name = "SQLUpdate";
			this.SQLUpdate.Size = new System.Drawing.Size(97, 36);
			this.SQLUpdate.TabIndex = 5;
			this.SQLUpdate.Text = "Update";
			this.SQLUpdate.UseVisualStyleBackColor = true;
			this.SQLUpdate.Click += new System.EventHandler(this.SQLUpdate_Click);
			//
			// SQLB
			//
			SQLB.Anchor = ((AnchorStyles)((((AnchorStyles.Top
			| AnchorStyles.Left)
			| AnchorStyles.Right))));
			this.SQLB.Location = new System.Drawing.Point(0, 40);
			this.SQLB.BackColor = System.Drawing.SystemColors.Control;
			this.SQLB.Size = new System.Drawing.Size(800, 30);
			this.SQLB.AutoScroll = true;
			// 
			// TaskView
			// 
			this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.BackColor = System.Drawing.Color.White;
			this.Font = new System.Drawing.Font("Arial", 12F);
			this.Name = "TaskView";
			this.Location = new System.Drawing.Point(0,0);
			this.Size = new System.Drawing.Size(800, 70);
			this.TabIndex = 0;
			this.Controls.Add(this.SQLUpdate);
			this.Controls.Add(this.SQLInsert);
			this.Controls.Add(this.SQLSelect);
			this.Controls.Add(this.SQLWrite);
			this.Controls.Add(this.SQLSelectX);
			this.Controls.Add(this.SQLDelete);
			this.Controls.Add(this.TaskName);
			this.Controls.Add(SQLB);

		}

		private void SQLWrite_Click(object sender, EventArgs e)
		{
			WriteSQLView view = new WriteSQLView();
			view.OnOk = () => {
				WriteSQL q = view.Get();
				if (q != null)
				{
					View(q);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void SQLSelect_Click(object sender, EventArgs e)
		{
			SelectView view = new SelectView(Database);
			view.OnOk = () => {
				Select q = view.Get();
				if (q != null)
				{
					View(q);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void SQLSelectX_Click(object sender, EventArgs e)
		{
			SelectXView view = new SelectXView() { Selects = SQL.TakeWhile(s => s is Select).Cast<Select>() };
			view.OnOk = () => {
				SelectX q = view.Get();
				if (q != null)
				{
					View(q);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void SQLInsert_Click(object sender, EventArgs e)
		{
			InsertView view = new InsertView() { Database = Database};
			view.OnOk = () => {
				Insert q = view.Get();
				if (q != null)
				{
					View(q);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void SQLUpdate_Click(object sender, EventArgs e)
		{
			UpdateView view = new UpdateView() { Database = Database};
			view.OnOk = () => {
				Update q = view.Get();
				if (q != null)
				{
					View(q);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void SQLDelete_Click(object sender, EventArgs e)
		{
			DeleteView view = new DeleteView() { Database = Database};
			view.OnOk = () => {
				Delete d = view.Get();
				if (d != null)
				{
					View(d);
					view.Close();
				}
				else
					InfoDialog.Of("Invalid");
			};
			view.ShowDialog();
		}

		private void View(SQLOperation o)
		{
			if (SQL.Any(s => s.Write() == o.Write()))
				return;
			CheckBox b = new CheckBox()
			{
				Text = o.ToString(),
				Checked = true,
				AutoSize = true
			};
			SQLB.Controls.Add(b);
			SQL.Add(o);
			b.CheckedChanged += (s, e) => {
                InfoDialog dialog = new InfoDialog("Are You Sure ?")
                {
                    OnOk = () =>
                    {
                        SQLB.Controls.Remove(b);
                        SQL.Remove(o);
                    }
                };
                dialog.Show();
            };

		}
	}
}
