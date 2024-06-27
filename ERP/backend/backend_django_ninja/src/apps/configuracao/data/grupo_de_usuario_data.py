# ./src/apps/configuracao/data/grupo_de_usuario_data.py

import logging
from django.db.utils import IntegrityError
from ..models.grupo_de_usuario import GrupoDeUsuario

class GrupoDeUsuarioData:
	@staticmethod
	def inserir(dados):
		return GrupoDeUsuario.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return GrupoDeUsuario.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return GrupoDeUsuario.objects.get(id=id)

	@staticmethod
	def alterar(grupo_de_usuario, dados):
		for attr, valor in dados.items():
			setattr(grupo_de_usuario, attr, valor)
		grupo_de_usuario.save()
		return grupo_de_usuario

	@staticmethod
	def excluir(grupo_de_usuario):
		grupo_de_usuario.delete()
