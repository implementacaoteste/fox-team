# ./src/apps/gestao_de_projeto/schemas/status_de_tarefa_schema.py

from ninja import Schema

class StatusDeTarefaSchema(Schema):
	descricao: str

