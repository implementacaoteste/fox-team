# ./src/apps/gestao_de_projeto/schemas/historia_de_usuario_schema.py

from ninja import Schema
from typing import Optional, List
from datetime import date, datetime
from .projeto_schema import ProjetoSchema
from .status_de_historia_de_usuario_schema import StatusDeHistoriaDeUsuarioSchema
from apps.configuracao.schemas.usuario_schema import UsuarioSchema

class HistoriaDeUsuarioSchema(Schema):
	titulo: str
	descricao_detalhada: str
	anexo: List[dict]
	status: StatusDeHistoriaDeUsuarioSchema
	participantes: Optional[List[UsuarioSchema]]
	peso: int
	projeto: ProjetoSchema
	prioridade: int
	data_prevista: Optional[date]
	data_entrega: Optional[date]
	data_cadastro: datetime


