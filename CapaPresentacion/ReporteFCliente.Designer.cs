namespace CapaPresentacion
{
    partial class ReporteFCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteFCliente));
            this.spmostrar_clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReportes = new CapaPresentacion.DataSetReportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spmostrar_clienteTableAdapter = new CapaPresentacion.DataSetReportesTableAdapters.spmostrar_clienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrar_clienteBindingSource
            // 
            this.spmostrar_clienteBindingSource.DataMember = "spmostrar_cliente";
            this.spmostrar_clienteBindingSource.DataSource = this.DataSetReportes;
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
            reportDataSource1.Value = this.spmostrar_clienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReporteCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(776, 469);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // spmostrar_clienteTableAdapter
            // 
            this.spmostrar_clienteTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteFCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 469);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteFCliente";
            this.Text = "ReporteFCliente";
            this.Load += new System.EventHandler(this.ReporteFCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spmostrar_clienteBindingSource;
        private DataSetReportes DataSetReportes;
        private DataSetReportesTableAdapters.spmostrar_clienteTableAdapter spmostrar_clienteTableAdapter;
    }
}