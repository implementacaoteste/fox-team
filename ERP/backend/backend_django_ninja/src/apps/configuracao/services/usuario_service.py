# ./src/apps/configuracao/services/usuario_service.py

import logging
from django.db.utils import IntegrityError
from ..data.usuario_data import UsuarioData

class UsuarioService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir usuário com os seguintes dados: {dados}")
		try:
			return UsuarioData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir usuário: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os usuários")
		try:
			return UsuarioData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os usuários: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os usuários: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar usuário por id")
		try:
			return UsuarioData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar usuário por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar usuário por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar usuário de id: {id}, com os dados: {dados}")
		try:
			usuario = UsuarioData.buscar_por_id(id)
			return UsuarioData.alterar(usuario, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar usuário: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir usuário de id: {id}")
		try:
			usuario = UsuarioData.buscar_por_id(id)
			UsuarioData.excluir(usuario)
			logging.info(f"usuário excluído: {usuario}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir usuário: {str(e)}")
