# ./src/apps/configuracao/services/grupo_de_usuario_service.py

import logging
from django.db.utils import IntegrityError
from ..data.grupo_de_usuario_data import GrupoDeUsuarioData

class GrupoDeUsuarioService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir grupo de usuário com os seguintes dados: {dados}")
		try:
			return GrupoDeUsuarioData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir grupo de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir grupo de usuário: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os grupos de usuários")
		try:
			return GrupoDeUsuarioData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os grupos de usuários: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os grupos de usuários: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar grupo de usuário por id")
		try:
			return GrupoDeUsuarioData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar grupo de usuário por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar grupo de usuário por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar grupo de usuário de id: {id}, com os dados: {dados}")
		try:
			grupo_de_usuario = GrupoDeUsuarioData.buscar_por_id(id)
			return GrupoDeUsuarioData.alterar(grupo_de_usuario, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar grupo de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar grupo de usuário: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir grupo de usuário de id: {id}")
		try:
			grupo_de_usuario = GrupoDeUsuarioData.buscar_por_id(id)
			GrupoDeUsuarioData.excluir(grupo_de_usuario)
			logging.info(f"grupo de usuário excluído: {grupo_de_usuario}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir grupo de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir grupo de usuário: {str(e)}")
