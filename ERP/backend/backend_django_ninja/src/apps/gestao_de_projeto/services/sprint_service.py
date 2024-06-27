# ./src/apps/gestao_de_projeto/services/sprint_service.py

import logging
from django.db.utils import IntegrityError
from ..data.sprint_data import SprintData

class SprintService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir sprint com os seguintes dados: {dados}")
		try:
			return SprintData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir sprint: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir sprint: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os sprints")
		try:
			return SprintData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todas as sprints: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todas as sprints: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar sprint por id")
		try:
			return SprintData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar sprint por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar sprint por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar sprint de id: {id}, com os dados: {dados}")
		try:
			sprint = SprintData.buscar_por_id(id)
			return SprintData.alterar(sprint, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar sprint: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar sprint: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir sprint de id: {id}")
		try:
			sprint = SprintData.buscar_por_id(id)
			SprintData.excluir(sprint)
			logging.info(f"sprint excluída: {sprint}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir sprint: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir sprint: {str(e)}")
