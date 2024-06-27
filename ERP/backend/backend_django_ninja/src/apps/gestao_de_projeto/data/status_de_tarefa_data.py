# ./src/apps/gestao_de_projeto/data/status_de_tarefa_data.py

import logging
from django.db.utils import IntegrityError
from ..models.status_de_tarefa import StatusDeTarefa

class StatusDeTarefaData:
	@staticmethod
	def inserir(dados):
		return StatusDeTarefa.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return StatusDeTarefa.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return StatusDeTarefa.objects.get(id=id)

	@staticmethod
	def alterar(status_de_tarefa, dados):
		for attr, valor in dados.items():
			setattr(status_de_tarefa, attr, valor)
		status_de_tarefa.save()
		return status_de_tarefa

	@staticmethod
	def excluir(status_de_tarefa):
		status_de_tarefa.delete()
