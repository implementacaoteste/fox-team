# ./src/apps/gestao_de_projeto/schemas/status_de_historia_de_usuario_schema.py

from ninja import Schema

class StatusDeHistoriaDeUsuarioSchema(Schema):
	descricao: str

