# ./src/apps/gestao_de_projeto/data/comentario_data.py

import logging
from django.db.utils import IntegrityError
from ..models.comentario import Comentario

class ComentarioData:
	@staticmethod
	def inserir(dados):
		return Comentario.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Comentario.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Comentario.objects.get(id=id)

	@staticmethod
	def alterar(comentario, dados):
		for attr, valor in dados.items():
			setattr(comentario, attr, valor)
		comentario.save()
		return comentario

	@staticmethod
	def excluir(comentario):
		comentario.delete()
