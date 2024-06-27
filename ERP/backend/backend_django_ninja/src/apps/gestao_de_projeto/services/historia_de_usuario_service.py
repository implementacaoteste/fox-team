# ./src/apps/gestao_de_projeto/services/historia_de_usuario_service.py

import logging
from django.db.utils import IntegrityError
from ..data.historia_de_usuario_data import HistoriaDeUsuarioData

class HistoriaDeUsuarioService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir historia de usuário com os seguintes dados: {dados}")
		try:
			return HistoriaDeUsuarioData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir historia de usuário: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os historias de usuários")
		try:
			return HistoriaDeUsuarioData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todas as historias de usuários: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todas as historias de usuários: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar historia de usuário por id")
		try:
			return HistoriaDeUsuarioData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar historia de usuário por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar historia de usuário por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar historia de usuário de id: {id}, com os dados: {dados}")
		try:
			historia_de_usuario = HistoriaDeUsuarioData.buscar_por_id(id)
			return HistoriaDeUsuarioData.alterar(historia_de_usuario, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar historia de usuário: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir historia de usuário de id: {id}")
		try:
			historia_de_usuario = HistoriaDeUsuarioData.buscar_por_id(id)
			HistoriaDeUsuarioData.excluir(historia_de_usuario)
			logging.info(f"historia de usuário excluída: {historia_de_usuario}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir historia de usuário: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir historia de usuário: {str(e)}")
