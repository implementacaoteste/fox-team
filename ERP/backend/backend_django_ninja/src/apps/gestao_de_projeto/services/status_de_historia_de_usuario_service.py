# ./src/apps/gestao_de_projeto/services/status_de_historia_de_usuario_service.py

import logging
from django.db.utils import IntegrityError
from ..data.status_de_historia_de_usuario_data import StatusDeHistoriaDeUsuarioData

class StatusDeHistoriaDeUsuarioService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir status de historia de usuário com os seguintes dados: {dados}")
		try:
			return StatusDeHistoriaDeUsuarioData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir status de historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir status de historia de usuário: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os statuss de historias de usuários")
		try:
			return StatusDeHistoriaDeUsuarioData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os statuss de historias de usuários: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os statuss de historias de usuários: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar status de historia de usuário por id")
		try:
			return StatusDeHistoriaDeUsuarioData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar status de historia de usuário por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar status de historia de usuário por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar status de historia de usuário de id: {id}, com os dados: {dados}")
		try:
			status_de_historia_de_usuario = StatusDeHistoriaDeUsuarioData.buscar_por_id(id)
			return StatusDeHistoriaDeUsuarioData.alterar(status_de_historia_de_usuario, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar status de historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar status de historia de usuário: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir status de historia de usuário de id: {id}")
		try:
			status_de_historia_de_usuario = StatusDeHistoriaDeUsuarioData.buscar_por_id(id)
			StatusDeHistoriaDeUsuarioData.excluir(status_de_historia_de_usuario)
			logging.info(f"status de historia de usuário excluído: {status_de_historia_de_usuario}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir status de historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir status de historia de usuário: {str(e)}")
