using CoworkingRoom.Data;
using CoworkingRoom.Models;
using Npgsql;
using System;

namespace CoworkingRoom.Repositories
{
    public class AgendamentoRepository
    {
        public void Adicionar(Agendamento agendamento)
        {
            const string sql = @"INSERT INTO agendamento (sala_id, data_inicio, data_fim) 
                                 VALUES (@salaId, @inicio, @fim)";

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("salaId", agendamento.SalaId);
                    cmd.Parameters.AddWithValue("inicio", agendamento.DataHoraInicio);
                    cmd.Parameters.AddWithValue("fim", agendamento.DataHoraFim);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Agendamento> ListarTodos()
        {
            var lista = new List<Agendamento>();
            const string sql = "SELECT id, sala_id, data_inicio, data_fim FROM agendamento ORDER BY data_inicio DESC";

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Agendamento
                            {
                                Id = (int)dr["id"],
                                SalaId = (int)dr["sala_id"],
                                DataHoraInicio = (DateTime)dr["data_inicio"],
                                DataHoraFim = (DateTime)dr["data_fim"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}