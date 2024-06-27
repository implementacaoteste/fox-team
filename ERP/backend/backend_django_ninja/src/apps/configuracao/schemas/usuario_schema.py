# ./src/apps/configuracao/schemas/usuario_schema.py

from ninja import Schema

class UsuarioSchema(Schema):
    nome: str
    nome_usuario: str
    email: str
    url_foto: str
    ativo: bool
	
	
