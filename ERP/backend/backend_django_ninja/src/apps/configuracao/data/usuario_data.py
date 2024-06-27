# ./src/apps/configuracao/data/usuario_data.py

import logging
from django.db.utils import IntegrityError
from ..models.usuario import Usuario

class UsuarioData:
	@staticmethod
	def inserir(dados):
		return Usuario.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Usuario.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Usuario.objects.get(id=id)

	@staticmethod
	def alterar(usuario, dados):
		for attr, valor in dados.items():
			setattr(usuario, attr, valor)
		usuario.save()
		return usuario

	@staticmethod
	def excluir(usuario):
		usuario.delete()
