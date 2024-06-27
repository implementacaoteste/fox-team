# ./src/apps/gestao_de_projeto/data/historia_de_usuario_data.py

import logging
from django.db.utils import IntegrityError
from ..models.historia_de_usuario import HistoriaDeUsuario

class HistoriaDeUsuarioData:
	@staticmethod
	def inserir(dados):
		return HistoriaDeUsuario.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return HistoriaDeUsuario.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return HistoriaDeUsuario.objects.get(id=id)

	@staticmethod
	def alterar(historia_de_usuario, dados):
		for attr, valor in dados.items():
			setattr(historia_de_usuario, attr, valor)
		historia_de_usuario.save()
		return historia_de_usuario

	@staticmethod
	def excluir(historia_de_usuario):
		historia_de_usuario.delete()
