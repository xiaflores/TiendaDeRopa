namespace CapaPresentacion
{
    partial class frmReporteTrabajador
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteTrabajador));
            this.spmostrar_trabajadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReportes = new CapaPresentacion.DataSetReportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spmostrar_trabajadorTableAdapter = new CapaPresentacion.DataSetReportesTableAdapters.spmostrar_trabajadorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_trabajadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrar_trabajadorBindingSource
            // 
            this.spmostrar_trabajadorBindingSource.DataMember = "spmostrar_trabajador";
            this.spmostrar_trabajadorBindingSource.DataSource = this.DataSetReportes;
            // 
            // DataSetReportes
            // 
            this.DataSetReportes.DataSetName = "DataSetReportes";
            this.DataSetReportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spmostrar_trabajadorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReporteTrabajadores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1018, 431);
            this.reportViewer1.TabIndex = 0;
            // 
            // spmostrar_trabajadorTableAdapter
            // 
            this.spmostrar_trabajadorTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 431);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporteTrabajador";
            this.Text = "frmReporteTrabajador";
            this.Load += new System.EventHandler(this.frmReporteTrabajador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_trabajadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spmostrar_trabajadorBindingSource;
        private DataSetReportes DataSetReportes;
        private DataSetReportesTableAdapters.spmostrar_trabajadorTableAdapter spmostrar_trabajadorTableAdapter;
    }
}