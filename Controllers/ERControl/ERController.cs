using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
using DatabaseDesigner.Models.IFD;
using Microsoft.TeamFoundation.Common;
using System.ComponentModel.Design;
using DatabaseDesigner.Models.Preference;

namespace DatabaseDesigner.Controllers.ERControl
{
	internal partial class ERController : DiagramController
	{
		public ERScene Scene;

		public ERDiagramView View { get; }

		public ScaleTool ScaleTool { get; }

		public ERController(ERScene scene) : base(scene.ERDiagramView1, scene.ScaleTool1)
		{
			Scene = scene;
			View = scene.ERDiagramView1;
			Tools = scene.ERTools1;
			scene.ERTools1.Free.Click += Free_Click;
			scene.ERTools1.Ent.Click += Ent_Click;
			scene.ERTools1.Rel.Click += Rel_Click;
			scene.ScaleTool1.ZoomIn.Click += ZoomIn_Click;
			scene.ScaleTool1.ZoomOut.Click += ZoomOut_Click;
			SetDefaultMouseListner();
		}

		private void ZoomOut_Click(object sender, EventArgs e) => View.Preferences.Scale--;

		private void ZoomIn_Click(object sender, EventArgs e) => View.Preferences.Scale++;


		private void Rel_Click(object sender, EventArgs e) => OnClick = NewRelation;

		private void Ent_Click(object sender, EventArgs e) => OnClick = NewEntity;

		private void Free_Click(object sender, EventArgs e) => SetDefault();

		public override void ChangeMode()
		{
			base.ChangeMode();
			Scene.EntityOptions1.View = null;
			Scene.AttributeOptions1.View = null;
			Scene.RelationOptions1.View = null;
			Scene.BranchOptions1.View = null;
			Scene.UnionOptions1.View = null;
			Scene.ERTools1.Free.Select();
		}

		public override void DefaultMouseClick(object s, MouseEventArgs e)
		{
			if(s is EntityView v)
			{
				Scene.EntityOptions1.Location = PointToScene(v.Center);
				Scene.EntityOptions1.View = v;
				Scene.AttributeOptions1.View = null;
				Scene.RelationOptions1.View = null;
				Scene.BranchOptions1.View = null;
				Scene.UnionOptions1.View = null;
			}
			else if(s is AttributeView a)
			{
				Scene.AttributeOptions1.Location = PointToScene(a.Center);
				Scene.EntityOptions1.View = null;
				Scene.AttributeOptions1.View = a;
				Scene.RelationOptions1.View = null;
				Scene.BranchOptions1.View = null;
				Scene.UnionOptions1.View = null;
			}
			else if(s is RelationView r)
			{
				Scene.RelationOptions1.Location = PointToScene(r.Center);
				Scene.EntityOptions1.View = null;
				Scene.AttributeOptions1.View = null;
				Scene.RelationOptions1.View = r;
				Scene.BranchOptions1.View = null;
				Scene.UnionOptions1.View = null;
			}
			else if(s is BranchView b)
			{
				Scene.BranchOptions1.Location = PointToScene(b.Center);
				Scene.EntityOptions1.View = null;
				Scene.AttributeOptions1.View = null;
				Scene.RelationOptions1.View = null;
				Scene.BranchOptions1.View = b;
				Scene.UnionOptions1.View = null;
			}
			else if(s is UnionView u)
			{
				Scene.UnionOptions1.Location = PointToScene(u.Center);
				Scene.EntityOptions1.View = null;
				Scene.AttributeOptions1.View = null;
				Scene.RelationOptions1.View = null;
				Scene.BranchOptions1.View = null;
				Scene.UnionOptions1.View = u;
			}
			else
			{
				Scene.EntityOptions1.View = null;
				Scene.AttributeOptions1.View = null;
				Scene.RelationOptions1.View = null;
				Scene.BranchOptions1.View = null;
				Scene.UnionOptions1.View = null;
				if (s == View)
					OnClick?.Invoke(e.Location);
			}
		}
	
	
		public void ValidEER(ERDiagram E)
		{
			Entity en = E.Entities.Find(e => !e.Attributes.Any(a => a.Key) && e.Parents.IsNullOrEmpty());
			if (en != null)
				throw new InvalidOperationException($"Entitie {en} Has No Key");
			Attribute at = E.Attributes.Find(a => a.Attributes.Count == 1);
            if (at != null)
				throw new InvalidOperationException($"Attribute {at} of {at.Super} Has Only One Sub");
			Relation re = E.Relations.Find(r => r.Entities.Count < 2);
			if (re != null)
				throw new InvalidOperationException($"Relation {re} Has Less Than 2 Entities");
			Branch br = E.Branches.Find(b => b.Super == null || b.Subs.Count < 2);
			if (br != null)
				throw new InvalidOperationException($"Branche {br.Super} Are Not Complete");
			Union un = E.Unions.Find(u => u.Sub == null || u.Supers.Count < 2);
			if (un != null)
				throw new InvalidOperationException($"Union {un.Sub} Are Not Complete");

		}

        public override void SetPreferences()
        {
            ERPreferencesEdit edit = new ERPreferencesEdit();
            if (edit.ShowDialog() == DialogResult.OK)
            {
                UpdatePreferences(edit.Get());
            }
        }

        private void UpdatePreferences(ERPreferences eRPreferences)
        {
            
        }
    }
}
