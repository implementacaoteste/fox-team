# ./src/apps/gestao_de_projeto/data/projeto_data.py

import logging
from django.db.utils import IntegrityError
from ..models.projeto import Projeto

class ProjetoData:
	@staticmethod
	def inserir(dados):
		return Projeto.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Projeto.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Projeto.objects.get(id=id)

	@staticmethod
	def alterar(projeto, dados):
		for attr, valor in dados.items():
			setattr(projeto, attr, valor)
		projeto.save()
		return projeto

	@staticmethod
	def excluir(projeto):
		projeto.delete()
