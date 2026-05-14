using CoworkingRoom.Repositories;
using CoworkingRoom.Models;
using System;
using System.Windows.Forms;

namespace CoworkingRoom
{
    public partial class FormPrincipal : Form
    {
        private readonly SalaRepository _salaRepository;

        public FormPrincipal()
        {
            InitializeComponent();
            _salaRepository = new SalaRepository();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Carrega a grade de salas que você já validou
            AtualizarGradeSalas();
            CarregarComboSalas();
            AtualizarGradeAgendamentos();
        }

        private void btnSalvarSala_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeSala.Text))
                {
                    MessageBox.Show("O nome da sala é obrigatório.");
                    return;
                }

                var novaSala = new Sala { Nome = txtNomeSala.Text.Trim() };
                _salaRepository.Adicionar(novaSala);

                MessageBox.Show("Sala cadastrada com sucesso!");
                txtNomeSala.Clear();
                AtualizarGradeSalas();
                CarregarComboSalas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizarGradeSalas()
        {
            try
            {
                dgvSalas.DataSource = null;
                dgvSalas.DataSource = _salaRepository.ListarTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista: {ex.Message}");
            }
        }


        private void CarregarComboSalas()
        {
            var salaRepo = new SalaRepository();
            var listaSalas = salaRepo.ListarTodas();

            cmbSalas.DataSource = listaSalas;
            cmbSalas.DisplayMember = "Nome"; // O que aparece para o usuário
            cmbSalas.ValueMember = "Id";     // O valor que salvamos no banco (sala_id)
        }


        private void AtualizarGradeAgendamentos()
        {
            try
            {
                var repo = new AgendamentoRepository();
                dgvAgendamentos.DataSource = null;
                dgvAgendamentos.DataSource = repo.ListarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar agendamentos: {ex.Message}");
            }
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Criamos o objeto com os dados da tela
                var novoAgendamento = new Agendamento
                {
                    SalaId = (int)cmbSalas.SelectedValue,
                    DataHoraInicio = dtpInicio.Value,
                    DataHoraFim = dtpFim.Value
                };

                // 2. Chamamos o repositório para salvar no PostgreSQL
                var repo = new AgendamentoRepository();
                repo.Adicionar(novoAgendamento);

                MessageBox.Show("Reserva realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Atualiza a grade de agendamentos (opcional se você criar o método de listar)
                AtualizarGradeAgendamentos();
            }
            catch (Exception ex)
            {
                // Se a TRIGGER do banco disparar (conflito), cai aqui!
                MessageBox.Show("Erro ao agendar: " + ex.Message, "Conflito ou Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluirSala_Click(object sender, EventArgs e)
        {
            if (dgvSalas.CurrentRow == null) return;

            // Pega o ID da sala selecionada na grade
            int idSala = (int)dgvSalas.CurrentRow.Cells["Id"].Value;
            string nomeSala = dgvSalas.CurrentRow.Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show($"Deseja excluir a sala '{nomeSala}'?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    _salaRepository.Excluir(idSala);
                    MessageBox.Show("Sala excluída com sucesso!");
                    AtualizarGradeSalas();
                    CarregarComboSalas(); // Atualiza o combo de agendamento também
                }
                catch (Exception ex)
                {
                    // Aqui vai cair se a TRIGGER do banco barrar por ter agendamento futuro!
                    MessageBox.Show(ex.Message, "Erro ao Excluir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
    }
}