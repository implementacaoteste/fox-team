# ./src/apps/gestao_de_projeto/schemas/projeto_schema.py

from ninja import Schema
from typing import Optional, List
from apps.configuracao.schemas.usuario_schema import UsuarioSchema

class ProjetoSchema(Schema):
	nome: str
	descricao: str
	participantes: Optional[List[UsuarioSchema]]
	ativo: bool


