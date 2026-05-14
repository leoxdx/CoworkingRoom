# Sistema de Agendamento de Salas - Coworking

Uma aplicação desktop para gestão de salas e reservas. O foco principal foi garantir que todas as regras de negócio e validações ocorram diretamente no banco de dados.

## 🛠️ Tecnologias
- C# / Windows Forms (.NET)
- PostgreSQL
- Npgsql (Acesso a dados)

## 📌 Regras Implementadas (Banco de Dados)
As seguintes validações foram feitas via **Triggers** e **Constraints** no PostgreSQL:
- **Nomes Únicos**: Impedir salas com nomes repetidos.
- **Sobreposição**: Bloqueio de agendamentos conflitantes para a mesma sala.
- **Datas**: Validação para que a data de término seja maior que a de início.
- **Exclusão Segura**: Bloqueio de remoção de salas que possuem agendamentos futuros.
- **Log de Auditoria**: Registro automático de todas as operações (INSERT, UPDATE, DELETE) na tabela log_operacao.

## 📂 Estrutura do Projeto
O projeto foi organizado separando as responsabilidades para facilitar a manutenção:
- `Models`: Classes de entidade (Sala, Agendamento).
- `Repositories`: Lógica de persistência e comandos SQL isolados.
- `Database`: Pasta contendo o script `script_db.sql` para criação da estrutura.
- `Data`: Configuração do contexto e conexão com o banco.

## 🚀 Como rodar
1. No seu PostgreSQL, execute o conteúdo do arquivo `Database/script_db.sql`.
2. Abra a solução no Visual Studio.
3. Ajuste a string de conexão no arquivo `App.config` com suas credenciais locais (Host, Port, User, Password).
4. Compile e inicie o projeto.