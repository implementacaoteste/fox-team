# ./src/apps/gestao_de_projeto/data/tarefa_data.py

import logging
from django.db.utils import IntegrityError
from ..models.tarefa import Tarefa

class TarefaData:
	@staticmethod
	def inserir(dados):
		return Tarefa.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Tarefa.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Tarefa.objects.get(id=id)

	@staticmethod
	def alterar(tarefa, dados):
		for attr, valor in dados.items():
			setattr(tarefa, attr, valor)
		tarefa.save()
		return tarefa

	@staticmethod
	def excluir(tarefa):
		tarefa.delete()
