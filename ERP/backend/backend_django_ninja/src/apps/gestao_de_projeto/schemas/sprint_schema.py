# ./src/apps/gestao_de_projeto/schemas/sprint_schema.py

from ninja import Schema
from typing import Optional
from datetime import date, datetime
from .projeto_schema import ProjetoSchema

class SprintSchema(Schema):
	titulo: str
	entregue: bool
	projeto: ProjetoSchema
	ativo: bool
	data_prevista: Optional[date]
	data_entrega: Optional[date]
	data_cadastro: datetime


