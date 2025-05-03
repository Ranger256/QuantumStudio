
namespace Quantum2
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainButtonPanel = new System.Windows.Forms.Panel();
            this.ValueGroupLabel = new System.Windows.Forms.Label();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.ValueInstructionLabel = new System.Windows.Forms.Label();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.PreviousGroupButton = new System.Windows.Forms.Button();
            this.PreviousInstructionButton = new System.Windows.Forms.Button();
            this.NextGroupButton = new System.Windows.Forms.Button();
            this.NextInstructionButton = new System.Windows.Forms.Button();
            this.PlayCircuitButton = new System.Windows.Forms.Button();
            this.CircuitInitializationPanel = new System.Windows.Forms.Panel();
            this.RkGateButton = new System.Windows.Forms.Button();
            this.ClearCircuitButton = new System.Windows.Forms.Button();
            this.HGateButton = new System.Windows.Forms.Button();
            this.CZButton = new System.Windows.Forms.Button();
            this.CYButton = new System.Windows.Forms.Button();
            this.CNOTButton = new System.Windows.Forms.Button();
            this.U3Button = new System.Windows.Forms.Button();
            this.U2Button = new System.Windows.Forms.Button();
            this.U1Button = new System.Windows.Forms.Button();
            this.SButton = new System.Windows.Forms.Button();
            this.TButton = new System.Windows.Forms.Button();
            this.RzButton = new System.Windows.Forms.Button();
            this.RyButton = new System.Windows.Forms.Button();
            this.RxButton = new System.Windows.Forms.Button();
            this.PaulZButton = new System.Windows.Forms.Button();
            this.PaulYButton = new System.Windows.Forms.Button();
            this.PaulXButton = new System.Windows.Forms.Button();
            this.DeleteLastGateButton = new System.Windows.Forms.Button();
            this.MeasurmentsButton = new System.Windows.Forms.Button();
            this.InitializationQuantumCircuitButton = new System.Windows.Forms.Button();
            this.SaveSchemeButton = new System.Windows.Forms.Button();
            this.LoadSchemeButton = new System.Windows.Forms.Button();
            this.ScrollPanelOfQuantumCircuit = new System.Windows.Forms.Panel();
            this.PanelOfQuantumStates = new System.Windows.Forms.Panel();
            this.StateAmplLabel = new System.Windows.Forms.Label();
            this.LegendStateSystemPanel = new System.Windows.Forms.Panel();
            this.LegendStateSystemGreenLabe = new System.Windows.Forms.Label();
            this.LegendStateSystemBluePanel = new System.Windows.Forms.Panel();
            this.LegendStateSystemGreenLabel = new System.Windows.Forms.Label();
            this.LegendStateSystemGreenPanel = new System.Windows.Forms.Panel();
            this.LegendStateSystemRedLabel = new System.Windows.Forms.Label();
            this.LegendStateSystemRedPanel = new System.Windows.Forms.Panel();
            this.DecotativePanel0 = new System.Windows.Forms.Panel();
            this.DecorativePanel1 = new System.Windows.Forms.Panel();
            this.PanelOfTheMeasuredQubits = new System.Windows.Forms.Panel();
            this.MeasurmentQubitsLabel = new System.Windows.Forms.Label();
            this.ClearMeasurmentQubitsButton = new System.Windows.Forms.Button();
            this.MeasurmentsQubitsScrollPanel = new System.Windows.Forms.Panel();
            this.ImageManipulationButton = new System.Windows.Forms.Button();
            this.QASMButton = new System.Windows.Forms.Button();
            this.barChartAmplitudeStates1 = new Quantum2.View.BarChartAmplitudeStates();
            this.LabelMeasurmentQubits = new System.Windows.Forms.Label();
            this.MainButtonPanel.SuspendLayout();
            this.CircuitInitializationPanel.SuspendLayout();
            this.PanelOfQuantumStates.SuspendLayout();
            this.LegendStateSystemPanel.SuspendLayout();
            this.PanelOfTheMeasuredQubits.SuspendLayout();
            this.MeasurmentsQubitsScrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainButtonPanel
            // 
            this.MainButtonPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainButtonPanel.Controls.Add(this.ValueGroupLabel);
            this.MainButtonPanel.Controls.Add(this.GroupLabel);
            this.MainButtonPanel.Controls.Add(this.ValueInstructionLabel);
            this.MainButtonPanel.Controls.Add(this.InstructionLabel);
            this.MainButtonPanel.Controls.Add(this.PreviousGroupButton);
            this.MainButtonPanel.Controls.Add(this.PreviousInstructionButton);
            this.MainButtonPanel.Controls.Add(this.NextGroupButton);
            this.MainButtonPanel.Controls.Add(this.NextInstructionButton);
            this.MainButtonPanel.Controls.Add(this.PlayCircuitButton);
            this.MainButtonPanel.Location = new System.Drawing.Point(-7, 26);
            this.MainButtonPanel.Name = "MainButtonPanel";
            this.MainButtonPanel.Size = new System.Drawing.Size(120, 613);
            this.MainButtonPanel.TabIndex = 0;
            // 
            // ValueGroupLabel
            // 
            this.ValueGroupLabel.AutoSize = true;
            this.ValueGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueGroupLabel.Location = new System.Drawing.Point(6, 499);
            this.ValueGroupLabel.Name = "ValueGroupLabel";
            this.ValueGroupLabel.Size = new System.Drawing.Size(20, 22);
            this.ValueGroupLabel.TabIndex = 8;
            this.ValueGroupLabel.Text = "0";
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupLabel.Location = new System.Drawing.Point(8, 477);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(74, 22);
            this.GroupLabel.TabIndex = 7;
            this.GroupLabel.Text = "Группа:";
            // 
            // ValueInstructionLabel
            // 
            this.ValueInstructionLabel.AutoSize = true;
            this.ValueInstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ValueInstructionLabel.Location = new System.Drawing.Point(6, 455);
            this.ValueInstructionLabel.Name = "ValueInstructionLabel";
            this.ValueInstructionLabel.Size = new System.Drawing.Size(20, 22);
            this.ValueInstructionLabel.TabIndex = 6;
            this.ValueInstructionLabel.Text = "0";
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InstructionLabel.Location = new System.Drawing.Point(8, 433);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(114, 22);
            this.InstructionLabel.TabIndex = 5;
            this.InstructionLabel.Text = "Инструкция:";
            this.InstructionLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PreviousGroupButton
            // 
            this.PreviousGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousGroupButton.Location = new System.Drawing.Point(19, 350);
            this.PreviousGroupButton.Name = "PreviousGroupButton";
            this.PreviousGroupButton.Size = new System.Drawing.Size(80, 80);
            this.PreviousGroupButton.TabIndex = 4;
            this.PreviousGroupButton.Text = "Предыдущая группа";
            this.PreviousGroupButton.UseVisualStyleBackColor = true;
            this.PreviousGroupButton.Click += new System.EventHandler(this.PreviousGroupButton_Click);
            // 
            // PreviousInstructionButton
            // 
            this.PreviousInstructionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousInstructionButton.Location = new System.Drawing.Point(19, 264);
            this.PreviousInstructionButton.Name = "PreviousInstructionButton";
            this.PreviousInstructionButton.Size = new System.Drawing.Size(80, 80);
            this.PreviousInstructionButton.TabIndex = 3;
            this.PreviousInstructionButton.Text = "Предыдущая инструкция";
            this.PreviousInstructionButton.UseVisualStyleBackColor = true;
            this.PreviousInstructionButton.Click += new System.EventHandler(this.PreviousInstructionButton_Click);
            // 
            // NextGroupButton
            // 
            this.NextGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextGroupButton.Location = new System.Drawing.Point(19, 178);
            this.NextGroupButton.Name = "NextGroupButton";
            this.NextGroupButton.Size = new System.Drawing.Size(80, 80);
            this.NextGroupButton.TabIndex = 2;
            this.NextGroupButton.Text = "Следующая группа";
            this.NextGroupButton.UseVisualStyleBackColor = true;
            this.NextGroupButton.Click += new System.EventHandler(this.NextGroupButton_Click);
            // 
            // NextInstructionButton
            // 
            this.NextInstructionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextInstructionButton.Location = new System.Drawing.Point(19, 92);
            this.NextInstructionButton.Name = "NextInstructionButton";
            this.NextInstructionButton.Size = new System.Drawing.Size(80, 80);
            this.NextInstructionButton.TabIndex = 1;
            this.NextInstructionButton.Text = "Следующая инструкция";
            this.NextInstructionButton.UseVisualStyleBackColor = true;
            this.NextInstructionButton.Click += new System.EventHandler(this.NextInstructionButton_Click);
            // 
            // PlayCircuitButton
            // 
            this.PlayCircuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayCircuitButton.Location = new System.Drawing.Point(19, 6);
            this.PlayCircuitButton.Name = "PlayCircuitButton";
            this.PlayCircuitButton.Size = new System.Drawing.Size(80, 80);
            this.PlayCircuitButton.TabIndex = 0;
            this.PlayCircuitButton.Text = "Выполнить схему";
            this.PlayCircuitButton.UseVisualStyleBackColor = true;
            this.PlayCircuitButton.Click += new System.EventHandler(this.PlayCircuitButton_Click);
            // 
            // CircuitInitializationPanel
            // 
            this.CircuitInitializationPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CircuitInitializationPanel.Controls.Add(this.RkGateButton);
            this.CircuitInitializationPanel.Controls.Add(this.ClearCircuitButton);
            this.CircuitInitializationPanel.Controls.Add(this.HGateButton);
            this.CircuitInitializationPanel.Controls.Add(this.CZButton);
            this.CircuitInitializationPanel.Controls.Add(this.CYButton);
            this.CircuitInitializationPanel.Controls.Add(this.CNOTButton);
            this.CircuitInitializationPanel.Controls.Add(this.U3Button);
            this.CircuitInitializationPanel.Controls.Add(this.U2Button);
            this.CircuitInitializationPanel.Controls.Add(this.U1Button);
            this.CircuitInitializationPanel.Controls.Add(this.SButton);
            this.CircuitInitializationPanel.Controls.Add(this.TButton);
            this.CircuitInitializationPanel.Controls.Add(this.RzButton);
            this.CircuitInitializationPanel.Controls.Add(this.RyButton);
            this.CircuitInitializationPanel.Controls.Add(this.RxButton);
            this.CircuitInitializationPanel.Controls.Add(this.PaulZButton);
            this.CircuitInitializationPanel.Controls.Add(this.PaulYButton);
            this.CircuitInitializationPanel.Controls.Add(this.PaulXButton);
            this.CircuitInitializationPanel.Controls.Add(this.DeleteLastGateButton);
            this.CircuitInitializationPanel.Controls.Add(this.MeasurmentsButton);
            this.CircuitInitializationPanel.Controls.Add(this.InitializationQuantumCircuitButton);
            this.CircuitInitializationPanel.Location = new System.Drawing.Point(108, 26);
            this.CircuitInitializationPanel.Name = "CircuitInitializationPanel";
            this.CircuitInitializationPanel.Size = new System.Drawing.Size(905, 113);
            this.CircuitInitializationPanel.TabIndex = 1;
            // 
            // RkGateButton
            // 
            this.RkGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RkGateButton.Location = new System.Drawing.Point(792, 39);
            this.RkGateButton.Name = "RkGateButton";
            this.RkGateButton.Size = new System.Drawing.Size(75, 30);
            this.RkGateButton.TabIndex = 19;
            this.RkGateButton.Text = "Rk";
            this.RkGateButton.UseVisualStyleBackColor = true;
            this.RkGateButton.Click += new System.EventHandler(this.RkGateButton_Click);
            // 
            // ClearCircuitButton
            // 
            this.ClearCircuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearCircuitButton.Location = new System.Drawing.Point(3, 75);
            this.ClearCircuitButton.Name = "ClearCircuitButton";
            this.ClearCircuitButton.Size = new System.Drawing.Size(215, 30);
            this.ClearCircuitButton.TabIndex = 18;
            this.ClearCircuitButton.Text = "Очистить схему";
            this.ClearCircuitButton.UseVisualStyleBackColor = true;
            this.ClearCircuitButton.Click += new System.EventHandler(this.ClearCircuitButton_Click);
            // 
            // HGateButton
            // 
            this.HGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HGateButton.Location = new System.Drawing.Point(224, 3);
            this.HGateButton.Name = "HGateButton";
            this.HGateButton.Size = new System.Drawing.Size(75, 30);
            this.HGateButton.TabIndex = 17;
            this.HGateButton.Text = "Адамара";
            this.HGateButton.UseVisualStyleBackColor = true;
            this.HGateButton.Click += new System.EventHandler(this.HGateButton_Click);
            // 
            // CZButton
            // 
            this.CZButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CZButton.Location = new System.Drawing.Point(711, 39);
            this.CZButton.Name = "CZButton";
            this.CZButton.Size = new System.Drawing.Size(75, 30);
            this.CZButton.TabIndex = 16;
            this.CZButton.Text = "CZ";
            this.CZButton.UseVisualStyleBackColor = true;
            this.CZButton.Click += new System.EventHandler(this.CZButton_Click);
            // 
            // CYButton
            // 
            this.CYButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CYButton.Location = new System.Drawing.Point(630, 39);
            this.CYButton.Name = "CYButton";
            this.CYButton.Size = new System.Drawing.Size(75, 30);
            this.CYButton.TabIndex = 15;
            this.CYButton.Text = "CY";
            this.CYButton.UseVisualStyleBackColor = true;
            this.CYButton.Click += new System.EventHandler(this.CYButton_Click);
            // 
            // CNOTButton
            // 
            this.CNOTButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CNOTButton.Location = new System.Drawing.Point(549, 39);
            this.CNOTButton.Name = "CNOTButton";
            this.CNOTButton.Size = new System.Drawing.Size(75, 30);
            this.CNOTButton.TabIndex = 14;
            this.CNOTButton.Text = "CNOT";
            this.CNOTButton.UseVisualStyleBackColor = true;
            this.CNOTButton.Click += new System.EventHandler(this.CNOTButton_Click);
            // 
            // U3Button
            // 
            this.U3Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.U3Button.Location = new System.Drawing.Point(468, 39);
            this.U3Button.Name = "U3Button";
            this.U3Button.Size = new System.Drawing.Size(75, 30);
            this.U3Button.TabIndex = 13;
            this.U3Button.Text = "U3";
            this.U3Button.UseVisualStyleBackColor = true;
            this.U3Button.Click += new System.EventHandler(this.U3Button_Click);
            // 
            // U2Button
            // 
            this.U2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.U2Button.Location = new System.Drawing.Point(387, 39);
            this.U2Button.Name = "U2Button";
            this.U2Button.Size = new System.Drawing.Size(75, 30);
            this.U2Button.TabIndex = 12;
            this.U2Button.Text = "U2";
            this.U2Button.UseVisualStyleBackColor = true;
            this.U2Button.Click += new System.EventHandler(this.U2Button_Click);
            // 
            // U1Button
            // 
            this.U1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.U1Button.Location = new System.Drawing.Point(305, 39);
            this.U1Button.Name = "U1Button";
            this.U1Button.Size = new System.Drawing.Size(75, 30);
            this.U1Button.TabIndex = 11;
            this.U1Button.Text = "U1";
            this.U1Button.UseVisualStyleBackColor = true;
            this.U1Button.Click += new System.EventHandler(this.U1Button_Click);
            // 
            // SButton
            // 
            this.SButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SButton.Location = new System.Drawing.Point(549, 3);
            this.SButton.Name = "SButton";
            this.SButton.Size = new System.Drawing.Size(75, 30);
            this.SButton.TabIndex = 10;
            this.SButton.Text = "S";
            this.SButton.UseVisualStyleBackColor = true;
            this.SButton.Click += new System.EventHandler(this.SButton_Click);
            // 
            // TButton
            // 
            this.TButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TButton.Location = new System.Drawing.Point(630, 3);
            this.TButton.Name = "TButton";
            this.TButton.Size = new System.Drawing.Size(75, 30);
            this.TButton.TabIndex = 9;
            this.TButton.Text = "T";
            this.TButton.UseVisualStyleBackColor = true;
            this.TButton.Click += new System.EventHandler(this.TButton_Click);
            // 
            // RzButton
            // 
            this.RzButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RzButton.Location = new System.Drawing.Point(224, 39);
            this.RzButton.Name = "RzButton";
            this.RzButton.Size = new System.Drawing.Size(75, 30);
            this.RzButton.TabIndex = 8;
            this.RzButton.Text = "Rz";
            this.RzButton.UseVisualStyleBackColor = true;
            this.RzButton.Click += new System.EventHandler(this.RzButton_Click);
            // 
            // RyButton
            // 
            this.RyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RyButton.Location = new System.Drawing.Point(792, 3);
            this.RyButton.Name = "RyButton";
            this.RyButton.Size = new System.Drawing.Size(75, 30);
            this.RyButton.TabIndex = 7;
            this.RyButton.Text = "Ry";
            this.RyButton.UseVisualStyleBackColor = true;
            this.RyButton.Click += new System.EventHandler(this.RyButton_Click);
            // 
            // RxButton
            // 
            this.RxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RxButton.Location = new System.Drawing.Point(711, 3);
            this.RxButton.Name = "RxButton";
            this.RxButton.Size = new System.Drawing.Size(75, 30);
            this.RxButton.TabIndex = 6;
            this.RxButton.Text = "Rx";
            this.RxButton.UseVisualStyleBackColor = true;
            this.RxButton.Click += new System.EventHandler(this.RxButton_Click);
            // 
            // PaulZButton
            // 
            this.PaulZButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaulZButton.Location = new System.Drawing.Point(468, 3);
            this.PaulZButton.Name = "PaulZButton";
            this.PaulZButton.Size = new System.Drawing.Size(75, 30);
            this.PaulZButton.TabIndex = 5;
            this.PaulZButton.Text = "Паули-Z";
            this.PaulZButton.UseVisualStyleBackColor = true;
            this.PaulZButton.Click += new System.EventHandler(this.PaulZButton_Click);
            // 
            // PaulYButton
            // 
            this.PaulYButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaulYButton.Location = new System.Drawing.Point(387, 3);
            this.PaulYButton.Name = "PaulYButton";
            this.PaulYButton.Size = new System.Drawing.Size(75, 30);
            this.PaulYButton.TabIndex = 4;
            this.PaulYButton.Text = "Паули-Y";
            this.PaulYButton.UseVisualStyleBackColor = true;
            this.PaulYButton.Click += new System.EventHandler(this.PaulYButton_Click);
            // 
            // PaulXButton
            // 
            this.PaulXButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PaulXButton.Location = new System.Drawing.Point(305, 3);
            this.PaulXButton.Name = "PaulXButton";
            this.PaulXButton.Size = new System.Drawing.Size(75, 30);
            this.PaulXButton.TabIndex = 3;
            this.PaulXButton.Text = "Паули-X";
            this.PaulXButton.UseVisualStyleBackColor = true;
            this.PaulXButton.Click += new System.EventHandler(this.PaulXButton_Click);
            // 
            // DeleteLastGateButton
            // 
            this.DeleteLastGateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteLastGateButton.Location = new System.Drawing.Point(224, 75);
            this.DeleteLastGateButton.Name = "DeleteLastGateButton";
            this.DeleteLastGateButton.Size = new System.Drawing.Size(215, 30);
            this.DeleteLastGateButton.TabIndex = 2;
            this.DeleteLastGateButton.Text = "Удалить последний гейт";
            this.DeleteLastGateButton.UseVisualStyleBackColor = true;
            this.DeleteLastGateButton.Click += new System.EventHandler(this.DeleteLastGateButton_Click);
            // 
            // MeasurmentsButton
            // 
            this.MeasurmentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MeasurmentsButton.Location = new System.Drawing.Point(3, 39);
            this.MeasurmentsButton.Name = "MeasurmentsButton";
            this.MeasurmentsButton.Size = new System.Drawing.Size(215, 30);
            this.MeasurmentsButton.TabIndex = 1;
            this.MeasurmentsButton.Text = "Измерения";
            this.MeasurmentsButton.UseVisualStyleBackColor = true;
            this.MeasurmentsButton.Click += new System.EventHandler(this.MeasurmentsButton_Click);
            // 
            // InitializationQuantumCircuitButton
            // 
            this.InitializationQuantumCircuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InitializationQuantumCircuitButton.Location = new System.Drawing.Point(3, 3);
            this.InitializationQuantumCircuitButton.Name = "InitializationQuantumCircuitButton";
            this.InitializationQuantumCircuitButton.Size = new System.Drawing.Size(215, 30);
            this.InitializationQuantumCircuitButton.TabIndex = 0;
            this.InitializationQuantumCircuitButton.Text = "Инициализация квантовой схемы";
            this.InitializationQuantumCircuitButton.UseVisualStyleBackColor = true;
            this.InitializationQuantumCircuitButton.Click += new System.EventHandler(this.InitializationQuantumCircuitButton_Click);
            // 
            // SaveSchemeButton
            // 
            this.SaveSchemeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveSchemeButton.Location = new System.Drawing.Point(5, 1);
            this.SaveSchemeButton.Name = "SaveSchemeButton";
            this.SaveSchemeButton.Size = new System.Drawing.Size(217, 25);
            this.SaveSchemeButton.TabIndex = 2;
            this.SaveSchemeButton.Text = "Сохранить схему";
            this.SaveSchemeButton.UseVisualStyleBackColor = true;
            this.SaveSchemeButton.Click += new System.EventHandler(this.SaveSchemeButton_Click);
            // 
            // LoadSchemeButton
            // 
            this.LoadSchemeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadSchemeButton.Location = new System.Drawing.Point(228, 1);
            this.LoadSchemeButton.Name = "LoadSchemeButton";
            this.LoadSchemeButton.Size = new System.Drawing.Size(217, 25);
            this.LoadSchemeButton.TabIndex = 3;
            this.LoadSchemeButton.Text = "Загрузить схему";
            this.LoadSchemeButton.UseVisualStyleBackColor = true;
            this.LoadSchemeButton.Click += new System.EventHandler(this.LoadSchemeButton_Click);
            // 
            // ScrollPanelOfQuantumCircuit
            // 
            this.ScrollPanelOfQuantumCircuit.AutoScroll = true;
            this.ScrollPanelOfQuantumCircuit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ScrollPanelOfQuantumCircuit.Location = new System.Drawing.Point(111, 137);
            this.ScrollPanelOfQuantumCircuit.Name = "ScrollPanelOfQuantumCircuit";
            this.ScrollPanelOfQuantumCircuit.Size = new System.Drawing.Size(896, 210);
            this.ScrollPanelOfQuantumCircuit.TabIndex = 5;
            // 
            // PanelOfQuantumStates
            // 
            this.PanelOfQuantumStates.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PanelOfQuantumStates.Controls.Add(this.StateAmplLabel);
            this.PanelOfQuantumStates.Controls.Add(this.LegendStateSystemPanel);
            this.PanelOfQuantumStates.Controls.Add(this.barChartAmplitudeStates1);
            this.PanelOfQuantumStates.Location = new System.Drawing.Point(111, 353);
            this.PanelOfQuantumStates.Name = "PanelOfQuantumStates";
            this.PanelOfQuantumStates.Size = new System.Drawing.Size(665, 289);
            this.PanelOfQuantumStates.TabIndex = 6;
            // 
            // StateAmplLabel
            // 
            this.StateAmplLabel.AutoSize = true;
            this.StateAmplLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StateAmplLabel.Location = new System.Drawing.Point(13, 5);
            this.StateAmplLabel.Name = "StateAmplLabel";
            this.StateAmplLabel.Size = new System.Drawing.Size(100, 22);
            this.StateAmplLabel.TabIndex = 3;
            this.StateAmplLabel.Text = "Состояния";
            // 
            // LegendStateSystemPanel
            // 
            this.LegendStateSystemPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemGreenLabe);
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemBluePanel);
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemGreenLabel);
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemGreenPanel);
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemRedLabel);
            this.LegendStateSystemPanel.Controls.Add(this.LegendStateSystemRedPanel);
            this.LegendStateSystemPanel.Location = new System.Drawing.Point(8, 30);
            this.LegendStateSystemPanel.Name = "LegendStateSystemPanel";
            this.LegendStateSystemPanel.Size = new System.Drawing.Size(170, 247);
            this.LegendStateSystemPanel.TabIndex = 2;
            // 
            // LegendStateSystemGreenLabe
            // 
            this.LegendStateSystemGreenLabe.AutoSize = true;
            this.LegendStateSystemGreenLabe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LegendStateSystemGreenLabe.Location = new System.Drawing.Point(46, 56);
            this.LegendStateSystemGreenLabe.Name = "LegendStateSystemGreenLabe";
            this.LegendStateSystemGreenLabe.Size = new System.Drawing.Size(101, 17);
            this.LegendStateSystemGreenLabe.TabIndex = 5;
            this.LegendStateSystemGreenLabe.Text = "Мнимая часть";
            this.LegendStateSystemGreenLabe.Click += new System.EventHandler(this.LegendStateSystemGreenLabe_Click);
            // 
            // LegendStateSystemBluePanel
            // 
            this.LegendStateSystemBluePanel.BackColor = System.Drawing.Color.Blue;
            this.LegendStateSystemBluePanel.Location = new System.Drawing.Point(10, 56);
            this.LegendStateSystemBluePanel.Name = "LegendStateSystemBluePanel";
            this.LegendStateSystemBluePanel.Size = new System.Drawing.Size(30, 30);
            this.LegendStateSystemBluePanel.TabIndex = 4;
            // 
            // LegendStateSystemGreenLabel
            // 
            this.LegendStateSystemGreenLabel.AutoSize = true;
            this.LegendStateSystemGreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LegendStateSystemGreenLabel.Location = new System.Drawing.Point(46, 98);
            this.LegendStateSystemGreenLabel.Name = "LegendStateSystemGreenLabel";
            this.LegendStateSystemGreenLabel.Size = new System.Drawing.Size(44, 17);
            this.LegendStateSystemGreenLabel.TabIndex = 3;
            this.LegendStateSystemGreenLabel.Text = "Фаза";
            // 
            // LegendStateSystemGreenPanel
            // 
            this.LegendStateSystemGreenPanel.BackColor = System.Drawing.Color.Green;
            this.LegendStateSystemGreenPanel.Location = new System.Drawing.Point(10, 98);
            this.LegendStateSystemGreenPanel.Name = "LegendStateSystemGreenPanel";
            this.LegendStateSystemGreenPanel.Size = new System.Drawing.Size(30, 30);
            this.LegendStateSystemGreenPanel.TabIndex = 2;
            // 
            // LegendStateSystemRedLabel
            // 
            this.LegendStateSystemRedLabel.AutoSize = true;
            this.LegendStateSystemRedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LegendStateSystemRedLabel.Location = new System.Drawing.Point(46, 10);
            this.LegendStateSystemRedLabel.Name = "LegendStateSystemRedLabel";
            this.LegendStateSystemRedLabel.Size = new System.Drawing.Size(122, 34);
            this.LegendStateSystemRedLabel.TabIndex = 1;
            this.LegendStateSystemRedLabel.Text = "Действительная \r\nчасть";
            // 
            // LegendStateSystemRedPanel
            // 
            this.LegendStateSystemRedPanel.BackColor = System.Drawing.Color.Red;
            this.LegendStateSystemRedPanel.Location = new System.Drawing.Point(10, 14);
            this.LegendStateSystemRedPanel.Name = "LegendStateSystemRedPanel";
            this.LegendStateSystemRedPanel.Size = new System.Drawing.Size(30, 30);
            this.LegendStateSystemRedPanel.TabIndex = 0;
            // 
            // DecotativePanel0
            // 
            this.DecotativePanel0.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DecotativePanel0.Location = new System.Drawing.Point(111, 345);
            this.DecotativePanel0.Name = "DecotativePanel0";
            this.DecotativePanel0.Size = new System.Drawing.Size(899, 10);
            this.DecotativePanel0.TabIndex = 7;
            // 
            // DecorativePanel1
            // 
            this.DecorativePanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DecorativePanel1.Location = new System.Drawing.Point(771, 353);
            this.DecorativePanel1.Name = "DecorativePanel1";
            this.DecorativePanel1.Size = new System.Drawing.Size(10, 277);
            this.DecorativePanel1.TabIndex = 8;
            // 
            // PanelOfTheMeasuredQubits
            // 
            this.PanelOfTheMeasuredQubits.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PanelOfTheMeasuredQubits.Controls.Add(this.MeasurmentQubitsLabel);
            this.PanelOfTheMeasuredQubits.Controls.Add(this.ClearMeasurmentQubitsButton);
            this.PanelOfTheMeasuredQubits.Controls.Add(this.MeasurmentsQubitsScrollPanel);
            this.PanelOfTheMeasuredQubits.Location = new System.Drawing.Point(780, 353);
            this.PanelOfTheMeasuredQubits.Name = "PanelOfTheMeasuredQubits";
            this.PanelOfTheMeasuredQubits.Size = new System.Drawing.Size(230, 286);
            this.PanelOfTheMeasuredQubits.TabIndex = 9;
            // 
            // MeasurmentQubitsLabel
            // 
            this.MeasurmentQubitsLabel.AutoSize = true;
            this.MeasurmentQubitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MeasurmentQubitsLabel.Location = new System.Drawing.Point(19, 5);
            this.MeasurmentQubitsLabel.Name = "MeasurmentQubitsLabel";
            this.MeasurmentQubitsLabel.Size = new System.Drawing.Size(176, 22);
            this.MeasurmentQubitsLabel.TabIndex = 2;
            this.MeasurmentQubitsLabel.Text = "Измерения кубитов";
            // 
            // ClearMeasurmentQubitsButton
            // 
            this.ClearMeasurmentQubitsButton.Location = new System.Drawing.Point(7, 251);
            this.ClearMeasurmentQubitsButton.Name = "ClearMeasurmentQubitsButton";
            this.ClearMeasurmentQubitsButton.Size = new System.Drawing.Size(205, 26);
            this.ClearMeasurmentQubitsButton.TabIndex = 1;
            this.ClearMeasurmentQubitsButton.Text = "Очистить измерения кубитов";
            this.ClearMeasurmentQubitsButton.UseVisualStyleBackColor = true;
            this.ClearMeasurmentQubitsButton.Click += new System.EventHandler(this.ClearMeasurmentQubitsButton_Click);
            // 
            // MeasurmentsQubitsScrollPanel
            // 
            this.MeasurmentsQubitsScrollPanel.AutoScroll = true;
            this.MeasurmentsQubitsScrollPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.MeasurmentsQubitsScrollPanel.Controls.Add(this.LabelMeasurmentQubits);
            this.MeasurmentsQubitsScrollPanel.Location = new System.Drawing.Point(7, 30);
            this.MeasurmentsQubitsScrollPanel.Name = "MeasurmentsQubitsScrollPanel";
            this.MeasurmentsQubitsScrollPanel.Size = new System.Drawing.Size(205, 215);
            this.MeasurmentsQubitsScrollPanel.TabIndex = 0;
            // 
            // ImageManipulationButton
            // 
            this.ImageManipulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImageManipulationButton.Location = new System.Drawing.Point(451, 1);
            this.ImageManipulationButton.Name = "ImageManipulationButton";
            this.ImageManipulationButton.Size = new System.Drawing.Size(217, 25);
            this.ImageManipulationButton.TabIndex = 10;
            this.ImageManipulationButton.Text = "Работа с изображениями";
            this.ImageManipulationButton.UseVisualStyleBackColor = true;
            this.ImageManipulationButton.Click += new System.EventHandler(this.ImageManipulationButton_Click);
            // 
            // QASMButton
            // 
            this.QASMButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QASMButton.Location = new System.Drawing.Point(674, 1);
            this.QASMButton.Name = "QASMButton";
            this.QASMButton.Size = new System.Drawing.Size(217, 25);
            this.QASMButton.TabIndex = 11;
            this.QASMButton.Text = "QASM";
            this.QASMButton.UseVisualStyleBackColor = true;
            this.QASMButton.Click += new System.EventHandler(this.QASMButton_Click);
            // 
            // barChartAmplitudeStates1
            // 
            this.barChartAmplitudeStates1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.barChartAmplitudeStates1.Location = new System.Drawing.Point(184, 3);
            this.barChartAmplitudeStates1.Name = "barChartAmplitudeStates1";
            this.barChartAmplitudeStates1.Size = new System.Drawing.Size(470, 274);
            this.barChartAmplitudeStates1.TabIndex = 1;
            this.barChartAmplitudeStates1.Load += new System.EventHandler(this.barChartAmplitudeStates1_Load_1);
            // 
            // LabelMeasurmentQubits
            // 
            this.LabelMeasurmentQubits.AutoSize = true;
            this.LabelMeasurmentQubits.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMeasurmentQubits.Location = new System.Drawing.Point(3, 8);
            this.LabelMeasurmentQubits.Name = "LabelMeasurmentQubits";
            this.LabelMeasurmentQubits.Size = new System.Drawing.Size(46, 18);
            this.LabelMeasurmentQubits.TabIndex = 0;
            this.LabelMeasurmentQubits.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 642);
            this.Controls.Add(this.QASMButton);
            this.Controls.Add(this.ImageManipulationButton);
            this.Controls.Add(this.PanelOfTheMeasuredQubits);
            this.Controls.Add(this.DecorativePanel1);
            this.Controls.Add(this.DecotativePanel0);
            this.Controls.Add(this.PanelOfQuantumStates);
            this.Controls.Add(this.ScrollPanelOfQuantumCircuit);
            this.Controls.Add(this.LoadSchemeButton);
            this.Controls.Add(this.SaveSchemeButton);
            this.Controls.Add(this.CircuitInitializationPanel);
            this.Controls.Add(this.MainButtonPanel);
            this.Name = "MainForm";
            this.Text = "QuantumStudio";
            this.MainButtonPanel.ResumeLayout(false);
            this.MainButtonPanel.PerformLayout();
            this.CircuitInitializationPanel.ResumeLayout(false);
            this.PanelOfQuantumStates.ResumeLayout(false);
            this.PanelOfQuantumStates.PerformLayout();
            this.LegendStateSystemPanel.ResumeLayout(false);
            this.LegendStateSystemPanel.PerformLayout();
            this.PanelOfTheMeasuredQubits.ResumeLayout(false);
            this.PanelOfTheMeasuredQubits.PerformLayout();
            this.MeasurmentsQubitsScrollPanel.ResumeLayout(false);
            this.MeasurmentsQubitsScrollPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainButtonPanel;
        private System.Windows.Forms.Panel CircuitInitializationPanel;
        private System.Windows.Forms.Button SaveSchemeButton;
        private System.Windows.Forms.Button LoadSchemeButton;
        private System.Windows.Forms.Button NextGroupButton;
        private System.Windows.Forms.Button NextInstructionButton;
        private System.Windows.Forms.Button PlayCircuitButton;
        private System.Windows.Forms.Button PreviousGroupButton;
        private System.Windows.Forms.Button PreviousInstructionButton;
        private System.Windows.Forms.Button MeasurmentsButton;
        private System.Windows.Forms.Button InitializationQuantumCircuitButton;
        private System.Windows.Forms.Button DeleteLastGateButton;
        private System.Windows.Forms.Button U3Button;
        private System.Windows.Forms.Button U2Button;
        private System.Windows.Forms.Button U1Button;
        private System.Windows.Forms.Button SButton;
        private System.Windows.Forms.Button TButton;
        private System.Windows.Forms.Button RzButton;
        private System.Windows.Forms.Button RyButton;
        private System.Windows.Forms.Button RxButton;
        private System.Windows.Forms.Button PaulZButton;
        private System.Windows.Forms.Button PaulYButton;
        private System.Windows.Forms.Button PaulXButton;
        private System.Windows.Forms.Button CZButton;
        private System.Windows.Forms.Button CYButton;
        private System.Windows.Forms.Button CNOTButton;
        private System.Windows.Forms.Panel ScrollPanelOfQuantumCircuit;
        private System.Windows.Forms.Panel PanelOfQuantumStates;
        private System.Windows.Forms.Panel DecotativePanel0;
        private System.Windows.Forms.Panel DecorativePanel1;
        private System.Windows.Forms.Panel PanelOfTheMeasuredQubits;
        private View.BarChartAmplitudeStates barChartAmplitudeStates1;
        private System.Windows.Forms.Panel LegendStateSystemPanel;
        private System.Windows.Forms.Label LegendStateSystemGreenLabel;
        private System.Windows.Forms.Panel LegendStateSystemGreenPanel;
        private System.Windows.Forms.Label LegendStateSystemRedLabel;
        private System.Windows.Forms.Panel LegendStateSystemRedPanel;
        private System.Windows.Forms.Panel MeasurmentsQubitsScrollPanel;
        private System.Windows.Forms.Button ClearMeasurmentQubitsButton;
        private System.Windows.Forms.Label MeasurmentQubitsLabel;
        private System.Windows.Forms.Button HGateButton;
        private System.Windows.Forms.Label StateAmplLabel;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Label ValueGroupLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Label ValueInstructionLabel;
        private System.Windows.Forms.Button ClearCircuitButton;
        private System.Windows.Forms.Label LegendStateSystemGreenLabe;
        private System.Windows.Forms.Panel LegendStateSystemBluePanel;
        private System.Windows.Forms.Button RkGateButton;
        private System.Windows.Forms.Button ImageManipulationButton;
        private System.Windows.Forms.Button QASMButton;
        private System.Windows.Forms.Label LabelMeasurmentQubits;
        //private View.BarChartAmplitudeStates barChartAmplitudeStates1;
    }
}

