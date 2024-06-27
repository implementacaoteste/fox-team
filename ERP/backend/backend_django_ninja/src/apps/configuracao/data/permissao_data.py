# ./src/apps/configuracao/data/permissao_data.py

import logging
from django.db.utils import IntegrityError
from ..models.permissao import Permissao

class PermissaoData:
	@staticmethod
	def inserir(dados):
		return Permissao.objects.create(**dados)

	@staticmethod
	def buscar_todos():
		return Permissao.objects.all()

	@staticmethod
	def buscar_por_id(id):
		return Permissao.objects.get(id=id)

	@staticmethod
	def alterar(permissao, dados):
		for attr, valor in dados.items():
			setattr(permissao, attr, valor)
		permissao.save()
		return permissao

	@staticmethod
	def excluir(permissao):
		permissao.delete()
