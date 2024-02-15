using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal class TableView : Panel
	{
		private Button TableName;
		private Panel AttContainer;
		private readonly List<(Property Att, AttrView View)> Attributes = new List<(Property Att, AttrView View)>();
		private Table Table_;
		public Database Database;
		public Table Table
		{
			get { return Table_; }
			set
			{
				Set(value);
			}
		}
		public TableView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AttContainer = new System.Windows.Forms.Panel();
			TableName = new System.Windows.Forms.Button();
			AttContainer.SuspendLayout();
			SuspendLayout();
			this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// AttContainer
			// 
			AttContainer.Font = new System.Drawing.Font("Arial", 8F);
			AttContainer.Location = new System.Drawing.Point(0, 51);
			AttContainer.Name = "AttContainer";
			AttContainer.Size = new System.Drawing.Size(861, 404);
			AttContainer.TabIndex = 0;
			AttContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// TableView
			// 
			ClientSize = new System.Drawing.Size(861, 453);
			Controls.Add(TableName);
			Controls.Add(AttContainer);
			Name = "TableView";
			AttContainer.ResumeLayout(false);
			ResumeLayout(false);
			// 
			// TableName
			// 
			TableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			TableName.Font = new System.Drawing.Font("Arial", 16F);
			TableName.ForeColor = System.Drawing.Color.DarkGray;
			TableName.Location = new System.Drawing.Point(0, 0);
			TableName.Name = "TableName";
			TableName.Size = new System.Drawing.Size(861, 45);
			TableName.TabIndex = 0;
			TableName.Text = "Table";
			TableName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			TableName.UseVisualStyleBackColor = true;
            TableName.Click += TableName_Click;
		}

        private void TableName_Click(object sender, EventArgs e)
        {
            TableEdit edit = new TableEdit();
            edit.Set(Table);
            //edit.Cancelbutton.Visible = false;
            edit.OnOk = () =>
            {
                edit.Update(Table, Database);
                TableName.Text = Table.Name;
            };
            Parent.Focus();
            edit.Show();
        }

        public void AddAttribute(Property attribute)
		{
			AttContainer.Controls.Add(new AttrView(attribute, Attributes));
		}


		public void Set(Table table)
		{
			Table_ = table;
			TableName.Text = table.Name;
			table.Attributes.ForEach(AddAttribute);
			AttContainer.Height = AttrView.Step * Attributes.Count;
			Height = TableName.Height + AttContainer.Height + 10;
		}

		public void Modify()
		{
			Table.Attributes = new Models.Base.UList<Property>(Attributes.ConvertAll(a => a.Att));
		}
	}
}
