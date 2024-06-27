# ./src/apps/gestao_de_projeto/data/status_de_historia_de_usuario_data.py

import logging
from django.db.utils import IntegrityError
from ..models.status_de_historia_de_usuario import StatusDeHistoriaDeUsuario

class StatusDeHistoriaDeUsuarioData:
	@staticmethod
	def inserir(dados):
		return StatusDeHistoriaDeUsuario.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return StatusDeHistoriaDeUsuario.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return StatusDeHistoriaDeUsuario.objects.get(id=id)

	@staticmethod
	def alterar(status_de_historia_de_usuario, dados):
		for attr, valor in dados.items():
			setattr(status_de_historia_de_usuario, attr, valor)
		status_de_historia_de_usuario.save()
		return status_de_historia_de_usuario

	@staticmethod
	def excluir(status_de_historia_de_usuario):
		status_de_historia_de_usuario.delete()
