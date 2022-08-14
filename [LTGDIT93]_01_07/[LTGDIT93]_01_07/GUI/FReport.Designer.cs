
namespace _LTGDIT93__01_07
{
    partial class FReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.GetThongTinPhieuThueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLNhaTroDataSet = new _LTGDIT93__01_07.QLNhaTroDataSet();
            this.getThongTinChuNhaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNhaTroDataSet1 = new _LTGDIT93__01_07.QLNhaTroDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetThongTinPhieuThueTableAdapter = new _LTGDIT93__01_07.QLNhaTroDataSetTableAdapters.GetThongTinPhieuThueTableAdapter();
            this.getThongTinChuNhaTableAdapter = new _LTGDIT93__01_07.QLNhaTroDataSet1TableAdapters.GetThongTinChuNhaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GetThongTinPhieuThueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNhaTroDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getThongTinChuNhaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhaTroDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // GetThongTinPhieuThueBindingSource
            // 
            this.GetThongTinPhieuThueBindingSource.DataMember = "GetThongTinPhieuThue";
            this.GetThongTinPhieuThueBindingSource.DataSource = this.QLNhaTroDataSet;
            // 
            // QLNhaTroDataSet
            // 
            this.QLNhaTroDataSet.DataSetName = "QLNhaTroDataSet";
            this.QLNhaTroDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getThongTinChuNhaBindingSource
            // 
            this.getThongTinChuNhaBindingSource.DataMember = "GetThongTinChuNha";
            this.getThongTinChuNhaBindingSource.DataSource = this.qLNhaTroDataSet1;
            // 
            // qLNhaTroDataSet1
            // 
            this.qLNhaTroDataSet1.DataSetName = "QLNhaTroDataSet1";
            this.qLNhaTroDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GetThongTinPhieuThueBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.getThongTinChuNhaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_LTGDIT93__01_07.ReportYeuCau.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(860, 851);
            this.reportViewer1.TabIndex = 0;
            // 
            // GetThongTinPhieuThueTableAdapter
            // 
            this.GetThongTinPhieuThueTableAdapter.ClearBeforeFill = true;
            // 
            // getThongTinChuNhaTableAdapter
            // 
            this.getThongTinChuNhaTableAdapter.ClearBeforeFill = true;
            // 
            // FReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 851);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FReport";
            this.Load += new System.EventHandler(this.FReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetThongTinPhieuThueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNhaTroDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getThongTinChuNhaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhaTroDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource GetThongTinPhieuThueBindingSource;
        private QLNhaTroDataSet QLNhaTroDataSet;
        private QLNhaTroDataSetTableAdapters.GetThongTinPhieuThueTableAdapter GetThongTinPhieuThueTableAdapter;
        private System.Windows.Forms.BindingSource getThongTinChuNhaBindingSource;
        private QLNhaTroDataSet1 qLNhaTroDataSet1;
        private QLNhaTroDataSet1TableAdapters.GetThongTinChuNhaTableAdapter getThongTinChuNhaTableAdapter;
    }
}