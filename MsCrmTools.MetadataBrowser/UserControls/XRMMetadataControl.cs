﻿using Microsoft.Xrm.Sdk.Metadata;
using MsCrmTools.MetadataBrowser.AppCode;
using MsCrmTools.MetadataBrowser.AppCode.AttributeMd;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace MsCrmTools.MetadataBrowser.UserControls
{
    public partial class XRMMetadataControl : UserControl
    {
        private bool header = true;

        [DefaultValue(null)]
        [Category("Dataverse Metadata")]
        [Description("Set any EntityMetadata or AttributeMetadata.")]
        [Browsable(true)]
        public object SelectedObject
        {
            get => propMeta.SelectedObject;
            set
            {
                panInfo1.Visible = header;
                panInfo2.Visible = header;
                panel2.Visible = header;
                if (value is EntityMetadata ent)
                {
                    lblInfo1Value.Text = ent.LogicalName;
                    panInfo2.Visible = false;
                    propMeta.SelectedObject = new EntityMetadataInfo(ent);
                }
                else if (value is AttributeMetadata att)
                {
                    lblInfo1Value.Text = att.EntityLogicalName;
                    lblInfo2Value.Text = att.LogicalName;
                    propMeta.SelectedObject = new AttributeMetadataInfo(att);
                }
                else
                {
                    lblInfo1Value.Text = "";
                    lblInfo2Value.Text = "";
                    propMeta.SelectedObject = value;
                }
            }
        }

        [Category("Dataverse Metadata")]
        [Description("True to show entity and attribute to the metadata.")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool Header
        {
            get => header;
            set
            {
                header = value;
                SelectedObject = propMeta.SelectedObject;
            }
        }

        [Category("Dataverse Metadata")]
        [Description("True to show a header separator.")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool HeaderSeparator { get => panSeparator1.Visible; set => panSeparator1.Visible = value; }

        [Category("Dataverse Metadata")]
        [Description("True to show a header separator.")]
        [DefaultValue(true)]
        [Browsable(true)]
        public bool MscrmLinkSeparator { get => panSeparator2.Visible; set => panSeparator2.Visible = value; }

        public XRMMetadataControl()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MscrmTools/MsCrmTools.MetadataBrowser/wiki");
        }
    }
}
