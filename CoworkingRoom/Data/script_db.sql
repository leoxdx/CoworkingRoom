-- CRIAÇÃO DAS TABELAS 
CREATE TABLE sala (
    id SERIAL PRIMARY KEY,
    nome TEXT NOT NULL UNIQUE -- Nome único e obrigatório 
);

CREATE TABLE agendamento (
    id SERIAL PRIMARY KEY,
    sala_id INTEGER NOT NULL REFERENCES sala(id), -- Relacionamento obrigatório 
    data_inicio TIMESTAMP NOT NULL,
    data_fim TIMESTAMP NOT NULL,
    CONSTRAINT check_datas CHECK (data_fim > data_inicio) -- Validação de datas 
);

CREATE TABLE log_operacao (
    id SERIAL PRIMARY KEY,
    nome_tabela TEXT NOT NULL, 
    tipo_operacao TEXT NOT NULL, 
    data_hora TIMESTAMP DEFAULT NOW() 
);

-- TRIGGER: LOG DE OPERAÇÕES 
CREATE OR REPLACE FUNCTION fn_log_operacoes()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO log_operacao (nome_tabela, tipo_operacao, data_hora)
    VALUES (TG_TABLE_NAME, TG_OP, NOW());
    RETURN NULL;
END;
$$ LANGUAGE plpgsql;

-- Aplicando Log na tabela Sala
CREATE TRIGGER tg_log_sala
AFTER INSERT OR UPDATE OR DELETE ON sala
FOR EACH ROW EXECUTE FUNCTION fn_log_operacoes();

-- Aplicando Log na tabela Agendamento
CREATE TRIGGER tg_log_agendamento
AFTER INSERT OR UPDATE OR DELETE ON agendamento
FOR EACH ROW EXECUTE FUNCTION fn_log_operacoes();

-- 3. TRIGGER: VALIDAÇÃO DE SOBREPOSIÇÃO (Obrigatório) 
CREATE OR REPLACE FUNCTION fn_check_sobreposicao()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (
        SELECT 1 FROM agendamento 
        WHERE sala_id = NEW.sala_id 
        AND id <> COALESCE(NEW.id, -1) -- Ignora o próprio registro em caso de Update
        AND (NEW.data_inicio, NEW.data_fim) OVERLAPS (data_inicio, data_fim)
    ) THEN
        RAISE EXCEPTION 'Não permitir sobreposição de agendamentos para a mesma sala.';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tg_check_sobreposicao
BEFORE INSERT OR UPDATE ON agendamento
FOR EACH ROW EXECUTE FUNCTION fn_check_sobreposicao();

-- TRIGGER: IMPEDIR EXCLUSÃO DE SALA COM AGENDAMENTO FUTURO 
CREATE OR REPLACE FUNCTION fn_validar_exclusao_sala()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM agendamento WHERE sala_id = OLD.id AND data_fim > NOW()) THEN
        RAISE EXCEPTION 'Não permitir exclusão de uma sala que possua agendamento futuro.';
    END IF;
    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tg_validar_exclusao_sala
BEFORE DELETE ON sala
FOR EACH ROW EXECUTE FUNCTION fn_validar_exclusao_sala();