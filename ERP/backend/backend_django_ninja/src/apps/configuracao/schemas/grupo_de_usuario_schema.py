# ./src/apps/configuracao/schemas/grupo_de_usuario_schema.py

from ninja import Schema

class GrupoDeUsuarioSchema(Schema):
	descricao: str
	ativo: bool
	
	
