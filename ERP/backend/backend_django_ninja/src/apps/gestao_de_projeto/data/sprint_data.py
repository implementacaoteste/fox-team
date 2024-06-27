# ./src/apps/gestao_de_projeto/data/sprint_data.py

import logging
from django.db.utils import IntegrityError
from ..models.sprint import Sprint

class SprintData:
	@staticmethod
	def inserir(dados):
		return Sprint.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Sprint.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Sprint.objects.get(id=id)

	@staticmethod
	def alterar(sprint, dados):
		for attr, valor in dados.items():
			setattr(sprint, attr, valor)
		sprint.save()
		return sprint

	@staticmethod
	def excluir(sprint):
		sprint.delete()
