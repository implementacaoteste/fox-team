# ./src/apps/gestao_de_projeto/services/status_de_tarefa_service.py

import logging
from django.db.utils import IntegrityError
from ..data.status_de_tarefa_data import StatusDeTarefaData

class StatusDeTarefaService:
	@staticmethod
	def inserir(dados):
		logging.info(f"Inserir status de tarefa com os seguintes dados: {dados}")
		try:
			return StatusDeTarefaData.inserir(dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao inserir status de tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao inserir status de tarefa: {str(e)}")

	@staticmethod
	def buscar_todos():
		logging.info(f"Buscar todos os statuss de tarefas")
		try:
			return StatusDeTarefaData.buscar_todos()
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar todos os statuss de tarefas: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar todos os statuss de tarefas: {str(e)}")

	@staticmethod
	def buscar_por_id(id):
		logging.info(f"Buscar status de tarefa por id")
		try:
			return StatusDeTarefaData.buscar_por_id(id)
		except IntegrityError as e:
			raise ValueError(f"Erro ao buscar status de tarefa por id: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao buscar status de tarefa por id: {str(e)}")

	@staticmethod
	def alterar(id, dados):
		logging.info(f"Alterar status de tarefa de id: {id}, com os dados: {dados}")
		try:
			status_de_tarefa = StatusDeTarefaData.buscar_por_id(id)
			return StatusDeTarefaData.alterar(status_de_tarefa, dados)
		except IntegrityError as e:
			raise ValueError(f"Erro ao alterar status de tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao alterar status de tarefa: {str(e)}")

	@staticmethod
	def excluir(id):
		logging.info(f"Excluir status de tarefa de id: {id}")
		try:
			status_de_tarefa = StatusDeTarefaData.buscar_por_id(id)
			StatusDeTarefaData.excluir(status_de_tarefa)
			logging.info(f"status de tarefa excluído: {status_de_tarefa}")
		except IntegrityError as e:
			raise ValueError(f"Erro ao excluir status de tarefa: {str(e)}")
		except Exception as e:
			raise ValueError(f"Erro inesperado ao excluir status de tarefa: {str(e)}")
