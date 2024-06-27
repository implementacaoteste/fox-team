# ./src/apps/configuracao/schemas/permissao_schema.py

from ninja import Schema

class PermissaoSchema(Schema):
	descricao: str

