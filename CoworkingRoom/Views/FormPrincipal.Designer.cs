namespace CoworkingRoom
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalvarSala = new Button();
            txtNomeSala = new TextBox();
            dgvSalas = new DataGridView();
            lblNomeSala = new Label();
            lblTituloGrade = new Label();
            cmbSalas = new ComboBox();
            dtpInicio = new DateTimePicker();
            dtpFim = new DateTimePicker();
            btnAgendar = new Button();
            dgvAgendamentos = new DataGridView();
            lblComboSala = new Label();
            lblTituloLista = new Label();
            lblDataInicio = new Label();
            lblDataFim = new Label();
            btnExcluirSala = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).BeginInit();
            SuspendLayout();
            // 
            // btnSalvarSala
            // 
            btnSalvarSala.Location = new Point(31, 380);
            btnSalvarSala.Name = "btnSalvarSala";
            btnSalvarSala.Size = new Size(131, 47);
            btnSalvarSala.TabIndex = 0;
            btnSalvarSala.Text = "Salvar Sala";
            btnSalvarSala.UseVisualStyleBackColor = true;
            btnSalvarSala.Click += btnSalvarSala_Click;
            // 
            // txtNomeSala
            // 
            txtNomeSala.Location = new Point(31, 351);
            txtNomeSala.Name = "txtNomeSala";
            txtNomeSala.Size = new Size(100, 23);
            txtNomeSala.TabIndex = 1;
            // 
            // dgvSalas
            // 
            dgvSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalas.Location = new Point(190, 333);
            dgvSalas.Name = "dgvSalas";
            dgvSalas.Size = new Size(240, 150);
            dgvSalas.TabIndex = 2;
            // 
            // lblNomeSala
            // 
            lblNomeSala.AutoSize = true;
            lblNomeSala.Location = new Point(31, 333);
            lblNomeSala.Name = "lblNomeSala";
            lblNomeSala.Size = new Size(83, 15);
            lblNomeSala.TabIndex = 3;
            lblNomeSala.Text = "Nome da Sala:";
            // 
            // lblTituloGrade
            // 
            lblTituloGrade.AutoSize = true;
            lblTituloGrade.Location = new Point(190, 315);
            lblTituloGrade.Name = "lblTituloGrade";
            lblTituloGrade.Size = new Size(100, 15);
            lblTituloGrade.TabIndex = 4;
            lblTituloGrade.Text = "Salas Cadastradas";
            // 
            // cmbSalas
            // 
            cmbSalas.FormattingEnabled = true;
            cmbSalas.Location = new Point(31, 47);
            cmbSalas.Name = "cmbSalas";
            cmbSalas.Size = new Size(121, 23);
            cmbSalas.TabIndex = 5;
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.Location = new Point(31, 102);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 23);
            dtpInicio.TabIndex = 6;
            // 
            // dtpFim
            // 
            dtpFim.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpFim.Format = DateTimePickerFormat.Custom;
            dtpFim.Location = new Point(31, 150);
            dtpFim.Name = "dtpFim";
            dtpFim.Size = new Size(200, 23);
            dtpFim.TabIndex = 7;
            // 
            // btnAgendar
            // 
            btnAgendar.Location = new Point(31, 193);
            btnAgendar.Name = "btnAgendar";
            btnAgendar.Size = new Size(131, 47);
            btnAgendar.TabIndex = 8;
            btnAgendar.Text = "Confirmar Agendamento";
            btnAgendar.UseVisualStyleBackColor = true;
            btnAgendar.Click += btnAgendar_Click;
            // 
            // dgvAgendamentos
            // 
            dgvAgendamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgendamentos.Location = new Point(269, 107);
            dgvAgendamentos.Name = "dgvAgendamentos";
            dgvAgendamentos.Size = new Size(240, 150);
            dgvAgendamentos.TabIndex = 9;
            // 
            // lblComboSala
            // 
            lblComboSala.AutoSize = true;
            lblComboSala.Location = new Point(31, 29);
            lblComboSala.Name = "lblComboSala";
            lblComboSala.Size = new Size(100, 15);
            lblComboSala.TabIndex = 10;
            lblComboSala.Text = "Selecione da Sala:";
            // 
            // lblTituloLista
            // 
            lblTituloLista.AutoSize = true;
            lblTituloLista.Location = new Point(269, 84);
            lblTituloLista.Name = "lblTituloLista";
            lblTituloLista.Size = new Size(146, 15);
            lblTituloLista.TabIndex = 11;
            lblTituloLista.Text = "Agendamentos realizados:";
            // 
            // lblDataInicio
            // 
            lblDataInicio.AutoSize = true;
            lblDataInicio.Location = new Point(31, 84);
            lblDataInicio.Name = "lblDataInicio";
            lblDataInicio.Size = new Size(98, 15);
            lblDataInicio.TabIndex = 12;
            lblDataInicio.Text = "Início da Reserva:";
            // 
            // lblDataFim
            // 
            lblDataFim.AutoSize = true;
            lblDataFim.Location = new Point(31, 132);
            lblDataFim.Name = "lblDataFim";
            lblDataFim.Size = new Size(113, 15);
            lblDataFim.TabIndex = 13;
            lblDataFim.Text = "Término da Reserva:";
            // 
            // btnExcluirSala
            // 
            btnExcluirSala.Location = new Point(449, 380);
            btnExcluirSala.Name = "btnExcluirSala";
            btnExcluirSala.Size = new Size(131, 47);
            btnExcluirSala.TabIndex = 14;
            btnExcluirSala.Text = "Excluir Sala";
            btnExcluirSala.UseVisualStyleBackColor = true;
            btnExcluirSala.Click += btnExcluirSala_Click;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 509);
            Controls.Add(btnExcluirSala);
            Controls.Add(lblDataFim);
            Controls.Add(lblDataInicio);
            Controls.Add(lblTituloLista);
            Controls.Add(lblComboSala);
            Controls.Add(dgvAgendamentos);
            Controls.Add(btnAgendar);
            Controls.Add(dtpFim);
            Controls.Add(dtpInicio);
            Controls.Add(cmbSalas);
            Controls.Add(lblTituloGrade);
            Controls.Add(lblNomeSala);
            Controls.Add(dgvSalas);
            Controls.Add(txtNomeSala);
            Controls.Add(btnSalvarSala);
            Name = "FormPrincipal";
            Text = "Form1";
            Load += FormPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvarSala;
        private TextBox txtNomeSala;
        private DataGridView dgvSalas;
        private Label lblNomeSala;
        private Label lblTituloGrade;
        private ComboBox cmbSalas;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFim;
        private Button btnAgendar;
        private DataGridView dgvAgendamentos;
        private Label lblComboSala;
        private Label lblTituloLista;
        private Label lblDataInicio;
        private Label lblDataFim;
        private Button btnExcluirSala;
    }
}
