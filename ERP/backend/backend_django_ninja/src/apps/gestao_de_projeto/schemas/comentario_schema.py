# ./src/apps/gestao_de_projeto/schemas/comentario_schema.py

from ninja import Schema
from ..schemas.tarefa_schema import TarefaSchema
from apps.configuracao.schemas.usuario_schema import UsuarioSchema
from ..schemas.historia_de_usuario_schema import HistoriaDeUsuarioSchema

class ComentarioSchema(Schema):
	descricao: str
	usuario: UsuarioSchema
	tarefa: TarefaSchema
	historia_de_usuario: HistoriaDeUsuarioSchema
	automatico: bool

