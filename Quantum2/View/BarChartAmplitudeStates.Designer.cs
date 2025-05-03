
namespace Quantum2.View
{
    partial class BarChartAmplitudeStates
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._hScrollBar = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // _hScrollBar
            // 
            this._hScrollBar.Location = new System.Drawing.Point(0, 260);
            this._hScrollBar.Name = "_hScrollBar";
            this._hScrollBar.Size = new System.Drawing.Size(470, 17);
            this._hScrollBar.TabIndex = 0;
            this._hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this._hScrollBar_Scroll);
            // 
            // BarChartAmplitudeStates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this._hScrollBar);
            this.Name = "BarChartAmplitudeStates";
            this.Size = new System.Drawing.Size(470, 250);
            this.Load += new System.EventHandler(this.BarChartAmplitudeStates_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar _hScrollBar;
    }
}
