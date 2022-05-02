namespace CapaPresentacion
{
    partial class ReporteFVentas
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
            this.spmostrar_ventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReportes = new CapaPresentacion.DataSetReportes();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spmostrar_ventaTableAdapter = new CapaPresentacion.DataSetReportesTableAdapters.spmostrar_ventaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_ventaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrar_ventaBindingSource
            // 
            this.spmostrar_ventaBindingSource.DataMember = "spmostrar_venta";
            this.spmostrar_ventaBindingSource.DataSource = this.DataSetReportes;
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
            reportDataSource1.Value = this.spmostrar_ventaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReporteVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(750, 387);
            this.reportViewer1.TabIndex = 0;
            // 
            // spmostrar_ventaTableAdapter
            // 
            this.spmostrar_ventaTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteFVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 387);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteFVentas";
            this.Text = "ReporteFVentas";
            this.Load += new System.EventHandler(this.ReporteFVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_ventaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spmostrar_ventaBindingSource;
        private DataSetReportes DataSetReportes;
        private DataSetReportesTableAdapters.spmostrar_ventaTableAdapter spmostrar_ventaTableAdapter;
    }
}