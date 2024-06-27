# ./src/apps/configuracao/services/permissao_service.py

import logging
from django.db.utils import IntegrityError
from ..data.permissao_data import PermissaoData

class PermissaoService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir permissão com os seguintes dados: {dados}")
		try:
			return PermissaoData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir permissão: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir permissão: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os permissões")
		try:
			return PermissaoData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todas as permissões: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todas as permissões: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar permissão por id")
		try:
			return PermissaoData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar permissão por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar permissão por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar permissão de id: {id}, com os dados: {dados}")
		try:
			permissao = PermissaoData.buscar_por_id(id)
			return PermissaoData.alterar(permissao, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar permissão: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar permissão: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir permissão de id: {id}")
		try:
			permissao = PermissaoData.buscar_por_id(id)
			PermissaoData.excluir(permissao)
			logging.info(f"permissão excluída: {permissao}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir permissão: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir permissão: {str(e)}")
