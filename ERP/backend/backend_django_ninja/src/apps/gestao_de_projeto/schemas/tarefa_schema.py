# ./src/apps/gestao_de_projeto/schemas/tarefa_schema.py

from ninja import Schema
from typing import Optional, List
from datetime import date, datetime
from .sprint_schema import SprintSchema
from .projeto_schema import ProjetoSchema
from .status_de_tarefa_schema import StatusDeTarefaSchema
from .historia_de_usuario_schema import HistoriaDeUsuarioSchema
from apps.configuracao.schemas.usuario_schema import UsuarioSchema

class TarefaSchema(Schema):
	titulo: str
	descricao_detalhada: str
	anexo: List[dict]
	status: StatusDeTarefaSchema
	participantes: Optional[List[UsuarioSchema]]
	testadores: Optional[List[UsuarioSchema]]
	peso: int
	projeto: ProjetoSchema
	prioridade: int
	historia_de_usuario: HistoriaDeUsuarioSchema
	sprint: SprintSchema
	data_prevista: Optional[date]
	data_entrega: Optional[date]
	data_cadastro: datetime


