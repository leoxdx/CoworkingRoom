using Npgsql;
using CoworkingRoom.Models;
using CoworkingRoom.Data;
using System;
using System.Collections.Generic;

namespace CoworkingRoom.Repositories
{
    public class SalaRepository
    {
        public void Adicionar(Sala sala)
        {
            const string sql = "INSERT INTO sala (nome) VALUES (@nome)";

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    // Parameterized query para evitar SQL Injection
                    cmd.Parameters.AddWithValue("nome", sala.Nome);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex) when (ex.SqlState == "23505") // Unique Violation
                    {
                        throw new Exception("Já existe uma sala com este nome.");
                    }
                }
            }
        }

        public List<Sala> ListarTodas()
        {
            var salas = new List<Sala>();
            const string sql = "SELECT id, nome FROM sala ORDER BY nome";

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salas.Add(new Sala
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        });
                    }
                }
            }
            return salas;
        }

        public void Excluir(int id)
        {
            const string sql = "DELETE FROM sala WHERE id = @id";

            using (var conn = DbContext.GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}